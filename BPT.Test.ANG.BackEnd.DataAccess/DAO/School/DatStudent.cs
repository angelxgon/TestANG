namespace BPT.Test.ANG.BackEnd.DataAccess.DAO.School
{
    using BPT.Test.ANG.BackEnd.DataAccess.DAO.Entitys;
    using BPT.Test.ANG.BackEnd.EntityLayer.School;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class DatStudent : IDatStudent
    {
        SchoolContext _schoolContext;

        public DatStudent(SchoolContext schoolContext) 
        {
            _schoolContext = schoolContext;
        }

        public async Task<EntStudent> GetStudent(int id)
        {
            try
            {
              /* var result = tPAGCContext.Estudiantes.ToList();
                if (result.Count() > 0)
                {
                    return Ok(result);
                }*/
                return null;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<List<EntStudent>> GetStudents()
        {            
            try
            {
                var estudents = new List<EntStudent>();
                var data = _schoolContext.Estudiantes.ToList();
                foreach (var item in data) {
                    estudents.Add(new EntStudent { 
                        Id = item.Id,
                        FechaNacimiento = item.FechaNacimiento,
                        Nombre = item.Nombre
                    });
                }
                return estudents;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro "+ex.Message);
            }
        }

        public async Task<bool> SaveStudent(EntStudent entStudent)
        {
            try
            {
                var student = new Estudiante()
                {
                    FechaNacimiento = entStudent.FechaNacimiento,
                    Nombre = entStudent.Nombre
                };
                _schoolContext.Estudiantes.Add(student);
                await _schoolContext.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro " + ex.Message);
            }
            return false;
        }

        public async Task<bool> UpdateStudent(EntStudent entStudent)
        {
            throw new NotImplementedException();
        }
        public async Task<bool> DeleteStudent(EntStudent entStudent)
        {
            throw new NotImplementedException();
        }

        public async Task<List<EntStudentAssignment>> GetStudentAssignment(int idStudent)
        {
            try
            {
                List<EntStudentAssignment> entStudentAssignments = new List<EntStudentAssignment>();
                entStudentAssignments = (from studt in _schoolContext.Estudiantes
                                         join assig_stud in _schoolContext.AsignacionesEstudiantes on studt.Id equals assig_stud.Idestudiante
                                         join assig in _schoolContext.Asignaciones on assig_stud.Idasignacion equals assig.Id
                                         where studt.Id == idStudent
                                         select new EntStudentAssignment
                                         {
                                             IdStudent = studt.Id,
                                             NombreStudent = studt.Nombre,
                                             FechaNacimiento = studt.FechaNacimiento,
                                             IdAssignment = assig.Id,
                                             NombreAssignment = assig.Nombre
                                         }).ToList();
                return entStudentAssignments;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro " + ex.Message);
            }
            return new List<EntStudentAssignment>();
        }
    }
}
