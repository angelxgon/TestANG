namespace BPT.Test.ANG.BackEnd.BusinessLayer.School
{
    using BPT.Test.ANG.BackEnd.DataAccess;
    using BPT.Test.ANG.BackEnd.DataAccess.DAO.School;
    using BPT.Test.ANG.BackEnd.EntityLayer.School;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class BusStudent : IBusStudent
    {
        SchoolContext _schoolContext;

        public BusStudent(SchoolContext schoolContext)
        {
            _schoolContext = schoolContext;
        }

        public async Task<EntStudent> GetStudent(int id)
        {
            return await new DatStudent(_schoolContext).GetStudent(id);
        }

        public async Task<List<EntStudent>> GetStudents()
        {
            return await new DatStudent(_schoolContext).GetStudents();
        }

        public async Task<bool> SaveStudent(EntStudent entStudent)
        {
            return await new DatStudent(_schoolContext).SaveStudent(entStudent);
        }

        public async Task<bool> UpdateStudent(EntStudent entStudent)
        {
            throw new System.NotImplementedException();
        }

        public async Task<bool> DeleteStudent(EntStudent entStudent)
        {
            throw new System.NotImplementedException();
        }

        public async Task<List<EntStudentAssignment>> GetStudentAssignment(int idStudent)
        {
            return await new DatStudent(_schoolContext).GetStudentAssignment(idStudent);
        }

    }
}
