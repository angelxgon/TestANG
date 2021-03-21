namespace BPT.Test.ANG.BackEnd.BusinessLayer.School
{
    using BPT.Test.ANG.BackEnd.EntityLayer.School;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IBusAssignment
    {
        Task<EntStudent> GetAssignment();
        Task<List<EntAssignment>> GetAssignments();
        Task<bool> SaveAssignment(EntAssignment entAssignment);
        Task<bool> UpdateAssignment(EntAssignment entAssignment);
        Task<bool> DeleteAssignment(EntAssignment entAssignment);

    }
}
