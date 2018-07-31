using System.Collections.Generic;
using ESVersions.Models;

namespace ESVersions.Services
{
    public interface IDataService
    {
        IEnumerable<Software> GetSoftwares(string version);
    }
}