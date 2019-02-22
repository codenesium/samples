using FluentAssertions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TestsNS.Api.Client;
using TestsNS.Api.Contracts;
using TestsNS.Api.DataAccess;
using TestsNS.Api.Services;
using Xunit;

namespace TestsNS.Api.Web.IntegrationTests
{
	[Trait("Type", "Integration")]
	[Trait("Table", "TestAllFieldType")]
	[Trait("Area", "Integration")]
	public partial class TestAllFieldTypeIntegrationTests
	{
		public TestAllFieldTypeIntegrationTests()
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

			var model = new ApiTestAllFieldTypeClientRequestModel();
			model.SetProperties(2, BitConverter.GetBytes(2), true, "B", DateTime.Parse("1/1/1988 12:00:00 AM"), DateTime.Parse("1/1/1988 12:00:00 AM"), DateTime.Parse("1/1/1988 12:00:00 AM"), DateTimeOffset.Parse("1/1/1988 12:00:00 AM"), 2m, 2, 2, 2, Guid.Parse("3842cac4-b9a0-8223-0dcc-509a6f75849b"), BitConverter.GetBytes(2), 2m, "B", "B", 2m, "B", 2m, DateTime.Parse("1/1/1988 12:00:00 AM"), 2, 2m, "B", TimeSpan.Parse("02:00:00"), BitConverter.GetBytes(2), 2, Guid.Parse("3842cac4-b9a0-8223-0dcc-509a6f75849b"), BitConverter.GetBytes(2), "B", "B", "B");
			var model2 = new ApiTestAllFieldTypeClientRequestModel();
			model2.SetProperties(3, BitConverter.GetBytes(3), true, "C", DateTime.Parse("1/1/1989 12:00:00 AM"), DateTime.Parse("1/1/1989 12:00:00 AM"), DateTime.Parse("1/1/1989 12:00:00 AM"), DateTimeOffset.Parse("1/1/1989 12:00:00 AM"), 3m, 3, 3, 3, Guid.Parse("8d721ec8-4c9d-632f-6f06-7f89cc14862c"), BitConverter.GetBytes(3), 3m, "C", "C", 3m, "C", 3m, DateTime.Parse("1/1/1989 12:00:00 AM"), 3, 3m, "C", TimeSpan.Parse("03:00:00"), BitConverter.GetBytes(3), 3, Guid.Parse("8d721ec8-4c9d-632f-6f06-7f89cc14862c"), BitConverter.GetBytes(3), "C", "C", "C");
			var request = new List<ApiTestAllFieldTypeClientRequestModel>() {model, model2};
			CreateResponse<List<ApiTestAllFieldTypeClientResponseModel>> result = await client.TestAllFieldTypeBulkInsertAsync(request);

			result.Success.Should().BeTrue();
			result.Record.Should().NotBeNull();

