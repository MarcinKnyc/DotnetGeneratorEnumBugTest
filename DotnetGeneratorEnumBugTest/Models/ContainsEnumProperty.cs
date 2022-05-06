using DotnetGeneratorEnumBugTest.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace DotnetGeneratorEnumBugTest.Models
{
    public class ContainsEnumProperty
    {
        [Key]
        public Guid Id { get; set; }
        public EnumType EnumType { get; set; }
    }
}
