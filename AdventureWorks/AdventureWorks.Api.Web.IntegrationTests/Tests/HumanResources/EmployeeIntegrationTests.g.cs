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
	[Trait("Table", "Employee")]
	[Trait("Area", "Integration")]
	public partial class EmployeeIntegrationTests
	{
		public EmployeeIntegrationTests()
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

			var model = new ApiEmployeeClientRequestModel();
			model.SetProperties(DateTime.Parse("1/1/1988 12:00:00 AM"), true, "B", DateTime.Parse("1/1/1988 12:00:00 AM"), "B", "B", "B", DateTime.Parse("1/1/1988 12:00:00 AM"), "B", 2, Guid.Parse("3842cac4-b9a0-8223-0dcc-509a6f75849b"), true, 2, 2);
			var model2 = new ApiEmployeeClientRequestModel();
			model2.SetProperties(DateTime.Parse("1/1/1989 12:00:00 AM"), true, "C", DateTime.Parse("1/1/1989 12:00:00 AM"), "C", "C", "C", DateTime.Parse("1/1/1989 12:00:00 AM"), "C", 3, Guid.Parse("8d721ec8-4c9d-632f-6f06-7f89cc14862c"), true, 3, 3);
			var request = new List<ApiEmployeeClientRequestModel>() {model, model2};
			CreateResponse<List<ApiEmployeeClientResponseModel>> result = await client.EmployeeBulkInsertAsync(request);

			result.Success.Should().BeTrue();
			result.Record.Should().NotBeNull();

			context.Set<Employee>().ToList()[1].BirthDate.Should().Be(DateTime.Parse("1/1/1988 12:00:00 AM"));
			context.Set<Employee>().ToList()[1].CurrentFlag.Should().Be(true);
			context.Set<Employee>().ToList()[1].Gender.Should().Be("B");
			context.Set<Employee>().ToList()[1].HireDate.Should().Be(DateTime.Parse("1/1/1988 12:00:00 AM"));
			context.Set<Employee>().ToList()[1].JobTitle.Should().Be("B");
			context.Set<Employee>().ToList()[1].LoginID.Should().Be("B");
			context.Set<Employee>().ToList()[1].MaritalStatu.Should().Be("B");
			context.Set<Employee>().ToList()[1].ModifiedDate.Should().Be(DateTime.Parse("1/1/1988 12:00:00 AM"));
			context.Set<Employee>().ToList()[1].NationalIDNumber.Should().Be("B");
			context.Set<Employee>().ToList()[1].OrganizationLevel.Should().Be(2);
			context.Set<Employee>().ToList()[1].Rowguid.Should().Be(Guid.Parse("3842cac4-b9a0-8223-0dcc-509a6f75849b"));
			context.Set<Employee>().ToList()[1].SalariedFlag.Should().Be(true);
			context.Set<Employee>().ToList()[1].SickLeaveHour.Should().Be(2);
			context.Set<Employee>().ToList()[1].VacationHour.Should().Be(2);

			context.Set<Employee>().ToList()[2].BirthDate.Should().Be(DateTime.Parse("1/1/1989 12:00:00 AM"));
			context.Set<Employee>().ToList()[2].CurrentFlag.Should().Be(true);
			context.Set<Employee>().ToList()[2].Gender.Should().Be("C");
			context.Set<Employee>().ToList()[2].HireDate.Should().Be(DateTime.Parse("1/1/1989 12:00:00 AM"));
			context.Set<Employee>().ToList()[2].JobTitle.Should().Be("C");
			context.Set<Employee>().ToList()[2].LoginID.Should().Be("C");
			context.Set<Employee>().ToList()[2].MaritalStatu.Should().Be("C");
			context.Set<Employee>().ToList()[2].ModifiedDate.Should().Be(DateTime.Parse("1/1/1989 12:00:00 AM"));
			context.Set<Employee>().ToList()[2].NationalIDNumber.Should().Be("C");
			context.Set<Employee>().ToList()[2].OrganizationLevel.Should().Be(3);
			context.Set<Employee>().ToList()[2].Rowguid.Should().Be(Guid.Parse("8d721ec8-4c9d-632f-6f06-7f89cc14862c"));
			context.Set<Employee>().ToList()[2].SalariedFlag.Should().Be(true);
			context.Set<Employee>().ToList()[2].SickLeaveHour.Should().Be(3);
			context.Set<Employee>().ToList()[2].VacationHour.Should().Be(3);
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

			var model = new ApiEmployeeClientRequestModel();
			model.SetProperties(DateTime.Parse("1/1/1988 12:00:00 AM"), true, "B", DateTime.Parse("1/1/1988 12:00:00 AM"), "B", "B", "B", DateTime.Parse("1/1/1988 12:00:00 AM"), "B", 2, Guid.Parse("3842cac4-b9a0-8223-0dcc-509a6f75849b"), true, 2, 2);
			CreateResponse<ApiEmployeeClientResponseModel> result = await client.EmployeeCreateAsync(model);

			result.Success.Should().BeTrue();
			result.Record.Should().NotBeNull();
			context.Set<Employee>().ToList()[1].BirthDate.Should().Be(DateTime.Parse("1/1/1988 12:00:00 AM"));
			context.Set<Employee>().ToList()[1].CurrentFlag.Should().Be(true);
			context.Set<Employee>().ToList()[1].Gender.Should().Be("B");
			context.Set<Employee>().ToList()[1].HireDate.Should().Be(DateTime.Parse("1/1/1988 12:00:00 AM"));
			context.Set<Employee>().ToList()[1].JobTitle.Should().Be("B");
			context.Set<Employee>().ToList()[1].LoginID.Should().Be("B");
			context.Set<Employee>().ToList()[1].MaritalStatu.Should().Be("B");
			context.Set<Employee>().ToList()[1].ModifiedDate.Should().Be(DateTime.Parse("1/1/1988 12:00:00 AM"));
			context.Set<Employee>().ToList()[1].NationalIDNumber.Should().Be("B");
			context.Set<Employee>().ToList()[1].OrganizationLevel.Should().Be(2);
			context.Set<Employee>().ToList()[1].Rowguid.Should().Be(Guid.Parse("3842cac4-b9a0-8223-0dcc-509a6f75849b"));
			context.Set<Employee>().ToList()[1].SalariedFlag.Should().Be(true);
			context.Set<Employee>().ToList()[1].SickLeaveHour.Should().Be(2);
			context.Set<Employee>().ToList()[1].VacationHour.Should().Be(2);

			result.Record.BirthDate.Should().Be(DateTime.Parse("1/1/1988 12:00:00 AM"));
			result.Record.CurrentFlag.Should().Be(true);
			result.Record.Gender.Should().Be("B");
			result.Record.HireDate.Should().Be(DateTime.Parse("1/1/1988 12:00:00 AM"));
			result.Record.JobTitle.Should().Be("B");
			result.Record.LoginID.Should().Be("B");
			result.Record.MaritalStatu.Should().Be("B");
			result.Record.ModifiedDate.Should().Be(DateTime.Parse("1/1/1988 12:00:00 AM"));
			result.Record.NationalIDNumber.Should().Be("B");
			result.Record.OrganizationLevel.Should().Be(2);
			result.Record.Rowguid.Should().Be(Guid.Parse("3842cac4-b9a0-8223-0dcc-509a6f75849b"));
			result.Record.SalariedFlag.Should().Be(true);
			result.Record.SickLeaveHour.Should().Be(2);
			result.Record.VacationHour.Should().Be(2);
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
			var mapper = new ApiEmployeeServerModelMapper();
			ApplicationDbContext context = testServer.Host.Services.GetService(typeof(ApplicationDbContext)) as ApplicationDbContext;
			IEmployeeService service = testServer.Host.Services.GetService(typeof(IEmployeeService)) as IEmployeeService;
			ApiEmployeeServerResponseModel model = await service.Get(1);

			ApiEmployeeClientRequestModel request = mapper.MapServerResponseToClientRequest(model);
			request.SetProperties(DateTime.Parse("1/1/1988 12:00:00 AM"), true, "B", DateTime.Parse("1/1/1988 12:00:00 AM"), "B", "B", "B", DateTime.Parse("1/1/1988 12:00:00 AM"), "B", 2, Guid.Parse("3842cac4-b9a0-8223-0dcc-509a6f75849b"), true, 2, 2);

			UpdateResponse<ApiEmployeeClientResponseModel> updateResponse = await client.EmployeeUpdateAsync(model.BusinessEntityID, request);

			context.Entry(context.Set<Employee>().ToList()[0]).Reload();
			updateResponse.Record.Should().NotBeNull();
			updateResponse.Success.Should().BeTrue();
			updateResponse.Record.BusinessEntityID.Should().Be(1);
			context.Set<Employee>().ToList()[0].BirthDate.Should().Be(DateTime.Parse("1/1/1988 12:00:00 AM"));
			context.Set<Employee>().ToList()[0].CurrentFlag.Should().Be(true);
			context.Set<Employee>().ToList()[0].Gender.Should().Be("B");
			context.Set<Employee>().ToList()[0].HireDate.Should().Be(DateTime.Parse("1/1/1988 12:00:00 AM"));
			context.Set<Employee>().ToList()[0].JobTitle.Should().Be("B");
			context.Set<Employee>().ToList()[0].LoginID.Should().Be("B");
			context.Set<Employee>().ToList()[0].MaritalStatu.Should().Be("B");
			context.Set<Employee>().ToList()[0].ModifiedDate.Should().Be(DateTime.Parse("1/1/1988 12:00:00 AM"));
			context.Set<Employee>().ToList()[0].NationalIDNumber.Should().Be("B");
			context.Set<Employee>().ToList()[0].OrganizationLevel.Should().Be(2);
			context.Set<Employee>().ToList()[0].Rowguid.Should().Be(Guid.Parse("3842cac4-b9a0-8223-0dcc-509a6f75849b"));
			context.Set<Employee>().ToList()[0].SalariedFlag.Should().Be(true);
			context.Set<Employee>().ToList()[0].SickLeaveHour.Should().Be(2);
			context.Set<Employee>().ToList()[0].VacationHour.Should().Be(2);

			updateResponse.Record.BusinessEntityID.Should().Be(1);
			updateResponse.Record.BirthDate.Should().Be(DateTime.Parse("1/1/1988 12:00:00 AM"));
			updateResponse.Record.CurrentFlag.Should().Be(true);
			updateResponse.Record.Gender.Should().Be("B");
			updateResponse.Record.HireDate.Should().Be(DateTime.Parse("1/1/1988 12:00:00 AM"));
			updateResponse.Record.JobTitle.Should().Be("B");
			updateResponse.Record.LoginID.Should().Be("B");
			updateResponse.Record.MaritalStatu.Should().Be("B");
			updateResponse.Record.ModifiedDate.Should().Be(DateTime.Parse("1/1/1988 12:00:00 AM"));
			updateResponse.Record.NationalIDNumber.Should().Be("B");
			updateResponse.Record.OrganizationLevel.Should().Be(2);
			updateResponse.Record.Rowguid.Should().Be(Guid.Parse("3842cac4-b9a0-8223-0dcc-509a6f75849b"));
			updateResponse.Record.SalariedFlag.Should().Be(true);
			updateResponse.Record.SickLeaveHour.Should().Be(2);
			updateResponse.Record.VacationHour.Should().Be(2);
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

			IEmployeeService service = testServer.Host.Services.GetService(typeof(IEmployeeService)) as IEmployeeService;
			var model = new ApiEmployeeServerRequestModel();
			model.SetProperties(DateTime.Parse("1/1/1988 12:00:00 AM"), true, "B", DateTime.Parse("1/1/1988 12:00:00 AM"), "B", "B", "B", DateTime.Parse("1/1/1988 12:00:00 AM"), "B", 2, Guid.Parse("3842cac4-b9a0-8223-0dcc-509a6f75849b"), true, 2, 2);
			CreateResponse<ApiEmployeeServerResponseModel> createdResponse = await service.Create(model);

			createdResponse.Success.Should().BeTrue();

			ActionResponse deleteResult = await client.EmployeeDeleteAsync(2);

			deleteResult.Success.Should().BeTrue();
			ApiEmployeeServerResponseModel verifyResponse = await service.Get(2);

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

			ApiEmployeeClientResponseModel response = await client.EmployeeGetAsync(1);

			response.Should().NotBeNull();
			response.BirthDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.BusinessEntityID.Should().Be(1);
			response.CurrentFlag.Should().Be(true);
			response.Gender.Should().Be("A");
			response.HireDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.JobTitle.Should().Be("A");
			response.LoginID.Should().Be("A");
			response.MaritalStatu.Should().Be("A");
			response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.NationalIDNumber.Should().Be("A");
			response.OrganizationLevel.Should().Be(1);
			response.Rowguid.Should().Be(Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));
			response.SalariedFlag.Should().Be(true);
			response.SickLeaveHour.Should().Be(1);
			response.VacationHour.Should().Be(1);
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
			ApiEmployeeClientResponseModel response = await client.EmployeeGetAsync(default(int));

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
			List<ApiEmployeeClientResponseModel> response = await client.EmployeeAllAsync();

			response.Count.Should().BeGreaterThan(0);
			response[0].BirthDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response[0].BusinessEntityID.Should().Be(1);
			response[0].CurrentFlag.Should().Be(true);
			response[0].Gender.Should().Be("A");
			response[0].HireDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response[0].JobTitle.Should().Be("A");
			response[0].LoginID.Should().Be("A");
			response[0].MaritalStatu.Should().Be("A");
			response[0].ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response[0].NationalIDNumber.Should().Be("A");
			response[0].OrganizationLevel.Should().Be(1);
			response[0].Rowguid.Should().Be(Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));
			response[0].SalariedFlag.Should().Be(true);
			response[0].SickLeaveHour.Should().Be(1);
			response[0].VacationHour.Should().Be(1);
		}

		[Fact]
		public virtual async void TestByLoginIDFound()
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
			ApiEmployeeClientResponseModel response = await client.ByEmployeeByLoginID("A");

			response.Should().NotBeNull();

			response.BirthDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.BusinessEntityID.Should().Be(1);
			response.CurrentFlag.Should().Be(true);
			response.Gender.Should().Be("A");
			response.HireDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.JobTitle.Should().Be("A");
			response.LoginID.Should().Be("A");
			response.MaritalStatu.Should().Be("A");
			response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.NationalIDNumber.Should().Be("A");
			response.OrganizationLevel.Should().Be(1);
			response.Rowguid.Should().Be(Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));
			response.SalariedFlag.Should().Be(true);
			response.SickLeaveHour.Should().Be(1);
			response.VacationHour.Should().Be(1);
		}

		[Fact]
		public virtual async void TestByLoginIDNotFound()
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
			ApiEmployeeClientResponseModel response = await client.ByEmployeeByLoginID("test_value");

			response.Should().BeNull();
		}

		[Fact]
		public virtual async void TestByNationalIDNumberFound()
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
			ApiEmployeeClientResponseModel response = await client.ByEmployeeByNationalIDNumber("A");

			response.Should().NotBeNull();

			response.BirthDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.BusinessEntityID.Should().Be(1);
			response.CurrentFlag.Should().Be(true);
			response.Gender.Should().Be("A");
			response.HireDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.JobTitle.Should().Be("A");
			response.LoginID.Should().Be("A");
			response.MaritalStatu.Should().Be("A");
			response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.NationalIDNumber.Should().Be("A");
			response.OrganizationLevel.Should().Be(1);
			response.Rowguid.Should().Be(Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));
			response.SalariedFlag.Should().Be(true);
			response.SickLeaveHour.Should().Be(1);
			response.VacationHour.Should().Be(1);
		}

		[Fact]
		public virtual async void TestByNationalIDNumberNotFound()
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
			ApiEmployeeClientResponseModel response = await client.ByEmployeeByNationalIDNumber("test_value");

			response.Should().BeNull();
		}

		[Fact]
		public virtual async void TestByRowguidFound()
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
			ApiEmployeeClientResponseModel response = await client.ByEmployeeByRowguid(Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));

			response.Should().NotBeNull();

			response.BirthDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.BusinessEntityID.Should().Be(1);
			response.CurrentFlag.Should().Be(true);
			response.Gender.Should().Be("A");
			response.HireDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.JobTitle.Should().Be("A");
			response.LoginID.Should().Be("A");
			response.MaritalStatu.Should().Be("A");
			response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.NationalIDNumber.Should().Be("A");
			response.OrganizationLevel.Should().Be(1);
			response.Rowguid.Should().Be(Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));
			response.SalariedFlag.Should().Be(true);
			response.SickLeaveHour.Should().Be(1);
			response.VacationHour.Should().Be(1);
		}

		[Fact]
		public virtual async void TestByRowguidNotFound()
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
			ApiEmployeeClientResponseModel response = await client.ByEmployeeByRowguid(default(Guid));

			response.Should().BeNull();
		}

		[Fact]
		public virtual async void TestForeignKeyJobCandidatesByBusinessEntityIDFound()
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
			List<ApiJobCandidateClientResponseModel> response = await client.JobCandidatesByBusinessEntityID(1);

			response.Should().NotBeEmpty();
		}

		[Fact]
		public virtual async void TestForeignKeyJobCandidatesByBusinessEntityIDNotFound()
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
			List<ApiJobCandidateClientResponseModel> response = await client.JobCandidatesByBusinessEntityID(default(int));

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
				var result = await client.EmployeeAllAsync(token);
			};

			testCancellation.Should().Throw<OperationCanceledException>();
		}
	}
}

/*<Codenesium>
    <Hash>9d083416f419f4c1c8b077a48ba9d7e0</Hash>
</Codenesium>*/