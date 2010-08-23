using DotNetNuke.Entities.Modules;
using DotNetNuke.Services.Search;

namespace BeerCollection
{
    public class BeerCollectionController : ISearchable, IPortable
    {
        public string ExportModule(int ModuleID)
        {
            return string.Empty;
        }

        public void ImportModule(int ModuleID, string Content, string Version, int UserID)
        {
            
        }

        public DotNetNuke.Services.Search.SearchItemInfoCollection GetSearchItems(ModuleInfo ModInfo)
        {
            return new SearchItemInfoCollection();
        }
    }
}