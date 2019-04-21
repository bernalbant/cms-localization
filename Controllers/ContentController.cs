using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using CmsLocalization.AutoMapperMapping;
using CmsLocalization.DB;
using CmsLocalization.Infastructure;
using CmsLocalization.Models;
using Microsoft.AspNetCore.Mvc;


namespace CmsLocalization.Controllers
{
    public class ContentController : ControllerBase
    {
        private readonly IMapper _mapper;

        private readonly IContentRepository _contentRepository;
        private readonly IContentMappingRepository _contentMappingRepository;
        private readonly ILanguageRepository _languageRepository;

        public ContentController(IContentRepository contentRepository, IContentMappingRepository contentMappingRepository,
            ILanguageRepository languageRepository, IMapper mapper)
        {
            _contentRepository = contentRepository;
            _contentMappingRepository = contentMappingRepository;
            _languageRepository = languageRepository;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            var contents = _contentRepository.GetAll();
            return View(contents);
        }

        public IActionResult Create()
        {
            var model = new ContentModel();
            model.Languages = _languageRepository.GetAll().ToList();

            //get mapping proporties
            AddLocales(_languageRepository, model.Locales);
            return View(model);
        }

        [HttpPost]
        public IActionResult Create(ContentModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var content = model.ToEntity(_mapper);
                    content.CreatedBy = "Berkay";
                    _contentRepository.Insert(content); //create content and mappings
                    _contentRepository.Save();

                    TempData["Message"] = "The new content has been added successfully.";
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
            var content = _contentRepository.GetById(id);
            if (content == null)
                return RedirectToAction("Index");

            try
            {
                var mappingModel = new List<ContentMappingModel>();
                var contentModel = content.ToModel(_mapper);
                AddLocales(_languageRepository, mappingModel, (locale, languageId) =>
                {
                    foreach (var item in contentModel.Locales.Where(l => l.LanguageId == languageId))
                    {
                        locale.Title = item.Title;
                        locale.SubTitle = item.SubTitle;
                        locale.Description = item.Description;
                    }
                });
                contentModel.Languages = _languageRepository.GetAll().ToList();
                return View(contentModel);
            }
            catch (Exception ex)
            {
                ViewBag.Message = ex.ToString();
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Edit(ContentModel model)
        {
            var content = _contentRepository.GetById(model.Id);
            if (content == null)
                return RedirectToAction("Index");

            if (ModelState.IsValid)
            {
                try
                {
                    content = model.ToEntity(content, _mapper);
                    _contentRepository.Update(content); //update content and mappings

                    TempData["Message"] = "The content has been updated successfully.";
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    ViewBag.Message = ex.ToString();
                }
            }
            model.Languages = _languageRepository.GetAll().ToList();
            return View(model);
        }

        public IActionResult Delete(int id)
        {
            var content = _contentRepository.GetById(id);
            if (content == null)
                return RedirectToAction("Index");

            try
            {
                _contentRepository.Delete(content);
                _contentRepository.Save();
                TempData["Message"] = "The content has been deleted successfully.";
            }
            catch (Exception ex)
            {
                ViewBag.Message = ex.ToString();
            }
            return RedirectToAction("Index");
        }
    }
}
