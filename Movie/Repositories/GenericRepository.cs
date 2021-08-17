using Dapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Movie.Repositories
{
    public abstract class GenericRepository<TModel>
    {
        protected IDbConnection _db { get; set; }

        protected string CONNECTION_STRING;

        protected GenericRepository (IConfiguration configuration)  //เป็นขั่นตอนการดึงค่าAPPsetting ดึง CONNETSION sting
        {
            CONNECTION_STRING = configuration.GetSection("ConnectionStrings:AppDB").Value;
            _db  = new SqlConnection(CONNECTION_STRING);
        }

        public abstract string CreateSelectString();  //propoty ตั้งเป้นclassกลางที่สามารถทำงานต่อได้
        public abstract int Add(TModel tModel);
        public abstract int Update(TModel tModel);
        public abstract int Delete(TModel tModel);

        public IEnumerable<TModel> GetAll()//รับชุดสตริงของเลเยอร์repoให้เป็นGet all เพื่อให้โยนเข้าไปได้เเต่ไม่ต้องเขียนทุกrepo เรียกใช้เป็น ไดนามิก เพื่อให้ดึงมาใช้ร่วมกันได้
        {
            var models = new List<TModel>();
            using (var db = new SqlConnection(CONNECTION_STRING))
            {
                models = db.Query<TModel>(CreateSelectString()).ToList();
            }
            return models;
        }

        public TModel GetById(int id)//รับเเค่่ชุดCreateSelectString
        {
            var models = new List<TModel>();
            using (var db = new SqlConnection(CONNECTION_STRING))
            {
                models = db.Query<TModel>(CreateSelectString() + " WHERE Id = @Id", new
                {
                    id
                }).ToList();
            }
            return models.FirstOrDefault(); //เมื่อคิวรี่มาเอาชุดเเรกของคิวรี่นั้น
        }
    }
}
