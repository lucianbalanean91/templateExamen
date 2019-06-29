using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using templateExamen.Models;

namespace templateExamen.ViewModels
{
    public class PachetGetModel
    {
        public string TaraOrigine { get; set; }
        public string DenumireExpeditor { get; set; }
        public string TaraDestinatie { get; set; }
        public string DenumireDestinatar { get; set; }
        public string AdresaDestinatar { get; set; }
        public double Cost { get; set; }


        public static PachetGetModel FromPachet (Pachet pachet)
        {
            return new PachetGetModel
            {   
                TaraOrigine = pachet.TaraOrigine,
                DenumireExpeditor = pachet.DenumireExpeditor,
                TaraDestinatie = pachet.TaraDestinatie,
                DenumireDestinatar = pachet.DenumireDestinatar,
                AdresaDestinatar = pachet.AdresaDestinatar,
                Cost = pachet.Cost
             
            };
        }
    }
}