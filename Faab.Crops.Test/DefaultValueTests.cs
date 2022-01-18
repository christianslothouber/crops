using NUnit.Framework;

namespace Faab.Crops.Test;

[TestFixture]
public class DefaultValueTests
{
    private interface IAnyInterface {}

    [Theory]
    public void CropWithReferenceTypeGivenNoValueShouldHaveNullAsValue(CropStatus status)
    {
        // Act
        var crop = new Crop<IAnyInterface>(status);

        // Assert
        Assert.Null(crop.Value);
    }

    [Theory]
    public void CropWithValueTypeGivenNoValueShouldHaveDefaultAsValue(CropStatus status)
    {
        // Act
        var crop = new Crop<int>(status);

        // Assert
        Assert.AreEqual(default(int), crop.Value);
    }
}
