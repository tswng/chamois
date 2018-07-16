﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

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

        public static List<connItem> fn_getSavedConnections(string path)
        {
            var connectionItems = new List<connItem>();
            System.Xml.Serialization.XmlSerializer reader = new System.Xml.Serialization.XmlSerializer(typeof(List<connItem>));
            System.IO.StreamReader file = new System.IO.StreamReader(path);
            connectionItems = (List<connItem>)reader.Deserialize(file);
            file.Close();
            return connectionItems.ToList();
        }

        public static void fn_saveAllConnections(List<connItem> itemz, string path)
        {
            var writer = new System.Xml.Serialization.XmlSerializer(typeof(List<connItem>));
            var wfile = new System.IO.StreamWriter(path);
            writer.Serialize(wfile, itemz);
            wfile.Close();
        }
    }



}