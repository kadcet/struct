// struct=yapı => değer tipinde bir değişken tipi oluştuturuz stack te tutlan veri tiplerinden biri
// kullanıcının adı, soyadı, email,yaş, doğum tarihi bir arada tutulsun

public class Program
{


    /*ACCES MODIFIERS ( Erişim Belirleyiciler)
     * public : her yerden erişilebilir
     * private: Sadece içerisinde olduğu class/struct içerisinden erişilebilir
     * internal: Sadece içerisinde olduğu assembly den erişilebilir
     * protected: Sadece içerisinde olduğu class/struck ve kalıtım alan class/struct tarafından erişilebilir
     * */

    struct ROAS
    {
        public string reklamKanali;
        public double reklamMaliyeti;
        public double birimFiyat;
        public int satilanUrunAdedi;

        public double RoasGetirisi()
        {
            return ((satilanUrunAdedi * birimFiyat) / reklamMaliyeti) * 100;
        }

        public void EkranaYaz()
        {
            Console.WriteLine($"Reklam Kanalı : {reklamKanali}");
            Console.WriteLine($"Reklam Maliyeti : {reklamMaliyeti}");
            Console.WriteLine($"Satılan Ürün Adedi : {satilanUrunAdedi}");
            Console.WriteLine($"Birim Fiyat : {birimFiyat}");
            Console.WriteLine($"ROAS Getirisi : %{RoasGetirisi()}");
        }
    }

    static List<ROAS> ROASList=new List<ROAS>();

    public static void Main()
    {
        // Struct (yapı) : kendi tiplerimizi oluşturmak için kullanıyoruz.
        // Structlar deper tiplidir. (value type)

        #region Uygulama Örneği
        /* Kullanıcı program başladığında menü görür
         * 1. Yeeni ROAS hesaplaması
         * 2. ROAS hesap listesi => daha önce hesaplanan roast ların listesi
         * 3. Çıkış
         */

        /* ROAS = Gelir/Maliyetx100
         * Örn. 700 TL reklam harcaması karşılığında 1200 TL gelir elde ettik.
         * (1200/700)x100= %171
         */
        #endregion

        #region Örnek Struct Kullanımı
        //ROAS r;
        //r.reklamKanali = "Facebook";
        //r.reklamMaliyeti = 2500;
        //r.satilanUrunAdedi = 10;
        //r.birimFiyat = 120;
        //r.EkranaYaz();

        #endregion

        Menu();


    }

    static void Menu()
    {
        Console.Clear();
        Console.WriteLine("1. Yeni ROAS Hesabı\n2. ROAS Hesap Listesi\n3. Çıkış");

        MenuSelection();
    }

    static void MenuSelection()
    {
        Console.Write("Yapılacak işlemi seçin :");
        string choose = Console.ReadLine();
        switch (choose)
        {
            case "1":
                NewRoas();
                break;
            case "2":
                ListOfROAS();
                break;
            case "3":
                Environment.Exit(0);
                break;
            default:
                Console.WriteLine("Hatalı seçim. Tekrar Deneyin.");
                MenuSelection(); // Recursive
                break;
        }
    }

    static void ListOfROAS()
    {
        //for (int i = 0; i < ROASList.Count; i++)
        //{
        //    ROASList[i].EkranaYaz();
        //    Console.WriteLine("--------------------");
        //}

        foreach (var roas in ROASList)
        {
            roas.EkranaYaz();
            Console.WriteLine("---------------------------------");
        }


        Again();

    }

    static void NewRoas()
    {
        ROAS r;
        Console.WriteLine("Reklam Kanalı Adı: ");
        r.reklamKanali = Console.ReadLine();
        Console.WriteLine("Reklam Maliyeti: ");
        r.reklamMaliyeti = Convert.ToDouble(Console.ReadLine());
        Console.WriteLine("Satılan ürün adedi :");
        r.satilanUrunAdedi = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Ürün Birim fiyatı :");
        r.birimFiyat = Convert.ToDouble(Console.ReadLine());

        Console.WriteLine($"ROAS Getirisi : %{r.RoasGetirisi()}");

        ROASList.Add(r);

        Again();
    }

    static void Again()
    {
        Console.WriteLine("Meniye dönmek için ENTER");
        Console.ReadLine();
        Menu();
    }
}
