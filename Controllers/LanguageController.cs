using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CmsLocalization.AutoMapperMapping;
using CmsLocalization.Infastructure;
using CmsLocalization.Models;
using Microsoft.AspNetCore.Mvc;


namespace CmsLocalization.Controllers
{
    public class LanguageController : Controller
    {
        private readonly IMapper _mapper;
        private readonly ILanguageRepository _languageRepository;

        public LanguageController(ILanguageRepository languageRepository, IMapper mapper)
        {
            _languageRepository = languageRepository;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            var languages = _languageRepository.GetAll();
            return View(languages);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(LanguageModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var language = model.ToEntity(_mapper);
                    language.CreatedBy = "Berkay";
                    _languageRepository.Insert(language);
                    _languageRepository.Save();
                    TempData["Message"] = "Dil başarıyla eklenmiştir.";
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    ViewBag.Message = ex.ToString();
                }
            }
            return View(model);
        }

        public IActionResult Edit(int id)
        {
            var language = _languageRepository.GetById(id);
            if (language == null)
                return RedirectToAction("Index");

            try
            {
                var languageModel = language.ToModel(_mapper);
                return View(languageModel);
            }
            catch (Exception ex)
            {
                ViewBag.Message = ex.ToString();
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Edit(LanguageModel model)
        {
            var language = _languageRepository.GetById(model.Id);
            if (language == null)
                return RedirectToAction("Index");

            if (ModelState.IsValid)
            {
                try
                {
                    language = model.ToEntity(language, _mapper);
                    _languageRepository.Update(language);
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    ViewBag.Message = ex.ToString();
                }
            }
            return View(model);
        }

        public IActionResult Delete(int id)
        {
            var language = _languageRepository.GetById(id);
            if (language == null)
                return RedirectToAction("Index");

            try
            {
                _languageRepository.Delete(language);
                _languageRepository.Save();
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ViewBag.Message = ex.ToString();
            }
            return RedirectToAction("Index");
        }
    }
}
