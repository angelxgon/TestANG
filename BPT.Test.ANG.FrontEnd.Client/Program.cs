namespace BPT.Test.ANG.FrontEnd.Client
{
    using System;
    using System.Net;

    public class Program
    {
        public static void Main(string[] args)
        {
            Program prg = new Program();
            Console.WriteLine("================  Estudiantes  ==================");
            Console.WriteLine("");
            prg.getStudents();
            Console.WriteLine("");
            Console.WriteLine("===============  Asignaciones  ==================");
            Console.WriteLine("");
            prg.getAssignments();
            Console.WriteLine("");
            Console.WriteLine("=========  Asignaciones x Estudiante  ===========");
            Console.WriteLine("");
            prg.getAssignmentsEstudents();
            Console.WriteLine("");
            Console.WriteLine("===========================================");
            Console.WriteLine("Termino de Pruebas");
        }

        private string GetServicesRest(string url) 
        {
            string resp = new WebClient().DownloadString(url);
            return resp;
        }


        public void getStudents()
        {
            var resp = GetServicesRest("https://localhost:44380/Students/GetStudents");
            if (resp != null){
                Console.WriteLine(resp);
            }
            else {
                Console.WriteLine("No existen datos");
            }
        }

        public void getAssignments()
        {
            var resp = GetServicesRest("https://localhost:44380/Assignments/GetAssignments");
            if (resp != null)
            {
                Console.WriteLine(resp);
            }
            else
            {
                Console.WriteLine("No existen datos");
            }
        }

        public void getAssignmentsEstudents()
        {
            var resp = GetServicesRest("https://localhost:44380/Students/GetStudentsAssignments?idStudent=1");
            if (resp != null)
            {
                Console.WriteLine(resp);
            }
            else
            {
                Console.WriteLine("No existen datos");
            }
        }



    }
}
