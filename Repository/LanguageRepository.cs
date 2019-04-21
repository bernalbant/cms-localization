using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using CmsLocalization.DB;
using CmsLocalization.Infastructure;

namespace CmsLocalization.Repository
{
public class LanguageRepository : ILanguageRepository
    {
        private readonly CMS_Context _context;

        private readonly IContentRepository _contentRepository;
        private readonly IContentMappingRepository _contentMappingRepository;

        public LanguageRepository(CMS_Context context,
            IContentRepository contentRepository,
            IContentMappingRepository contentMappingRepository)
        {
            _context = context;
            _contentRepository = contentRepository;
            _contentMappingRepository = contentMappingRepository;
        }

        public Language GetById(int id)
        {
            var language = _context.Languages.Where(c => c.Id == id).FirstOrDefault();
            return language;
        }

        public IEnumerable<Language> GetAll()
        {
            return _context.Languages.ToList();
        }

        public IQueryable<Language> GetMany(Expression<Func<Language, bool>> expression)
        {
            return _context.Languages.Where(expression);
        }

        public Language Get(Expression<Func<Language, bool>> expression)
        {
            return _context.Languages.Where(expression).FirstOrDefault();
        }

        public void Insert(Language entity)
        {
            //save language
            _context.Languages.Add(entity);
            Save();

            //save mappings for new lang
            var contents = _contentRepository.GetAll();
            foreach (var content in contents)
            {
                var contentMapping = new ContentMapping
                {
                    LanguageId = entity.Id,
                    ContentId = content.Id
                };
                _contentMappingRepository.Insert(contentMapping);
            }
            Save();
        }

        public int InsertAndGetId(Language entity)
        {
            Insert(entity);
            return entity.Id;
        }

        public void Update(Language entity)
        {
            Save();
        }
        public void Delete(Language entity)
        {
            _context.Languages.Remove(entity);
        }

        public int Save()
        {
            return _context.SaveChanges();
        }
    }
}