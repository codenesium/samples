using FluentAssertions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using StudioResourceManagerMTNS.Api.Client;
using StudioResourceManagerMTNS.Api.Contracts;
using StudioResourceManagerMTNS.Api.DataAccess;
using StudioResourceManagerMTNS.Api.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace StudioResourceManagerMTNS.Api.Web.IntegrationTests
{
	[Trait("Type", "Integration")]
	[Trait("Table", "TeacherTeacherSkill")]
	[Trait("Area", "Integration")]
	public partial class TeacherTeacherSkillIntegrationTests
	{
		public TeacherTeacherSkillIntegrationTests()
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

			var model = new ApiTeacherTeacherSkillClientRequestModel();
			model.SetProperties(1, 1);
			var model2 = new ApiTeacherTeacherSkillClientRequestModel();
			model2.SetProperties(1, 1);
			var request = new List<ApiTeacherTeacherSkillClientRequestModel>() {model, model2};
			CreateResponse<List<ApiTeacherTeacherSkillClientResponseModel>> result = await client.TeacherTeacherSkillBulkInsertAsync(request);

			result.Success.Should().BeTrue();
			result.Record.Should().NotBeNull();

			context.Set<TeacherTeacherSkill>().ToList()[1].TeacherId.Should().Be(1);
			context.Set<TeacherTeacherSkill>().ToList()[1].TeacherSkillId.Should().Be(1);

			context.Set<TeacherTeacherSkill>().ToList()[2].TeacherId.Should().Be(1);
			context.Set<TeacherTeacherSkill>().ToList()[2].TeacherSkillId.Should().Be(1);
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

			var model = new ApiTeacherTeacherSkillClientRequestModel();
			model.SetProperties(1, 1);
			CreateResponse<ApiTeacherTeacherSkillClientResponseModel> result = await client.TeacherTeacherSkillCreateAsync(model);

			result.Success.Should().BeTrue();
			result.Record.Should().NotBeNull();
			context.Set<TeacherTeacherSkill>().ToList()[1].TeacherId.Should().Be(1);
			context.Set<TeacherTeacherSkill>().ToList()[1].TeacherSkillId.Should().Be(1);

			result.Record.TeacherId.Should().Be(1);
			result.Record.TeacherSkillId.Should().Be(1);
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
			var mapper = new ApiTeacherTeacherSkillServerModelMapper();
			ApplicationDbContext context = testServer.Host.Services.GetService(typeof(ApplicationDbContext)) as ApplicationDbContext;
			ITeacherTeacherSkillService service = testServer.Host.Services.GetService(typeof(ITeacherTeacherSkillService)) as ITeacherTeacherSkillService;
			ApiTeacherTeacherSkillServerResponseModel model = await service.Get(1);

			ApiTeacherTeacherSkillClientRequestModel request = mapper.MapServerResponseToClientRequest(model);
			request.SetProperties(1, 1);

			UpdateResponse<ApiTeacherTeacherSkillClientResponseModel> updateResponse = await client.TeacherTeacherSkillUpdateAsync(model.Id, request);

			context.Entry(context.Set<TeacherTeacherSkill>().ToList()[0]).Reload();
			updateResponse.Record.Should().NotBeNull();
			updateResponse.Success.Should().BeTrue();
			updateResponse.Record.Id.Should().Be(1);
			context.Set<TeacherTeacherSkill>().ToList()[0].TeacherId.Should().Be(1);
			context.Set<TeacherTeacherSkill>().ToList()[0].TeacherSkillId.Should().Be(1);

			updateResponse.Record.Id.Should().Be(1);
			updateResponse.Record.TeacherId.Should().Be(1);
			updateResponse.Record.TeacherSkillId.Should().Be(1);
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

			ITeacherTeacherSkillService service = testServer.Host.Services.GetService(typeof(ITeacherTeacherSkillService)) as ITeacherTeacherSkillService;
			var model = new ApiTeacherTeacherSkillServerRequestModel();
			model.SetProperties(1, 1);
			CreateResponse<ApiTeacherTeacherSkillServerResponseModel> createdResponse = await service.Create(model);

			createdResponse.Success.Should().BeTrue();

			ActionResponse deleteResult = await client.TeacherTeacherSkillDeleteAsync(2);

			deleteResult.Success.Should().BeTrue();
			ApiTeacherTeacherSkillServerResponseModel verifyResponse = await service.Get(2);

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

			ApiTeacherTeacherSkillClientResponseModel response = await client.TeacherTeacherSkillGetAsync(1);

			response.Should().NotBeNull();
			response.Id.Should().Be(1);
			response.TeacherId.Should().Be(1);
			response.TeacherSkillId.Should().Be(1);
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
			ApiTeacherTeacherSkillClientResponseModel response = await client.TeacherTeacherSkillGetAsync(default(int));

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
			List<ApiTeacherTeacherSkillClientResponseModel> response = await client.TeacherTeacherSkillAllAsync();

			response.Count.Should().BeGreaterThan(0);
			response[0].Id.Should().Be(1);
			response[0].TeacherId.Should().Be(1);
			response[0].TeacherSkillId.Should().Be(1);
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
				var result = await client.TeacherTeacherSkillAllAsync(token);
			};

			testCancellation.Should().Throw<OperationCanceledException>();
		}
	}
}

/*<Codenesium>
    <Hash>b95816a2a05a272a8a714f10b2100ee9</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/