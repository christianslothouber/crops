using NUnit.Framework;

namespace Faab.Crops.Test;

[TestFixture]
public class ImplicitConstructionTests
{
    private interface IAnyInterface {}

    [Theory]
    public void ImplicitConstructionValueCropGivenStatusShouldHaveStatusButNoValueOrMessage(CropStatus status)
    {
        // Act
        Crop<IAnyInterface> crop = status;

        // Assert
        Assert.AreEqual(status, crop.Status);
        Assert.Null(crop.Value);
        Assert.Null(crop.Message);
    }
    
    [Theory]
    public void ImplicitConstructionValueCropGivenStatusAndMessageShouldHaveStatusAndMessageButNoValue(CropStatus status)
    {
        // Arrange
        const string message = "This is the status message";
        
        // Act
        Crop<IAnyInterface> crop = (status, message);

        // Assert
        Assert.AreEqual(status, crop.Status);
        Assert.AreEqual(message, crop.Message);
        Assert.Null(crop.Value);
    }

    [Theory]
    public void ImplicitConstructionValueCropGivenValueShouldHaveOkStatusAndValueButNoMessage([Random(3)] int value)
    {
        // Act
        Crop<int> crop = value;

        // Assert
        Assert.AreEqual(CropStatus.Ok, crop.Status);
        Assert.AreEqual(value, crop.Value);
        Assert.Null(crop.Message);
    }

    [Theory]
    public void ImplicitConstructionVoidCropGivenStatusShouldHaveStatusButNoMessage(CropStatus status)
    {
        // Act
        Crop crop = status;

        // Assert
        Assert.AreEqual(status, crop.Status);
        Assert.Null(crop.Message);
    }
    
    [Theory]
    public void ImplicitConstructionVoidCropGivenStatusAndMessageShouldHaveStatusAndMessage(CropStatus status)
    {
        // Arrange
        const string message = "This is the status message";

        // Act
        Crop crop = (status, message);

        // Assert
        Assert.AreEqual(status, crop.Status);
        Assert.AreEqual(message, crop.Message);
    }
}
