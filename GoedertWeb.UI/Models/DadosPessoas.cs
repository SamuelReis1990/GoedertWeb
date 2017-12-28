using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GoedertWeb.UI.Models
{
    public class DadosPessoas
    {
        public string id_pessoa { get; set; }
        public string id_tipo_pessoa { get; set; }
        public string nome { get; set; }
        public string sexo { get; set; }
        public string foto { get; set; }
        public string old_id { get; set; }
        public string dt_ini_val { get; set; }
        public string dt_fim_val { get; set; }
        public string descricao { get; set; }
    }
}