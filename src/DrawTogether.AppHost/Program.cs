var builder = DistributedApplication.CreateBuilder(args);

var sqlServer = builder.AddSqlServer("sql");

var db = sqlServer.AddDatabase("DrawTogetherDb");

var migrationService = builder.AddProject<Projects.DrawTogether_MigrationService>("MigrationService")
    .WaitFor(db)
    .WithReference(db);

builder.AddProject<Projects.DrawTogether>("DrawTogether")
    .WithReference(db, "DefaultConnection")
    .WaitForCompletion(migrationService);

builder
    .Build()
    .Run();
