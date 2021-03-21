namespace BPT.Test.ANG.BackEnd.BusinessLayer.School
{
    using BPT.Test.ANG.BackEnd.DataAccess;
    using BPT.Test.ANG.BackEnd.DataAccess.DAO.School;
    using BPT.Test.ANG.BackEnd.EntityLayer.School;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class BusAssignment : IBusAssignment
    {
        SchoolContext _schoolContext;

        public BusAssignment(SchoolContext schoolContext) 
        {
            _schoolContext = schoolContext;
        }

        public async Task<EntStudent> GetAssignment()
        {
            throw new System.NotImplementedException();
        }

        public async Task<List<EntAssignment>> GetAssignments()
        {
            return await new DatAssignment(_schoolContext).GetAssignments();
        }

        public async Task<bool> SaveAssignment(EntAssignment entAssignment)
        {
            return await new DatAssignment(_schoolContext).SaveAssignment(entAssignment);
        }

        public async Task<bool> UpdateAssignment(EntAssignment entAssignment)
        {
            throw new System.NotImplementedException();
        }

        public async Task<bool> DeleteAssignment(EntAssignment entAssignment)
        {
            throw new System.NotImplementedException();
        }
    }
}
