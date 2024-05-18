namespace ConsoleApp1;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Formats.Jpeg;
using SixLabors.ImageSharp.PixelFormats;
using SixLabors.ImageSharp.Processing;
using System.IO;
public static class ImageHelper
{

    public static byte[] CompressImage(byte[] imageBytes, int quality, int width, int height)
    {

        using (var image = Image.Load<Rgba32>(imageBytes))
        {
            // Calculate the new size while maintaining the aspect ratio
            Size newSize = CalculateNewSize(image.Width, image.Height, width, height);

            // Resize the image
            image.Mutate(x => x.Resize(new ResizeOptions
            {
                Size = newSize,
                Mode = ResizeMode.Max
            }));

            var jpegOptions = new JpegEncoder
            {
                Quality = quality // Set the quality level
            };

            using (var outputStream = new MemoryStream())
            {
                image.Save(outputStream, jpegOptions);
                return outputStream.ToArray();
            }
        }
    }

    private static Size CalculateNewSize(int originalWidth, int originalHeight, int maxWidth, int maxHeight)
    {
        double widthRatio = (double)maxWidth / originalWidth;
        double heightRatio = (double)maxHeight / originalHeight;
        double ratio = Math.Min(widthRatio, heightRatio);

        int newWidth = (int)(originalWidth * ratio);
        int newHeight = (int)(originalHeight * ratio);

        return new Size(newWidth, newHeight);
    }
}
