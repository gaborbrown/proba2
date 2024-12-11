using elozo2.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace elozo2.Controllers
{
    [Route("api/mozi")]
    [ApiController]
    public class MoziController : ControllerBase
    {
        // GET: api/<MoziController>
        [HttpGet]
        public IActionResult Get()
        {
            StudentContext context = new StudentContext();
            return Ok(context.Movies);
        }

        [HttpGet("booking")]
        public IActionResult GetBooking()
        {
            StudentContext context = new StudentContext();
            return Ok(context.Bookings);
        }

        // GET api/<MoziController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {

            StudentContext context = new StudentContext();

            var film = (from x in context.Movies
                        where x.MovieId == id
                        select x).FirstOrDefault();

            return Ok(film);
        }


        [HttpGet("/api/mozi/booking/{id}")]
        public IActionResult GetBooking(int id)
        {

            StudentContext context = new StudentContext();

            var film = (from x in context.Bookings
                        where x.BookingId == id
                        select x).FirstOrDefault();

            return Ok(film);
        }


        // POST api/<MoziController>
        [HttpPost]
        public void Post([FromBody] Movie film)
        {
            StudentContext context = new StudentContext();

            context.Add(film);
            context.SaveChanges();
        }


        [HttpPost("{id}")]
        public IActionResult PostMovieChange([FromBody] Movie film)
        {
            StudentContext context = new StudentContext();

            var valasztott = (from x in context.Movies
                        where x.MovieId == film.MovieId
                        select x).FirstOrDefault();

            valasztott.Title = film.Title;
            valasztott.Description = film.Description;
            valasztott.Duration = film.Duration;
            valasztott.Rating = film.Rating;

            context.SaveChanges();

            return Ok("ok");
        }



        [HttpPost("/Booking/{id}")]
        public IActionResult PostBookingChange([FromBody] Booking booking)
        {
            StudentContext context = new StudentContext();

            var valasztott = (from x in context.Bookings
                              where x.BookingId == booking.BookingId
                              select x).FirstOrDefault();

            valasztott.MovieName = booking.MovieName;
            valasztott.CustomerName = booking.CustomerName;
            valasztott.SeatNumber = booking.SeatNumber;
    

            context.SaveChanges();

            return Ok("ok");
        }

        // PUT api/<MoziController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<MoziController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            StudentContext context = new StudentContext();

            var valasztott = (from x in context.Movies
                              where x.MovieId == id
                              select x).FirstOrDefault();

            context.Remove(valasztott);
            context.SaveChanges();

            return Ok("ok");
        }
    }
}
