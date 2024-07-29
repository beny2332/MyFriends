namespace MyFriends.DAL
{
    // קונסטרקטור לניהול הנתונים של המחלקה
    public class Data
    {
        // מחרוזת החיבור למסד הנתונים
        string ConnectionString = 
        "Server=LAPTOP-ARI;" + 
        "initial catalog=my_friends;" +
        "User Id=sa;" +
        "Password=211488770;" +
        "TrustServerCertificate=True";

        // קונסטרקטור פרטי למניעת יצירת מופעים מחוץ למחלקה
        private Data() 
        {
            // יצירת מוםע של שכבת הנתונים עם מחרוזת החיבור
            Layer = new DataLayer(ConnectionString);
        }

        // משתנה סטטי לשמירת מופע יחיד של המחלקה
        static Data GetData;

        // מאפיין סטטי לשמירת לקבלת שכבת הנתונים
        public static DataLayer Get {get
            {
                if (GetData == null) 
                {
                    GetData = new Data();
                }
                return GetData.Layer;
            }               
        }
        // מאפיין לשמירת שכבת הנתונים
        public DataLayer Layer { get; set; }
    }
}
