using FluentResults;

namespace Orleans.Serialization.FluentResults.Tests;

[GenerateSerializer]
internal class ExceptionalErrorChild : ExceptionalError
{
  [Id(0)]
  public string Extra { get; set; } = string.Empty;

  public ExceptionalErrorChild() : base(new InvalidOperationException("Invalid."))
  {
  }
}
