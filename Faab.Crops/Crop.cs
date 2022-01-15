namespace Faab.Crops;

public class Crop<T> : Crop
{
    public T Value { get; }

    public Crop(T value) : base(CropStatus.Ok)
    {
        Value = value;
    }

    public Crop(T value, CropStatus status) : base(status)
    {
        Value = value;
    }

    public static implicit operator Crop<T>(T value) => new(value);
}

public class Crop
{
    public CropStatus Status { get; }

    public string Message { get; }

    public static Crop Void => CropStatus.Ok;

    public Crop(CropStatus status)
    {
        Status = status;
    }

    public Crop(CropStatus status, string message)
    {
        Status = status;
        Message = message;
    }

    public static implicit operator Crop(CropStatus status) => new(status);
};