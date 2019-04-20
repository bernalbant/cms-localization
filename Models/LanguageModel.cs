using System;
namespace CmsLocalization.Models
{
    public class LanguageModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LanguageCulture { get; set; }
        public string UniqueSeoCode { get; set; }
        public bool Published { get; set; }
        public int DisplayOrder { get; set; }
    }
}