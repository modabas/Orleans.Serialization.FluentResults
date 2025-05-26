using FluentResults;
using Orleans.TestingHost;

namespace Orleans.Serialization.FluentResults.Tests;


[Collection(ClusterCollection.Name)]
public class ResultOfTSerializationTests
{
  private readonly TestCluster _cluster;

  public ResultOfTSerializationTests(ClusterFixture fixture)
  {
    _cluster = fixture.Cluster;
  }

  [Fact]
  public async Task OkResultWithValueStructAsync()
  {
    // Arrange
    var testGrain = _cluster.GrainFactory.GetGrain<IResultOfTSerializationGrain>(0);

    // Act
    var result = await testGrain.OkResultWithValueStruct();

    // Assert
    Assert.NotNull(result);
    Assert.True(result.IsSuccess);
    Assert.False(result.IsFailed);
    Assert.Equal(42, result.Value.Number);
    Assert.Equal("Meaning of life.", result.Value.String);
    Assert.Empty(result.Reasons);
  }

  [Fact]
  public async Task OkResultWithValueClassAsync()
  {
    // Arrange
    var testGrain = _cluster.GrainFactory.GetGrain<IResultOfTSerializationGrain>(0);

    // Act
    var result = await testGrain.OkResultWithValueClass();

    // Assert
    Assert.NotNull(result);
    Assert.True(result.IsSuccess);
    Assert.False(result.IsFailed);
    Assert.NotNull(result.Value);
    Assert.Equal(42, result.Value.Number);
    Assert.Equal("Meaning of life.", result.Value.String);
    Assert.Empty(result.Reasons);
  }

  [Fact]
  public async Task OkResultWithValueRecordAsync()
  {
    // Arrange
    var testGrain = _cluster.GrainFactory.GetGrain<IResultOfTSerializationGrain>(0);

    // Act
    var result = await testGrain.OkResultWithValueRecord();

    // Assert
    Assert.NotNull(result);
    Assert.True(result.IsSuccess);
    Assert.False(result.IsFailed);
    Assert.NotNull(result.Value);
    Assert.Equal(42, result.Value.Number);
    Assert.Equal("Meaning of life.", result.Value.String);
    Assert.Empty(result.Reasons);
  }

  [Fact]
  public async Task OkResultWithValueStructAndReasonsAsync()
  {
    // Arrange
    var testGrain = _cluster.GrainFactory.GetGrain<IResultOfTSerializationGrain>(0);

    // Act
    var result = await testGrain.OkResultWithValueStructAndReasons();

    // Assert
    Assert.NotNull(result);
    Assert.True(result.IsSuccess);
    Assert.False(result.IsFailed);
    Assert.Equal(42, result.Value.Number);
    Assert.Equal("Meaning of life.", result.Value.String);
    Assert.Equal(3, result.Reasons.Count);
    Assert.Equal("Success 1", result.Reasons[0].Message);
    Assert.Equal("Success 2", result.Reasons[1].Message);
    Assert.IsType<SuccessChild>(result.Reasons[2]);
    Assert.Equal("Success Message", result.Reasons[2].Message);
    Assert.Equal("Success 3 Extra", ((SuccessChild)result.Reasons[2]).Extra);
  }

  [Fact]
  public async Task OkResultWithValueClassAndReasonsAsync()
  {
    // Arrange
    var testGrain = _cluster.GrainFactory.GetGrain<IResultOfTSerializationGrain>(0);

    // Act
    var result = await testGrain.OkResultWithValueClassAndReasons();

    // Assert
    Assert.NotNull(result);
    Assert.True(result.IsSuccess);
    Assert.False(result.IsFailed);
    Assert.NotNull(result.Value);
    Assert.Equal(42, result.Value.Number);
    Assert.Equal("Meaning of life.", result.Value.String);
    Assert.Equal(3, result.Reasons.Count);
    Assert.Equal("Success 1", result.Reasons[0].Message);
    Assert.Equal("Success 2", result.Reasons[1].Message);
    Assert.IsType<SuccessChild>(result.Reasons[2]);
    Assert.Equal("Success Message", result.Reasons[2].Message);
    Assert.Equal("Success 3 Extra", ((SuccessChild)result.Reasons[2]).Extra);
  }