			context.Set<TestAllFieldType>().ToList()[1].FieldBigInt.Should().Be(2);
			context.Set<TestAllFieldType>().ToList()[1].FieldBinary.Should().BeEquivalentTo(BitConverter.GetBytes(2));
			context.Set<TestAllFieldType>().ToList()[1].FieldBit.Should().Be(true);
			context.Set<TestAllFieldType>().ToList()[1].FieldChar.Should().Be("B");
			context.Set<TestAllFieldType>().ToList()[1].FieldDate.Should().Be(DateTime.Parse("1/1/1988 12:00:00 AM"));
			context.Set<TestAllFieldType>().ToList()[1].FieldDateTime.Should().Be(DateTime.Parse("1/1/1988 12:00:00 AM"));
			context.Set<TestAllFieldType>().ToList()[1].FieldDateTime2.Should().Be(DateTime.Parse("1/1/1988 12:00:00 AM"));
			context.Set<TestAllFieldType>().ToList()[1].FieldDateTimeOffset.Should().Be(DateTimeOffset.Parse("1/1/1988 12:00:00 AM"));
			context.Set<TestAllFieldType>().ToList()[1].FieldDecimal.Should().Be(2m);
			context.Set<TestAllFieldType>().ToList()[1].FieldFloat.Should().Be(2);
			context.Set<TestAllFieldType>().ToList()[1].FieldGeography.Should().Be(2);
			context.Set<TestAllFieldType>().ToList()[1].FieldGeometry.Should().Be(2);
			context.Set<TestAllFieldType>().ToList()[1].FieldHierarchyId.Should().Be(Guid.Parse("3842cac4-b9a0-8223-0dcc-509a6f75849b"));
			context.Set<TestAllFieldType>().ToList()[1].FieldImage.Should().BeEquivalentTo(BitConverter.GetBytes(2));
			context.Set<TestAllFieldType>().ToList()[1].FieldMoney.Should().Be(2m);
			context.Set<TestAllFieldType>().ToList()[1].FieldNChar.Should().Be("B");
			context.Set<TestAllFieldType>().ToList()[1].FieldNText.Should().Be("B");
			context.Set<TestAllFieldType>().ToList()[1].FieldNumeric.Should().Be(2m);
			context.Set<TestAllFieldType>().ToList()[1].FieldNVarchar.Should().Be("B");
			context.Set<TestAllFieldType>().ToList()[1].FieldReal.Should().Be(2m);
			context.Set<TestAllFieldType>().ToList()[1].FieldSmallDateTime.Should().Be(DateTime.Parse("1/1/1988 12:00:00 AM"));
			context.Set<TestAllFieldType>().ToList()[1].FieldSmallInt.Should().Be(2);
			context.Set<TestAllFieldType>().ToList()[1].FieldSmallMoney.Should().Be(2m);
			context.Set<TestAllFieldType>().ToList()[1].FieldText.Should().Be("B");
			context.Set<TestAllFieldType>().ToList()[1].FieldTime.Should().Be(TimeSpan.Parse("02:00:00"));
			context.Set<TestAllFieldType>().ToList()[1].FieldTimestamp.Should().BeEquivalentTo(BitConverter.GetBytes(2));
			context.Set<TestAllFieldType>().ToList()[1].FieldTinyInt.Should().Be(2);
			context.Set<TestAllFieldType>().ToList()[1].FieldUniqueIdentifier.Should().Be(Guid.Parse("3842cac4-b9a0-8223-0dcc-509a6f75849b"));
			context.Set<TestAllFieldType>().ToList()[1].FieldVarBinary.Should().BeEquivalentTo(BitConverter.GetBytes(2));
			context.Set<TestAllFieldType>().ToList()[1].FieldVarchar.Should().Be("B");
			context.Set<TestAllFieldType>().ToList()[1].FieldVariant.Should().Be("B");
			context.Set<TestAllFieldType>().ToList()[1].FieldXML.Should().Be("B");

