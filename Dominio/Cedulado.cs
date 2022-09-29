

#nullable disable

namespace Dominio
{
    public partial class Cedulado
    {
        public int NumeroCedula { get; set; }
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public string FechaNacimineto { get; set; }
        public string Nacionalidad { get; set; }
        public int? FkCedula { get; set; }
    }
}
