using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityAPI.Config;
using EntityAPI.Models;
using ProjetService.Utils;

namespace ProjetService.Services
{
    public class ResultatService
    {

        public static void SaveResultat(Resultat resultat)
        {
            using (var ctx = new ConfigContext())
            {
                resultat.IdAuteur = 1;
                ctx.Resultats.AddOrUpdate(resultat);
                ctx.SaveChanges();
            }          
        }

        public static List<Resultat> GetResultat(int idAuteur, int idDestinataire)
        {
            using (var ctx = new ConfigContext())
            {
                List<Resultat> listResultat = ctx.Resultats.Where(m =>
                (m.IdAuteur == idAuteur && m.IdDestinataire == idDestinataire)
                || (m.IdAuteur == idDestinataire && m.IdDestinataire == idAuteur))
                .ToList();
                return listResultat;
            }
        }

        public static List<ResultatView> GetResultatById(int idAuteur)
        {
            using (var ctx = new ConfigContext())
            {
                List<ResultatView> listResultat = ctx.ResultatsView.Where(m =>(m.IdAuteur == idAuteur && m.IdDestinataire == idAuteur))
                .ToList();
                return listResultat;
            }
        }

        public static List<ResultatView> AllResultat()
        {
            using (var ctx = new ConfigContext())
            {
                List<ResultatView> res = ctx.ResultatsView.ToList();
                return res;
            }
        }

    }
}
