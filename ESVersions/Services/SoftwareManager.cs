using ESVersions.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ESVersions.Services
{
    public static class SoftwareManager
    {
        public static IEnumerable<Software> GetAllSoftware()
        {
            return new List<Software>
            {
                new Software
                {
                    Name = "MS Word",
                    Version = "13.2.1"
                },
                new Software
                {
                    Name = "Angular1",
                    Version = "1.0.9"
                },
                new Software
                {
                    Name = "Angular2",
                    Version = "2.0"
                },
                new Software
                {
                    Name = "Doom",
                    Version = "0.0.5"
                },
                new Software
                {
                    Name = "Clippy",
                    Version = "2.1"
                },
                new Software
                {
                    Name = "Visual Studio",
                    Version = "2017.0.1"
                },
                new Software
                {
                    Name = "Sublime3",
                    Version = "3.9"
                },
                new Software
                {
                    Name = "Call of Duty",
                    Version = "9.9.9"
                }
            };
        }

        public static IEnumerable<Software> GetSoftwareBeyondVersion(Version inputVersion)
        {                        
            var result = new List<Software>();

            var temp = GetAllSoftware();

            foreach (var item in temp)
            {                
                var ver = Version.Parse(item.Version);

                if(ver > inputVersion)
                {
                    result.Add(item);
                }
            }

            return result;
        }

        public static bool Validate(string version)
        {
            var versionParts = version.Split('.');

            // Check if any part of the version is a string
            foreach (var item in versionParts)
            {
                int result;

                if (!int.TryParse(item, out result))
                {
                    return false;
                }
            }

            return true;
        }

        public static Version FormatVersion(string version)
        {
            if(version.Split('.').Count() < 3 && !version.EndsWith("."))
            {
                version += ".0";
            }

            return Version.Parse(version); 
        }
    }
}