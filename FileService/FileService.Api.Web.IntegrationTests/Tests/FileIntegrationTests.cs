using FileServiceNS.Api.Client;
using FileServiceNS.Api.Contracts;
using FileServiceNS.Api.DataAccess;
using FileServiceNS.Api.Services;
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

namespace FileServiceNS.Api.Web.IntegrationTests
{
	[Trait("Type", "Integration")]
	[Trait("Table", "File")]
	[Trait("Area", "Integration")]
	public partial class FileIntegrationTests
	{
		public FileIntegrationTests()
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

			client.SetBearerToken(JWTTestHelper.GenerateBearerToken());

			ApplicationDbContext context = testServer.Host.Services.GetService(typeof(ApplicationDbContext)) as ApplicationDbContext;

			var model = new ApiFileClientRequestModel();
			model.SetProperties(1, DateTime.Parse("1/1/1988 12:00:00 AM"), "B", DateTime.Parse("1/1/1988 12:00:00 AM"), "B", Guid.Parse("3842cac4-b9a0-8223-0dcc-509a6f75849b"), 2m, 1, "B", "B", "B");
			var model2 = new ApiFileClientRequestModel();
			model2.SetProperties(1, DateTime.Parse("1/1/1989 12:00:00 AM"), "C", DateTime.Parse("1/1/1989 12:00:00 AM"), "C", Guid.Parse("8d721ec8-4c9d-632f-6f06-7f89cc14862c"), 3m, 1, "C", "C", "C");
			var request = new List<ApiFileClientRequestModel>() {model, model2};
			CreateResponse<List<ApiFileClientResponseModel>> result = await client.FileBulkInsertAsync(request);

			result.Success.Should().BeTrue();
			result.Record.Should().NotBeNull();

			context.Set<File>().ToList()[1].BucketId.Should().Be(1);
			context.Set<File>().ToList()[1].DateCreated.Should().Be(DateTime.Parse("1/1/1988 12:00:00 AM"));
			context.Set<File>().ToList()[1].Description.Should().Be("B");
			context.Set<File>().ToList()[1].Expiration.Should().Be(DateTime.Parse("1/1/1988 12:00:00 AM"));
			context.Set<File>().ToList()[1].Extension.Should().Be("B");
			context.Set<File>().ToList()[1].ExternalId.Should().Be(Guid.Parse("3842cac4-b9a0-8223-0dcc-509a6f75849b"));
			context.Set<File>().ToList()[1].FileSizeInByte.Should().Be(2m);
			context.Set<File>().ToList()[1].FileTypeId.Should().Be(1);
			context.Set<File>().ToList()[1].Location.Should().Be("B");
			context.Set<File>().ToList()[1].PrivateKey.Should().Be("B");
			context.Set<File>().ToList()[1].PublicKey.Should().Be("B");

			context.Set<File>().ToList()[2].BucketId.Should().Be(1);
			context.Set<File>().ToList()[2].DateCreated.Should().Be(DateTime.Parse("1/1/1989 12:00:00 AM"));
			context.Set<File>().ToList()[2].Description.Should().Be("C");
			context.Set<File>().ToList()[2].Expiration.Should().Be(DateTime.Parse("1/1/1989 12:00:00 AM"));
			context.Set<File>().ToList()[2].Extension.Should().Be("C");
			context.Set<File>().ToList()[2].ExternalId.Should().Be(Guid.Parse("8d721ec8-4c9d-632f-6f06-7f89cc14862c"));
			context.Set<File>().ToList()[2].FileSizeInByte.Should().Be(3m);
			context.Set<File>().ToList()[2].FileTypeId.Should().Be(1);
			context.Set<File>().ToList()[2].Location.Should().Be("C");
			context.Set<File>().ToList()[2].PrivateKey.Should().Be("C");
			context.Set<File>().ToList()[2].PublicKey.Should().Be("C");
		}

