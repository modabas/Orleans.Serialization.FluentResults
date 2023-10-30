using FluentResults;

namespace Orleans.Serialization.FluentResults;

[RegisterConverter]
public sealed class ErrorSurrogateConverter : IConverter<Error, ReasonSurrogate>,
    IPopulator<Error, ReasonSurrogate>
{
    public Error ConvertFromSurrogate(in ReasonSurrogate surrogate)
    {
        var error = new Error(surrogate.Message);

        error.CausedBy(surrogate.Reasons);
        error.WithMetadata(surrogate.Metadata);

        return error;
    }

    public ReasonSurrogate ConvertToSurrogate(in Error value)
    {
        return new ReasonSurrogate
        {
            Reasons = value.Reasons,
            Metadata = value.Metadata,
            Message = value.Message,
            Exception = null
        };
    }

    public void Populate(in ReasonSurrogate surrogate, Error value)
    {
        value.Reasons.Clear();
        value.CausedBy(surrogate.Reasons);
        value.Metadata.Clear();
        value.WithMetadata(surrogate.Metadata);
    }
}