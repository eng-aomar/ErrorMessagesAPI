using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace ErrorMessagesAPI.Config
{
    public class MongoDBConfig
    {
        public string Database { get
            {
                return Environment.GetEnvironmentVariable("database");
            }

                
                }
        public string Host
        {
            get
            {
                return Environment.GetEnvironmentVariable("Host");
            }


        }
        public int Port { get
            {
                return 27017;
            }
                }
        public string User
        {
            get
            {
                return Environment.GetEnvironmentVariable("username");
            }


        }
        public string Password
        {
            get
            {
                return Environment.GetEnvironmentVariable("password");
            }


        }
        public string ConnectionString
        {
            get
            {
                if (string.IsNullOrEmpty(User) || string.IsNullOrEmpty(Password))
                    return $@"mongodb://{Host}:{Port}";

                return $@"mongodb://{User}:{Password}@{Host}:{Port}/{Database}";
                
            }
        }
    }
}
