using System.Threading.Tasks;
using NUnit.Framework;

namespace Faab.Crops.Test;

[TestFixture]
public class MethodExampleTests
{
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
    public async Task AsyncNotFoundExample([Random(1)] int value)
    {
        // Arrange
        async Task<Crop<int>> Act(bool found)
        {
            await Task.CompletedTask;
            
            if (found) return value;

            return CropStatus.NotFound;
        }

        // Act
        var foundCrop = await Act(true);
        var notFoundCrop = await Act(false);

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
        Crop<int> Act(int input)
        {
            if (input < 10) return (CropStatus.BadRequest, message);

            return value;
        }

        // Act
        var good = Act(20);
        var bad = Act(5);

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
    
    
    [Test]
    public async Task AsyncVoidCropExample()
    {
        // Arrange
        async Task<Crop> Act(bool success)
        {
            await Task.CompletedTask;
            
            if (success) return new Crop();

            return CropStatus.Timeout;
        }

        // Act
        var good = await Act(true);
        var bad = await Act(false);

        // Assert
        Assert.True(good.IsOk());

        Assert.True(bad.IsNotOk());
        Assert.AreEqual(CropStatus.Timeout, bad.Status);
    }
}
