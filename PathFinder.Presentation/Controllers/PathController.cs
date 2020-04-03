using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using PathFinder.DataAccess.Entities;
using PathFinder.Presentation.Requests;
using PathFinder.Service.PathFinderService;

namespace PathFinder.Presentation.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PathController : ControllerBase
    {

        private readonly IPathService _pathService;


        public PathController(IPathService pathService)
        {
            _pathService = pathService;
        }

        [HttpGet]
        public ActionResult GetList()
        {
            var result = _pathService.GetList();

            return Ok(result);
        }

        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            var result = _pathService.Get(id);

            return Ok(result);
        }

        [HttpPost]
        public ActionResult Post(PathCreateRequest request)
        {

            var result = new List<PathEntity>();

            foreach(var item in request.Inputs)
            {
               result.Add(_pathService.Create(item));
            }

            return Ok(result);
        }
    }
}
