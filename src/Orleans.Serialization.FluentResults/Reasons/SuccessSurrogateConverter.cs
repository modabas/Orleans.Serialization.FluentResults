using FluentResults;

namespace Orleans.Serialization.FluentResults;

[RegisterConverter]
public sealed class SuccessSurrogateConverter : IConverter<Success, ReasonSurrogate>,
    IPopulator<Success, ReasonSurrogate>
{
    public Success ConvertFromSurrogate(in ReasonSurrogate surrogate)
    {
        return new Success(surrogate.Message)
                .WithMetadata(surrogate.Metadata);
    }

    public ReasonSurrogate ConvertToSurrogate(in Success value)
    {
        return new ReasonSurrogate
        {
            Message = value.Message,
            Metadata = value.Metadata,
            Reasons = null,
            Exception = null
        };
    }

    public void Populate(in ReasonSurrogate surrogate, Success value)
    {
        value.Metadata.Clear();
        value.WithMetadata(surrogate.Metadata);
    }
}