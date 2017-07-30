using Library.API.Entities;
using Library.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Library.API.Services
{
    public class PropertyMappingService : IPropertyMappingService
    {
        private readonly Dictionary<string, PropertyMappingValue> _authorPropertyMapping =
            new Dictionary<string, PropertyMappingValue>
            {
                {"Id", new PropertyMappingValue(new List<string>() {"Id"})},
                {"Genre", new PropertyMappingValue(new List<string>() {"Genre"})},
                {"Age", new PropertyMappingValue(new List<string>() {"DateOfBirth"}, true)},
                {"Name", new PropertyMappingValue(new List<string>() {"FirstName", "LastName"}, true)}
            };

        private readonly IList<IPropertyMapping> _propertyMappings = new List<IPropertyMapping>();

        public PropertyMappingService()
        {
            _propertyMappings.Add(new PropertyMapping<AuthorDto, Author>(_authorPropertyMapping));
        }

        public Dictionary<string, PropertyMappingValue> GetPropertyMapping<TSource, TDestination>()
        {
            var mathcingMapping = _propertyMappings.OfType<PropertyMapping<TSource, TDestination>>();
            if (mathcingMapping.Count() == 1)
            {
                return mathcingMapping.First().MappingDictionary;
            }
            throw new Exception("Cannot find propert mapping instance");
        }

        public bool ValidMappingExistsFor<TSource, TDestination>(string fields)
        {
            var propertyMapping = GetPropertyMapping<TSource, TDestination>();
            if (string.IsNullOrWhiteSpace(fields))
            {
                return true;
            }
            var fieldsAfterSplit = fields.Split(',');
            foreach (var field in fieldsAfterSplit)
            {
                var trimmedField = field.Trim();
                var indexOfFirstSpace = trimmedField.IndexOf(" ");
                var propertyName = indexOfFirstSpace == -1 ? trimmedField : trimmedField.Remove(indexOfFirstSpace);
                if (!propertyMapping.ContainsKey(propertyName))
                {
                    return false;
                }
            }
            return true;
        }
    }
}
