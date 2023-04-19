using APIHotel.Model;

namespace APIHotel.Data.Repositories
{
    public interface IHotelRepository
    {
        Task<IEnumerable<Hotel>> GetAllHotels();
        Task<Hotel> GetDetails(int id);
        Task<bool> InsertHotel(Hotel hotel);
        Task<bool> UpdateHotel(Hotel hotel);
        Task<bool> DeleteHotel(Hotel hotel);
        Task<IEnumerable<Hotel>> FilterHotels(string categoria, int? minCalificacion, int? maxCalificacion);
        Task<IEnumerable<Hotel>> SortHotels(string Byprecio);

    }
}
