using FluentAssertions;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using TestsNS.Api.Contracts;
using Xunit;

namespace TestsNS.Api.Contracts.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "TestAllFieldType")]
	[Trait("Area", "ApiModel")]
	public class TestApiTestAllFieldTypeModelMapper
	{
		[Fact]
		public void MapRequestToResponse()
		{
			var mapper = new ApiTestAllFieldTypeModelMapper();
			var model = new ApiTestAllFieldTypeRequestModel();
			model.SetProperties(1, BitConverter.GetBytes(1), true, "A", DateTime.Parse("1/1/1987 12:00:00 AM"), DateTime.Parse("1/1/1987 12:00:00 AM"), DateTime.Parse("1/1/1987 12:00:00 AM"), DateTimeOffset.Parse("1/1/1987 12:00:00 AM"), 1, 1, BitConverter.GetBytes(1), 1m, "A", "A", 1m, "A", 1m, DateTime.Parse("1/1/1987 12:00:00 AM"), 1, 1m, "A", TimeSpan.Parse("0"), BitConverter.GetBytes(1), 1, Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"), BitConverter.GetBytes(1), "A", "A");
			ApiTestAllFieldTypeResponseModel response = mapper.MapRequestToResponse(1, model);

			response.FieldBigInt.Should().Be(1);
			response.FieldBinary.Should().BeEquivalentTo(BitConverter.GetBytes(1));
			response.FieldBit.Should().Be(true);
			response.FieldChar.Should().Be("A");
			response.FieldDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.FieldDateTime.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.FieldDateTime2.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.FieldDateTimeOffset.Should().Be(DateTimeOffset.Parse("1/1/1987 12:00:00 AM"));
			response.FieldDecimal.Should().Be(1);
			response.FieldFloat.Should().Be(1);
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
			response.FieldTime.Should().Be(TimeSpan.Parse("0"));
			response.FieldTimestamp.Should().BeEquivalentTo(BitConverter.GetBytes(1));
			response.FieldTinyInt.Should().Be(1);
			response.FieldUniqueIdentifier.Should().Be(Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));
			response.FieldVarBinary.Should().BeEquivalentTo(BitConverter.GetBytes(1));
			response.FieldVarchar.Should().Be("A");
			response.FieldXML.Should().Be("A");
			response.Id.Should().Be(1);
		}

		[Fact]
		public void MapResponseToRequest()
		{
			var mapper = new ApiTestAllFieldTypeModelMapper();
			var model = new ApiTestAllFieldTypeResponseModel();
			model.SetProperties(1, 1, BitConverter.GetBytes(1), true, "A", DateTime.Parse("1/1/1987 12:00:00 AM"), DateTime.Parse("1/1/1987 12:00:00 AM"), DateTime.Parse("1/1/1987 12:00:00 AM"), DateTimeOffset.Parse("1/1/1987 12:00:00 AM"), 1, 1, BitConverter.GetBytes(1), 1m, "A", "A", 1m, "A", 1m, DateTime.Parse("1/1/1987 12:00:00 AM"), 1, 1m, "A", TimeSpan.Parse("0"), BitConverter.GetBytes(1), 1, Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"), BitConverter.GetBytes(1), "A", "A");
			ApiTestAllFieldTypeRequestModel response = mapper.MapResponseToRequest(model);

			response.FieldBigInt.Should().Be(1);
			response.FieldBinary.Should().BeEquivalentTo(BitConverter.GetBytes(1));
			response.FieldBit.Should().Be(true);
			response.FieldChar.Should().Be("A");
			response.FieldDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.FieldDateTime.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.FieldDateTime2.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.FieldDateTimeOffset.Should().Be(DateTimeOffset.Parse("1/1/1987 12:00:00 AM"));
			response.FieldDecimal.Should().Be(1);
			response.FieldFloat.Should().Be(1);
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
			response.FieldTime.Should().Be(TimeSpan.Parse("0"));
			response.FieldTimestamp.Should().BeEquivalentTo(BitConverter.GetBytes(1));
			response.FieldTinyInt.Should().Be(1);
			response.FieldUniqueIdentifier.Should().Be(Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));
			response.FieldVarBinary.Should().BeEquivalentTo(BitConverter.GetBytes(1));
			response.FieldVarchar.Should().Be("A");
			response.FieldXML.Should().Be("A");
		}

		[Fact]
		public void CreatePatch()
		{
			var mapper = new ApiTestAllFieldTypeModelMapper();
			var model = new ApiTestAllFieldTypeRequestModel();
			model.SetProperties(1, BitConverter.GetBytes(1), true, "A", DateTime.Parse("1/1/1987 12:00:00 AM"), DateTime.Parse("1/1/1987 12:00:00 AM"), DateTime.Parse("1/1/1987 12:00:00 AM"), DateTimeOffset.Parse("1/1/1987 12:00:00 AM"), 1, 1, BitConverter.GetBytes(1), 1m, "A", "A", 1m, "A", 1m, DateTime.Parse("1/1/1987 12:00:00 AM"), 1, 1m, "A", TimeSpan.Parse("0"), BitConverter.GetBytes(1), 1, Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"), BitConverter.GetBytes(1), "A", "A");

			JsonPatchDocument<ApiTestAllFieldTypeRequestModel> patch = mapper.CreatePatch(model);
			var response = new ApiTestAllFieldTypeRequestModel();
			patch.ApplyTo(response);
			response.FieldBigInt.Should().Be(1);
			response.FieldBinary.Should().BeEquivalentTo(BitConverter.GetBytes(1));
			response.FieldBit.Should().Be(true);
			response.FieldChar.Should().Be("A");
			response.FieldDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.FieldDateTime.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.FieldDateTime2.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.FieldDateTimeOffset.Should().Be(DateTimeOffset.Parse("1/1/1987 12:00:00 AM"));
			response.FieldDecimal.Should().Be(1);
			response.FieldFloat.Should().Be(1);
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
			response.FieldTime.Should().Be(TimeSpan.Parse("0"));
			response.FieldTimestamp.Should().BeEquivalentTo(BitConverter.GetBytes(1));
			response.FieldTinyInt.Should().Be(1);
			response.FieldUniqueIdentifier.Should().Be(Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));
			response.FieldVarBinary.Should().BeEquivalentTo(BitConverter.GetBytes(1));
			response.FieldVarchar.Should().Be("A");
			response.FieldXML.Should().Be("A");
		}
	}
}

/*<Codenesium>
    <Hash>da6d5e3bfb44fa96d0bf38938134253c</Hash>
</Codenesium>*/