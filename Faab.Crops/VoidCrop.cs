namespace Faab.Crops;

public class Crop
{
    public CropStatus Status { get; }
    public string? Message { get; }

    public Crop()
    {
        Status = CropStatus.Ok;
        Message = default;
    }

    public Crop(CropStatus status)
    {
        Status = status;
        Message = default;
    }

    public Crop(CropStatus status, string message)
    {
        Status = status;
        Message = message;
    }

    public static implicit operator Crop(CropStatus status) => new(status);
}
