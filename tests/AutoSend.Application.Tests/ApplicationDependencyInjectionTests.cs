using FluentAssertions;

using Microsoft.Extensions.DependencyInjection;

namespace AutoSend.Application.Tests;

public class ApplicationDependencyInjectionTests
{
    [Fact]
    public void ShouldInjectServicesCorrectly()
    {
        var serviceCollection = new ServiceCollection();
        serviceCollection.AddApplicationServices();
        var serviceProvider = serviceCollection.BuildServiceProvider(validateScopes: true);
        
        serviceProvider.Should().NotBeNull();
    }
}