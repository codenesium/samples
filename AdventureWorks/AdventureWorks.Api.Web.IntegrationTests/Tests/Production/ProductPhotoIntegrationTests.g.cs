using AdventureWorksNS.Api.Client;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using AdventureWorksNS.Api.Services;
using FluentAssertions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace AdventureWorksNS.Api.Web.IntegrationTests
{
	[Trait("Type", "Integration")]
	[Trait("Table", "ProductPhoto")]
	[Trait("Area", "Integration")]
	public partial class ProductPhotoIntegrationTests
	{
		public ProductPhotoIntegrationTests()
		{
		}

		[Fact]
		public virtual async void TestBulkInsert()
		{
			var builder = new WebHostBuilder()
			              .UseEnvironment("Production")
			              .UseStartup<TestStartup>();
			TestServer testServer = new TestServer(builder);
			var client = new ApiClient(testServer.CreateClient());

			JWTHelper jwtHelper = new JWTHelper();
			client.SetBearerToken(jwtHelper.GenerateBearerToken(
									  "defaultJWTPassword",
									  "https://www.codenesium.com",
									  "https://www.codenesium.com",
									  "test@test.com",
									  "Passw0rd$"));

			ApplicationDbContext context = testServer.Host.Services.GetService(typeof(ApplicationDbContext)) as ApplicationDbContext;

			var model = new ApiProductPhotoClientRequestModel();
			model.SetProperties(BitConverter.GetBytes(2), "B", DateTime.Parse("1/1/1988 12:00:00 AM"), BitConverter.GetBytes(2), "B");
			var model2 = new ApiProductPhotoClientRequestModel();
			model2.SetProperties(BitConverter.GetBytes(3), "C", DateTime.Parse("1/1/1989 12:00:00 AM"), BitConverter.GetBytes(3), "C");
			var request = new List<ApiProductPhotoClientRequestModel>() {model, model2};
			CreateResponse<List<ApiProductPhotoClientResponseModel>> result = await client.ProductPhotoBulkInsertAsync(request);

			result.Success.Should().BeTrue();
			result.Record.Should().NotBeNull();

			context.Set<ProductPhoto>().ToList()[1].LargePhoto.Should().BeEquivalentTo(BitConverter.GetBytes(2));
			context.Set<ProductPhoto>().ToList()[1].LargePhotoFileName.Should().Be("B");
			context.Set<ProductPhoto>().ToList()[1].ModifiedDate.Should().Be(DateTime.Parse("1/1/1988 12:00:00 AM"));
			context.Set<ProductPhoto>().ToList()[1].ThumbNailPhoto.Should().BeEquivalentTo(BitConverter.GetBytes(2));
			context.Set<ProductPhoto>().ToList()[1].ThumbnailPhotoFileName.Should().Be("B");

			context.Set<ProductPhoto>().ToList()[2].LargePhoto.Should().BeEquivalentTo(BitConverter.GetBytes(3));
			context.Set<ProductPhoto>().ToList()[2].LargePhotoFileName.Should().Be("C");
			context.Set<ProductPhoto>().ToList()[2].ModifiedDate.Should().Be(DateTime.Parse("1/1/1989 12:00:00 AM"));
			context.Set<ProductPhoto>().ToList()[2].ThumbNailPhoto.Should().BeEquivalentTo(BitConverter.GetBytes(3));
			context.Set<ProductPhoto>().ToList()[2].ThumbnailPhotoFileName.Should().Be("C");
		}

		[Fact]
		public virtual async void TestCreate()
		{
			var builder = new WebHostBuilder()
			              .UseEnvironment("Production")
			              .UseStartup<TestStartup>();
			TestServer testServer = new TestServer(builder);
			var client = new ApiClient(testServer.CreateClient());
			JWTHelper jwtHelper = new JWTHelper();
			client.SetBearerToken(jwtHelper.GenerateBearerToken(
									  "defaultJWTPassword",
									  "https://www.codenesium.com",
									  "https://www.codenesium.com",
									  "test@test.com",
									  "Passw0rd$"));
			ApplicationDbContext context = testServer.Host.Services.GetService(typeof(ApplicationDbContext)) as ApplicationDbContext;

			var model = new ApiProductPhotoClientRequestModel();
			model.SetProperties(BitConverter.GetBytes(2), "B", DateTime.Parse("1/1/1988 12:00:00 AM"), BitConverter.GetBytes(2), "B");
			CreateResponse<ApiProductPhotoClientResponseModel> result = await client.ProductPhotoCreateAsync(model);

			result.Success.Should().BeTrue();
			result.Record.Should().NotBeNull();
			context.Set<ProductPhoto>().ToList()[1].LargePhoto.Should().BeEquivalentTo(BitConverter.GetBytes(2));
			context.Set<ProductPhoto>().ToList()[1].LargePhotoFileName.Should().Be("B");
			context.Set<ProductPhoto>().ToList()[1].ModifiedDate.Should().Be(DateTime.Parse("1/1/1988 12:00:00 AM"));
			context.Set<ProductPhoto>().ToList()[1].ThumbNailPhoto.Should().BeEquivalentTo(BitConverter.GetBytes(2));
			context.Set<ProductPhoto>().ToList()[1].ThumbnailPhotoFileName.Should().Be("B");

			result.Record.LargePhoto.Should().BeEquivalentTo(BitConverter.GetBytes(2));
			result.Record.LargePhotoFileName.Should().Be("B");
			result.Record.ModifiedDate.Should().Be(DateTime.Parse("1/1/1988 12:00:00 AM"));
			result.Record.ThumbNailPhoto.Should().BeEquivalentTo(BitConverter.GetBytes(2));
			result.Record.ThumbnailPhotoFileName.Should().Be("B");
		}

		[Fact]
		public virtual async void TestUpdate()
		{
			var builder = new WebHostBuilder()
			              .UseEnvironment("Production")
			              .UseStartup<TestStartup>();
			TestServer testServer = new TestServer(builder);

			var client = new ApiClient(testServer.CreateClient());
			JWTHelper jwtHelper = new JWTHelper();
			client.SetBearerToken(jwtHelper.GenerateBearerToken(
									  "defaultJWTPassword",
									  "https://www.codenesium.com",
									  "https://www.codenesium.com",
									  "test@test.com",
									  "Passw0rd$"));
			var mapper = new ApiProductPhotoServerModelMapper();
			ApplicationDbContext context = testServer.Host.Services.GetService(typeof(ApplicationDbContext)) as ApplicationDbContext;
			IProductPhotoService service = testServer.Host.Services.GetService(typeof(IProductPhotoService)) as IProductPhotoService;
			ApiProductPhotoServerResponseModel model = await service.Get(1);

			ApiProductPhotoClientRequestModel request = mapper.MapServerResponseToClientRequest(model);
			request.SetProperties(BitConverter.GetBytes(2), "B", DateTime.Parse("1/1/1988 12:00:00 AM"), BitConverter.GetBytes(2), "B");

			UpdateResponse<ApiProductPhotoClientResponseModel> updateResponse = await client.ProductPhotoUpdateAsync(model.ProductPhotoID, request);

			context.Entry(context.Set<ProductPhoto>().ToList()[0]).Reload();
			updateResponse.Record.Should().NotBeNull();
			updateResponse.Success.Should().BeTrue();
			updateResponse.Record.ProductPhotoID.Should().Be(1);
			context.Set<ProductPhoto>().ToList()[0].LargePhoto.Should().BeEquivalentTo(BitConverter.GetBytes(2));
			context.Set<ProductPhoto>().ToList()[0].LargePhotoFileName.Should().Be("B");
			context.Set<ProductPhoto>().ToList()[0].ModifiedDate.Should().Be(DateTime.Parse("1/1/1988 12:00:00 AM"));
			context.Set<ProductPhoto>().ToList()[0].ThumbNailPhoto.Should().BeEquivalentTo(BitConverter.GetBytes(2));
			context.Set<ProductPhoto>().ToList()[0].ThumbnailPhotoFileName.Should().Be("B");

			updateResponse.Record.ProductPhotoID.Should().Be(1);
			updateResponse.Record.LargePhoto.Should().BeEquivalentTo(BitConverter.GetBytes(2));
			updateResponse.Record.LargePhotoFileName.Should().Be("B");
			updateResponse.Record.ModifiedDate.Should().Be(DateTime.Parse("1/1/1988 12:00:00 AM"));
			updateResponse.Record.ThumbNailPhoto.Should().BeEquivalentTo(BitConverter.GetBytes(2));
			updateResponse.Record.ThumbnailPhotoFileName.Should().Be("B");
		}

		[Fact]
		public virtual async void TestDelete()
		{
			var builder = new WebHostBuilder()
			              .UseEnvironment("Production")
			              .UseStartup<TestStartup>();
			TestServer testServer = new TestServer(builder);
			var client = new ApiClient(testServer.CreateClient());
			JWTHelper jwtHelper = new JWTHelper();
			client.SetBearerToken(jwtHelper.GenerateBearerToken(
									  "defaultJWTPassword",
									  "https://www.codenesium.com",
									  "https://www.codenesium.com",
									  "test@test.com",
									  "Passw0rd$"));
			ApplicationDbContext context = testServer.Host.Services.GetService(typeof(ApplicationDbContext)) as ApplicationDbContext;

			IProductPhotoService service = testServer.Host.Services.GetService(typeof(IProductPhotoService)) as IProductPhotoService;
			var model = new ApiProductPhotoServerRequestModel();
			model.SetProperties(BitConverter.GetBytes(2), "B", DateTime.Parse("1/1/1988 12:00:00 AM"), BitConverter.GetBytes(2), "B");
			CreateResponse<ApiProductPhotoServerResponseModel> createdResponse = await service.Create(model);

			createdResponse.Success.Should().BeTrue();

			ActionResponse deleteResult = await client.ProductPhotoDeleteAsync(2);

			deleteResult.Success.Should().BeTrue();
			ApiProductPhotoServerResponseModel verifyResponse = await service.Get(2);

			verifyResponse.Should().BeNull();
		}

		[Fact]
		public virtual async void TestGetFound()
		{
			var builder = new WebHostBuilder()
			              .UseEnvironment("Production")
			              .UseStartup<TestStartup>();
			TestServer testServer = new TestServer(builder);

			var client = new ApiClient(testServer.CreateClient());
			JWTHelper jwtHelper = new JWTHelper();
			client.SetBearerToken(jwtHelper.GenerateBearerToken(
									  "defaultJWTPassword",
									  "https://www.codenesium.com",
									  "https://www.codenesium.com",
									  "test@test.com",
									  "Passw0rd$"));
			ApplicationDbContext context = testServer.Host.Services.GetService(typeof(ApplicationDbContext)) as ApplicationDbContext;

			ApiProductPhotoClientResponseModel response = await client.ProductPhotoGetAsync(1);

			response.Should().NotBeNull();
			response.LargePhoto.Should().BeEquivalentTo(BitConverter.GetBytes(1));
			response.LargePhotoFileName.Should().Be("A");
			response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.ProductPhotoID.Should().Be(1);
			response.ThumbNailPhoto.Should().BeEquivalentTo(BitConverter.GetBytes(1));
			response.ThumbnailPhotoFileName.Should().Be("A");
		}

		[Fact]
		public virtual async void TestGetNotFound()
		{
			var builder = new WebHostBuilder()
			              .UseEnvironment("Production")
			              .UseStartup<TestStartup>();
			TestServer testServer = new TestServer(builder);

			var client = new ApiClient(testServer.CreateClient());
			JWTHelper jwtHelper = new JWTHelper();
			client.SetBearerToken(jwtHelper.GenerateBearerToken(
									  "defaultJWTPassword",
									  "https://www.codenesium.com",
									  "https://www.codenesium.com",
									  "test@test.com",
									  "Passw0rd$"));
			ApiProductPhotoClientResponseModel response = await client.ProductPhotoGetAsync(default(int));

			response.Should().BeNull();
		}

		[Fact]
		public virtual async void TestAll()
		{
			var builder = new WebHostBuilder()
			              .UseEnvironment("Production")
			              .UseStartup<TestStartup>();
			TestServer testServer = new TestServer(builder);

			var client = new ApiClient(testServer.CreateClient());
			JWTHelper jwtHelper = new JWTHelper();
			client.SetBearerToken(jwtHelper.GenerateBearerToken(
									  "defaultJWTPassword",
									  "https://www.codenesium.com",
									  "https://www.codenesium.com",
									  "test@test.com",
									  "Passw0rd$"));
			List<ApiProductPhotoClientResponseModel> response = await client.ProductPhotoAllAsync();

			response.Count.Should().BeGreaterThan(0);
			response[0].LargePhoto.Should().BeEquivalentTo(BitConverter.GetBytes(1));
			response[0].LargePhotoFileName.Should().Be("A");
			response[0].ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response[0].ProductPhotoID.Should().Be(1);
			response[0].ThumbNailPhoto.Should().BeEquivalentTo(BitConverter.GetBytes(1));
			response[0].ThumbnailPhotoFileName.Should().Be("A");
		}

		[Fact]
		public virtual async void TestForeignKeyProductProductPhotoesByProductPhotoIDFound()
		{
			var builder = new WebHostBuilder()
			              .UseEnvironment("Production")
			              .UseStartup<TestStartup>();
			TestServer testServer = new TestServer(builder);

			var client = new ApiClient(testServer.CreateClient());
			JWTHelper jwtHelper = new JWTHelper();
			client.SetBearerToken(jwtHelper.GenerateBearerToken(
									  "defaultJWTPassword",
									  "https://www.codenesium.com",
									  "https://www.codenesium.com",
									  "test@test.com",
									  "Passw0rd$"));
			List<ApiProductProductPhotoClientResponseModel> response = await client.ProductProductPhotoesByProductPhotoID(1);

			response.Should().NotBeEmpty();
		}

		[Fact]
		public virtual async void TestForeignKeyProductProductPhotoesByProductPhotoIDNotFound()
		{
			var builder = new WebHostBuilder()
			              .UseEnvironment("Production")
			              .UseStartup<TestStartup>();
			TestServer testServer = new TestServer(builder);

			var client = new ApiClient(testServer.CreateClient());
			JWTHelper jwtHelper = new JWTHelper();
			client.SetBearerToken(jwtHelper.GenerateBearerToken(
									  "defaultJWTPassword",
									  "https://www.codenesium.com",
									  "https://www.codenesium.com",
									  "test@test.com",
									  "Passw0rd$"));
			List<ApiProductProductPhotoClientResponseModel> response = await client.ProductProductPhotoesByProductPhotoID(default(int));

			response.Should().BeEmpty();
		}

		[Fact]
		public virtual void TestClientCancellationToken()
		{
			Func<Task> testCancellation = async () =>
			{
				var builder = new WebHostBuilder()
				              .UseEnvironment("Production")
				              .UseStartup<TestStartup>();
				TestServer testServer = new TestServer(builder);

				var client = new ApiClient(testServer.BaseAddress.OriginalString);
				CancellationTokenSource tokenSource = new CancellationTokenSource();
				CancellationToken token = tokenSource.Token;
				tokenSource.Cancel();
				var result = await client.ProductPhotoAllAsync(token);
			};

			testCancellation.Should().Throw<OperationCanceledException>();
		}
	}
}

/*<Codenesium>
    <Hash>06663cf1ca5946c4e5d1794d084e7f58</Hash>
</Codenesium>*/