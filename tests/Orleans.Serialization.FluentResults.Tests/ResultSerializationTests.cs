using FluentResults;
using Orleans.TestingHost;

namespace Orleans.Serialization.FluentResults.Tests;

[Collection(ClusterCollection.Name)]
public class ResultSerializationTests
{
  private readonly TestCluster _cluster;

  public ResultSerializationTests(ClusterFixture fixture)
  {
    _cluster = fixture.Cluster;
  }

  [Fact]
  public async Task OkResultAsync()
  {
    // Arrange
    var testGrain = _cluster.GrainFactory.GetGrain<IResultSerializationGrain>(0);

    // Act
    var result = await testGrain.OkResult();

    // Assert
    Assert.NotNull(result);
    Assert.True(result.IsSuccess);
    Assert.False(result.IsFailed);
    Assert.Equal(3, result.Reasons.Count);
    Assert.Equal("Success 1", result.Reasons[0].Message);
    Assert.Equal("Success 2", result.Reasons[1].Message);
    Assert.IsType<SuccessChild>(result.Reasons[2]);
    Assert.Equal("Success Message", result.Reasons[2].Message);
    Assert.Equal("Success 3 Extra", ((SuccessChild)result.Reasons[2]).Extra);
  }

  [Fact]
  public async Task FailedResultAsync()
  {
    // Arrange
    var testGrain = _cluster.GrainFactory.GetGrain<IResultSerializationGrain>(0);

    // Act
    var result = await testGrain.FailedResult();

    // Assert
    Assert.NotNull(result);
    Assert.False(result.IsSuccess);
    Assert.True(result.IsFailed);
    Assert.Equal(6, result.Reasons.Count);
    Assert.Equal("Error 1", result.Reasons[0].Message);
    Assert.Equal("Error 2", result.Reasons[1].Message);
    Assert.IsType<ErrorChild>(result.Reasons[2]);
    Assert.Equal("Error Message", result.Reasons[2].Message);
    Assert.Equal("Error 3 Extra", ((ErrorChild)result.Reasons[2]).Extra);
    Assert.IsType<ExceptionalErrorChild>(result.Reasons[3]);
    Assert.Equal("Invalid.", result.Reasons[3].Message);
    Assert.Equal("Error 4 Extra", ((ExceptionalErrorChild)result.Reasons[3]).Extra);
    Assert.IsType<InvalidOperationException>(((ExceptionalErrorChild)result.Reasons[3]).Exception);
    Assert.IsType<ExceptionalError>(result.Reasons[4]);
    Assert.Equal("Error 5", result.Reasons[4].Message);
    Assert.IsType<ApplicationException>(((ExceptionalError)result.Reasons[4]).Exception);
    Assert.IsType<SuccessChild>(result.Reasons[5]);
    Assert.Equal("Success Message", result.Reasons[5].Message);
    Assert.Equal("Success 3 Extra", ((SuccessChild)result.Reasons[5]).Extra);
  }

}
