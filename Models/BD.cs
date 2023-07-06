using System.Data.SqlClient;
using Dapper;

static class BD{
        private static string _connectionString= @"server=localhost;DataBase=Elecciones2023;Trusted_connection=True;";
        public static void AgregarCandidato(Candidato can)
        {        
                string SQL="INSERT INTO Candidato(IdCandidato,IdPartido,Apellido,Nombre,FechaNacimiento,Foto,Postulacion) VALUES(@pIdPartido,@pApellido,@pNombre,@pFechaNacimiento,@pFoto,@pPostulacion)";
                using(SqlConnection db = new SqlConnection(_connectionString))
                {
                        db.Execute(SQL,new{pIdCandidato=can.IDCandidato, pIdPartido=can.IDPartido, pApellido=can.Apellido, pNombre=can.Nombre, pFechaNacimiento=can.FechaNacimiento,pFoto=can.Foto,pPostulacion=can.Postulacion});
                }
        }

        public static int EliminarCandidato(int idCandidato)
            {
        
            }
        public static Partido VerInfoPartido(int idPartido)
        {}
        public static Candidato VerInfoCandidato(int idCandidato)
          {}        
        public static ListarPartidos()

            {}
        public static ListarCandidatos(int idPartido)
            {}

}