-> Modificar la siguiente linea del App Settings de la API para que apunte al servidor sql donde se ejecutara el script para crear la bd:

"connectionStrings": {
    "ConnectionDB": "Data Source=Tu Servidor de BD;Initial Catalog=CrediconsultigBD;Integrated Security=true"
}

-> Las tablas de la base de datos ya cuentan con algunos registros de prueba. 
-> Por motivos tecnicos el proyecto se realizo con Net Core 5.0.
-> La solucion ya tiene configurada en sus propiedades que ambos proyectos se ejecuten, si en dado caso no fuese asi en las propiedades de la solucion -> opcion start up project
    alli podra configurarse nuevamente la ejecucion de proyectos simultaneos.

