
using Microsoft.Extensions.Configuration;
using System;
using System.IO;

namespace PetPals.Utility
{
    internal class DbConnUtil
    {
        private static IConfiguration _iconfiguration;

        static DbConnUtil()
        {
            try
            {
                GetAppSettingsFile();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error initializing DbConnUtil: {ex.Message}");
                throw;
            }
        }

        private static void GetAppSettingsFile()
        {
            var builder = new ConfigurationBuilder()
                         .SetBasePath(Directory.GetCurrentDirectory())
                         .AddJsonFile("appsettings.json");

            _iconfiguration = builder.Build();
        }

        public static string GetConnString()
        {
            return _iconfiguration.GetConnectionString("LocalConnectionString");
        }
    }
}