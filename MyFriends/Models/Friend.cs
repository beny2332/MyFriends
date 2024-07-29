using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyFriends.Models
{
    public class Friend
    {
        public Friend() 
        {
            Images = new List<Image>();
        }
        
        [Key]
        public int Id { get; set; }

        [Display(Name = "שם פרטי")]
        public string FirstName { get; set; } = "";
        [Display(Name = "שם משפחה")]
        public string LastName { get; set; } = "";
        [Display(Name = "שם מלא"), NotMapped]
        public string Fullname { get { return FirstName + " " + LastName; } }
        [Display(Name = "מספר טלפון"), Phone]
        public string PhoneNumber { get; set; } = "";
        [Display(Name = "כתובת אימייל"),EmailAddress(ErrorMessage ="כתובת מייל אינה נכונה")]
        public string EmailAddress { get; set; } = "";
        public List<Image> Images { get; set; }

        [Display(Name ="הוספת תמונה"), NotMapped]
        public IFormFile SetImage 
        { 
            get { return null; }
            set 
            {
                if (value == null) 
                {
                    return;
                }
                // יצירת מקום בזיכרון עבור קובץ
                MemoryStream stream = new MemoryStream();
                value.CopyTo(stream);
               
                // המרת המקום בזיכרון שיצירנו לבייטים
                byte[] streamArray = stream.ToArray();

                // הוספת הצמונה לרשימת התמונות של החבר
                AddImage(streamArray);
            } 
        }
        public void AddImage(byte[] image)
        {
            // דרך אחת לייצר מופע של קלאס 
            Image img = new Image()
            {
                MyImage = image,
                Friend = this
            };

           // דרך שנייה לייצר מופע של קלאס
           // img.MyImage = image;
           // img.Friend = this;
            Images.Add(img);
        }
    }
}
