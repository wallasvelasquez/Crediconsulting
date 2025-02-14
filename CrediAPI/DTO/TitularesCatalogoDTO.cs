namespace CrediAPI.DTO
{
    public class TitularesCatalogoDTO
    {
        public int TitularID { get; set; }
        public (string Nombres, string Apellidos) NombreInfo { get; init; }
        public string NombreCompleto => $"{NombreInfo.Nombres} {NombreInfo.Apellidos}";
    }
}
