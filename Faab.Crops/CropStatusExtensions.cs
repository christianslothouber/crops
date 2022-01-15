namespace Faab.Crops;

public static class CropStatusExtensions
{
    public static bool IsOk(this CropStatus status)
    {
        return status < CropStatus.BadRequest;
    }

    public static bool IsNotOk(this CropStatus status)
    {
        return !status.IsOk();
    }
}