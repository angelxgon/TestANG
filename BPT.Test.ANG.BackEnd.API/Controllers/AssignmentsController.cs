
namespace BPT.Test.ANG.BackEnd.API.Controllers
{
    using BPT.Test.ANG.BackEnd.BusinessLayer.School;
    using BPT.Test.ANG.BackEnd.EntityLayer.School;
    using Microsoft.AspNetCore.Mvc;
    using System;
    using System.Threading.Tasks;

    public class AssignmentsController : Controller
    {

        #region
        private readonly IBusAssignment _ibusAssignment;
        #endregion

        #region Constructor
        public AssignmentsController(IBusAssignment ibusAssignment)
        {
            _ibusAssignment = ibusAssignment;
        }
        #endregion

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<ActionResult> GetAssignments()
        {
            var result = _ibusAssignment.GetAssignments();
            if (result.Result.Count > 0)
            {
                return Ok(result.Result);
            }
            return NotFound("No Hay Registros");
        }

        [HttpGet]
        public async Task<ActionResult> GetAssignment(int id)
        {
            return NotFound("No Hay Registros");
        }

        [HttpPost]
        public async Task<ActionResult> Createssignment(string Nombre)
        {
            try
            {
                var assign = new EntAssignment()
                {
                    Nombre = Nombre,
                };

                var result = await _ibusAssignment.SaveAssignment(assign);
                if (result)
                {
                    return Ok("Operacion Exitosa");
                }
                else
                {
                    return NotFound("No se grabo estudiante");
                }
            }
            catch (Exception ex)
            {
                return NotFound(ex.ToString());
            }
        }
    }
}