		[Fact]
		public virtual async void TestCreate()
		{
			var builder = new WebHostBuilder()
			              .UseEnvironment("Production")
			              .UseStartup<TestStartup>();
			TestServer testServer = new TestServer(builder);
			var client = new ApiClient(testServer.CreateClient());
			client.SetBearerToken(JWTTestHelper.GenerateBearerToken());
			ApplicationDbContext context = testServer.Host.Services.GetService(typeof(ApplicationDbContext)) as ApplicationDbContext;

			var model = new ApiFileClientRequestModel();
			model.SetProperties(1, DateTime.Parse("1/1/1988 12:00:00 AM"), "B", DateTime.Parse("1/1/1988 12:00:00 AM"), "B", Guid.Parse("3842cac4-b9a0-8223-0dcc-509a6f75849b"), 2m, 1, "B", "B", "B");
			CreateResponse<ApiFileClientResponseModel> result = await client.FileCreateAsync(model);

			result.Success.Should().BeTrue();
			result.Record.Should().NotBeNull();
			context.Set<File>().ToList()[1].BucketId.Should().Be(1);
			context.Set<File>().ToList()[1].DateCreated.Should().Be(DateTime.Parse("1/1/1988 12:00:00 AM"));
			context.Set<File>().ToList()[1].Description.Should().Be("B");
			context.Set<File>().ToList()[1].Expiration.Should().Be(DateTime.Parse("1/1/1988 12:00:00 AM"));
			context.Set<File>().ToList()[1].Extension.Should().Be("B");
			context.Set<File>().ToList()[1].ExternalId.Should().Be(Guid.Parse("3842cac4-b9a0-8223-0dcc-509a6f75849b"));
			context.Set<File>().ToList()[1].FileSizeInByte.Should().Be(2m);
			context.Set<File>().ToList()[1].FileTypeId.Should().Be(1);
			context.Set<File>().ToList()[1].Location.Should().Be("B");
			context.Set<File>().ToList()[1].PrivateKey.Should().Be("B");
			context.Set<File>().ToList()[1].PublicKey.Should().Be("B");

			result.Record.BucketId.Should().Be(1);
			result.Record.DateCreated.Should().Be(DateTime.Parse("1/1/1988 12:00:00 AM"));
			result.Record.Description.Should().Be("B");
			result.Record.Expiration.Should().Be(DateTime.Parse("1/1/1988 12:00:00 AM"));
			result.Record.Extension.Should().Be("B");
			result.Record.ExternalId.Should().Be(Guid.Parse("3842cac4-b9a0-8223-0dcc-509a6f75849b"));
			result.Record.FileSizeInByte.Should().Be(2m);
			result.Record.FileTypeId.Should().Be(1);
			result.Record.Location.Should().Be("B");
			result.Record.PrivateKey.Should().Be("B");
			result.Record.PublicKey.Should().Be("B");
		}

		[Fact]
		public virtual async void TestUpdate()
		{
			var builder = new WebHostBuilder()
			              .UseEnvironment("Production")
			              .UseStartup<TestStartup>();
			TestServer testServer = new TestServer(builder);

			var client = new ApiClient(testServer.CreateClient());
			client.SetBearerToken(JWTTestHelper.GenerateBearerToken());
			var mapper = new ApiFileServerModelMapper();
			ApplicationDbContext context = testServer.Host.Services.GetService(typeof(ApplicationDbContext)) as ApplicationDbContext;
			IFileService service = testServer.Host.Services.GetService(typeof(IFileService)) as IFileService;
			ApiFileServerResponseModel model = await service.Get(1);

			ApiFileClientRequestModel request = mapper.MapServerResponseToClientRequest(model);
			request.SetProperties(1, DateTime.Parse("1/1/1988 12:00:00 AM"), "B", DateTime.Parse("1/1/1988 12:00:00 AM"), "B", Guid.Parse("3842cac4-b9a0-8223-0dcc-509a6f75849b"), 2m, 1, "B", "B", "B");

			UpdateResponse<ApiFileClientResponseModel> updateResponse = await client.FileUpdateAsync(model.Id, request);

			context.Entry(context.Set<File>().ToList()[0]).Reload();
			updateResponse.Record.Should().NotBeNull();
			updateResponse.Success.Should().BeTrue();
			updateResponse.Record.Id.Should().Be(1);
			context.Set<File>().ToList()[0].BucketId.Should().Be(1);
			context.Set<File>().ToList()[0].DateCreated.Should().Be(DateTime.Parse("1/1/1988 12:00:00 AM"));
			context.Set<File>().ToList()[0].Description.Should().Be("B");
			context.Set<File>().ToList()[0].Expiration.Should().Be(DateTime.Parse("1/1/1988 12:00:00 AM"));
			context.Set<File>().ToList()[0].Extension.Should().Be("B");
			context.Set<File>().ToList()[0].ExternalId.Should().Be(Guid.Parse("3842cac4-b9a0-8223-0dcc-509a6f75849b"));
			context.Set<File>().ToList()[0].FileSizeInByte.Should().Be(2m);
			context.Set<File>().ToList()[0].FileTypeId.Should().Be(1);
			context.Set<File>().ToList()[0].Location.Should().Be("B");
			context.Set<File>().ToList()[0].PrivateKey.Should().Be("B");
			context.Set<File>().ToList()[0].PublicKey.Should().Be("B");

			updateResponse.Record.Id.Should().Be(1);
			updateResponse.Record.BucketId.Should().Be(1);
			updateResponse.Record.DateCreated.Should().Be(DateTime.Parse("1/1/1988 12:00:00 AM"));
			updateResponse.Record.Description.Should().Be("B");
			updateResponse.Record.Expiration.Should().Be(DateTime.Parse("1/1/1988 12:00:00 AM"));
			updateResponse.Record.Extension.Should().Be("B");
			updateResponse.Record.ExternalId.Should().Be(Guid.Parse("3842cac4-b9a0-8223-0dcc-509a6f75849b"));
			updateResponse.Record.FileSizeInByte.Should().Be(2m);
			updateResponse.Record.FileTypeId.Should().Be(1);
			updateResponse.Record.Location.Should().Be("B");
			updateResponse.Record.PrivateKey.Should().Be("B");
			updateResponse.Record.PublicKey.Should().Be("B");
		}

