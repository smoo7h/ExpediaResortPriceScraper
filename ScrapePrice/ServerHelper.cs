using DevExpress.Xpo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScrapePrice
{
    public class ServerHelper
    {
        public ServerHelper()
        {
            CurrentSession = CreateServerSession();
        }

        public Session CurrentSession { get; set; }

        public static Session CreateServerSession()
        {
            ///Dunno if we will need to use this, old pic dic, probably should just attach picture name to ActivityType object
          
            //dun forget to switch when going live.
            string liveCon = @"Integrated Security=SSPI;Pooling=false;Data Source=(localdb)\mssqllocaldb;Initial Catalog=ExpediaDownload";
            Session space = new Session();
            space.ConnectionString = liveCon;
            space.Connect();
            return space;
        }
    }



}
