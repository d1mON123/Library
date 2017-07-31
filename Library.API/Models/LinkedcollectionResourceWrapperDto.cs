using System.Collections.Generic;

namespace Library.API.Models
{
    public class LinkedcollectionResourceWrapperDto<T> : LinkedResourceBaseDto where T : LinkedResourceBaseDto
    {
        public IEnumerable<T> Value { get; set; }

        public LinkedcollectionResourceWrapperDto(IEnumerable<T> value)
        {
            Value = value;
        }
    }
}
