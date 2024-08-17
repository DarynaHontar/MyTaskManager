using Microsoft.AspNetCore.Mvc;
using MyTaskManager.Models;
using MyTaskManager.Services;

namespace MyTaskManager.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LifeSpheresController : Controller
    {
        private readonly ILifeSphereService lifeSphereService;

        public LifeSpheresController(ILifeSphereService lifeSphereService)
        {
            this.lifeSphereService = lifeSphereService;
        }

        [HttpGet]
        public ActionResult GetLifeSpheres()
        {
            var lifeSpheres = lifeSphereService.GetLifeSpheres();
            return lifeSpheres.Count > 0 ? Ok(lifeSpheres) : StatusCode(204);
        }

        [HttpPost]
        public ActionResult AddLifeSphere([FromBody] CreateLifeSphereRequest request)
        {
            if (request == null) return StatusCode(204);
            lifeSphereService.AddLifeSphere(request);
            return Ok();
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteLifeSphere(int id)
        {
            bool result = lifeSphereService.DeleteLifeSphere(id);
            if (result == false) return StatusCode(204);
            return Ok();
        }

        [HttpPut]
        public ActionResult UpdateLifeSphere(int id, [FromBody] CreateLifeSphereRequest request)
        {
            var lifeSphere = lifeSphereService.UpdateLifeSphere(id, request);
            if (lifeSphere == null) return StatusCode(204);
            return Ok(lifeSphere);
        }

        [HttpGet("{id}")]
        public ActionResult GetLifeSphereById(int id)
        {
            var lifeSphere = lifeSphereService.GetLifeSphereById(id);
            if (lifeSphere == null) return StatusCode(204);
            return Ok(lifeSphere);
        }
    }
}