  [Fact]
  public async Task OkResultWithValueRecordAndReasonsAsync()
  {
    // Arrange
    var testGrain = _cluster.GrainFactory.GetGrain<IResultOfTSerializationGrain>(0);

    // Act
    var result = await testGrain.OkResultWithValueRecordAndReasons();

    // Assert
    Assert.NotNull(result);
    Assert.True(result.IsSuccess);
    Assert.False(result.IsFailed);
    Assert.NotNull(result.Value);
    Assert.Equal(42, result.Value.Number);
    Assert.Equal("Meaning of life.", result.Value.String);
    Assert.Equal(3, result.Reasons.Count);
    Assert.Equal("Success 1", result.Reasons[0].Message);
    Assert.Equal("Success 2", result.Reasons[1].Message);
    Assert.IsType<SuccessChild>(result.Reasons[2]);
    Assert.Equal("Success Message", result.Reasons[2].Message);
    Assert.Equal("Success 3 Extra", ((SuccessChild)result.Reasons[2]).Extra);
  }

  [Fact]
  public async Task FailedResultWithValueStructAsync()
  {
    // Arrange
    var testGrain = _cluster.GrainFactory.GetGrain<IResultOfTSerializationGrain>(0);

    // Act
    var result = await testGrain.FailedResultWithValueStruct();

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

  [Fact]
  public async Task FailedResultWithValueClassAsync()
  {
    // Arrange
    var testGrain = _cluster.GrainFactory.GetGrain<IResultOfTSerializationGrain>(0);

    // Act
    var result = await testGrain.FailedResultWithValueClass();

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

  [Fact]
  public async Task FailedResultWithValueRecordAsync()
  {
    // Arrange
    var testGrain = _cluster.GrainFactory.GetGrain<IResultOfTSerializationGrain>(0);

    // Act
    var result = await testGrain.FailedResultWithValueRecord();

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

  [Fact]
  public async Task FailedResultWithValueInValueStructAsync()
  {
    // Arrange
    var testGrain = _cluster.GrainFactory.GetGrain<IResultOfTSerializationGrain>(0);

    // Act
    var result = await testGrain.FailedResultWithValueInValueStruct();

    // Assert
    Assert.NotNull(result);
    Assert.False(result.IsSuccess);
    Assert.True(result.IsFailed);
    Assert.Equal(42, result.ValueOrDefault.Number);
    Assert.Equal("Meaning of life.", result.ValueOrDefault.String);
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

  [Fact]
  public async Task FailedResultWithValueInValueClassAsync()
  {
    // Arrange
    var testGrain = _cluster.GrainFactory.GetGrain<IResultOfTSerializationGrain>(0);

    // Act
    var result = await testGrain.FailedResultWithValueInValueClass();

    // Assert
    Assert.NotNull(result);
    Assert.False(result.IsSuccess);
    Assert.True(result.IsFailed);
    Assert.NotNull(result.ValueOrDefault);
    Assert.Equal(42, result.ValueOrDefault.Number);
    Assert.Equal("Meaning of life.", result.ValueOrDefault.String);
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

  [Fact]
  public async Task FailedResultWithValueInValueRecordAsync()
  {
    // Arrange
    var testGrain = _cluster.GrainFactory.GetGrain<IResultOfTSerializationGrain>(0);

    // Act
    var result = await testGrain.FailedResultWithValueInValueRecord();

    // Assert
    Assert.NotNull(result);
    Assert.False(result.IsSuccess);
    Assert.True(result.IsFailed);
    Assert.NotNull(result.ValueOrDefault);
    Assert.Equal(42, result.ValueOrDefault.Number);
    Assert.Equal("Meaning of life.", result.ValueOrDefault.String);
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
