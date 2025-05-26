using FluentResults;

namespace Orleans.Serialization.FluentResults.Tests;

[GenerateSerializer]
internal class ErrorChild : Error
{
  [Id(0)]
  public string Extra { get; set; } = string.Empty;

  public ErrorChild()
    : base("Error Message")
  {
  }
}
