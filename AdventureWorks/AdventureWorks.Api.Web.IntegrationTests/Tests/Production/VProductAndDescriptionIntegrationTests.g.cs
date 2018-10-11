using AdventureWorksNS.Api.Client;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.Services;
using FluentAssertions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace AdventureWorksNS.Api.Web.IntegrationTests
{
	[Trait("Type", "Integration")]
	[Trait("Table", "VProductAndDescription")]
	[Trait("Area", "Integration")]
	public class VProductAndDescriptionIntegrationTests : IClassFixture<TestWebApplicationFactory>
	{
		public VProductAndDescriptionIntegrationTests(TestWebApplicationFactory fixture)
		{
			this.Client = new ApiClient(fixture.CreateClient());
		}

		public ApiClient Client { get; }

		[Fact]
		public async void TestGet()
		{
			ApiVProductAndDescriptionResponseModel response = await this.Client.VProductAndDescriptionGetAsync("A");

			response.Should().NotBeNull();
		}

		[Fact]
		public async void TestAll()
		{
			List<ApiVProductAndDescriptionResponseModel> response = await this.Client.VProductAndDescriptionAllAsync();

			response.Count.Should().BeGreaterThan(0);
		}
	}
}

/*<Codenesium>
    <Hash>9144a1d04f2c8ce7ee6acc8466b58bfc</Hash>
</Codenesium>*/