			context.Set<TestAllFieldType>().ToList()[2].FieldBigInt.Should().Be(3);
			context.Set<TestAllFieldType>().ToList()[2].FieldBinary.Should().BeEquivalentTo(BitConverter.GetBytes(3));
			context.Set<TestAllFieldType>().ToList()[2].FieldBit.Should().Be(true);
			context.Set<TestAllFieldType>().ToList()[2].FieldChar.Should().Be("C");
			context.Set<TestAllFieldType>().ToList()[2].FieldDate.Should().Be(DateTime.Parse("1/1/1989 12:00:00 AM"));
			context.Set<TestAllFieldType>().ToList()[2].FieldDateTime.Should().Be(DateTime.Parse("1/1/1989 12:00:00 AM"));
			context.Set<TestAllFieldType>().ToList()[2].FieldDateTime2.Should().Be(DateTime.Parse("1/1/1989 12:00:00 AM"));
			context.Set<TestAllFieldType>().ToList()[2].FieldDateTimeOffset.Should().Be(DateTimeOffset.Parse("1/1/1989 12:00:00 AM"));
			context.Set<TestAllFieldType>().ToList()[2].FieldDecimal.Should().Be(3m);
			context.Set<TestAllFieldType>().ToList()[2].FieldFloat.Should().Be(3);
			context.Set<TestAllFieldType>().ToList()[2].FieldGeography.Should().Be(3);
			context.Set<TestAllFieldType>().ToList()[2].FieldGeometry.Should().Be(3);
			context.Set<TestAllFieldType>().ToList()[2].FieldHierarchyId.Should().Be(Guid.Parse("8d721ec8-4c9d-632f-6f06-7f89cc14862c"));
			context.Set<TestAllFieldType>().ToList()[2].FieldImage.Should().BeEquivalentTo(BitConverter.GetBytes(3));
			context.Set<TestAllFieldType>().ToList()[2].FieldMoney.Should().Be(3m);
			context.Set<TestAllFieldType>().ToList()[2].FieldNChar.Should().Be("C");
			context.Set<TestAllFieldType>().ToList()[2].FieldNText.Should().Be("C");
			context.Set<TestAllFieldType>().ToList()[2].FieldNumeric.Should().Be(3m);
			context.Set<TestAllFieldType>().ToList()[2].FieldNVarchar.Should().Be("C");
			context.Set<TestAllFieldType>().ToList()[2].FieldReal.Should().Be(3m);
			context.Set<TestAllFieldType>().ToList()[2].FieldSmallDateTime.Should().Be(DateTime.Parse("1/1/1989 12:00:00 AM"));
			context.Set<TestAllFieldType>().ToList()[2].FieldSmallInt.Should().Be(3);
			context.Set<TestAllFieldType>().ToList()[2].FieldSmallMoney.Should().Be(3m);
			context.Set<TestAllFieldType>().ToList()[2].FieldText.Should().Be("C");
			context.Set<TestAllFieldType>().ToList()[2].FieldTime.Should().Be(TimeSpan.Parse("03:00:00"));
			context.Set<TestAllFieldType>().ToList()[2].FieldTimestamp.Should().BeEquivalentTo(BitConverter.GetBytes(3));
			context.Set<TestAllFieldType>().ToList()[2].FieldTinyInt.Should().Be(3);
			context.Set<TestAllFieldType>().ToList()[2].FieldUniqueIdentifier.Should().Be(Guid.Parse("8d721ec8-4c9d-632f-6f06-7f89cc14862c"));
			context.Set<TestAllFieldType>().ToList()[2].FieldVarBinary.Should().BeEquivalentTo(BitConverter.GetBytes(3));
			context.Set<TestAllFieldType>().ToList()[2].FieldVarchar.Should().Be("C");
			context.Set<TestAllFieldType>().ToList()[2].FieldVariant.Should().Be("C");
			context.Set<TestAllFieldType>().ToList()[2].FieldXML.Should().Be("C");
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

			var model = new ApiTestAllFieldTypeClientRequestModel();
			model.SetProperties(2, BitConverter.GetBytes(2), true, "B", DateTime.Parse("1/1/1988 12:00:00 AM"), DateTime.Parse("1/1/1988 12:00:00 AM"), DateTime.Parse("1/1/1988 12:00:00 AM"), DateTimeOffset.Parse("1/1/1988 12:00:00 AM"), 2m, 2, 2, 2, Guid.Parse("3842cac4-b9a0-8223-0dcc-509a6f75849b"), BitConverter.GetBytes(2), 2m, "B", "B", 2m, "B", 2m, DateTime.Parse("1/1/1988 12:00:00 AM"), 2, 2m, "B", TimeSpan.Parse("02:00:00"), BitConverter.GetBytes(2), 2, Guid.Parse("3842cac4-b9a0-8223-0dcc-509a6f75849b"), BitConverter.GetBytes(2), "B", "B", "B");
			CreateResponse<ApiTestAllFieldTypeClientResponseModel> result = await client.TestAllFieldTypeCreateAsync(model);

