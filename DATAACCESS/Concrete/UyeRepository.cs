using Dapper;
using DATAACCESS.Abstract;
using ENTITIES;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DATAACCESS.Concrete
{
    public class UyeRepository : IUyeRepository
    {
        private readonly string _tableName = "Uye";
      
        private SqlConnection SqlConnection()
        {
            return new SqlConnection("Server=.;Database=Dapper3Db;uid=yusuf;pwd=123");
        }
        private IDbConnection CreateConnection()
        {
            var conn = SqlConnection(); 
            conn.Open();
            return conn;
        }
        public IEnumerable<Uye> GetAll()
        {
            using(var conn = CreateConnection())
            {
                IEnumerable<Uye> uyeler = conn.Query<Uye>($"SELECT * FROM {_tableName}");
                conn.Close();
                return uyeler;
            }
        } 

        public void DeleteUye(Guid id)
        {
            using (var conn = CreateConnection())
            {
                conn.Execute($"delete from {_tableName} where Id=@Id", new {Id = id});
                conn.Close();
            }
        }

        public Uye GetById(Guid id)
        {
            using (var conn = CreateConnection())
            {
                var uye = conn.QueryFirstOrDefault<Uye>($"select * from {_tableName} where Id=@Id", new { Id = id });
                conn.Close();
                return uye;
            }
        }

        public void InsertUye(Uye uye)
        {
            using (var conn = CreateConnection())
            {
                conn.Execute($"insert into {_tableName}(Id,Name,Surname,KullaniciAdi,Age) values (@Id,@Name,@Surname,@KullaniciAdi,@Age)", new Uye
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = uye.Name,
                    Surname = uye.Surname,
                    KullaniciAdi = uye.KullaniciAdi,
                    Age = uye.Age,
                });
                conn.Close();
            }
        }

        public void UpdateUye(Uye uye)
        {
            using(var conn = CreateConnection())
            {
                if (uye != null)
                {
                    conn.Execute($"update {_tableName} set Id=@Id,Name=@Name,Surname=@Surname,KullaniciAdi=@KullaniciAdi,Age=@Age where Id=@Id", new Uye
                    {
                        Id = uye.Id.ToString(),
                        Name = uye.Name,
                        Surname = uye.Surname,
                        KullaniciAdi = uye.KullaniciAdi,
                        Age = uye.Age,
                    });
                    conn.Close();
                }
                else
                {
                    throw new Exception("Üye bulunmamaktadır!");
                }
            }
        }
    }
}
