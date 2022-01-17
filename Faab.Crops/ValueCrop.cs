namespace Faab.Crops;

public class Crop<T> : Crop
{
    public T? Value { get; }

    public Crop(T value, CropStatus status) : base(status)
    {
        Value = value;
    }

    public Crop(T value) : base(CropStatus.Ok)
    {
        Value = value;
    }

    public Crop(CropStatus status) : base(status)
    {
        Value = default;
    }

    public Crop(CropStatus status, string message) : base(status, message)
    {
        Value = default;
    }

    public static implicit operator Crop<T>(T value) => new(value);
    public static implicit operator Crop<T>(CropStatus status) => new(status);
}
