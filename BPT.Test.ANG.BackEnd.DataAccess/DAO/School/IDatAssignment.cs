namespace BPT.Test.ANG.BackEnd.DataAccess.DAO.School
{
    using BPT.Test.ANG.BackEnd.EntityLayer.School;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IDatAssignment
    {
        Task<EntAssignment> GetAssignment();
        Task<List<EntAssignment>> GetAssignments();
        Task<bool> SaveAssignment(EntAssignment entAssignment);
        Task<bool> UpdateAssignment(EntAssignment entAssignment);
        Task<bool> DeleteAssignment(EntAssignment entAssignment);
        Task<List<EntStudentAssignment>> GetStudentAssignment(EntStudent entStudent);
    }
}
