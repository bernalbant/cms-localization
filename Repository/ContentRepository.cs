using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using CmsLocalization.DB;
using CmsLocalization.Infastructure;
using Microsoft.EntityFrameworkCore;

namespace CmsLocalization.Repository
{
public class ContentRepository : IContentRepository
    {
        private readonly IContentMappingRepository _contentMappingRepository;

        private readonly CMS_Context _context;

        public ContentRepository(CMS_Context context, IContentMappingRepository contentMappingRepository)
        {
            this._context = context;
            this._contentMappingRepository = contentMappingRepository;
        }

        public Content GetById(int id)
        {
            var content = _context.Contents.Include(c => c.Locales).Where(c => c.Id == id).FirstOrDefault();
            return content;
        }

        public IEnumerable<Content> GetAll()
        {
            return _context.Contents.Include(c => c.Locales).ToList();
        }

        public IQueryable<Content> GetMany(Expression<Func<Content, bool>> expression)
        {
            return _context.Contents.Include(c => c.Locales).Where(expression);
        }

        public Content Get(Expression<Func<Content, bool>> expression)
        {
            return _context.Contents.Include(c => c.Locales).Where(expression).FirstOrDefault();
        }

        public void Insert(Content entity)
        {
            entity.CreatedBy = "Berkay Ernalbant";
            entity.CreatedDate = DateTime.Now;
            _context.Contents.Add(entity);
        }

        public int InsertAndGetId(Content entity)
        {
            entity.CreatedBy = "Berkay Ernalbant";
            entity.CreatedDate = DateTime.Now;
            _context.Contents.Add(entity);
            Save();
            return entity.Id;
        }

        public void Update(Content entity)
        {
            Save();
        }
        public void Delete(Content entity)
        {
            var contentMappings = _contentMappingRepository.GetMany(m => m.ContentId == entity.Id);
            //delete also content mappings
            foreach (var contMap in contentMappings)
            {
                _contentMappingRepository.Delete(contMap);
            }
            Save();
            Delete(entity);
            Save();
        }

        public int Save()
        {
            return _context.SaveChanges();
        }
    }
}