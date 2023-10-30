using FluentResults;

namespace Orleans.Serialization.FluentResults;

[GenerateSerializer]
public struct ResultSurrogate
{
    [Id(0)]
    public List<IReason> Reasons;
}

[GenerateSerializer]
public struct ResultSurrogate<TValue>
{
    [Id(0)]
    public List<IReason> Reasons;

    [Id(1)]
    public TValue? Value;
}