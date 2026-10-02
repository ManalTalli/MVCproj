using Ecommerce.Enums;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection.Metadata;

namespace Ecommerce.Models
{
    public class Category
    {
        public int Id { get; set; }

        [Column(TypeName="varchar(30)")]
        public string Name { get; set; }
        [EnumDataType(typeof(Status))]
        public Status Status { get; set; }
        public List<Products> Products { get; set; }
    }
}
