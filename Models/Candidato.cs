public class Candidato{

public int IdCandidato{get;set;}
public int idPartido{get;set;}
public string Apellido{get;set;}
public string Nombre{get;set;}
public DateTime FechaNacimiento{get;set;}
public string Foto{get;set;}
public string Postulacion{get;set;}

public Candidato(){}

public Candidato(int idcandidato, int idpartido, string apellido, string nombre, DateTime fechanacimiento, string foto, string postulacion)
{
    IdCandidato=idcandidato;
    idPartido=idpartido;
    Apellido=apellido;
    Nombre=nombre;
    FechaNacimiento=fechanacimiento;
    Foto=foto;
    Postulacion=postulacion;
}
}