// See https://aka.ms/new-console-template for more information
using ConsoleApp1;

Console.WriteLine("Hello, World!");
string imagePath = "adsiztasarim.png"; // Küçültülecek resmin dosya yolu
string outputPath = Guid.NewGuid().ToString() + "-img.jpg"; // Küçültülmüş resmin kaydedileceği dosya yolu
int quality = 20; // Kalite seviyesi (1-100 arası)
int newWidth = 800; // Yeni genişlik
int newHeight = 600;

byte[] imageBytes = File.ReadAllBytes(imagePath);
byte[] compressedImageBytes = ImageHelper.CompressImage(imageBytes, quality, newWidth, newHeight);

File.WriteAllBytes(outputPath, compressedImageBytes);

