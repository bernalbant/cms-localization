using System;
using System.Collections.Generic;

namespace CmsLocalization.Models
{
    public class ContentModel : ILocalizedModel<ContentMappingModel>
    {
        public ContentModel()
        {
            Locales = new List<ContentMappingModel>();
        }

        public int Id { get; set; }
        public string EntityName { get; set; }
        public IList<ContentMappingModel> Locales { get; set; }
    }

    public class ContentMappingModel : ILocalizedModelLocal
    {
        public int Id { get; set; }
        public int ContentId { get; set; }
        public int LanguageId { get; set; }
        public string Title { get; set; }
        public string SubTitle { get; set; }
        public string Description { get; set; }
    }
}