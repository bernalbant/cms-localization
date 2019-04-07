using System.Collections.Generic;
using CmsLocalization.DB;

namespace CmsLocalization.Infastructure
{
    public interface IContentMappingRepository : IRepository<ContentMapping>
    {
        IList<ContentMapping> GetMappingsByContentId(int id); 
    }
}