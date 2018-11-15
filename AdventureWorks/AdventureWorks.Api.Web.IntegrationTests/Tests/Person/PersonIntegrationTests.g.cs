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
	[Trait("Table", "Person")]
	[Trait("Area", "Integration")]
	public partial class PersonIntegrationTests
	{
		public PersonIntegrationTests()
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

			var model = new ApiPersonClientRequestModel();
			model.SetProperties("B", "B", 2, "B", "B", "B", DateTime.Parse("1/1/1988 12:00:00 AM"), true, "B", Guid.Parse("3842cac4-b9a0-8223-0dcc-509a6f75849b"), "B", "B");
			var model2 = new ApiPersonClientRequestModel();
			model2.SetProperties("C", "C", 3, "C", "C", "C", DateTime.Parse("1/1/1989 12:00:00 AM"), true, "C", Guid.Parse("8d721ec8-4c9d-632f-6f06-7f89cc14862c"), "C", "C");
			var request = new List<ApiPersonClientRequestModel>() {model, model2};
			CreateResponse<List<ApiPersonClientResponseModel>> result = await client.PersonBulkInsertAsync(request);

			result.Success.Should().BeTrue();
			result.Record.Should().NotBeNull();

			context.Set<Person>().ToList()[1].AdditionalContactInfo.Should().Be("B");
			context.Set<Person>().ToList()[1].Demographic.Should().Be("B");
			context.Set<Person>().ToList()[1].EmailPromotion.Should().Be(2);
			context.Set<Person>().ToList()[1].FirstName.Should().Be("B");
			context.Set<Person>().ToList()[1].LastName.Should().Be("B");
			context.Set<Person>().ToList()[1].MiddleName.Should().Be("B");
			context.Set<Person>().ToList()[1].ModifiedDate.Should().Be(DateTime.Parse("1/1/1988 12:00:00 AM"));
			context.Set<Person>().ToList()[1].NameStyle.Should().Be(true);
			context.Set<Person>().ToList()[1].PersonType.Should().Be("B");
			context.Set<Person>().ToList()[1].Rowguid.Should().Be(Guid.Parse("3842cac4-b9a0-8223-0dcc-509a6f75849b"));
			context.Set<Person>().ToList()[1].Suffix.Should().Be("B");
			context.Set<Person>().ToList()[1].Title.Should().Be("B");

			context.Set<Person>().ToList()[2].AdditionalContactInfo.Should().Be("C");
			context.Set<Person>().ToList()[2].Demographic.Should().Be("C");
			context.Set<Person>().ToList()[2].EmailPromotion.Should().Be(3);
			context.Set<Person>().ToList()[2].FirstName.Should().Be("C");
			context.Set<Person>().ToList()[2].LastName.Should().Be("C");
			context.Set<Person>().ToList()[2].MiddleName.Should().Be("C");
			context.Set<Person>().ToList()[2].ModifiedDate.Should().Be(DateTime.Parse("1/1/1989 12:00:00 AM"));
			context.Set<Person>().ToList()[2].NameStyle.Should().Be(true);
			context.Set<Person>().ToList()[2].PersonType.Should().Be("C");
			context.Set<Person>().ToList()[2].Rowguid.Should().Be(Guid.Parse("8d721ec8-4c9d-632f-6f06-7f89cc14862c"));
			context.Set<Person>().ToList()[2].Suffix.Should().Be("C");
			context.Set<Person>().ToList()[2].Title.Should().Be("C");
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

			var model = new ApiPersonClientRequestModel();
			model.SetProperties("B", "B", 2, "B", "B", "B", DateTime.Parse("1/1/1988 12:00:00 AM"), true, "B", Guid.Parse("3842cac4-b9a0-8223-0dcc-509a6f75849b"), "B", "B");
			CreateResponse<ApiPersonClientResponseModel> result = await client.PersonCreateAsync(model);

			result.Success.Should().BeTrue();
			result.Record.Should().NotBeNull();
			context.Set<Person>().ToList()[1].AdditionalContactInfo.Should().Be("B");
			context.Set<Person>().ToList()[1].Demographic.Should().Be("B");
			context.Set<Person>().ToList()[1].EmailPromotion.Should().Be(2);
			context.Set<Person>().ToList()[1].FirstName.Should().Be("B");
			context.Set<Person>().ToList()[1].LastName.Should().Be("B");
			context.Set<Person>().ToList()[1].MiddleName.Should().Be("B");
			context.Set<Person>().ToList()[1].ModifiedDate.Should().Be(DateTime.Parse("1/1/1988 12:00:00 AM"));
			context.Set<Person>().ToList()[1].NameStyle.Should().Be(true);
			context.Set<Person>().ToList()[1].PersonType.Should().Be("B");
			context.Set<Person>().ToList()[1].Rowguid.Should().Be(Guid.Parse("3842cac4-b9a0-8223-0dcc-509a6f75849b"));
			context.Set<Person>().ToList()[1].Suffix.Should().Be("B");
			context.Set<Person>().ToList()[1].Title.Should().Be("B");

			result.Record.AdditionalContactInfo.Should().Be("B");
			result.Record.Demographic.Should().Be("B");
			result.Record.EmailPromotion.Should().Be(2);
			result.Record.FirstName.Should().Be("B");
			result.Record.LastName.Should().Be("B");
			result.Record.MiddleName.Should().Be("B");
			result.Record.ModifiedDate.Should().Be(DateTime.Parse("1/1/1988 12:00:00 AM"));
			result.Record.NameStyle.Should().Be(true);
			result.Record.PersonType.Should().Be("B");
			result.Record.Rowguid.Should().Be(Guid.Parse("3842cac4-b9a0-8223-0dcc-509a6f75849b"));
			result.Record.Suffix.Should().Be("B");
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
			var mapper = new ApiPersonServerModelMapper();
			ApplicationDbContext context = testServer.Host.Services.GetService(typeof(ApplicationDbContext)) as ApplicationDbContext;
			IPersonService service = testServer.Host.Services.GetService(typeof(IPersonService)) as IPersonService;
			ApiPersonServerResponseModel model = await service.Get(1);

			ApiPersonClientRequestModel request = mapper.MapServerResponseToClientRequest(model);
			request.SetProperties("B", "B", 2, "B", "B", "B", DateTime.Parse("1/1/1988 12:00:00 AM"), true, "B", Guid.Parse("3842cac4-b9a0-8223-0dcc-509a6f75849b"), "B", "B");

			UpdateResponse<ApiPersonClientResponseModel> updateResponse = await client.PersonUpdateAsync(model.BusinessEntityID, request);

			context.Entry(context.Set<Person>().ToList()[0]).Reload();
			updateResponse.Record.Should().NotBeNull();
			updateResponse.Success.Should().BeTrue();
			updateResponse.Record.BusinessEntityID.Should().Be(1);
			context.Set<Person>().ToList()[0].AdditionalContactInfo.Should().Be("B");
			context.Set<Person>().ToList()[0].Demographic.Should().Be("B");
			context.Set<Person>().ToList()[0].EmailPromotion.Should().Be(2);
			context.Set<Person>().ToList()[0].FirstName.Should().Be("B");
			context.Set<Person>().ToList()[0].LastName.Should().Be("B");
			context.Set<Person>().ToList()[0].MiddleName.Should().Be("B");
			context.Set<Person>().ToList()[0].ModifiedDate.Should().Be(DateTime.Parse("1/1/1988 12:00:00 AM"));
			context.Set<Person>().ToList()[0].NameStyle.Should().Be(true);
			context.Set<Person>().ToList()[0].PersonType.Should().Be("B");
			context.Set<Person>().ToList()[0].Rowguid.Should().Be(Guid.Parse("3842cac4-b9a0-8223-0dcc-509a6f75849b"));
			context.Set<Person>().ToList()[0].Suffix.Should().Be("B");
			context.Set<Person>().ToList()[0].Title.Should().Be("B");

			updateResponse.Record.BusinessEntityID.Should().Be(1);
			updateResponse.Record.AdditionalContactInfo.Should().Be("B");
			updateResponse.Record.Demographic.Should().Be("B");
			updateResponse.Record.EmailPromotion.Should().Be(2);
			updateResponse.Record.FirstName.Should().Be("B");
			updateResponse.Record.LastName.Should().Be("B");
			updateResponse.Record.MiddleName.Should().Be("B");
			updateResponse.Record.ModifiedDate.Should().Be(DateTime.Parse("1/1/1988 12:00:00 AM"));
			updateResponse.Record.NameStyle.Should().Be(true);
			updateResponse.Record.PersonType.Should().Be("B");
			updateResponse.Record.Rowguid.Should().Be(Guid.Parse("3842cac4-b9a0-8223-0dcc-509a6f75849b"));
			updateResponse.Record.Suffix.Should().Be("B");
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

			IPersonService service = testServer.Host.Services.GetService(typeof(IPersonService)) as IPersonService;
			var model = new ApiPersonServerRequestModel();
			model.SetProperties("B", "B", 2, "B", "B", "B", DateTime.Parse("1/1/1988 12:00:00 AM"), true, "B", Guid.Parse("3842cac4-b9a0-8223-0dcc-509a6f75849b"), "B", "B");
			CreateResponse<ApiPersonServerResponseModel> createdResponse = await service.Create(model);

			createdResponse.Success.Should().BeTrue();

			ActionResponse deleteResult = await client.PersonDeleteAsync(2);

			deleteResult.Success.Should().BeTrue();
			ApiPersonServerResponseModel verifyResponse = await service.Get(2);

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

			ApiPersonClientResponseModel response = await client.PersonGetAsync(1);

			response.Should().NotBeNull();
			response.AdditionalContactInfo.Should().Be("A");
			response.BusinessEntityID.Should().Be(1);
			response.Demographic.Should().Be("A");
			response.EmailPromotion.Should().Be(1);
			response.FirstName.Should().Be("A");
			response.LastName.Should().Be("A");
			response.MiddleName.Should().Be("A");
			response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.NameStyle.Should().Be(true);
			response.PersonType.Should().Be("A");
			response.Rowguid.Should().Be(Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));
			response.Suffix.Should().Be("A");
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
			ApiPersonClientResponseModel response = await client.PersonGetAsync(default(int));

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

			List<ApiPersonClientResponseModel> response = await client.PersonAllAsync();

			response.Count.Should().BeGreaterThan(0);
			response[0].AdditionalContactInfo.Should().Be("A");
			response[0].BusinessEntityID.Should().Be(1);
			response[0].Demographic.Should().Be("A");
			response[0].EmailPromotion.Should().Be(1);
			response[0].FirstName.Should().Be("A");
			response[0].LastName.Should().Be("A");
			response[0].MiddleName.Should().Be("A");
			response[0].ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response[0].NameStyle.Should().Be(true);
			response[0].PersonType.Should().Be("A");
			response[0].Rowguid.Should().Be(Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));
			response[0].Suffix.Should().Be("A");
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
			ApiPersonClientResponseModel response = await client.ByPersonByRowguid(Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));

			response.Should().NotBeNull();

			response.AdditionalContactInfo.Should().Be("A");
			response.BusinessEntityID.Should().Be(1);
			response.Demographic.Should().Be("A");
			response.EmailPromotion.Should().Be(1);
			response.FirstName.Should().Be("A");
			response.LastName.Should().Be("A");
			response.MiddleName.Should().Be("A");
			response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.NameStyle.Should().Be(true);
			response.PersonType.Should().Be("A");
			response.Rowguid.Should().Be(Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));
			response.Suffix.Should().Be("A");
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
			ApiPersonClientResponseModel response = await client.ByPersonByRowguid(default(Guid));

			response.Should().BeNull();
		}

		[Fact]
		public virtual async void TestByLastNameFirstNameMiddleNameFound()
		{
			var builder = new WebHostBuilder()
			              .UseEnvironment("Production")
			              .UseStartup<TestStartup>();
			TestServer testServer = new TestServer(builder);

			var client = new ApiClient(testServer.CreateClient());
			List<ApiPersonClientResponseModel> response = await client.ByPersonByLastNameFirstNameMiddleName("A", "A", "A");

			response.Should().NotBeEmpty();
			response[0].AdditionalContactInfo.Should().Be("A");
			response[0].BusinessEntityID.Should().Be(1);
			response[0].Demographic.Should().Be("A");
			response[0].EmailPromotion.Should().Be(1);
			response[0].FirstName.Should().Be("A");
			response[0].LastName.Should().Be("A");
			response[0].MiddleName.Should().Be("A");
			response[0].ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response[0].NameStyle.Should().Be(true);
			response[0].PersonType.Should().Be("A");
			response[0].Rowguid.Should().Be(Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));
			response[0].Suffix.Should().Be("A");
			response[0].Title.Should().Be("A");
		}

		[Fact]
		public virtual async void TestByLastNameFirstNameMiddleNameNotFound()
		{
			var builder = new WebHostBuilder()
			              .UseEnvironment("Production")
			              .UseStartup<TestStartup>();
			TestServer testServer = new TestServer(builder);

			var client = new ApiClient(testServer.CreateClient());
			List<ApiPersonClientResponseModel> response = await client.ByPersonByLastNameFirstNameMiddleName("test_value", "test_value", "test_value");

			response.Should().BeEmpty();
		}

		[Fact]
		public virtual async void TestByAdditionalContactInfoFound()
		{
			var builder = new WebHostBuilder()
			              .UseEnvironment("Production")
			              .UseStartup<TestStartup>();
			TestServer testServer = new TestServer(builder);

			var client = new ApiClient(testServer.CreateClient());
			List<ApiPersonClientResponseModel> response = await client.ByPersonByAdditionalContactInfo("A");

			response.Should().NotBeEmpty();
			response[0].AdditionalContactInfo.Should().Be("A");
			response[0].BusinessEntityID.Should().Be(1);
			response[0].Demographic.Should().Be("A");
			response[0].EmailPromotion.Should().Be(1);
			response[0].FirstName.Should().Be("A");
			response[0].LastName.Should().Be("A");
			response[0].MiddleName.Should().Be("A");
			response[0].ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response[0].NameStyle.Should().Be(true);
			response[0].PersonType.Should().Be("A");
			response[0].Rowguid.Should().Be(Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));
			response[0].Suffix.Should().Be("A");
			response[0].Title.Should().Be("A");
		}

		[Fact]
		public virtual async void TestByAdditionalContactInfoNotFound()
		{
			var builder = new WebHostBuilder()
			              .UseEnvironment("Production")
			              .UseStartup<TestStartup>();
			TestServer testServer = new TestServer(builder);

			var client = new ApiClient(testServer.CreateClient());
			List<ApiPersonClientResponseModel> response = await client.ByPersonByAdditionalContactInfo("test_value");

			response.Should().BeEmpty();
		}

		[Fact]
		public virtual async void TestByDemographicFound()
		{
			var builder = new WebHostBuilder()
			              .UseEnvironment("Production")
			              .UseStartup<TestStartup>();
			TestServer testServer = new TestServer(builder);

			var client = new ApiClient(testServer.CreateClient());
			List<ApiPersonClientResponseModel> response = await client.ByPersonByDemographic("A");

			response.Should().NotBeEmpty();
			response[0].AdditionalContactInfo.Should().Be("A");
			response[0].BusinessEntityID.Should().Be(1);
			response[0].Demographic.Should().Be("A");
			response[0].EmailPromotion.Should().Be(1);
			response[0].FirstName.Should().Be("A");
			response[0].LastName.Should().Be("A");
			response[0].MiddleName.Should().Be("A");
			response[0].ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response[0].NameStyle.Should().Be(true);
			response[0].PersonType.Should().Be("A");
			response[0].Rowguid.Should().Be(Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));
			response[0].Suffix.Should().Be("A");
			response[0].Title.Should().Be("A");
		}

		[Fact]
		public virtual async void TestByDemographicNotFound()
		{
			var builder = new WebHostBuilder()
			              .UseEnvironment("Production")
			              .UseStartup<TestStartup>();
			TestServer testServer = new TestServer(builder);

			var client = new ApiClient(testServer.CreateClient());
			List<ApiPersonClientResponseModel> response = await client.ByPersonByDemographic("test_value");

			response.Should().BeEmpty();
		}

		[Fact]
		public virtual async void TestForeignKeyPasswordsByBusinessEntityIDFound()
		{
			var builder = new WebHostBuilder()
			              .UseEnvironment("Production")
			              .UseStartup<TestStartup>();
			TestServer testServer = new TestServer(builder);

			var client = new ApiClient(testServer.CreateClient());
			List<ApiPasswordClientResponseModel> response = await client.PasswordsByBusinessEntityID(1);

			response.Should().NotBeEmpty();
		}

		[Fact]
		public virtual async void TestForeignKeyPasswordsByBusinessEntityIDNotFound()
		{
			var builder = new WebHostBuilder()
			              .UseEnvironment("Production")
			              .UseStartup<TestStartup>();
			TestServer testServer = new TestServer(builder);

			var client = new ApiClient(testServer.CreateClient());
			List<ApiPasswordClientResponseModel> response = await client.PasswordsByBusinessEntityID(default(int));

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
				var result = await client.PersonAllAsync(token);
			};

			testCancellation.Should().Throw<OperationCanceledException>();
		}
	}
}

/*<Codenesium>
    <Hash>d0baa2334c995791452df32bb56f1a3e</Hash>
</Codenesium>*/