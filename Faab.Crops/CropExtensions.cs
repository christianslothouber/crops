namespace Faab.Crops;

public static class CropExtensions
{
    public static bool IsOk(this Crop crop) => crop.Status < CropStatus.BadRequest;
    public static bool IsNotOk(this Crop crop) => !crop.IsOk();
}
