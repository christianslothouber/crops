using NUnit.Framework;

namespace Faab.Crops.Test;

[TestFixture]
public class UseCaseExampleTests
{
    [Test]
    public void ContrivedUseCase()
    {
        // Arrange
        static Crop<int> GetFirstGenerationPokemonStrength(int id)
        {
            return id switch
            {
                <= 0 => CropStatus.BadRequest,
                > 151 => CropStatus.NotFound,
                6 => 100,
                _ => 0
            };
        }

        // Act
        var missingno = GetFirstGenerationPokemonStrength(000);
        var absol = GetFirstGenerationPokemonStrength(359);
        var charizard = GetFirstGenerationPokemonStrength(006);
        var pikachu = GetFirstGenerationPokemonStrength(025);

        // Assert
        Assert.AreEqual(CropStatus.BadRequest, missingno.Status);
        Assert.AreEqual(0, missingno.Value);

        Assert.AreEqual(CropStatus.NotFound, absol.Status);
        Assert.AreEqual(0, absol.Value);

        Assert.AreEqual(CropStatus.Ok, charizard.Status);
        Assert.AreEqual(100, charizard.Value);

        Assert.AreEqual(CropStatus.Ok, pikachu.Status);
        Assert.AreEqual(0, pikachu.Value);
    }
}
