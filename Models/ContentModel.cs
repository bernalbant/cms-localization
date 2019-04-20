using System;
using System.Collections.Generic;
using CmsLocalization.DB;

namespace CmsLocalization.Models
{
    public class ContentModel : ILocalizedModel<ContentMappingModel>
    {
        public ContentModel()
        {
            Locales = new List<ContentMappingModel>();
            Languages = new List<Language>();
        }

        public int Id { get; set; }
        public string ContentName { get; set; }
        public bool IsActive { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedTime { get; set; }
        public IList<ContentMappingModel> Locales { get; set; }
        public IList<Language> Languages { get; set; }
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