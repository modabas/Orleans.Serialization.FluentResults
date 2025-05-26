using Orleans.TestingHost;

namespace Orleans.Serialization.FluentResults.Tests;

[Collection(ClusterCollection.Name)]
public class InheritanceSerializationTests
{
  private readonly TestCluster _cluster;

  public InheritanceSerializationTests(ClusterFixture fixture)
  {
    _cluster = fixture.Cluster;
  }

  [Fact]
  public async Task ErrorInheritanceAsync()
  {
    // Arrange
    var testGrain = _cluster.GrainFactory.GetGrain<IInheritanceSerializationGrain>(0);

    // Act
    var error = await testGrain.GetErrorChild("Error Extra");

    // Assert
    Assert.Equal("Error Message", error.Message);
    Assert.NotEqual("Error message", error.Message);
    Assert.Equal("Error Extra", error.Extra);
    Assert.NotEqual("Error extra", error.Extra);
  }

  [Fact]
  public async Task SuccessInheritanceAsync()
  {
    // Arrange
    var testGrain = _cluster.GrainFactory.GetGrain<IInheritanceSerializationGrain>(0);

    // Act
    var error = await testGrain.GetSuccessChild("Success Extra");

    // Assert
    Assert.Equal("Success Message", error.Message);
    Assert.NotEqual("Success message", error.Message);
    Assert.Equal("Success Extra", error.Extra);
    Assert.NotEqual("Success extra", error.Extra);
  }

  [Fact]
  public async Task ExceptionalErrorInheritanceAsync()
  {
    // Arrange
    var testGrain = _cluster.GrainFactory.GetGrain<IInheritanceSerializationGrain>(0);

    // Act
    var error = await testGrain.GetExceptionalErrorChild("Error Extra");

    // Assert
    Assert.Equal("Invalid.", error.Message);
    Assert.NotEqual("Error message", error.Message);
    Assert.Equal("Invalid.", error.Exception.Message);
    Assert.True(error.Exception is InvalidOperationException);
    Assert.Equal("Error Extra", error.Extra);
    Assert.NotEqual("Error extra", error.Extra);
  }
}
