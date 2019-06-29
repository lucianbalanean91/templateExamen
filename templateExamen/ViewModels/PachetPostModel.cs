using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using templateExamen.Models;

namespace templateExamen.ViewModels
{
    public class PachetPostModel
    {
        public string TaraOrigine { get; set; }
        public string DenumireExpeditor { get; set; }
        public string TaraDestinatie { get; set; }
        public string DenumireDestinatar { get; set; }
        public string AdresaDestinatar { get; set; }
        public double Cost { get; set; }
        public string CodTracking { get; set; }


        public static Pachet ToPachet (PachetPostModel pachetPostModel)
        {
            return new Pachet
            {
                TaraOrigine = pachetPostModel.TaraOrigine,
                DenumireExpeditor = pachetPostModel.DenumireExpeditor,
                TaraDestinatie = pachetPostModel.TaraDestinatie,
                DenumireDestinatar = pachetPostModel.DenumireDestinatar,
                AdresaDestinatar = pachetPostModel.AdresaDestinatar,
                Cost = pachetPostModel.Cost,
                CodTracking = pachetPostModel.CodTracking
            };
        }
    }


}
