using NUnit.Framework;

namespace Faab.Crops.Test;

[TestFixture]
public class MethodExampleTests
{
    private class Request
    {
        public int Value { get; set; }
    }

    [Test]
    public void NotFoundExample([Random(1)] int value)
    {
        // Arrange
        Crop<int> Act(bool found)
        {
            if (found) return value;

            return CropStatus.NotFound;
        }

        // Act
        var foundCrop = Act(true);
        var notFoundCrop = Act(false);

        // Assert
        Assert.True(foundCrop.IsOk());
        Assert.AreEqual(value, foundCrop.Value);

        Assert.True(notFoundCrop.IsNotOk());
    }

    [Test]
    public void BadRequestExample([Random(1)] int value)
    {
        const string message = "value is too small";

        // Arrange
        Crop<int> Act(Request request)
        {
            if (request.Value < 10) return (CropStatus.BadRequest, message);

            return value;
        }

        // Act
        var good = Act(new Request { Value = 20 });
        var bad = Act(new Request { Value = 5 });

        // Assert
        Assert.True(good.IsOk());
        Assert.AreEqual(value, good.Value);

        Assert.True(bad.IsNotOk());
        Assert.AreEqual(CropStatus.BadRequest, bad.Status);
        Assert.AreEqual(message, bad.Message);
    }
    
    [Test]
    public void VoidCropExample()
    {
        // Arrange
        Crop Act(bool success)
        {
            if (success) return new Crop();

            return CropStatus.Timeout;
        }

        // Act
        var good = Act(true);
        var bad = Act(false);

        // Assert
        Assert.True(good.IsOk());

        Assert.True(bad.IsNotOk());
        Assert.AreEqual(CropStatus.Timeout, bad.Status);
    }
}
