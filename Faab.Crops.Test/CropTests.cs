using NUnit.Framework;

namespace Faab.Crops.Test;

[TestFixture]
public class CropTests
{
    [Test]
    public void ImplicitConstructValueCropGivenValueShouldHaveOkStatusAndThatValue()
    {
        // Arrange
        const string value = "Hello, World!";

        // Act
        Crop<string> crop = value;

        // Assert
        Assert.AreEqual(CropStatus.Ok, crop.Status);
        Assert.AreEqual(value, crop.Value);
    }

    [Theory]
    public void ImplicitConstructStatusCropShouldHaveThatStatus(CropStatus status)
    {
        // Act
        Crop crop = status;

        // Assert
        Assert.AreEqual(status, crop.Status);
    }

    [Theory]
    public void ExplicitConstructCropGivenStatusAndValueShouldHaveThatStatusAndThatValue(
        CropStatus status,
        [Random(1)] int value)
    {
        // Act
        var crop = new Crop<int>(value, status);

        // Assert
        Assert.AreEqual(status, crop.Status);
        Assert.AreEqual(value, crop.Value);
    }
}
