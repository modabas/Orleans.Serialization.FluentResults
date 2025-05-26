namespace Orleans.Serialization.FluentResults.Tests;

[CollectionDefinition(Name)]
public sealed class ClusterCollection : ICollectionFixture<ClusterFixture>
{
  public const string Name = nameof(ClusterCollection);
}
