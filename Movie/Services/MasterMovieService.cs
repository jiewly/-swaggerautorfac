using Movie.Models;
using Movie.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Movie.Services
{
    public interface IMasterMovieService 
    {
        IEnumerable<MasterMovie> GetAll();
        MasterMovie GetById(int id);
        bool Add(MasterMovie model);
        bool Update(MasterMovie model);
        bool Delete(int id);

    }
    public class MasterMovieService : IMasterMovieService
        
    {
        private readonly IMasterMovieRepository masterMovieRepositories;
       public MasterMovieService(IMasterMovieRepository masterMovieRepositories) 
        {
            this.masterMovieRepositories = masterMovieRepositories;
        }

        public bool Add(MasterMovie model)
        {
            return masterMovieRepositories.Add(model)>0;
        }



        public bool Delete(int id)
        {
            var masterMovie = new MasterMovie { Id = id };
            return masterMovieRepositories.Delete(masterMovie) > 0;
        }

        public IEnumerable<MasterMovie> GetAll()
        {
            var listMovie = masterMovieRepositories.GetAll();
            return listMovie;
        }

        public MasterMovie GetById(int id)
        {
            var idMovie = masterMovieRepositories.GetById(id);
            return idMovie;
        }

        public bool Update(MasterMovie model)
        {
            var masterMovie = masterMovieRepositories.GetById(model.Id);
            masterMovie.Title = model.Title;
            masterMovie.ImgLink = model.ImgLink;
            masterMovie.Time = model.Time;
            masterMovie.Date = model.Date;
            masterMovie.Type = model.Type;
            return masterMovieRepositories.Update(masterMovie)>0;
        }
    }
}
