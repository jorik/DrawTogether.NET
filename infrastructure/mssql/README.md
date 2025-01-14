# MSSQL Image

This is a prebuilt [SQL Server 2022 on Linux](https://docs.microsoft.com/en-us/sql/linux/sql-server-linux-whats-new-2019) Docker image that contains a blank `DrawTogether` database which will subsequently be used by Akka.Persistence.Sql for relevant samples.

## Build

To build this image, run the `build.sh` or `build.cmd` script found in root of this directory.

```shell
build.sh [-t {tag}]
````

```shell
build.cmd [-t {tag}]
```

This will produce an image named `drawtogether.sqlserver:{tag}`.

If you leave out the `{tag}` parameter the image name will default to `drawtogether.sqlserver:0.1.0`.

### Adding Additional Schema

If you need additional tables or any other DDLs added to this sample, modify the [`setup.sql`](setup.sql) script inside this repository. Those schema modifications will be applied when the container first starts up.

### Deployment

To run this image you will still need to provide the default environment variable arguments required by the [SQL Server 2022 public Docker image](https://hub.docker.com/_/microsoft-mssql-server):

```shell
docker run -e "ACCEPT_EULA=Y" -e "SA_PASSWORD=yourStrong(!)Password" -p 1633:1433 -d drawtogether.sqlserver:0.1.0
```

This will produce a connection string that you can use to run Akka.Persistence (from the host machine):

```
Server=localhost; Database=DrawTogether; User Id=sa; Password=yourStrong(!)Password;
```

> **N.B.** It might take `drawtogether.sqlserver.sqlserver` up to 30 seconds to fully initialize the very first time it starts. Please be patient prior to running your sample and check the logs inside the Docker dashboard to see if the `DrawTogether` database has been created.