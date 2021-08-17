using Microsoft.AspNetCore.Mvc;
using Movie.Models;
using Movie.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Movie.ApiControllers
{
    [Route("api/mastermovies")]
    [ApiController]
    public class MasterMoviesController : ControllerBase
    {


        private readonly IMasterMovieService _masterMovieService;

        public MasterMoviesController(IMasterMovieService masterMovieService)
        {

            _masterMovieService = masterMovieService; //set dependency injection
        }
        [HttpGet]
        [Route("getall")]

        public IEnumerable<MasterMovie> GetAll()
        {
            var movies = _masterMovieService.GetAll();
            return movies;
        }
        [HttpGet]
        [Route("getbyid/{id?}")]

        public MasterMovie GetById(int id)
        {
            var item = _masterMovieService.GetById(id);//การส่งข้อมูลผ่านคิวรี่เพื่อที่จะได้เรียกค่ากลับคืนมา 
            return item;
        }
        [HttpPost]
        public IActionResult Add(MasterMovie item) 
        {
           _masterMovieService.Add(item);
            return Ok();
        }

        [HttpPut]
        public IActionResult Update(MasterMovie item) 
        {
            _masterMovieService.Update(item);
            return Ok();
        }
        [HttpDelete]

        public IActionResult Delete(int id) 
        {
            _masterMovieService.Delete(id);
            return Ok();
        }
    }
}