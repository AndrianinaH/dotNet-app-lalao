using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityAPI.Config;
using EntityAPI.Models;

namespace ProjetService.Services
{
    public class MessageService
    {
        public static void SaveMessage(Message message)
        {
            using (var ctx = new ConfigContext())
            {
                ctx.Messages.AddOrUpdate(message);
                ctx.SaveChanges();
            }
        }

        public static void DeleteMessage(Message message)
        {
            using (var ctx = new ConfigContext())
            {
                ctx.Messages.Attach(message);
                ctx.Messages.Remove(message);
                ctx.SaveChanges();
            }
        }

        public static List<Message> GetMessage(int idAut, int idDest)
        {
            using (var ctx = new ConfigContext())
            {
                List<Message> listMessage = ctx.Messages.Where(m => (m.IdAuteur == idAut && m.IdDestinataire == idDest) || (m.IdAuteur == idDest && m.IdDestinataire == idAut)).ToList();
                return listMessage;
            }
        }

        public static List<MessageView> GetMessageById(int idAut)
        {
            using (var ctx = new ConfigContext())
            {
                List<MessageView> listMessage = ctx.MessagesView.Where(m => (m.IdAuteur == idAut))
                    .OrderByDescending(m => m.DateCreation)
                    .ToList();
                return listMessage;
            }
        }

        public static List<Message> GetLastMessage(int idAut, int idDest, int idLastMessage)
        {
            using (var ctx = new ConfigContext())
            {
                List<Message> listMessage = ctx.Messages.Where(m => 
                    (m.IdAuteur == idDest && m.IdDestinataire == idAut && m.Id > idLastMessage))
                    .ToList();
                return listMessage;
            }
        }

        public static void AddViewMessage(int idAut, int idDest)
        {
            using (var ctx = new ConfigContext())
            {
                List<Message> listMessage = ctx.Messages.Where(m =>
                    (m.IdAuteur == idDest && m.IdDestinataire == idAut && m.Etat == "non-lu"))
                    .ToList();
                if (listMessage.Count != 0)
                {
                    foreach (Message mess in listMessage)
                    {
                        mess.Etat = "lu";
                        ctx.Messages.AddOrUpdate(mess);
                    }
                    ctx.SaveChanges();                
                }
            }                    
        }

        public static bool IsMessageVu(int idLastMessage, int idAut, int idDest)
        {
            using (var ctx = new ConfigContext())
            {
                Message myMessage = ctx.Messages.Single(m =>(m.Id == idLastMessage));
                bool result = false;
                if (myMessage.IdAuteur == idAut && myMessage.IdDestinataire == idDest && myMessage.Etat == "lu")
                {
                    result = true;
                }
                return result;
            }          
        }

        public static List<MessageView> AllMessage()
        {
            using (var ctx = new ConfigContext())
            {
                List<MessageView> res = ctx.MessagesView.ToList();
                return res;
            }
        }




    }
}
