# APIHotel

1. Crear proyecto ASP.net Core Web API
2. Crear una biblioteca de clases - interfaz para definir los métodos que cualquier clase de repositorio de hotel debe implementar para interactuar con la base de datos.
  GetAllHotels(): devuelve una lista de todos los hoteles disponibles.
  GetDetails(int id): devuelve los detalles de un hotel específico según su ID.
  InsertHotel(Hotel hotel): inserta un nuevo hotel en la base de datos.
  UpdateHotel(Hotel hotel): actualiza la información de un hotel existente en la base de datos.
  DeleteHotel(Hotel hotel): elimina un hotel existente de la base de datos.
  FilterHotels(string categoria, int? minCalificacion, int? maxCalificacion): filtra los hoteles por categoría y rango de calificación.
  SortHotels(string Byprecio): ordena los hoteles por precio.
 
 3. Crear una biblioteca de clases - interfaz para deficir los métodos para definir la cosnultas con la base de datos.
 4. Crear una biblioteca de clases - interfaz para representar la estructura de datos de una entidad hotelera en el sistema. 
 5. Crear el Controlador 
 6. Ejecutar el api.
