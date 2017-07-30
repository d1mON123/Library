using System.Collections.Generic;

namespace Library.API.Services
{
    public class PropertyMappingValue
    {
        public IEnumerable<string> DestinationProperties { get; set; }
        public bool Revert { get; set; }

        public PropertyMappingValue(IEnumerable<string> destinationProperties, bool revert = false)
        {
            DestinationProperties = destinationProperties;
            Revert = revert;
        }
    }
}
