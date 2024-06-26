using FluentAssertions;

using Microsoft.Extensions.DependencyInjection;

namespace AutoSend.Infrastructure.Tests;

public class InfrastructureDependencyInjectionTests
{
    [Fact]
    public void ShouldInjectServicesCorrectly()
    {
        var serviceCollection = new ServiceCollection();
        serviceCollection.AddInfrastructureServices();
        var serviceProvider = serviceCollection.BuildServiceProvider(validateScopes: true);
        
        serviceProvider.Should().NotBeNull();
    }
}