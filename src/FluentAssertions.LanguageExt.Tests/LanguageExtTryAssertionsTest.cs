using System;
using LanguageExt;
using Xunit;

namespace FluentAssertions.LanguageExt.Tests;

public class LanguageExtTryAssertionsTest
{
    private static Try<string> SuccessResult() => () => "success";
    private static Try<string> FailResult() => () => throw new Exception();

    [Fact]
    public void ShouldBeSuccess_with_Success_returns_expected_result()
    {
        var action = () => SuccessResult().Should().BeSuccess();

        action.Should().NotThrow();
    }

    [Fact]
    public void ShouldBeSuccess_with_Exception_returns_expected_result()
    {
        var action = () => FailResult().Should().BeSuccess();

        action.Should().Throw<Exception>();
    }

    [Fact]
    public void ShouldBeFail_with_Success_returns_expected_result()
    {
        var action = () => SuccessResult().Should().BeFail();

        action.Should().Throw<Exception>();
    }

    [Fact]
    public void ShouldBeFail_with_Exception_returns_expected_result()
    {
        var action = () => FailResult().Should().BeFail();

        action.Should().NotThrow();
    }
}