namespace BPT.Test.ANG.BackEnd.API.Controllers
{
    using BPT.Test.ANG.BackEnd.BusinessLayer.School;
    using BPT.Test.ANG.BackEnd.EntityLayer.School;
    using Microsoft.AspNetCore.Mvc;
    using System;
    using System.Threading.Tasks;

    public class StudentsController : Controller
    {
        #region
        private readonly IBusStudent _ibusStudent;
        #endregion

        #region Constructor
        public StudentsController(IBusStudent ibusStudent)
        {
            _ibusStudent = ibusStudent;
        }
        #endregion

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<ActionResult> GetStudents()
        {
            var result = _ibusStudent.GetStudents();
            if (result.Result.Count > 0) {
                return Ok(result.Result);
            }
            return NotFound("No Hay Registros");
        }

        [HttpGet]
        public async Task<ActionResult> GetStudent(int id)
        {
            try
            {
                var result = await _ibusStudent.GetStudent(id);
                if (result != null)
                {
                    Ok(result);
                }
                return NotFound("No Hay Registros");
            }
            catch (Exception ex)
            {
                return NotFound(ex.ToString());
            }
        }

        [HttpPost]
        public async Task<ActionResult> CreateStudent(string Nombre, string FechaNacimiento)
        {
            try
            {
                var studen = new EntStudent()
                {
                    Nombre = Nombre,
                    FechaNacimiento = Convert.ToDateTime(FechaNacimiento)
                };

                var result = await _ibusStudent.SaveStudent(studen);
                if (result)
                {
                   return Ok("Operacion Exitosa");
                }
                else {
                    return NotFound("No se grabo estudiante");
                }
            }
            catch (Exception ex)
            {
                return NotFound(ex.ToString());
            }
        }

        [HttpGet]
        public async Task<ActionResult> GetStudentsAssignments(int idStudent)
        {
            var result = _ibusStudent.GetStudentAssignment(idStudent);
            if (result.Result.Count > 0)
            {
                return Ok(result.Result);
            }
            return NotFound("No Hay Registros");
        }




    }
}
