using ESVersions.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ESVersions.Services
{
    public class DataService : IDataService
    {
        public IEnumerable<Software> GetSoftwares(string version)
        {
            if(SoftwareManager.Validate(version))
            {
                Version inputVersion = SoftwareManager.FormatVersion(version);
                return SoftwareManager.GetSoftwareBeyondVersion(inputVersion);
            }            
            else
            {
                throw new Exception();
            }
        }
    }
}