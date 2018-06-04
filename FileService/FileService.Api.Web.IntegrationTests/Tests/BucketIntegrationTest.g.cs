using FluentAssertions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using System;
using Xunit;

using FileServiceNS.Api.Contracts;
using FileServiceNS.Api.Services;
using FileServiceNS.Api.Client;

namespace FileServiceNS.Api.Web.IntegrationTests
{
	[Trait("Integration", " Bucket")]
	public class BucketTests
	{
		private TestServer server;
		private ApiClient client;

		public BucketTests()
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
    <Hash>12c9881ed8dbd59fdc2fe8dcff40a914</Hash>
</Codenesium>*/