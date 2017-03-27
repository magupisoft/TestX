using System;
using System.Threading.Tasks;
using System.Web.Http;

using MovieTest.Common.DTO;
using MovieTest.Common.Interfaces.Handlers;

namespace MovieTest.API.Controllers
{
    [RoutePrefix("api/movies")]
    public class MoviesController : ApiController
    {
        private readonly IAddMovieHandler addMovieHandler;
        private readonly IUpdateMovieHandler updateMovieHandler;
        private readonly IGetMovieHandler getMovieHandler;
        private readonly IGetMovieListHandler getMovieListHandler;
        private readonly IRemoveMovieHandler removeMovieHandler;

        public MoviesController(IAddMovieHandler addMovieHandler, IUpdateMovieHandler updateMovieHandler, IGetMovieHandler getMovieHandler, IGetMovieListHandler getMovieListHandler, IRemoveMovieHandler removeMovieHandler)
        {
            this.addMovieHandler = addMovieHandler;
            this.updateMovieHandler = updateMovieHandler;
            this.getMovieHandler = getMovieHandler;
            this.getMovieListHandler = getMovieListHandler;
            this.removeMovieHandler = removeMovieHandler;
        }

        // GET api/<controller>
        [Route("all"), HttpGet]
        public async Task<IHttpActionResult> GetAll()
        {
            var response = await this.getMovieListHandler.GetResponseAsync();
            if (response != null)
            {
                return this.Ok(response);
            }

            return this.NotFound();
        }

        // GET api/<controller>/5
        [Route("find/{id:guid}"), HttpGet]
        public async Task<IHttpActionResult> Get(Guid? id)
        {
            var response = await this.getMovieHandler.GetResponseAsync(id.Value);
            if (response != null)
            {
                return this.Ok(response);
            }

            return this.NotFound();
        }

        // Post api/<controller>/add
        [Route("add"), HttpPost]
        public async Task<IHttpActionResult> Post([FromBody]AddMovieRequest value)
        {
            var response = await this.addMovieHandler.GetResponseAsync(value);
            if (response)
            {
                return this.Ok(response);
            }

            return this.BadRequest();
        }

        // PUT api/<controller>/update
        [Route("update"), HttpPut]
        public async Task<IHttpActionResult> Put([FromBody]UpdateMovieRequest value)
        {
            var response = await this.updateMovieHandler.GetResponseAsync(value);
            if (response)
            {
                return this.Ok(response);
            }

            return this.BadRequest();
        }

        // DELETE api/<controller>/remove/{id:guid}
        [Route("remove/{id:guid}"), HttpDelete]
        public async Task<IHttpActionResult> Delete(Guid id)
        {
            var response = await this.removeMovieHandler.GetResponseAsync(id);
            if (response)
            {
                return this.Ok(response);
            }

            return this.BadRequest();
        }

        [Route("hello"), HttpGet]
        public string Hello()
        {
            return "Testing Api Controller";
        }
    }
}