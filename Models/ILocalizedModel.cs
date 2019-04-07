using System.Collections.Generic;

namespace CmsLocalization.Helpers
{
    public interface ILocalizedModel
    {
    }

    public interface ILocalizedModel<T> : ILocalizedModel where T : ILocalizedModelLocal
    {
        IList<T> Locales { get; set; }
    }

    public interface ILocalizedModelLocal
    {
        int LanguageId { get; set; }
    }
}
