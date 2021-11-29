using LanguageExt;
using Xunit;
using Xunit.Sdk;

namespace FluentAssertions.LanguageExt.Tests;

public class LanguageExtOptionAsyncBoolAssertionsTest
{
    private static OptionAsync<bool> SomeTrueResult() => Prelude.SomeAsync(true);
    private static OptionAsync<bool> SomeFalseResult() => Prelude.SomeAsync(false);
    private static OptionAsync<bool> NoneResult() => OptionAsync<bool>.None;

    [Fact]
    public void ShouldBeSomeTrue_with_expected_Some_returns_expected_result()
    {
        var action = () => SomeTrueResult().Should().BeSomeTrue();

        action.Should().NotThrow();
    }

    [Fact]
    public void ShouldBeSomeTrue_with_unexpected_Some_returns_expected_result()
    {
        var action = () => SomeFalseResult().Should().BeSomeTrue();

        action.Should().Throw<XunitException>();
    }

    [Fact]
    public void ShouldBeSomeTrue_with_None_returns_expected_result()
    {
        var action = () => NoneResult().Should().BeNone();

        action.Should().NotThrow();
    }

    [Fact]
    public void ShouldBeSomeFalse_with_expected_Some_returns_expected_result()
    {
        var action = () => SomeFalseResult().Should().BeSomeFalse();

        action.Should().NotThrow();
    }

    [Fact]
    public void ShouldBeSomeFalse_with_unexpected_Some_returns_expected_result()
    {
        var action = () => SomeTrueResult().Should().BeSomeFalse();

        action.Should().Throw<XunitException>();
    }

    [Fact]
    public void ShouldBeSomeFalse_with_None_returns_expected_result()
    {
        var action = () => NoneResult().Should().BeSomeFalse();

        action.Should().Throw<XunitException>();
    }
}