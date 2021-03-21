namespace BPT.Test.ANG.BackEnd.EntityLayer.School
{
    using System;

    public class EntStudentAssignment
    {
        public int IdStudent { get; set; }
        public int IdAssignment { get; set; }
        public string NombreAssignment { get; set; }     
        public string NombreStudent { get; set; }
        public DateTime FechaNacimiento { get; set; }
    }
}
