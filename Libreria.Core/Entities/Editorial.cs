using System;
using System.Collections.Generic;
using System.Text;

namespace Libreria.Core.Entities
{
    public class Editorial : IEditorial
    {
        public int EditorialId { get; set; }

        public string Name { get; set; }
    }
}
