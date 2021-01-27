﻿using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace ErrorMessagesAPI.Config
{
    public class MongoDBConfig
    {
        public string Database
        {
            get
            {

                return Environment.GetEnvironmentVariable("Mongo_DB");

            }
        }
        public string Host { get; set; }
        public int Port { get; set; }
        public string User { get; set; }
        public string Password { get; set; }
        public string ConnectionString
        {
            get
            {
                
               return  Environment.GetEnvironmentVariable("MongoDB__URL");

            }
        }
    }
}
