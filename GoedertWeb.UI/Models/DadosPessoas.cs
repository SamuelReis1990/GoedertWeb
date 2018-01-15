using System.Collections.Generic;

namespace GoedertWeb.UI.Models
{
    public class DadosPessoas
    {
        public DadosPessoas()
        {
            dadosDocumentos = new List<DadosDocumentos>();
        }

        public string id_pessoa { get; set; }
        public string id_tipo_pessoa { get; set; }
        public string nome { get; set; }
        public string sexo { get; set; }
        public byte[] foto { get; set; }
        public string dt_ini_val { get; set; }
        public string dt_fim_val { get; set; }
        public string descricao { get; set; }
        public string foto_string { get; set; }
        public List<DadosDocumentos> dadosDocumentos { get; set; }
    }
}