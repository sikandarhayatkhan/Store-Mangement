using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Super_Market
{
    class Product
    {
        public int id;
        public string name;
        public DateTime entrytime;
        public int sold;
        public bool isthere;

        public int Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public DateTime Entrytime { get => entrytime; set => entrytime = value; }
        public int Sold { get => sold; set => sold = value; }
        public bool Isthere { get => isthere; set => isthere = value; }

        public Product(int id, string name, DateTime entrytime, int sold, bool isthere)
        {
            this.Id = id;
            this.Name = name;
            this.Entrytime = entrytime;
            this.Sold = sold;
            this.Isthere = isthere;
        }
       public Product()
        {

        }
    }
}
