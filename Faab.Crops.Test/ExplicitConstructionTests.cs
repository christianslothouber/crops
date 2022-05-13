using NUnit.Framework;

namespace Faab.Crops.Test;

[TestFixture]
public class ExplicitConstructionTests
{
    [Theory]
    public void ExplicitConstructionValueCropGivenValueAndStatusShouldHaveValueAndStatusButNoMessage(
        CropStatus status,
        [Random(3)] int value)
    {
        // Act
        var crop = new Crop<int>(value, status);

        // Assert
        Assert.AreEqual(status, crop.Status);
        Assert.AreEqual(value, crop.Value);
        Assert.Null(crop.Message);
    }

    [Theory]
    public void ExplicitConstructionValueCropGivenStatusShouldHaveStatusButNoValueOrMessage(CropStatus status)
    {
        // Act
        var crop = new Crop<IAnyInterface>(status);

        // Assert
        Assert.AreEqual(status, crop.Status);
        Assert.Null(crop.Value);
        Assert.Null(crop.Message);
    }

    [Theory]
    public void ExplicitConstructionValueCropGivenValueShouldHaveOkStatusAndValueButNoMessage([Random(3)] int value)
    {
        // Act
        var crop = new Crop<int>(value);

        // Assert
        Assert.AreEqual(CropStatus.Ok, crop.Status);
        Assert.AreEqual(value, crop.Value);
        Assert.Null(crop.Message);
    }

    [Theory]
    public void ExplicitConstructionValueCropGivenStatusAndMessageShouldHaveStatusAndMessageButNoValue(
        CropStatus status)
    {
        // Arrange
        const string message = "Something went horribly wrong";

        // Act
        var crop = new Crop<IAnyInterface>(status, message);

        // Assert
        Assert.AreEqual(status, crop.Status);
        Assert.AreEqual(message, crop.Message);
        Assert.Null(crop.Value);
    }

    [Theory]
    public void ExplicitConstructionVoidCropGivenStatusShouldHaveStatusButNoMessage(CropStatus status)
    {
        // Act
        var crop = new Crop(status);

        // Assert
        Assert.AreEqual(status, crop.Status);
        Assert.Null(crop.Message);
    }

    [Theory]
    public void ExplicitConstructionVoidCropGivenStatusAndMessageShouldHaveStatusAndMessage(CropStatus status)
    {
        // Arrange
        const string message = "Something went horribly wrong";

        // Act
        var crop = new Crop(status, message);

        // Assert
        Assert.AreEqual(status, crop.Status);
        Assert.AreEqual(message, crop.Message);
    }

    [Theory]
    public void ExplicitConstructionVoidCropShouldHaveOkStatusAndNoMessage()
    {
        // Act
        var crop = new Crop();

        // Assert
        Assert.AreEqual(CropStatus.Ok, crop.Status);
        Assert.Null(crop.Message);
    }
}
