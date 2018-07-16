using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chamois.uitest
{
    public class connItem
    {
        public string connName { get; set; }
        public string dbDriver { get; set; }
        public string Hostname { get; set; }
        public string Port { get; set; }
        public string Database { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string savePassword { get; set; }
    }
}