			result.Success.Should().BeTrue();
			result.Record.Should().NotBeNull();
			context.Set<TestAllFieldType>().ToList()[1].FieldBigInt.Should().Be(2);
			context.Set<TestAllFieldType>().ToList()[1].FieldBinary.Should().BeEquivalentTo(BitConverter.GetBytes(2));
			context.Set<TestAllFieldType>().ToList()[1].FieldBit.Should().Be(true);
			context.Set<TestAllFieldType>().ToList()[1].FieldChar.Should().Be("B");
			context.Set<TestAllFieldType>().ToList()[1].FieldDate.Should().Be(DateTime.Parse("1/1/1988 12:00:00 AM"));
			context.Set<TestAllFieldType>().ToList()[1].FieldDateTime.Should().Be(DateTime.Parse("1/1/1988 12:00:00 AM"));
			context.Set<TestAllFieldType>().ToList()[1].FieldDateTime2.Should().Be(DateTime.Parse("1/1/1988 12:00:00 AM"));
			context.Set<TestAllFieldType>().ToList()[1].FieldDateTimeOffset.Should().Be(DateTimeOffset.Parse("1/1/1988 12:00:00 AM"));
			context.Set<TestAllFieldType>().ToList()[1].FieldDecimal.Should().Be(2m);
			context.Set<TestAllFieldType>().ToList()[1].FieldFloat.Should().Be(2);
			context.Set<TestAllFieldType>().ToList()[1].FieldGeography.Should().Be(2);
			context.Set<TestAllFieldType>().ToList()[1].FieldGeometry.Should().Be(2);
			context.Set<TestAllFieldType>().ToList()[1].FieldHierarchyId.Should().Be(Guid.Parse("3842cac4-b9a0-8223-0dcc-509a6f75849b"));
			context.Set<TestAllFieldType>().ToList()[1].FieldImage.Should().BeEquivalentTo(BitConverter.GetBytes(2));
			context.Set<TestAllFieldType>().ToList()[1].FieldMoney.Should().Be(2m);
			context.Set<TestAllFieldType>().ToList()[1].FieldNChar.Should().Be("B");
			context.Set<TestAllFieldType>().ToList()[1].FieldNText.Should().Be("B");
			context.Set<TestAllFieldType>().ToList()[1].FieldNumeric.Should().Be(2m);
			context.Set<TestAllFieldType>().ToList()[1].FieldNVarchar.Should().Be("B");
			context.Set<TestAllFieldType>().ToList()[1].FieldReal.Should().Be(2m);
			context.Set<TestAllFieldType>().ToList()[1].FieldSmallDateTime.Should().Be(DateTime.Parse("1/1/1988 12:00:00 AM"));
			context.Set<TestAllFieldType>().ToList()[1].FieldSmallInt.Should().Be(2);
			context.Set<TestAllFieldType>().ToList()[1].FieldSmallMoney.Should().Be(2m);
			context.Set<TestAllFieldType>().ToList()[1].FieldText.Should().Be("B");
			context.Set<TestAllFieldType>().ToList()[1].FieldTime.Should().Be(TimeSpan.Parse("02:00:00"));
			context.Set<TestAllFieldType>().ToList()[1].FieldTimestamp.Should().BeEquivalentTo(BitConverter.GetBytes(2));
			context.Set<TestAllFieldType>().ToList()[1].FieldTinyInt.Should().Be(2);
			context.Set<TestAllFieldType>().ToList()[1].FieldUniqueIdentifier.Should().Be(Guid.Parse("3842cac4-b9a0-8223-0dcc-509a6f75849b"));
			context.Set<TestAllFieldType>().ToList()[1].FieldVarBinary.Should().BeEquivalentTo(BitConverter.GetBytes(2));
			context.Set<TestAllFieldType>().ToList()[1].FieldVarchar.Should().Be("B");
			context.Set<TestAllFieldType>().ToList()[1].FieldVariant.Should().Be("B");
			context.Set<TestAllFieldType>().ToList()[1].FieldXML.Should().Be("B");

