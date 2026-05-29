string dosyaYolu = "notlar.txt";

List<string> notlar = new List<string>();

if (File.Exists(dosyaYolu))
{
    notlar = File.ReadAllLines(dosyaYolu).ToList();
}
else
{
    File.Create(dosyaYolu).Close();
}

while (true)
{

    // uygulama başlangıcı
    Console.WriteLine("""
        ==========================
        == Notlar Uygulaması V2 ==
        ==========================

        1. Not Ekle
        2. Notları Listele
        3. Not Sil
        4. Çıkış
        """);

    Console.Write("\nİşlem yapcağınız seçeneği giriniz: ");
    string secim = Console.ReadLine();
    Console.Clear();

    if (secim == "1")
    {
        Console.Write("Eklemek istediğin notu gir: ");
        string notEkle = Console.ReadLine();

        notlar.Add(notEkle);
        File.WriteAllLines(dosyaYolu, notlar);

        Console.Clear();
    }

    else if (secim == "2")
    {
        if (notlar.Count == 0)
        {
            Console.WriteLine("Herhangi bir notunuz bulunmamakta!");
        }
        else
        {
            Console.WriteLine("Notlarınız listeleniyor...\n");

            for (int i = 0; i < notlar.Count; i++)
            {
                Console.WriteLine(i + " - " + notlar[i]);
            }
        }
        Console.ReadKey();
        Console.Clear();

    } 
    
    else if (secim == "3") 
    {
        Console.Write("Silmek istediğiniz notun numarasını giriniz: ");

        if (!int.TryParse(Console.ReadLine(), out int notSil)) {

            Console.WriteLine("Geçerli bir sayı giriniz!");
            Console.ReadKey();
            Console.Clear();
            continue;
        }

        if (notSil < 0 || notSil >= notlar.Count)
        {
            Console.WriteLine("Böyle bir not yok.");
            Console.ReadKey();
            Console.Clear();
            continue;
        }

        notlar.RemoveAt(notSil);
        File.WriteAllLines(dosyaYolu, notlar);

        Console.WriteLine("Not silindi!");
        Console.ReadKey();
        Console.Clear();
    }

    else if (secim == "4") 
    {
        break;
    }

}
