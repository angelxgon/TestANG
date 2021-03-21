
namespace BPT.Test.ANG.BackEnd.DataAccess.DAO.Entitys
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public partial class Estudiante
    {
        [Key]
        public int Id { get; set; }
        public string Nombre { get; set; }
        public DateTime FechaNacimiento { get; set; }
    }
}
