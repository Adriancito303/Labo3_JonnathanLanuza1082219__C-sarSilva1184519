using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Labo3_JonnathanLanuza1082219__CésarSilva1184519.Models.Data
{
    public class Singleton
    {
        //Instancia única
        private readonly static Singleton MCInstance = new Singleton();
        public List<Medicine> MClientsList;
        public List<Medicine> SecondMClientsList;

        //Constructor
        private Singleton()
        {
            MClientsList = new List<Medicine>();
        }

        //método de obtencion de la instancia única
        public static Singleton Instance
        {
            get
            {
                return MCInstance;
            }
        }
    }
}
