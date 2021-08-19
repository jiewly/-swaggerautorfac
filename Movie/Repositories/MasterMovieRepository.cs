using Dapper;
using Microsoft.Extensions.Configuration;
using Movie.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Movie.Repositories
{
    public interface IMasterMovieRepository 
    {
        IEnumerable<MasterMovie> GetAll();
        MasterMovie GetById(int id);
        int Add   (MasterMovie model);
        int Update(MasterMovie model);
        int Delete(MasterMovie model);

    }

    //สร้าง interface เพื่อไม่ให้เรียกใช้เมดตอดโดยตรง
    public class MasterMovieRepository:GenericRepository<MasterMovie>,IMasterMovieRepository
    {
        public MasterMovieRepository(IConfiguration configuration) : base(configuration) //consturctor ชื่อ
        { 

        }

        public override int Add(MasterMovie tModel)//@ถ้าไม่มีจะerror
        {
            var commandStr = string.Format(@" INSERT INTO[dbo].[MasterMovie] 
                                    ([Title]
                                   ,[ImgLink]
                                   ,[Time]
                                   ,[Date]
                                   ,[Type])
                                     VALUES
                                     (@ParaTitle
                                    ,@ParaImgLink
                                    , @ParaTime
                                    ,@ParaDate      
                                    ,@ParaType  )");
            return _db.Execute(commandStr, MappingParameter (tModel)); 
                
 
        }

        public override string CreateSelectString()
        {
            var commandStr = "SElECT*FROM MasterMovie";
            return commandStr;
        }

        public override int Delete(MasterMovie tModel)
        {
            var commandStr = string.Format(@"DELETE FROM[dbo].[MasterMovie]
                                           WHERE [id]= @ParaId");

            return _db.Execute(commandStr, new { ParaId = tModel.Id });
        }

        public override int Update(MasterMovie tModel)
        {
            var commandStr = string.Format(@" UPDATE[dbo].[MasterMovie]
                                          SET  [Title]  = @ParaTitle,
                                              [ImgLink] = @ParaImgLink,
                                               [Time]= @ParaTime,
                                               [Date]= @ParaDate,
                                               [Type]= @ParaType
                                              WHERE [id]= @ParaId");
            return _db.Execute(commandStr, MappingParameter(tModel));
        }
        private object MappingParameter(MasterMovie tModel) 
        {
            return new
            {
                ParaId = tModel.Id,
                ParaTitle = tModel.Title,
                ParaImgLink = tModel.ImgLink,
                ParaTime=tModel.Time,
                ParaDate=tModel.Date,
                ParaType=tModel.Type
            };
            }
        }
    }

