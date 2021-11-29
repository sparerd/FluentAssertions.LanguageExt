﻿using FluentAssertions.Execution;
using FluentAssertions.Primitives;
using LanguageExt;

namespace FluentAssertions.LanguageExt;

public class LanguageExtValidationAssertions<TFail, TSuccess> : ReferenceTypeAssertions<Validation<TFail, TSuccess>, LanguageExtValidationAssertions<TFail, TSuccess>>
{
    public LanguageExtValidationAssertions(Validation<TFail, TSuccess> instance) : base(instance)
    {
    }

    protected override string Identifier => "validation";

    public AndConstraint<LanguageExtValidationAssertions<TFail, TSuccess>> BeFail(string because = "", params object[] becauseArgs)
    {
        Execute.Assertion
            .BecauseOf(because, becauseArgs)
            .WithExpectation("Expected {context:validation} to be Fail{reason}, ")
            .Given(() => Subject)
            .ForCondition(subject => subject.IsFail)
            .FailWith("but found to be {0}.", Subject);

        return new AndConstraint<LanguageExtValidationAssertions<TFail, TSuccess>>(this);
    }

    public AndConstraint<LanguageExtValidationAssertions<TFail, TSuccess>> BeSuccess(string because = "", params object[] becauseArgs)
    {
        Execute.Assertion
            .BecauseOf(because, becauseArgs)
            .WithExpectation("Expected {context:validation} to be Success{reason}, ")
            .Given(() => Subject)
            .ForCondition(subject => subject.IsSuccess)
            .FailWith("but found to be {0}.", Subject);

        return new AndConstraint<LanguageExtValidationAssertions<TFail, TSuccess>>(this);
    }
}