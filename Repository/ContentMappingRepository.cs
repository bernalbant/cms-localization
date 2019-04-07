using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using CmsLocalization.DB;
using CmsLocalization.Infastructure;
using Microsoft.EntityFrameworkCore;

namespace CmsLocalization.Repository
{
public class ContentMappingRepository : IContentMappingRepository
    {
        private readonly CMS_Context _context;

        public ContentMappingRepository(CMS_Context context)
        {
            this._context = context;
        }

        public ContentMapping GetById(int id)
        {
            var contentMapping = _context.ContentMappings.Where(c => c.Id == id).FirstOrDefault();
            return contentMapping;
        }

        public IEnumerable<ContentMapping> GetAll()
        {
            return _context.ContentMappings.ToList();
        }

        public IQueryable<ContentMapping> GetMany(Expression<Func<ContentMapping, bool>> expression)
        {
            return _context.ContentMappings.Where(expression);
        }

        public ContentMapping Get(Expression<Func<ContentMapping, bool>> expression)
        {
            return _context.ContentMappings.Where(expression).FirstOrDefault();
        }

        public void Insert(ContentMapping entity)
        {
            _context.ContentMappings.Add(entity);
        }

        public int InsertAndGetId(ContentMapping entity)
        {
            _context.ContentMappings.Add(entity);
            Save();
            return entity.Id;
        }

        public void Update(ContentMapping entity)
        {
            Save();
        }
        public void Delete(ContentMapping entity)
        {
            var contentMapping = _context.ContentMappings.Where(c => c.Id == entity.Id);       
            Delete(entity);
        }

        public int Save()
        {
            return _context.SaveChanges();
        }

        public IList<ContentMapping> GetMappingsByContentId(int id)
        {
            var mappings = GetMany(c => c.ContentId == id).ToList();
            return mappings;
        }

        public IList<ContentMapping> GetMappingsByContenteId(int id)
        {
            var contentMappings = GetMany(s => s.ContentId == id).ToList();
            return contentMappings;
        }
    }
}