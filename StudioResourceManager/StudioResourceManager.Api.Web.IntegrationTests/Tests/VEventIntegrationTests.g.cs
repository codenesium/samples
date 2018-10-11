using FluentAssertions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using StudioResourceManagerNS.Api.Client;
using StudioResourceManagerNS.Api.Contracts;
using StudioResourceManagerNS.Api.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace StudioResourceManagerNS.Api.Web.IntegrationTests
{
	[Trait("Type", "Integration")]
	[Trait("Table", "VEvent")]
	[Trait("Area", "Integration")]
	public class VEventIntegrationTests : IClassFixture<TestWebApplicationFactory>
	{
		public VEventIntegrationTests(TestWebApplicationFactory fixture)
		{
			this.Client = new ApiClient(fixture.CreateClient());
		}

		public ApiClient Client { get; }

		[Fact]
		public async void TestGet()
		{
			ApiVEventResponseModel response = await this.Client.VEventGetAsync(1);

			response.Should().NotBeNull();
		}

		[Fact]
		public async void TestAll()
		{
			List<ApiVEventResponseModel> response = await this.Client.VEventAllAsync();

			response.Count.Should().BeGreaterThan(0);
		}
	}
}

/*<Codenesium>
    <Hash>bde2e65e54d9030a281ea061e1fca2a7</Hash>
</Codenesium>*/