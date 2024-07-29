using System.ComponentModel.DataAnnotations;

namespace MyFriends.Models
{
    public class Image
    {
        [Key]
        public int Id { get; set; }
        public Friend Friend { get; set; }
        
        [Display(Name = "תמונה")]
        public byte[] MyImage { get; set; }
    }
}
