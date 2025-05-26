namespace Orleans.Serialization.FluentResults.Tests;

[GenerateSerializer]
[Alias("ModResults.Orleans.Tests.ValueRecord")]
internal record ValueRecord(int Number, string String);