			result.Record.FieldBigInt.Should().Be(2);
			result.Record.FieldBinary.Should().BeEquivalentTo(BitConverter.GetBytes(2));
			result.Record.FieldBit.Should().Be(true);
			result.Record.FieldChar.Should().Be("B");
			result.Record.FieldDate.Should().Be(DateTime.Parse("1/1/1988 12:00:00 AM"));
			result.Record.FieldDateTime.Should().Be(DateTime.Parse("1/1/1988 12:00:00 AM"));
			result.Record.FieldDateTime2.Should().Be(DateTime.Parse("1/1/1988 12:00:00 AM"));
			result.Record.FieldDateTimeOffset.Should().Be(DateTimeOffset.Parse("1/1/1988 12:00:00 AM"));
			result.Record.FieldDecimal.Should().Be(2m);
			result.Record.FieldFloat.Should().Be(2);
			result.Record.FieldGeography.Should().Be(2);
			result.Record.FieldGeometry.Should().Be(2);
			result.Record.FieldHierarchyId.Should().Be(Guid.Parse("3842cac4-b9a0-8223-0dcc-509a6f75849b"));
			result.Record.FieldImage.Should().BeEquivalentTo(BitConverter.GetBytes(2));
			result.Record.FieldMoney.Should().Be(2m);
			result.Record.FieldNChar.Should().Be("B");
			result.Record.FieldNText.Should().Be("B");
			result.Record.FieldNumeric.Should().Be(2m);
			result.Record.FieldNVarchar.Should().Be("B");
			result.Record.FieldReal.Should().Be(2m);
			result.Record.FieldSmallDateTime.Should().Be(DateTime.Parse("1/1/1988 12:00:00 AM"));
			result.Record.FieldSmallInt.Should().Be(2);
			result.Record.FieldSmallMoney.Should().Be(2m);
			result.Record.FieldText.Should().Be("B");
			result.Record.FieldTime.Should().Be(TimeSpan.Parse("02:00:00"));
			result.Record.FieldTimestamp.Should().BeEquivalentTo(BitConverter.GetBytes(2));
			result.Record.FieldTinyInt.Should().Be(2);
			result.Record.FieldUniqueIdentifier.Should().Be(Guid.Parse("3842cac4-b9a0-8223-0dcc-509a6f75849b"));
			result.Record.FieldVarBinary.Should().BeEquivalentTo(BitConverter.GetBytes(2));
			result.Record.FieldVarchar.Should().Be("B");
			result.Record.FieldVariant.Should().Be("B");
			result.Record.FieldXML.Should().Be("B");
		}

