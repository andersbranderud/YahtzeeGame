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

    [Theory]
    [InlineData(ScoreType.Ones, 2, 3, 4, 5, 6, 0)]
    // Number of Twos. 1 Two -> worth 2
    [InlineData(ScoreType.Twos, 2, 3, 4, 5, 6, 2)]
    [InlineData(ScoreType.Twos, 2, 2, 2, 5, 6, 6)]
    public void Calculate_VariousScenarios_VerifyScore(ScoreType scoreType, int valueDice1, int valueDice2, int valueDice3, int valueDice4, int valueDice5, int expectedScore)
    {
        var diceList = new List<int> { valueDice1, valueDice2, valueDice3, valueDice4, valueDice5 };
        var dice = new Dice();
        dice.AllDice = diceList;
        var score = ScoreCalculatorHelper.Calculate(dice, scoreType);
        score.Should().Be(expectedScore);
    }

    // 3 and 4 of a kind For 3 of a kind you must have at least 3 of the same die faces. You score the total of all the dice. For 4 of a ki
    [Theory]
    [InlineData(3, 2, 3, 4, 5, 6, 0)]
    [InlineData(3, 3, 3, 4, 3, 6, 19)]
    public void SumOfDigitOfAKind_VariousScenarios_VerifyScore(int digitOfAKind, int valueDice1, int valueDice2, int valueDice3, int valueDice4, int valueDice5, int expectedScore)
    {
        var diceList = new List<int> { valueDice1, valueDice2, valueDice3, valueDice4, valueDice5 };
        var dice = new Dice();
        dice.AllDice = diceList;
        var score = ScoreCalculatorHelper.SumOfDigitOfAKind(digitOfAKind, dice.AllDice);
        score.Should().Be(expectedScore);
    }
}