		[Fact]
		public virtual async void TestDelete()
		{
			var builder = new WebHostBuilder()
			              .UseEnvironment("Production")
			              .UseStartup<TestStartup>();
			TestServer testServer = new TestServer(builder);
			var client = new ApiClient(testServer.CreateClient());
			client.SetBearerToken(JWTTestHelper.GenerateBearerToken());
			ApplicationDbContext context = testServer.Host.Services.GetService(typeof(ApplicationDbContext)) as ApplicationDbContext;

			IFileService service = testServer.Host.Services.GetService(typeof(IFileService)) as IFileService;
			var model = new ApiFileServerRequestModel();
			model.SetProperties(1, DateTime.Parse("1/1/1988 12:00:00 AM"), "B", DateTime.Parse("1/1/1988 12:00:00 AM"), "B", Guid.Parse("3842cac4-b9a0-8223-0dcc-509a6f75849b"), 2m, 1, "B", "B", "B");
			CreateResponse<ApiFileServerResponseModel> createdResponse = await service.Create(model);

			createdResponse.Success.Should().BeTrue();

			ActionResponse deleteResult = await client.FileDeleteAsync(2);

			deleteResult.Success.Should().BeTrue();
			ApiFileServerResponseModel verifyResponse = await service.Get(2);

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
			client.SetBearerToken(JWTTestHelper.GenerateBearerToken());
			ApplicationDbContext context = testServer.Host.Services.GetService(typeof(ApplicationDbContext)) as ApplicationDbContext;

			ApiFileClientResponseModel response = await client.FileGetAsync(1);

			response.Should().NotBeNull();
			response.BucketId.Should().Be(1);
			response.DateCreated.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.Description.Should().Be("A");
			response.Expiration.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.Extension.Should().Be("A");
			response.ExternalId.Should().Be(Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));
			response.FileSizeInByte.Should().Be(1m);
			response.FileTypeId.Should().Be(1);
			response.Id.Should().Be(1);
			response.Location.Should().Be("A");
			response.PrivateKey.Should().Be("A");
			response.PublicKey.Should().Be("A");
		}

		[Fact]
		public virtual async void TestGetNotFound()
		{
			var builder = new WebHostBuilder()
			              .UseEnvironment("Production")
			              .UseStartup<TestStartup>();
			TestServer testServer = new TestServer(builder);

			var client = new ApiClient(testServer.CreateClient());
			client.SetBearerToken(JWTTestHelper.GenerateBearerToken());
			ApiFileClientResponseModel response = await client.FileGetAsync(default(int));

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
			client.SetBearerToken(JWTTestHelper.GenerateBearerToken());
			List<ApiFileClientResponseModel> response = await client.FileAllAsync();

			response.Count.Should().BeGreaterThan(0);
			response[0].BucketId.Should().Be(1);
			response[0].DateCreated.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response[0].Description.Should().Be("A");
			response[0].Expiration.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response[0].Extension.Should().Be("A");
			response[0].ExternalId.Should().Be(Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));
			response[0].FileSizeInByte.Should().Be(1m);
			response[0].FileTypeId.Should().Be(1);
			response[0].Id.Should().Be(1);
			response[0].Location.Should().Be("A");
			response[0].PrivateKey.Should().Be("A");
			response[0].PublicKey.Should().Be("A");
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
				var result = await client.FileAllAsync(token);
			};

			testCancellation.Should().Throw<OperationCanceledException>();
		}
	}
}

/*<Codenesium>
    <Hash>1d86466ff35727531ef990a7efef0c26</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/