		[Fact]
		public virtual async void TestUpdate()
		{
			var builder = new WebHostBuilder()
			              .UseEnvironment("Production")
			              .UseStartup<TestStartup>();
			TestServer testServer = new TestServer(builder);

			var client = new ApiClient(testServer.CreateClient());
			var mapper = new ApiTestAllFieldTypeServerModelMapper();
			ApplicationDbContext context = testServer.Host.Services.GetService(typeof(ApplicationDbContext)) as ApplicationDbContext;
			ITestAllFieldTypeService service = testServer.Host.Services.GetService(typeof(ITestAllFieldTypeService)) as ITestAllFieldTypeService;
			ApiTestAllFieldTypeServerResponseModel model = await service.Get(1);

			ApiTestAllFieldTypeClientRequestModel request = mapper.MapServerResponseToClientRequest(model);
			request.SetProperties(2, BitConverter.GetBytes(2), true, "B", DateTime.Parse("1/1/1988 12:00:00 AM"), DateTime.Parse("1/1/1988 12:00:00 AM"), DateTime.Parse("1/1/1988 12:00:00 AM"), DateTimeOffset.Parse("1/1/1988 12:00:00 AM"), 2m, 2, 2, 2, Guid.Parse("3842cac4-b9a0-8223-0dcc-509a6f75849b"), BitConverter.GetBytes(2), 2m, "B", "B", 2m, "B", 2m, DateTime.Parse("1/1/1988 12:00:00 AM"), 2, 2m, "B", TimeSpan.Parse("02:00:00"), BitConverter.GetBytes(2), 2, Guid.Parse("3842cac4-b9a0-8223-0dcc-509a6f75849b"), BitConverter.GetBytes(2), "B", "B", "B");

			UpdateResponse<ApiTestAllFieldTypeClientResponseModel> updateResponse = await client.TestAllFieldTypeUpdateAsync(model.Id, request);

			context.Entry(context.Set<TestAllFieldType>().ToList()[0]).Reload();
			updateResponse.Record.Should().NotBeNull();
			updateResponse.Success.Should().BeTrue();
			updateResponse.Record.Id.Should().Be(1);
			context.Set<TestAllFieldType>().ToList()[0].FieldBigInt.Should().Be(2);
			context.Set<TestAllFieldType>().ToList()[0].FieldBinary.Should().BeEquivalentTo(BitConverter.GetBytes(2));
			context.Set<TestAllFieldType>().ToList()[0].FieldBit.Should().Be(true);
			context.Set<TestAllFieldType>().ToList()[0].FieldChar.Should().Be("B");
			context.Set<TestAllFieldType>().ToList()[0].FieldDate.Should().Be(DateTime.Parse("1/1/1988 12:00:00 AM"));
			context.Set<TestAllFieldType>().ToList()[0].FieldDateTime.Should().Be(DateTime.Parse("1/1/1988 12:00:00 AM"));
			context.Set<TestAllFieldType>().ToList()[0].FieldDateTime2.Should().Be(DateTime.Parse("1/1/1988 12:00:00 AM"));
			context.Set<TestAllFieldType>().ToList()[0].FieldDateTimeOffset.Should().Be(DateTimeOffset.Parse("1/1/1988 12:00:00 AM"));
			context.Set<TestAllFieldType>().ToList()[0].FieldDecimal.Should().Be(2m);
			context.Set<TestAllFieldType>().ToList()[0].FieldFloat.Should().Be(2);
			context.Set<TestAllFieldType>().ToList()[0].FieldGeography.Should().Be(2);
			context.Set<TestAllFieldType>().ToList()[0].FieldGeometry.Should().Be(2);
			context.Set<TestAllFieldType>().ToList()[0].FieldHierarchyId.Should().Be(Guid.Parse("3842cac4-b9a0-8223-0dcc-509a6f75849b"));
			context.Set<TestAllFieldType>().ToList()[0].FieldImage.Should().BeEquivalentTo(BitConverter.GetBytes(2));
			context.Set<TestAllFieldType>().ToList()[0].FieldMoney.Should().Be(2m);
			context.Set<TestAllFieldType>().ToList()[0].FieldNChar.Should().Be("B");
			context.Set<TestAllFieldType>().ToList()[0].FieldNText.Should().Be("B");
			context.Set<TestAllFieldType>().ToList()[0].FieldNumeric.Should().Be(2m);
			context.Set<TestAllFieldType>().ToList()[0].FieldNVarchar.Should().Be("B");
			context.Set<TestAllFieldType>().ToList()[0].FieldReal.Should().Be(2m);
			context.Set<TestAllFieldType>().ToList()[0].FieldSmallDateTime.Should().Be(DateTime.Parse("1/1/1988 12:00:00 AM"));
			context.Set<TestAllFieldType>().ToList()[0].FieldSmallInt.Should().Be(2);
			context.Set<TestAllFieldType>().ToList()[0].FieldSmallMoney.Should().Be(2m);
			context.Set<TestAllFieldType>().ToList()[0].FieldText.Should().Be("B");
			context.Set<TestAllFieldType>().ToList()[0].FieldTime.Should().Be(TimeSpan.Parse("02:00:00"));
			context.Set<TestAllFieldType>().ToList()[0].FieldTimestamp.Should().BeEquivalentTo(BitConverter.GetBytes(2));
			context.Set<TestAllFieldType>().ToList()[0].FieldTinyInt.Should().Be(2);
			context.Set<TestAllFieldType>().ToList()[0].FieldUniqueIdentifier.Should().Be(Guid.Parse("3842cac4-b9a0-8223-0dcc-509a6f75849b"));
			context.Set<TestAllFieldType>().ToList()[0].FieldVarBinary.Should().BeEquivalentTo(BitConverter.GetBytes(2));
			context.Set<TestAllFieldType>().ToList()[0].FieldVarchar.Should().Be("B");
			context.Set<TestAllFieldType>().ToList()[0].FieldVariant.Should().Be("B");
			context.Set<TestAllFieldType>().ToList()[0].FieldXML.Should().Be("B");

			updateResponse.Record.Id.Should().Be(1);
			updateResponse.Record.FieldBigInt.Should().Be(2);
			updateResponse.Record.FieldBinary.Should().BeEquivalentTo(BitConverter.GetBytes(2));
			updateResponse.Record.FieldBit.Should().Be(true);
			updateResponse.Record.FieldChar.Should().Be("B");
			updateResponse.Record.FieldDate.Should().Be(DateTime.Parse("1/1/1988 12:00:00 AM"));
			updateResponse.Record.FieldDateTime.Should().Be(DateTime.Parse("1/1/1988 12:00:00 AM"));
			updateResponse.Record.FieldDateTime2.Should().Be(DateTime.Parse("1/1/1988 12:00:00 AM"));
			updateResponse.Record.FieldDateTimeOffset.Should().Be(DateTimeOffset.Parse("1/1/1988 12:00:00 AM"));
			updateResponse.Record.FieldDecimal.Should().Be(2m);
			updateResponse.Record.FieldFloat.Should().Be(2);
			updateResponse.Record.FieldGeography.Should().Be(2);
			updateResponse.Record.FieldGeometry.Should().Be(2);
			updateResponse.Record.FieldHierarchyId.Should().Be(Guid.Parse("3842cac4-b9a0-8223-0dcc-509a6f75849b"));
			updateResponse.Record.FieldImage.Should().BeEquivalentTo(BitConverter.GetBytes(2));
			updateResponse.Record.FieldMoney.Should().Be(2m);
			updateResponse.Record.FieldNChar.Should().Be("B");
			updateResponse.Record.FieldNText.Should().Be("B");
			updateResponse.Record.FieldNumeric.Should().Be(2m);
			updateResponse.Record.FieldNVarchar.Should().Be("B");
			updateResponse.Record.FieldReal.Should().Be(2m);
			updateResponse.Record.FieldSmallDateTime.Should().Be(DateTime.Parse("1/1/1988 12:00:00 AM"));
			updateResponse.Record.FieldSmallInt.Should().Be(2);
			updateResponse.Record.FieldSmallMoney.Should().Be(2m);
			updateResponse.Record.FieldText.Should().Be("B");
			updateResponse.Record.FieldTime.Should().Be(TimeSpan.Parse("02:00:00"));
			updateResponse.Record.FieldTimestamp.Should().BeEquivalentTo(BitConverter.GetBytes(2));
			updateResponse.Record.FieldTinyInt.Should().Be(2);
			updateResponse.Record.FieldUniqueIdentifier.Should().Be(Guid.Parse("3842cac4-b9a0-8223-0dcc-509a6f75849b"));
			updateResponse.Record.FieldVarBinary.Should().BeEquivalentTo(BitConverter.GetBytes(2));
			updateResponse.Record.FieldVarchar.Should().Be("B");
			updateResponse.Record.FieldVariant.Should().Be("B");
			updateResponse.Record.FieldXML.Should().Be("B");
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

			ITestAllFieldTypeService service = testServer.Host.Services.GetService(typeof(ITestAllFieldTypeService)) as ITestAllFieldTypeService;
			var model = new ApiTestAllFieldTypeServerRequestModel();
			model.SetProperties(2, BitConverter.GetBytes(2), true, "B", DateTime.Parse("1/1/1988 12:00:00 AM"), DateTime.Parse("1/1/1988 12:00:00 AM"), DateTime.Parse("1/1/1988 12:00:00 AM"), DateTimeOffset.Parse("1/1/1988 12:00:00 AM"), 2m, 2, 2, 2, Guid.Parse("3842cac4-b9a0-8223-0dcc-509a6f75849b"), BitConverter.GetBytes(2), 2m, "B", "B", 2m, "B", 2m, DateTime.Parse("1/1/1988 12:00:00 AM"), 2, 2m, "B", TimeSpan.Parse("02:00:00"), BitConverter.GetBytes(2), 2, Guid.Parse("3842cac4-b9a0-8223-0dcc-509a6f75849b"), BitConverter.GetBytes(2), "B", "B", "B");
			CreateResponse<ApiTestAllFieldTypeServerResponseModel> createdResponse = await service.Create(model);

			createdResponse.Success.Should().BeTrue();

			ActionResponse deleteResult = await client.TestAllFieldTypeDeleteAsync(2);

			deleteResult.Success.Should().BeTrue();
			ApiTestAllFieldTypeServerResponseModel verifyResponse = await service.Get(2);

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

			ApiTestAllFieldTypeClientResponseModel response = await client.TestAllFieldTypeGetAsync(1);

			response.Should().NotBeNull();
			response.FieldBigInt.Should().Be(1);
			response.FieldBinary.Should().BeEquivalentTo(BitConverter.GetBytes(1));
			response.FieldBit.Should().Be(true);
			response.FieldChar.Should().Be("A");
			response.FieldDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.FieldDateTime.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.FieldDateTime2.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.FieldDateTimeOffset.Should().Be(DateTimeOffset.Parse("1/1/1987 12:00:00 AM"));
			response.FieldDecimal.Should().Be(1m);
			response.FieldFloat.Should().Be(1);
			response.FieldGeography.Should().Be(1);
			response.FieldGeometry.Should().Be(1);
			response.FieldHierarchyId.Should().Be(Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));
			response.FieldImage.Should().BeEquivalentTo(BitConverter.GetBytes(1));
			response.FieldMoney.Should().Be(1m);
			response.FieldNChar.Should().Be("A");
			response.FieldNText.Should().Be("A");
			response.FieldNumeric.Should().Be(1m);
			response.FieldNVarchar.Should().Be("A");
			response.FieldReal.Should().Be(1m);
			response.FieldSmallDateTime.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.FieldSmallInt.Should().Be(1);
			response.FieldSmallMoney.Should().Be(1m);
			response.FieldText.Should().Be("A");
			response.FieldTime.Should().Be(TimeSpan.Parse("01:00:00"));
			response.FieldTimestamp.Should().BeEquivalentTo(BitConverter.GetBytes(1));
			response.FieldTinyInt.Should().Be(1);
			response.FieldUniqueIdentifier.Should().Be(Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));
			response.FieldVarBinary.Should().BeEquivalentTo(BitConverter.GetBytes(1));
			response.FieldVarchar.Should().Be("A");
			response.FieldVariant.Should().Be("A");
			response.FieldXML.Should().Be("A");
			response.Id.Should().Be(1);
		}

		[Fact]
		public virtual async void TestGetNotFound()
		{
			var builder = new WebHostBuilder()
			              .UseEnvironment("Production")
			              .UseStartup<TestStartup>();
			TestServer testServer = new TestServer(builder);

			var client = new ApiClient(testServer.CreateClient());
			ApiTestAllFieldTypeClientResponseModel response = await client.TestAllFieldTypeGetAsync(default(int));

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

			List<ApiTestAllFieldTypeClientResponseModel> response = await client.TestAllFieldTypeAllAsync();

			response.Count.Should().BeGreaterThan(0);
			response[0].FieldBigInt.Should().Be(1);
			response[0].FieldBinary.Should().BeEquivalentTo(BitConverter.GetBytes(1));
			response[0].FieldBit.Should().Be(true);
			response[0].FieldChar.Should().Be("A");
			response[0].FieldDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response[0].FieldDateTime.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response[0].FieldDateTime2.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response[0].FieldDateTimeOffset.Should().Be(DateTimeOffset.Parse("1/1/1987 12:00:00 AM"));
			response[0].FieldDecimal.Should().Be(1m);
			response[0].FieldFloat.Should().Be(1);
			response[0].FieldGeography.Should().Be(1);
			response[0].FieldGeometry.Should().Be(1);
			response[0].FieldHierarchyId.Should().Be(Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));
			response[0].FieldImage.Should().BeEquivalentTo(BitConverter.GetBytes(1));
			response[0].FieldMoney.Should().Be(1m);
			response[0].FieldNChar.Should().Be("A");
			response[0].FieldNText.Should().Be("A");
			response[0].FieldNumeric.Should().Be(1m);
			response[0].FieldNVarchar.Should().Be("A");
			response[0].FieldReal.Should().Be(1m);
			response[0].FieldSmallDateTime.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response[0].FieldSmallInt.Should().Be(1);
			response[0].FieldSmallMoney.Should().Be(1m);
			response[0].FieldText.Should().Be("A");
			response[0].FieldTime.Should().Be(TimeSpan.Parse("01:00:00"));
			response[0].FieldTimestamp.Should().BeEquivalentTo(BitConverter.GetBytes(1));
			response[0].FieldTinyInt.Should().Be(1);
			response[0].FieldUniqueIdentifier.Should().Be(Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));
			response[0].FieldVarBinary.Should().BeEquivalentTo(BitConverter.GetBytes(1));
			response[0].FieldVarchar.Should().Be("A");
			response[0].FieldVariant.Should().Be("A");
			response[0].FieldXML.Should().Be("A");
			response[0].Id.Should().Be(1);
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
				var result = await client.TestAllFieldTypeAllAsync(token);
			};

			testCancellation.Should().Throw<OperationCanceledException>();
		}
	}
}

/*<Codenesium>
    <Hash>059b3b3cc90514888bfdb653a398e4c5</Hash>
</Codenesium>*/