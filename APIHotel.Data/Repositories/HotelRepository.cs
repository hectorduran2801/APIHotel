using APIHotel.Model;
using Dapper;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIHotel.Data.Repositories
{
    public class HotelRepository : IHotelRepository
    {
        private readonly MySQLConfiguration _connectionString;
        public HotelRepository(MySQLConfiguration connectionString)
        {
            _connectionString = connectionString;
        }

        protected MySqlConnection dbConnection()
        {
            return new MySqlConnection(_connectionString.ConnectionString);
        }

        public async Task<IEnumerable<Hotel>> GetAllHotels()
        {
            var db = dbConnection();

            var sql = @" SELECT * FROM hotel";

            return await db.QueryAsync<Hotel>(sql, new { });
         }

        public async Task<Hotel> GetDetails(int id)
        {
            var db = dbConnection();

            var sql = @" SELECT * FROM hotel WHERE hotelid = @id";

            return await db.QueryFirstOrDefaultAsync<Hotel>(sql, new { id = id });
        }

        public async Task<bool> InsertHotel(Hotel hotel)
        {
            var db = dbConnection();

            var sql = @" INSERT INTO hotel(hotelid, hotelname, categoria, precio, fotos, calificacion, comentario) VALUES(@hotelid, @hotelname, @categoria, @precio, @fotos, @calificacion, @comentario)";

            var result = await db.ExecuteAsync(sql, new
            { hotel.hotelid, hotel.hotelname, hotel.categoria, hotel.precio, hotel.fotos, hotel.calificacion, hotel.comentario });

            return result > 0;
        }

        public async Task<bool> UpdateHotel(Hotel hotel)
        {
            var db = dbConnection();

            var sql = @"UPDATE hotel SET hotelid = @hotelid, hotelname = @hotelname, categoria = @categoria, precio = @precio, fotos = @fotos, calificacion = @calificacion, comentario = @comentario WHERE hotelid = @hotelid";
            var result = await db.ExecuteAsync(sql, new { hotel.hotelid, hotel.hotelname, hotel.categoria, hotel.precio, hotel.fotos, hotel.calificacion, hotel.comentario });

            return result > 0;
        }

        public async Task<bool> DeleteHotel(Hotel hotel)
        {
            var db = dbConnection();

            var sql = @" DELETE FROM hotel WHERE hotelid = @hotelid";

            var result = await db.ExecuteAsync(sql, new { hotelid = hotel.hotelid });

            return result > 0;
        }


        public async Task<IEnumerable<Hotel>> FilterHotels(string categoria, int? minCalificacion, int? maxCalificacion)
        {
            var db = dbConnection();

            var sql = @"SELECT * FROM hotel";

            if (!string.IsNullOrEmpty(categoria))
            {
                sql += " WHERE categoria = @categoria";
            }

            if (minCalificacion.HasValue && maxCalificacion.HasValue)
            {
                if (!string.IsNullOrEmpty(categoria))
                {
                    sql += " AND calificacion BETWEEN @minCalificacion AND @maxCalificacion";
                }
                else
                {
                    sql += " WHERE calificacion BETWEEN @minCalificacion AND @maxCalificacion";
                }
            }

            return await db.QueryAsync<Hotel>(sql, new { categoria, minCalificacion, maxCalificacion });
        }

        public async Task<IEnumerable<Hotel>> SortHotels(string Byprecio)
        {
            var db = dbConnection();

            var sql = @"SELECT * FROM hotel";

            if (Byprecio == "asc")
            {
                sql += " ORDER BY precio ASC";
            }
            else if (Byprecio == "desc")
            {
                sql += " ORDER BY precio DESC";
            }

            return await db.QueryAsync<Hotel>(sql, new { });
        }

    }
}
