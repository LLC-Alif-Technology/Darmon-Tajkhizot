using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DataTransferObjects.Description
{
    public class DescriptionResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Text { get; set; }
    }
}
