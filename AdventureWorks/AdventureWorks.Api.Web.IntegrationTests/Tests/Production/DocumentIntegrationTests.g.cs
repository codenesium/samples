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
	[Trait("Table", "Document")]
	[Trait("Area", "Integration")]
	public partial class DocumentIntegrationTests
	{
		public DocumentIntegrationTests()
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
			ApplicationDbContext context = testServer.Host.Services.GetService(typeof(ApplicationDbContext)) as ApplicationDbContext;

			var model = new ApiDocumentClientRequestModel();
			model.SetProperties(2, BitConverter.GetBytes(2), 2, "B", "B", "B", true, DateTime.Parse("1/1/1988 12:00:00 AM"), 2, "B", 2, "B");
			var model2 = new ApiDocumentClientRequestModel();
			model2.SetProperties(3, BitConverter.GetBytes(3), 3, "C", "C", "C", true, DateTime.Parse("1/1/1989 12:00:00 AM"), 3, "C", 3, "C");
			var request = new List<ApiDocumentClientRequestModel>() {model, model2};
			CreateResponse<List<ApiDocumentClientResponseModel>> result = await client.DocumentBulkInsertAsync(request);

			result.Success.Should().BeTrue();
			result.Record.Should().NotBeNull();

			context.Set<Document>().ToList()[1].ChangeNumber.Should().Be(2);
			context.Set<Document>().ToList()[1].Document1.Should().BeEquivalentTo(BitConverter.GetBytes(2));
			context.Set<Document>().ToList()[1].DocumentLevel.Should().Be(2);
			context.Set<Document>().ToList()[1].DocumentSummary.Should().Be("B");
			context.Set<Document>().ToList()[1].FileExtension.Should().Be("B");
			context.Set<Document>().ToList()[1].FileName.Should().Be("B");
			context.Set<Document>().ToList()[1].FolderFlag.Should().Be(true);
			context.Set<Document>().ToList()[1].ModifiedDate.Should().Be(DateTime.Parse("1/1/1988 12:00:00 AM"));
			context.Set<Document>().ToList()[1].Owner.Should().Be(2);
			context.Set<Document>().ToList()[1].Revision.Should().Be("B");
			context.Set<Document>().ToList()[1].Status.Should().Be(2);
			context.Set<Document>().ToList()[1].Title.Should().Be("B");

			context.Set<Document>().ToList()[2].ChangeNumber.Should().Be(3);
			context.Set<Document>().ToList()[2].Document1.Should().BeEquivalentTo(BitConverter.GetBytes(3));
			context.Set<Document>().ToList()[2].DocumentLevel.Should().Be(3);
			context.Set<Document>().ToList()[2].DocumentSummary.Should().Be("C");
			context.Set<Document>().ToList()[2].FileExtension.Should().Be("C");
			context.Set<Document>().ToList()[2].FileName.Should().Be("C");
			context.Set<Document>().ToList()[2].FolderFlag.Should().Be(true);
			context.Set<Document>().ToList()[2].ModifiedDate.Should().Be(DateTime.Parse("1/1/1989 12:00:00 AM"));
			context.Set<Document>().ToList()[2].Owner.Should().Be(3);
			context.Set<Document>().ToList()[2].Revision.Should().Be("C");
			context.Set<Document>().ToList()[2].Status.Should().Be(3);
			context.Set<Document>().ToList()[2].Title.Should().Be("C");
		}

		[Fact]
		public virtual async void TestCreate()
		{
			var builder = new WebHostBuilder()
			              .UseEnvironment("Production")
			              .UseStartup<TestStartup>();
			TestServer testServer = new TestServer(builder);
			var client = new ApiClient(testServer.CreateClient());
			ApplicationDbContext context = testServer.Host.Services.GetService(typeof(ApplicationDbContext)) as ApplicationDbContext;

			var model = new ApiDocumentClientRequestModel();
			model.SetProperties(2, BitConverter.GetBytes(2), 2, "B", "B", "B", true, DateTime.Parse("1/1/1988 12:00:00 AM"), 2, "B", 2, "B");
			CreateResponse<ApiDocumentClientResponseModel> result = await client.DocumentCreateAsync(model);

			result.Success.Should().BeTrue();
			result.Record.Should().NotBeNull();
			context.Set<Document>().ToList()[1].ChangeNumber.Should().Be(2);
			context.Set<Document>().ToList()[1].Document1.Should().BeEquivalentTo(BitConverter.GetBytes(2));
			context.Set<Document>().ToList()[1].DocumentLevel.Should().Be(2);
			context.Set<Document>().ToList()[1].DocumentSummary.Should().Be("B");
			context.Set<Document>().ToList()[1].FileExtension.Should().Be("B");
			context.Set<Document>().ToList()[1].FileName.Should().Be("B");
			context.Set<Document>().ToList()[1].FolderFlag.Should().Be(true);
			context.Set<Document>().ToList()[1].ModifiedDate.Should().Be(DateTime.Parse("1/1/1988 12:00:00 AM"));
			context.Set<Document>().ToList()[1].Owner.Should().Be(2);
			context.Set<Document>().ToList()[1].Revision.Should().Be("B");
			context.Set<Document>().ToList()[1].Status.Should().Be(2);
			context.Set<Document>().ToList()[1].Title.Should().Be("B");

			result.Record.ChangeNumber.Should().Be(2);
			result.Record.Document1.Should().BeEquivalentTo(BitConverter.GetBytes(2));
			result.Record.DocumentLevel.Should().Be(2);
			result.Record.DocumentSummary.Should().Be("B");
			result.Record.FileExtension.Should().Be("B");
			result.Record.FileName.Should().Be("B");
			result.Record.FolderFlag.Should().Be(true);
			result.Record.ModifiedDate.Should().Be(DateTime.Parse("1/1/1988 12:00:00 AM"));
			result.Record.Owner.Should().Be(2);
			result.Record.Revision.Should().Be("B");
			result.Record.Status.Should().Be(2);
			result.Record.Title.Should().Be("B");
		}

		[Fact]
		public virtual async void TestUpdate()
		{
			var builder = new WebHostBuilder()
			              .UseEnvironment("Production")
			              .UseStartup<TestStartup>();
			TestServer testServer = new TestServer(builder);

			var client = new ApiClient(testServer.CreateClient());
			var mapper = new ApiDocumentServerModelMapper();
			ApplicationDbContext context = testServer.Host.Services.GetService(typeof(ApplicationDbContext)) as ApplicationDbContext;
			IDocumentService service = testServer.Host.Services.GetService(typeof(IDocumentService)) as IDocumentService;
			ApiDocumentServerResponseModel model = await service.Get(Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));

			ApiDocumentClientRequestModel request = mapper.MapServerResponseToClientRequest(model);
			request.SetProperties(2, BitConverter.GetBytes(2), 2, "B", "B", "B", true, DateTime.Parse("1/1/1988 12:00:00 AM"), 2, "B", 2, "B");

			UpdateResponse<ApiDocumentClientResponseModel> updateResponse = await client.DocumentUpdateAsync(model.Rowguid, request);

			context.Entry(context.Set<Document>().ToList()[0]).Reload();
			updateResponse.Record.Should().NotBeNull();
			updateResponse.Success.Should().BeTrue();
			updateResponse.Record.Rowguid.Should().Be(Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));
			context.Set<Document>().ToList()[0].ChangeNumber.Should().Be(2);
			context.Set<Document>().ToList()[0].Document1.Should().BeEquivalentTo(BitConverter.GetBytes(2));
			context.Set<Document>().ToList()[0].DocumentLevel.Should().Be(2);
			context.Set<Document>().ToList()[0].DocumentSummary.Should().Be("B");
			context.Set<Document>().ToList()[0].FileExtension.Should().Be("B");
			context.Set<Document>().ToList()[0].FileName.Should().Be("B");
			context.Set<Document>().ToList()[0].FolderFlag.Should().Be(true);
			context.Set<Document>().ToList()[0].ModifiedDate.Should().Be(DateTime.Parse("1/1/1988 12:00:00 AM"));
			context.Set<Document>().ToList()[0].Owner.Should().Be(2);
			context.Set<Document>().ToList()[0].Revision.Should().Be("B");
			context.Set<Document>().ToList()[0].Status.Should().Be(2);
			context.Set<Document>().ToList()[0].Title.Should().Be("B");

			updateResponse.Record.Rowguid.Should().Be(Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));
			updateResponse.Record.ChangeNumber.Should().Be(2);
			updateResponse.Record.Document1.Should().BeEquivalentTo(BitConverter.GetBytes(2));
			updateResponse.Record.DocumentLevel.Should().Be(2);
			updateResponse.Record.DocumentSummary.Should().Be("B");
			updateResponse.Record.FileExtension.Should().Be("B");
			updateResponse.Record.FileName.Should().Be("B");
			updateResponse.Record.FolderFlag.Should().Be(true);
			updateResponse.Record.ModifiedDate.Should().Be(DateTime.Parse("1/1/1988 12:00:00 AM"));
			updateResponse.Record.Owner.Should().Be(2);
			updateResponse.Record.Revision.Should().Be("B");
			updateResponse.Record.Status.Should().Be(2);
			updateResponse.Record.Title.Should().Be("B");
		}

		[Fact]
		public virtual async void TestDelete()
		{
			var builder = new WebHostBuilder()
			              .UseEnvironment("Production")
			              .UseStartup<TestStartup>();
			TestServer testServer = new TestServer(builder);
			var client = new ApiClient(testServer.CreateClient());
			ApplicationDbContext context = testServer.Host.Services.GetService(typeof(ApplicationDbContext)) as ApplicationDbContext;

			IDocumentService service = testServer.Host.Services.GetService(typeof(IDocumentService)) as IDocumentService;
			var model = new ApiDocumentServerRequestModel();
			model.SetProperties(2, BitConverter.GetBytes(2), 2, "B", "B", "B", true, DateTime.Parse("1/1/1988 12:00:00 AM"), 2, "B", 2, "B");
			CreateResponse<ApiDocumentServerResponseModel> createdResponse = await service.Create(model);

			createdResponse.Success.Should().BeTrue();

			ActionResponse deleteResult = await client.DocumentDeleteAsync(Guid.Parse("3842cac4-b9a0-8223-0dcc-509a6f75849b"));

			deleteResult.Success.Should().BeTrue();
			ApiDocumentServerResponseModel verifyResponse = await service.Get(Guid.Parse("3842cac4-b9a0-8223-0dcc-509a6f75849b"));

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
			ApplicationDbContext context = testServer.Host.Services.GetService(typeof(ApplicationDbContext)) as ApplicationDbContext;

			ApiDocumentClientResponseModel response = await client.DocumentGetAsync(Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));

			response.Should().NotBeNull();
			response.ChangeNumber.Should().Be(1);
			response.Document1.Should().BeEquivalentTo(BitConverter.GetBytes(1));
			response.DocumentLevel.Should().Be(1);
			response.DocumentSummary.Should().Be("A");
			response.FileExtension.Should().Be("A");
			response.FileName.Should().Be("A");
			response.FolderFlag.Should().Be(true);
			response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.Owner.Should().Be(1);
			response.Revision.Should().Be("A");
			response.Rowguid.Should().Be(Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));
			response.Status.Should().Be(1);
			response.Title.Should().Be("A");
		}

		[Fact]
		public virtual async void TestGetNotFound()
		{
			var builder = new WebHostBuilder()
			              .UseEnvironment("Production")
			              .UseStartup<TestStartup>();
			TestServer testServer = new TestServer(builder);

			var client = new ApiClient(testServer.CreateClient());
			ApiDocumentClientResponseModel response = await client.DocumentGetAsync(default(Guid));

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

			List<ApiDocumentClientResponseModel> response = await client.DocumentAllAsync();

			response.Count.Should().BeGreaterThan(0);
			response[0].ChangeNumber.Should().Be(1);
			response[0].Document1.Should().BeEquivalentTo(BitConverter.GetBytes(1));
			response[0].DocumentLevel.Should().Be(1);
			response[0].DocumentSummary.Should().Be("A");
			response[0].FileExtension.Should().Be("A");
			response[0].FileName.Should().Be("A");
			response[0].FolderFlag.Should().Be(true);
			response[0].ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response[0].Owner.Should().Be(1);
			response[0].Revision.Should().Be("A");
			response[0].Rowguid.Should().Be(Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));
			response[0].Status.Should().Be(1);
			response[0].Title.Should().Be("A");
		}

		[Fact]
		public virtual async void TestByRowguidFound()
		{
			var builder = new WebHostBuilder()
			              .UseEnvironment("Production")
			              .UseStartup<TestStartup>();
			TestServer testServer = new TestServer(builder);

			var client = new ApiClient(testServer.CreateClient());
			ApiDocumentClientResponseModel response = await client.ByDocumentByRowguid(Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));

			response.Should().NotBeNull();

			response.ChangeNumber.Should().Be(1);
			response.Document1.Should().BeEquivalentTo(BitConverter.GetBytes(1));
			response.DocumentLevel.Should().Be(1);
			response.DocumentSummary.Should().Be("A");
			response.FileExtension.Should().Be("A");
			response.FileName.Should().Be("A");
			response.FolderFlag.Should().Be(true);
			response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.Owner.Should().Be(1);
			response.Revision.Should().Be("A");
			response.Rowguid.Should().Be(Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));
			response.Status.Should().Be(1);
			response.Title.Should().Be("A");
		}

		[Fact]
		public virtual async void TestByRowguidNotFound()
		{
			var builder = new WebHostBuilder()
			              .UseEnvironment("Production")
			              .UseStartup<TestStartup>();
			TestServer testServer = new TestServer(builder);

			var client = new ApiClient(testServer.CreateClient());
			ApiDocumentClientResponseModel response = await client.ByDocumentByRowguid(default(Guid));

			response.Should().BeNull();
		}

		[Fact]
		public virtual async void TestByFileNameRevisionFound()
		{
			var builder = new WebHostBuilder()
			              .UseEnvironment("Production")
			              .UseStartup<TestStartup>();
			TestServer testServer = new TestServer(builder);

			var client = new ApiClient(testServer.CreateClient());
			List<ApiDocumentClientResponseModel> response = await client.ByDocumentByFileNameRevision("A", "A");

			response.Should().NotBeEmpty();
			response[0].ChangeNumber.Should().Be(1);
			response[0].Document1.Should().BeEquivalentTo(BitConverter.GetBytes(1));
			response[0].DocumentLevel.Should().Be(1);
			response[0].DocumentSummary.Should().Be("A");
			response[0].FileExtension.Should().Be("A");
			response[0].FileName.Should().Be("A");
			response[0].FolderFlag.Should().Be(true);
			response[0].ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response[0].Owner.Should().Be(1);
			response[0].Revision.Should().Be("A");
			response[0].Rowguid.Should().Be(Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));
			response[0].Status.Should().Be(1);
			response[0].Title.Should().Be("A");
		}

		[Fact]
		public virtual async void TestByFileNameRevisionNotFound()
		{
			var builder = new WebHostBuilder()
			              .UseEnvironment("Production")
			              .UseStartup<TestStartup>();
			TestServer testServer = new TestServer(builder);

			var client = new ApiClient(testServer.CreateClient());
			List<ApiDocumentClientResponseModel> response = await client.ByDocumentByFileNameRevision("test_value", "test_value");

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
				var result = await client.DocumentAllAsync(token);
			};

			testCancellation.Should().Throw<OperationCanceledException>();
		}
	}
}

/*<Codenesium>
    <Hash>ad5365cf72fb913c7e5d0c10e607548b</Hash>
</Codenesium>*/