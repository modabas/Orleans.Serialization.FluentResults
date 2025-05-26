namespace Orleans.Serialization.FluentResults.Tests;

[GenerateSerializer]
[Alias("ModResults.Orleans.Tests.ValueClass")]
internal class ValueClass
{
  [Id(0)]
  public int Number { get; set; }
  [Id(1)]
  public string String { get; set; } = string.Empty;
}
