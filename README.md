# Sistema de ventas

El proyecto APISistemaVenta es una API desarrollada en C# utilizando una arquitectura en capas (n-capas) que incluye las siguientes capas: API, BLL (Business Logic Layer), DAL (Data Access Layer), IoC (Inversion of Control), Models, Utility, y DTO (Data Transfer Objects). La API está construida con Entity Framework para la gestión de la base de datos, y AutoMapper para el mapeo entre objetos.

La base de datos utilizada es SQL Server, y todos los scripts necesarios para la creación y poblamiento de la base de datos se encuentran en la carpeta **DBSchemasAndData**. Para conectar la API a la base de datos, solo es necesario configurar la cadena de conexión en el archivo de configuración *appsettings.json* utilizando la siguiente estructura:


``"ConnectionStrings": {
  "DbSql": "Server=SQL\\\\SQLEXPRESS;Database=DBVENTA;Trusted_Connection=true;TrustServerCertificate=true;"
}``


Debe reemplazar **SQL\\\\SQLEXPRESS** por el nombre de su servidor SQL Server. Esta cadena de conexión está preparada para entornos donde se utiliza autenticación con credenciales de Windows.

Una vez creada la base de datos, puede probar la API a través de Swagger, iniciando el proyecto desde Visual Studio o su IDE preferido.



# Sales System

The APISistemaVenta project is an API developed in C# using a layered architecture (n-layers) that includes the following layers: API, BLL (Business Logic Layer), DAL (Data Access Layer), IoC (Inversion of Control), Models, Utility, and DTO (Data Transfer Objects). The API is built with Entity Framework for database management, and AutoMapper for mapping between objects.

The database used is SQL Server, and all the necessary scripts for database creation and populating are located in the **DBSchemasAndData** folder. To connect the API to the database, it is only necessary to configure the connection string in the *appsettings.json* configuration file using the following structure:


``“ConnectionStrings”: {
  “DbSql": ”Server=SQL\\\\SQQLEXPRESS;Database=DBVENTA;Trusted_Connection=true;TrustServerCertificate=true;”
}``


You must replace **SQL\\\\SQLEXPRESS** with the name of your SQL Server. This connection string is prepared for environments where authentication with Windows credentials is used.

Once the database is created, you can test the API through Swagger by starting the project from Visual Studio or your preferred IDE.

