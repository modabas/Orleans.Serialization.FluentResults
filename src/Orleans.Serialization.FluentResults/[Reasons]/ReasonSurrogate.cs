using FluentResults;

namespace Orleans.Serialization.FluentResults;

[GenerateSerializer]
public struct ReasonSurrogate
{
  [Id(0)]
  public string Message;

  [Id(1)]
  public Dictionary<string, object> Metadata;

  [Id(2)]
  public List<IError>? Reasons;

  [Id(3)]
  public Exception? Exception;
}