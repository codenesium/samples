using FluentAssertions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using PetShippingNS.Api.Client;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
using PetShippingNS.Api.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace PetShippingNS.Api.Web.IntegrationTests
{
	[Trait("Type", "Integration")]
	[Trait("Table", "AirTransport")]
	[Trait("Area", "Integration")]
	public partial class AirTransportIntegrationTests
	{
		public AirTransportIntegrationTests()
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

			var model = new ApiAirTransportClientRequestModel();
			model.SetProperties(2, "B", 1, DateTime.Parse("1/1/1988 12:00:00 AM"), 2, DateTime.Parse("1/1/1988 12:00:00 AM"));
			var model2 = new ApiAirTransportClientRequestModel();
			model2.SetProperties(3, "C", 1, DateTime.Parse("1/1/1989 12:00:00 AM"), 3, DateTime.Parse("1/1/1989 12:00:00 AM"));
			var request = new List<ApiAirTransportClientRequestModel>() {model, model2};
			CreateResponse<List<ApiAirTransportClientResponseModel>> result = await client.AirTransportBulkInsertAsync(request);

			result.Success.Should().BeTrue();
			result.Record.Should().NotBeNull();

			context.Set<AirTransport>().ToList()[1].AirlineId.Should().Be(2);
			context.Set<AirTransport>().ToList()[1].FlightNumber.Should().Be("B");
			context.Set<AirTransport>().ToList()[1].HandlerId.Should().Be(1);
			context.Set<AirTransport>().ToList()[1].LandDate.Should().Be(DateTime.Parse("1/1/1988 12:00:00 AM"));
			context.Set<AirTransport>().ToList()[1].PipelineStepId.Should().Be(2);
			context.Set<AirTransport>().ToList()[1].TakeoffDate.Should().Be(DateTime.Parse("1/1/1988 12:00:00 AM"));

			context.Set<AirTransport>().ToList()[2].AirlineId.Should().Be(3);
			context.Set<AirTransport>().ToList()[2].FlightNumber.Should().Be("C");
			context.Set<AirTransport>().ToList()[2].HandlerId.Should().Be(1);
			context.Set<AirTransport>().ToList()[2].LandDate.Should().Be(DateTime.Parse("1/1/1989 12:00:00 AM"));
			context.Set<AirTransport>().ToList()[2].PipelineStepId.Should().Be(3);
			context.Set<AirTransport>().ToList()[2].TakeoffDate.Should().Be(DateTime.Parse("1/1/1989 12:00:00 AM"));
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

			var model = new ApiAirTransportClientRequestModel();
			model.SetProperties(2, "B", 1, DateTime.Parse("1/1/1988 12:00:00 AM"), 2, DateTime.Parse("1/1/1988 12:00:00 AM"));
			CreateResponse<ApiAirTransportClientResponseModel> result = await client.AirTransportCreateAsync(model);

			result.Success.Should().BeTrue();
			result.Record.Should().NotBeNull();
			context.Set<AirTransport>().ToList()[1].AirlineId.Should().Be(2);
			context.Set<AirTransport>().ToList()[1].FlightNumber.Should().Be("B");
			context.Set<AirTransport>().ToList()[1].HandlerId.Should().Be(1);
			context.Set<AirTransport>().ToList()[1].LandDate.Should().Be(DateTime.Parse("1/1/1988 12:00:00 AM"));
			context.Set<AirTransport>().ToList()[1].PipelineStepId.Should().Be(2);
			context.Set<AirTransport>().ToList()[1].TakeoffDate.Should().Be(DateTime.Parse("1/1/1988 12:00:00 AM"));

			result.Record.AirlineId.Should().Be(2);
			result.Record.FlightNumber.Should().Be("B");
			result.Record.HandlerId.Should().Be(1);
			result.Record.LandDate.Should().Be(DateTime.Parse("1/1/1988 12:00:00 AM"));
			result.Record.PipelineStepId.Should().Be(2);
			result.Record.TakeoffDate.Should().Be(DateTime.Parse("1/1/1988 12:00:00 AM"));
		}

		[Fact]
		public virtual async void TestUpdate()
		{
			var builder = new WebHostBuilder()
			              .UseEnvironment("Production")
			              .UseStartup<TestStartup>();
			TestServer testServer = new TestServer(builder);

			var client = new ApiClient(testServer.CreateClient());
			var mapper = new ApiAirTransportServerModelMapper();
			ApplicationDbContext context = testServer.Host.Services.GetService(typeof(ApplicationDbContext)) as ApplicationDbContext;
			IAirTransportService service = testServer.Host.Services.GetService(typeof(IAirTransportService)) as IAirTransportService;
			ApiAirTransportServerResponseModel model = await service.Get(1);

			ApiAirTransportClientRequestModel request = mapper.MapServerResponseToClientRequest(model);
			request.SetProperties(2, "B", 1, DateTime.Parse("1/1/1988 12:00:00 AM"), 2, DateTime.Parse("1/1/1988 12:00:00 AM"));

			UpdateResponse<ApiAirTransportClientResponseModel> updateResponse = await client.AirTransportUpdateAsync(model.Id, request);

			context.Entry(context.Set<AirTransport>().ToList()[0]).Reload();
			updateResponse.Record.Should().NotBeNull();
			updateResponse.Success.Should().BeTrue();
			updateResponse.Record.Id.Should().Be(1);
			context.Set<AirTransport>().ToList()[0].AirlineId.Should().Be(2);
			context.Set<AirTransport>().ToList()[0].FlightNumber.Should().Be("B");
			context.Set<AirTransport>().ToList()[0].HandlerId.Should().Be(1);
			context.Set<AirTransport>().ToList()[0].LandDate.Should().Be(DateTime.Parse("1/1/1988 12:00:00 AM"));
			context.Set<AirTransport>().ToList()[0].PipelineStepId.Should().Be(2);
			context.Set<AirTransport>().ToList()[0].TakeoffDate.Should().Be(DateTime.Parse("1/1/1988 12:00:00 AM"));

			updateResponse.Record.Id.Should().Be(1);
			updateResponse.Record.AirlineId.Should().Be(2);
			updateResponse.Record.FlightNumber.Should().Be("B");
			updateResponse.Record.HandlerId.Should().Be(1);
			updateResponse.Record.LandDate.Should().Be(DateTime.Parse("1/1/1988 12:00:00 AM"));
			updateResponse.Record.PipelineStepId.Should().Be(2);
			updateResponse.Record.TakeoffDate.Should().Be(DateTime.Parse("1/1/1988 12:00:00 AM"));
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

			IAirTransportService service = testServer.Host.Services.GetService(typeof(IAirTransportService)) as IAirTransportService;
			var model = new ApiAirTransportServerRequestModel();
			model.SetProperties(2, "B", 1, DateTime.Parse("1/1/1988 12:00:00 AM"), 2, DateTime.Parse("1/1/1988 12:00:00 AM"));
			CreateResponse<ApiAirTransportServerResponseModel> createdResponse = await service.Create(model);

			createdResponse.Success.Should().BeTrue();

			ActionResponse deleteResult = await client.AirTransportDeleteAsync(2);

			deleteResult.Success.Should().BeTrue();
			ApiAirTransportServerResponseModel verifyResponse = await service.Get(2);

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

			ApiAirTransportClientResponseModel response = await client.AirTransportGetAsync(1);

			response.Should().NotBeNull();
			response.AirlineId.Should().Be(1);
			response.FlightNumber.Should().Be("A");
			response.HandlerId.Should().Be(1);
			response.Id.Should().Be(1);
			response.LandDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.PipelineStepId.Should().Be(1);
			response.TakeoffDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
		}

		[Fact]
		public virtual async void TestGetNotFound()
		{
			var builder = new WebHostBuilder()
			              .UseEnvironment("Production")
			              .UseStartup<TestStartup>();
			TestServer testServer = new TestServer(builder);

			var client = new ApiClient(testServer.CreateClient());
			ApiAirTransportClientResponseModel response = await client.AirTransportGetAsync(default(int));

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

			List<ApiAirTransportClientResponseModel> response = await client.AirTransportAllAsync();

			response.Count.Should().BeGreaterThan(0);
			response[0].AirlineId.Should().Be(1);
			response[0].FlightNumber.Should().Be("A");
			response[0].HandlerId.Should().Be(1);
			response[0].Id.Should().Be(1);
			response[0].LandDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response[0].PipelineStepId.Should().Be(1);
			response[0].TakeoffDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
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
				var result = await client.AirTransportAllAsync(token);
			};

			testCancellation.Should().Throw<OperationCanceledException>();
		}
	}
}

/*<Codenesium>
    <Hash>983d12029c538816ec15aafc4775eb19</Hash>
</Codenesium>*/