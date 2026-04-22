using System;
using System.ComponentModel;

internal class Program
{
    private static void Main(string[] args)
    {
        //buat objek garasi
        Garasi garasi = new Garasi();

        //buat objek kendaraan
        Mobil mobil = new Mobil("Innova", 80, 4);
        Motor motor = new Motor("Beat", 20, 2);
        Kapal kapal = new Kapal("Pesiar", 22, "Laut");
        Perahu perahu = new Perahu("Kayu", 10, "Danau");

        //tambahkan ke garasi
        garasi.TambahKendaraan(mobil);
        garasi.TambahKendaraan(motor);
        garasi.TambahKendaraan(kapal);
        garasi.TambahKendaraan(perahu);

        //Tampilkan semua data
        garasi.DaftarKendaraan();

        //polymorphism
        mobil.Bergerak();
        motor.Bergerak();
        kapal.Bergerak();
        perahu.Bergerak();

        //panggil method khusus
        mobil.HitungRoda();
        motor.HitungRoda();
        kapal.CekKondisiAir();
        perahu.CekKondisiAir();
        mobil.Klakson();
        motor.Klakson();
        mobil.GasPol();
        motor.GasPol();
        kapal.Berlayar();
        kapal.Dayung();
        perahu.Berlayar();
        perahu.Dayung();

        //untuk pertanyaan nomor 5 :D
        Kendaraan k = new Motor("Vario", 77, 2);
        k.Bergerak();
    }
}

class Kendaraan
{
    public string Nama;
    public int Kecepatan;

    public Kendaraan(string nama,  int kecepatan)
    {
        Nama = nama;
        Kecepatan = kecepatan;
    }

    public void InfoKendaraan()
    {
        Console.WriteLine($"Nama: {Nama}, Kecepatan: {Kecepatan}");
    }

    public virtual void Bergerak() //polymorphism
    {
        Console.WriteLine($"{Nama} berkecepatan {Kecepatan} km/h");
    }
}

class Darat : Kendaraan
{
    public int jumlahRoda;

    public Darat(string nama, int kecepatan, int jumlahroda) : base(nama, kecepatan)
    {
        this.jumlahRoda = jumlahroda;
    }

    public void HitungRoda()
    {
        Console.WriteLine($"Rodanya ada: {jumlahRoda}");
    }
}

class Mobil : Darat
{
    public Mobil(string nama, int kecepatan, int jumlahroda) : base(nama, kecepatan, jumlahroda)
    {
    }

    public void Klakson()
    {
        Console.WriteLine("Tinnn Tinnnn");
    }

    public void GasPol()
    {
        Console.WriteLine("Mobil Gaspolll");
    }

    public override void Bergerak() //polymorphism
    {
        Console.WriteLine($"Mobil {Nama} bergerak!");
    }
}

class Motor : Darat
{
    public Motor(string nama, int kecepatan, int jumlahroda) : base(nama, kecepatan, jumlahroda)
    {
    }

    public void Klakson()
    {
        Console.WriteLine("Tett Tett");
    }

    public void GasPol()
    {
        Console.WriteLine("Motor Gaspolll");
    }

    public override void Bergerak() //polymorphism
    { 
        Console.WriteLine($"Motor {Nama} Bergerak!!");
    }
}

class Air : Kendaraan
{
    public string jenisAir;

    public Air(string nama, int kecepatan, string jenisair) : base(nama, kecepatan)
    {
        this.jenisAir = jenisair;
    }

    public void CekKondisiAir()
    {
        Console.WriteLine($"Kondisi air sekarang berada di: {jenisAir}");
    }
}

class Kapal : Air
{
    public Kapal(string nama, int kecepatan, string jenisair) : base(nama, kecepatan, jenisair)
    {
    }

    public void Berlayar()
    {
        Console.WriteLine("Kapal Berlayar");
    }

    public void Dayung()
    {
        Console.WriteLine("Kapal Didayung");
    }

    public override void Bergerak() //polymorphism
    {
        Console.WriteLine($"Kapal {Nama} bergerak!!!");
    }
}

class Perahu : Air
{
    public Perahu(string nama, int kecepatan, string jenisair) : base(nama, kecepatan, jenisair)
    {
    }

    public void Berlayar()
    {
        Console.WriteLine("Perahu Berlayar");
    }
    public void Dayung()
    {
        Console.WriteLine("Perahu Didayung");
    }

    public override void Bergerak() //polymorphism
    {
        Console.WriteLine($"Perahu {Nama} bergerak!!!!");
    }
}

class Garasi
{
    private List<Kendaraan> list = new List<Kendaraan>(); 
    public void TambahKendaraan(Kendaraan kendarraan)
    {
        list.Add(kendarraan);
    }

    public void DaftarKendaraan()
    {
        foreach (var k in list)
        {
            k.InfoKendaraan();
        }
    }
}
