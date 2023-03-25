using System.Drawing;

internal class Program
{
    private static void Main(string[] args)
    {
         //Günlük Koşu Mesafesi Ölçer(V.1.0)
        
        Console.CursorLeft = Console.WindowWidth / 2 - 10;
        Console.WriteLine("Bugun ne kadar koştum?\nHoşgeldiniz..");

    TekrarBasla:


        try
        {
            MesajGonder("Lütfen adım boyunuzu santimetre olarak giriniz: ");
            double _ortalamaAdimBoyu = Convert.ToInt32(Console.ReadLine());


            MesajGonder("Bir dakikada kaç adım attınız: ");
            int _adimSayisi = Convert.ToInt32(Console.ReadLine());

            MesajGonder("Koşu sürenizi giriniz, saat: (artan dakika bir sonraki adımda istenecektir.)");
            int _kosuSaati = Convert.ToInt32(Console.ReadLine());


            MesajGonder("Koşu sürenizi giriniz, artan dakika: ");
            int _kosuArtanDakika = Convert.ToInt32(Console.ReadLine());
            int _toplamKosuDakikasi = (_kosuSaati * 60) + _kosuArtanDakika;

            double _kullaniciToplamMesafe = KosuMesafesiHesapla(_ortalamaAdimBoyu, _adimSayisi, _toplamKosuDakikasi);

            MesajGonder($"Toplam Koşulan Mesafe: {Math.Round(_kullaniciToplamMesafe, 2)} metre");

            MesajGonder("Ayrıntılı ve doğruluğu yüksek mesafe tahmini için daha fazla bilgiye ihtiyacımız var.\nAyrıntılı mesafe için devam etmek istiyor musunuz? E/H");

            ConsoleKeyInfo cevap = Console.ReadKey();
            Console.WriteLine();
            if (cevap.KeyChar == 'E' || cevap.KeyChar == 'e')
            {
                double[] adimSayilari = new double[0];
                AdimSayisiDizisiOlustur(ref adimSayilari, _toplamKosuDakikasi);
                double _ortalamaAdimSayisi = OrtalamaAyrintiliAdimSayisiHesapla(ref adimSayilari);

                double _ayrintiliKosuMesafesi = KosuMesafesiHesapla(_ortalamaAdimBoyu, _ortalamaAdimSayisi, _toplamKosuDakikasi);

                MesajGonder($"Toplam Koşulan Mesafe: {Math.Round(_ayrintiliKosuMesafesi, 2)} metre");

            }

            else
            {
                UygulamayıKapat();
            }

        }
        catch (FormatException fex)
        {
            MesajGonder($"Lütfen sadece sayısal değer giriniz. Sistem mesajı--> {fex.Message}");

        }

        MesajGonder("Yeni bir hesaplama yapmak istiyor musunuz? E/H");
        ConsoleKeyInfo gelenCevap = Console.ReadKey();
        Console.WriteLine();



        if (gelenCevap.KeyChar == 'E' || gelenCevap.KeyChar == 'e')
        {
            goto TekrarBasla;
        }
        else
        {
            UygulamayıKapat();
        }

    }

    static void MesajGonder(string mesaj)
    {
        Console.WriteLine(mesaj);
    }

    static double KosuMesafesiHesapla(double ortAdimBoyu, double adimSayisi, int toplamKosuDakika)
    {
        double toplamMesafe = (ortAdimBoyu / 100) * adimSayisi * (toplamKosuDakika);
        return toplamMesafe;
    }
    static double[] AdimSayisiDizisiOlustur(ref double[] dizi, int toplamKosuDakikasi)
    {
        if (toplamKosuDakikasi % 20 == 0)
        {
            for (int i = 0; i < toplamKosuDakikasi / 20; i++) //20dakika için sorsun.
            {
                Array.Resize(ref dizi, dizi.Length + 1);

                MesajGonder($"{i + 1}. Periyot İçin Ortalama Adım Sayınızı Giriniz: (Periyotlar 20 Dakikalık olarak hesaplanmıştır.)");
                dizi[dizi.Length - 1] = Convert.ToInt32(Console.ReadLine());
            }


        }

        else
        {
            for (int i = 0; i < (toplamKosuDakikasi / 20) + 1; i++) //20dakika için sorsun.
            {
                Array.Resize(ref dizi, dizi.Length + 1);

                MesajGonder($"{i + 1}. Periyot İçin Ortalama Adım Sayınızı Giriniz: (Periyotlar 20 Dakikalık olarak hesaplanmıştır.)");
                dizi[dizi.Length - 1] = Convert.ToInt32(Console.ReadLine());
            }
        }

        return dizi;
    }

    static double OrtalamaAyrintiliAdimSayisiHesapla(ref double[] dizi)
    {
        double toplamAdimSayisi = 0;
        for (int i = 0; i < dizi.Length; i++)
        {
            toplamAdimSayisi += dizi[i];
        }
        double _ortalamaAdim = toplamAdimSayisi / dizi.Length;
        return _ortalamaAdim;
    }

    static void UygulamayıKapat()
    {
        MesajGonder("\n***************************************\nUygulama 3 Saniye Sonra Kapatılacak.\n***************************************");
        Thread.Sleep(3000);
        Environment.Exit(1);
    }

}