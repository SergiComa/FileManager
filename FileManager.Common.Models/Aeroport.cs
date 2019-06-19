using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileManager.DataAccess.DAO.Aeroport
{
    public class Aeroport
    {
        public string Name { get; set; }
        public Aeroport() { }
        public Aeroport(string name)
        {
            Name = name;
        }

        public override bool Equals(object obj)
        {
            var aeroport = obj as Aeroport;
            return aeroport != null &&
                   Name == aeroport.Name;
        }

        public override int GetHashCode()
        {
            return 539060726 + EqualityComparer<string>.Default.GetHashCode(Name);
        }
    }
}
