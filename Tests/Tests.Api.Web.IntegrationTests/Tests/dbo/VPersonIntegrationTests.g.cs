using FluentAssertions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TestsNS.Api.Client;
using TestsNS.Api.Contracts;
using TestsNS.Api.Services;
using Xunit;

namespace TestsNS.Api.Web.IntegrationTests
{
	[Trait("Type", "Integration")]
	[Trait("Table", "VPerson")]
	[Trait("Area", "Integration")]
	public class VPersonIntegrationTests : IClassFixture<TestWebApplicationFactory>
	{
		public VPersonIntegrationTests(TestWebApplicationFactory fixture)
		{
			this.Client = new ApiClient(fixture.CreateClient());
		}

		public ApiClient Client { get; }

		[Fact]
		public async void TestGet()
		{
			ApiVPersonResponseModel response = await this.Client.VPersonGetAsync(1);

			response.Should().NotBeNull();
		}

		[Fact]
		public async void TestAll()
		{
			List<ApiVPersonResponseModel> response = await this.Client.VPersonAllAsync();

			response.Count.Should().BeGreaterThan(0);
		}
	}
}

/*<Codenesium>
    <Hash>f948a092ad67b2ba6f096bde6b53f6ec</Hash>
</Codenesium>*/