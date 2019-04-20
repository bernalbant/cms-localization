using System;
using System.Collections.Generic;
using CmsLocalization.Infastructure;
using CmsLocalization.Models;
using Microsoft.AspNetCore.Mvc;


namespace CmsLocalization.Controllers
{
    public abstract class ControllerBase : Controller
    {
        protected virtual void AddLocales<TLocalizedModelLocal>(ILanguageRepository languageService, IList<TLocalizedModelLocal> locales) where TLocalizedModelLocal : ILocalizedModelLocal
        {
            AddLocales(languageService, locales, null);
        }

        protected virtual void AddLocales<TLocalizedModelLocal>(ILanguageRepository languageService, IList<TLocalizedModelLocal> locales, Action<TLocalizedModelLocal, int> configure) where TLocalizedModelLocal : ILocalizedModelLocal
        {
            foreach (var language in languageService.GetAll())
            {
                var locale = Activator.CreateInstance<TLocalizedModelLocal>();
                locale.LanguageId = language.Id;
                if (configure != null)
                {
                    configure.Invoke(locale, locale.LanguageId);
                }
                locales.Add(locale);
            }
        }
    }
}
