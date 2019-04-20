using System;
using AutoMapper;
using CmsLocalization.DB;
using CmsLocalization.Models;

namespace CmsLocalization.AutoMapperMapping
{
    public static class MappingExtensions
    {
        #region Content

        public static ContentModel ToModel(this Content entity, IMapper _mapper)
        {
            return _mapper.Map<Content, ContentModel>(entity);
        }

        public static Content ToEntity(this ContentModel model, IMapper _mapper)
        {
            return _mapper.Map<ContentModel, Content>(model);
        }

        public static Content ToEntity(this ContentModel model, Content destination, IMapper _mapper)
        {
            return _mapper.Map(model, destination);
        }

        #endregion

        #region ContentMapping

        public static ContentMappingModel ToModel(this ContentMapping entity, IMapper _mapper)
        {
            return _mapper.Map<ContentMapping, ContentMappingModel>(entity);
        }

        public static ContentMapping ToEntity(this ContentMappingModel model, IMapper _mapper)
        {
            return _mapper.Map<ContentMappingModel, ContentMapping>(model);
        }

        public static ContentMapping ToEntity(this ContentMappingModel model, ContentMapping destination, IMapper _mapper)
        {
            return _mapper.Map(model, destination);
        }

        #endregion

        #region Language

        public static LanguageModel ToModel(this Language entity, IMapper _mapper)
        {
            return _mapper.Map<Language, LanguageModel>(entity);
        }

        public static Language ToEntity(this LanguageModel model, IMapper _mapper)
        {
            return _mapper.Map<LanguageModel, Language>(model);
        }

        public static Language ToEntity(this LanguageModel model, Language destination, IMapper _mapper)
        {
            return _mapper.Map(model, destination);
        }

        #endregion

    }
}
