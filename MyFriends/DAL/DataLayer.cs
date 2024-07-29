using Microsoft.EntityFrameworkCore;
using MyFriends.Models;

namespace MyFriends.DAL
{
    /// <summary>
    /// מייצג את שכבת הגישה לנתונים של היישום, המרחיבה את מחלקת DbContext מ-Entity Framework Core.
    /// </summary>
    public class DataLayer : DbContext
    {
        /// <summary>
        /// מאתחל מופע חדש של מחלקת DataLayer באמצעות מחרוזת החיבור שצוינה.
        /// </summary>
        /// <param name="connectionString">מחרוזת החיבור למסד הנתונים.</param>
        public DataLayer(string connectionString) : base(GetOptions(connectionString))
        {
            // מבטיח שהמסד הנתונים נוצר, אם הוא לא קיים.
            Database.EnsureCreated();

            // מטעין נתוני התחלה אם מסד הנתונים ריק.
            Seed();
        }

        /// <summary>
        /// מטעין נתוני התחלה למסד הנתונים אם אין נתונים קיימים.
        /// </summary>
        private void Seed()
        {
            // אם קיימים נתונים בטבלת החברים, לא טוענים נתוני התחלה.
            if (Friends.Count() > 0)
            {
                return;
            }

            // יצירת חבר ראשון עם נתונים התחלתיים.
            Friend firstFriend = new Friend
            {
                FirstName = "בנימין",
                LastName = "לוי",
                EmailAddress = "binyamin@meno.com",
                PhoneNumber = "1234567890"
            };

            // הוספת החבר הראשון לטבלת החברים ושמירת השינויים.
            Friends.Add(firstFriend);
            SaveChanges();
        }

        /// <summary>
        /// מאפיין המייצג את טבלת החברים במסד הנתונים.
        /// </summary>
        public DbSet<Friend> Friends { get; set; }

        /// <summary>
        /// מאפיין המייצג את טבלת התמונות במסד הנתונים.
        /// </summary>
        public DbSet<Image> Images { get; set; }

        /// <summary>
        /// מגדיר את אפשרויות DbContext באמצעות מחרוזת החיבור שצוינה.
        /// </summary>
        /// <param name="connectionString">מחרוזת החיבור למסד הנתונים.</param>
        /// <returns>אובייקט DbContextOptions מוגדר.</returns>
        private static DbContextOptions GetOptions(string connectionString)
        {
            return SqlServerDbContextOptionsExtensions
                .UseSqlServer(new DbContextOptionsBuilder(), connectionString)
                .Options;
        }
    }
}
