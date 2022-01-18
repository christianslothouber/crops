using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace Faab.Crops.Test;

[TestFixture]
public class OkNotOkTests
{
    private IEnumerable<CropStatus> _validStatuses = null!;
    private IEnumerable<CropStatus> _invalidStatuses = null!;

    [SetUp]
    public void SetUp()
    {
        _validStatuses = new List<CropStatus>
        {
            CropStatus.Ok,
            CropStatus.Created,
            CropStatus.Accepted
        };

        _invalidStatuses = Enum.GetValues<CropStatus>()
                               .Where(s => !_validStatuses.Contains(s))
                               .ToList();
    }

    [Theory]
    public void CropGivenCertainStatusShouldBeOk(CropStatus status)
    {
        // Arrange
        Assume.That(_validStatuses.Contains(status));

        var crop = new Crop(status);

        // Act
        var ok = crop.IsOk();
        var notOk = crop.IsNotOk();

        // Assert
        Assert.True(ok);
        Assert.False(notOk);
    }

    [Theory]
    public void CropGivenCertainStatusShouldBeNotOk(CropStatus status)
    {
        // Arrange
        Assume.That(_invalidStatuses.Contains(status));

        var crop = new Crop(status);

        // Act
        var ok = crop.IsOk();
        var notOk = crop.IsNotOk();

        // Assert
        Assert.False(ok);
        Assert.True(notOk);
    }
}
