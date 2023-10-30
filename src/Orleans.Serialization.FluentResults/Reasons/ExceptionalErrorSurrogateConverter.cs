using FluentResults;

namespace Orleans.Serialization.FluentResults;

[RegisterConverter]
public sealed class ExceptionalErrorSurrogateConverter : IConverter<ExceptionalError, ReasonSurrogate>,
    IPopulator<ExceptionalError, ReasonSurrogate>
{
    public ExceptionalError ConvertFromSurrogate(in ReasonSurrogate surrogate)
    {
        var error = new ExceptionalError(surrogate.Message, surrogate.Exception);

        error.CausedBy(surrogate.Reasons);
        error.WithMetadata(surrogate.Metadata);

        return error;
    }

    public ReasonSurrogate ConvertToSurrogate(in ExceptionalError value)
    {
        return new ReasonSurrogate
        {
            Reasons = value.Reasons,
            Metadata = value.Metadata,
            Message = value.Message,
            Exception = value.Exception
        };
    }

    public void Populate(in ReasonSurrogate surrogate, ExceptionalError value)
    {
        value.Reasons.Clear();
        value.CausedBy(surrogate.Reasons);
        value.Metadata.Clear();
        value.WithMetadata(surrogate.Metadata);
    }
}