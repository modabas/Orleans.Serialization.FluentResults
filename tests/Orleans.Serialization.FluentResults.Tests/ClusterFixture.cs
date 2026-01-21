using Orleans.TestingHost;

namespace Orleans.Serialization.FluentResults.Tests;

public sealed class ClusterFixture : IDisposable
{
  public TestCluster Cluster { get; } = new TestClusterBuilder().Build();

  public ClusterFixture() => Cluster.Deploy();

  void IDisposable.Dispose() => Cluster.StopAllSilos();
}
