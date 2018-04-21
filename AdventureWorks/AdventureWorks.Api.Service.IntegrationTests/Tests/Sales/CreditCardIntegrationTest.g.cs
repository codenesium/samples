using FluentAssertions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using System;
using Xunit;

using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.BusinessObjects;
using AdventureWorksNS.Api.Client;

namespace AdventureWorksNS.Api.Service.IntegrationTests
{
	[Trait("Integration", " CreditCard")]
	public class CreditCardTests
	{
		private TestServer server;
		private ApiClient client;

		public CreditCardTests()
		{}

		[Fact]
		public async void TestCreate()
		{
			// setup
			this.server = new TestServer(new WebHostBuilder()
			                             .UseStartup<TestStartup>());

			this.client = new ApiClient(this.server.CreateClient());
		}

		[Fact]
		public async void TestUpdate()
		{
			// setup
			this.server = new TestServer(new WebHostBuilder()
			                             .UseStartup<TestStartup>());

			this.client = new ApiClient(this.server.CreateClient());
		}

		[Fact]
		public async void TestDelete()
		{
			// setup
			this.server = new TestServer(new WebHostBuilder()
			                             .UseStartup<TestStartup>());

			this.client = new ApiClient(this.server.CreateClient());
		}

		[Fact]
		public async void TestGetById()
		{
			// setup
			this.server = new TestServer(new WebHostBuilder()
			                             .UseStartup<TestStartup>());

			this.client = new ApiClient(this.server.CreateClient());
		}

		[Fact]
		public async void TestSearch()
		{
			// setup
			this.server = new TestServer(new WebHostBuilder()
			                             .UseStartup<TestStartup>());

			this.client = new ApiClient(this.server.CreateClient());
		}

		[Fact]
		public async void TestBulkInsert()
		{
			// setup
			this.server = new TestServer(new WebHostBuilder()
			                             .UseStartup<TestStartup>());

			this.client = new ApiClient(this.server.CreateClient());
		}
	}
}

/*<Codenesium>
    <Hash>b0be40a8b5b3db55ff24eb6f60cafacd</Hash>
</Codenesium>*/