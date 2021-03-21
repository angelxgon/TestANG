namespace BPT.Test.ANG.BackEnd.DataAccess.DAO.School
{
    using BPT.Test.ANG.BackEnd.EntityLayer.School;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IDatStudent
    {
        Task<EntStudent> GetStudent(int id);
        Task<List<EntStudent>> GetStudents();
        Task<bool> SaveStudent(EntStudent entStudent);
        Task<bool> UpdateStudent(EntStudent entStudent);
        Task<bool> DeleteStudent(EntStudent entStudent);
        Task<List<EntStudentAssignment>> GetStudentAssignment(int idStudent);
        
    }
}
