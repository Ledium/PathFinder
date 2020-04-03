using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PathFinder.DataAccess.Entities;
using PathFinder.Presentation.Requests;
using PathFinder.Service.PathFinderService;

namespace PathFinder.Presentation.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PathController : ControllerBase
    {

        private readonly IPathFinderService _pathService;


        public PathController(IPathFinderService pathService)
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
        public ActionResult Post(IEnumerable<int[]> arrays)
        {

            var result = new List<PathEntity>();

            foreach(var item in arrays)
            {
               result.Add(_pathService.Create(item));
            }

            return Ok(result);
        }
    }
}
