namespace BPT.Test.ANG.BackEnd.DataAccess.DAO.School
{
    using BPT.Test.ANG.BackEnd.DataAccess.DAO.Entitys;
    using BPT.Test.ANG.BackEnd.EntityLayer.School;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class DatAssignment : IDatAssignment
    {
        SchoolContext _schoolContext;

        public DatAssignment(SchoolContext schoolContext)
        {
            _schoolContext = schoolContext;
        }

        public async Task<EntAssignment> GetAssignment()
        {
            throw new NotImplementedException();
        }

        public async Task<List<EntAssignment>> GetAssignments()
        {
            try
            {
                var assignments = new List<EntAssignment>();
                var data = _schoolContext.Asignaciones.ToList();
                foreach (var item in data)
                {
                    assignments.Add(new EntAssignment
                    {
                        Id = item.Id,
                        Nombre = item.Nombre
                    });
                }
                return assignments;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro " + ex.Message);
            }
        }

        public async Task<bool> SaveAssignment(EntAssignment entAssignment)
        {
            try
            {
                var asignacione = new Asignacione()
                {
                      Nombre = entAssignment.Nombre
                };
                _schoolContext.Asignaciones.Add(asignacione);
                await _schoolContext.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro " + ex.Message);
            }
            return false;
        }

        public async Task<bool> UpdateAssignment(EntAssignment entAssignment)
        {
            throw new NotImplementedException();
        }
        public async Task<bool> DeleteAssignment(EntAssignment entAssignment)
        {
            throw new NotImplementedException();
        }

        public async Task<List<EntStudentAssignment>> GetStudentAssignment(EntStudent entStudent)
        {
            try
            {
                List<EntStudentAssignment> entStudentAssignments = new List<EntStudentAssignment>();
                entStudentAssignments = (from studt in _schoolContext.Estudiantes
                              join assig_stud in _schoolContext.AsignacionesEstudiantes on studt.Id equals assig_stud.Idestudiante
                              join assig in _schoolContext.Asignaciones on assig_stud.Idasignacion equals assig.Id
                              where studt.Nombre == entStudent.Nombre
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
