namespace Yahtzee.Tests;
using FluentAssertions;
using Yahtzee.Helpers;
public class ScoreCalculatorHelperTests
{
    [Theory]
    [InlineData(1, 2, 3, 4, 5, 6, 0)]
    [InlineData(1, 1, 3, 4, 5, 6, 1)]
    [InlineData(1, 1, 1, 4, 5, 6, 2)]
    [InlineData(2, 2, 2, 4, 5, 6, 4)]
    public void SumOfDiceWithGivenDigit_VariousScenarios_VerifyScore(int digit, int valueDice1, int valueDice2, int valueDice3, int valueDice4, int valueDice5, int expectedScore)
    {
        var allDice = new List<int> { valueDice1, valueDice2, valueDice3, valueDice4, valueDice5 };
        var score = ScoreCalculatorHelper.SumOfDiceWithGivenDigit(digit, allDice);
        score.Should().Be(expectedScore);
    }
}