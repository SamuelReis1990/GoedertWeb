namespace GoedertWeb.UI.Models
{
    public class DadosDocumentos
    {
        public string id_documento { get; set; }
        public string id_pessoa { get; set; }
        public string id_tipo_documento { get; set; }
        public string numero { get; set; }
        public string emissor { get; set; }
        public string dt_validade { get; set; }
        public string dt_emissao { get; set; }
        public string descricao { get; set; }
    }
}