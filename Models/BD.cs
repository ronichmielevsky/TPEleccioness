using System.Data.SqlClient;
using System.Collections.Generic;
using Dapper;

static class BD
{
    private static string _connectionString = @"server=localhost;DataBase=Elecciones2023;Trusted_connection=True;";
    public static void AgregarCandidato(Candidato can)
    {
        string SQL = "INSERT INTO Candidato(IdCandidato,IdPartido,Apellido,Nombre,FechaNacimiento,Foto,Postulacion) VALUES(@pIdPartido,@pApellido,@pNombre,@pFechaNacimiento,@pFoto,@pPostulacion)";
        using (SqlConnection db = new SqlConnection(_connectionString))
        {
            db.Execute(SQL, new { pIdCandidato = can.IDCandidato, pIdPartido = can.IDPartido, pApellido = can.Apellido, pNombre = can.Nombre, pFechaNacimiento = can.FechaNacimiento, pFoto = can.Foto, pPostulacion = can.Postulacion });
        }
    }

    public static int EliminarCandidato(int idCandidato)
    {
        int CandidatosEliminados = 0;
        using (SqlConnection db = new SqlConnection(_connectionString))
        {
            string SQL = "DELETE FROM Candidato WHERE IdCandidato= @IdCandidato";
            CandidatosEliminados = db.Execute(SQL, new { IdCandidato = idCandidato });
        }
        return CandidatosEliminados;
    }

    public static Partido VerInfoPartido(int idPartido)
    {
        Partido MiPartido = null;
        using (SqlConnection db = new SqlConnection(_connectionString))
        {
            string SQL = "SELECT * FROM Partido WHERE IdPartido=@Partido";
            MiPartido = db.QueryFirstOrDefault<Partido>(SQL, new { Partido = idPartido });
        }
        return MiPartido;
    }
    public static Candidato VerInfoCandidato(int idCandidato)
    {
        Candidato MiCandidato = null;
        using (SqlConnection db = new SqlConnection(_connectionString))
        {
            string SQL = "SELECT * FROM Candidato WHERE IdCandidato=@Candidato";
            MiCandidato = db.QueryFirstOrDefault<Candidato>(SQL, new { Candidato = idCandidato });
        }
        return MiCandidato;
    }
    public static List<Partido> ListarPartidos()
    {
        List<Partido> listPartido;
        using (SqlConnection db = new SqlConnection(_connectionString))
        {
            string SQL = "SELECT * FROM Partido";
            listPartido = db.Query<Partido>(SQL).ToList();
        }
        return listPartido;
    }
    public static List<Candidato> ListarCandidatos(int idPartido)
    {
        List<Candidato> listPartido;
        using (SqlConnection db = new SqlConnection(_connectionString))
        {
            string SQL = "SELECT * FROM Candidato WHERE IdPartido=@Partido";
            listPartido = db.Query<Candidato>(SQL, new { Partido = idPartido }).ToList();
        }
        return listPartido;
    }

}