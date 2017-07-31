using System.Collections.Generic;

namespace Library.API.Models
{
    public class LinkedResourceBaseDto
    {
        public List<LinkDto> Links { get; set; } = new List<LinkDto>();
    }
}
