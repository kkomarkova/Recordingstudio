using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HQrecordingstudioBlazor.Shared.Models
{
    public class CatalogueItem
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public int ArtistId { get; set; }
        public Decimal Price { get; set; }
        public string Tracklength { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DatePublished { get; set; }
        public int ParentId { get; set; }
        public int SoundCatId { get; set; }
    }
}
