using FluentAssertions;
using System;
using System.Collections.Generic;
using TestsNS.Api.Contracts;
using TestsNS.Api.DataAccess;
using Xunit;

namespace TestsNS.Api.Services
{
	[Trait("Type", "Unit")]
	[Trait("Table", "TestAllFieldType")]
	[Trait("Area", "DALMapper")]
	public class TestDALTestAllFieldTypeMapper
	{
		[Fact]
		public void MapModelToEntity()
		{
			var mapper = new DALTestAllFieldTypeMapper();
			ApiTestAllFieldTypeServerRequestModel model = new ApiTestAllFieldTypeServerRequestModel();
			model.SetProperties(1, BitConverter.GetBytes(1), true, "A", DateTime.Parse("1/1/1987 12:00:00 AM"), DateTime.Parse("1/1/1987 12:00:00 AM"), DateTime.Parse("1/1/1987 12:00:00 AM"), DateTimeOffset.Parse("1/1/1987 12:00:00 AM"), 1m, 1, 1, 1, Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"), BitConverter.GetBytes(1), 1m, "A", "A", 1m, "A", 1m, DateTime.Parse("1/1/1987 12:00:00 AM"), 1, 1m, "A", TimeSpan.Parse("01:00:00"), BitConverter.GetBytes(1), 1, Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"), BitConverter.GetBytes(1), "A", "A", "A");
			TestAllFieldType response = mapper.MapModelToEntity(1, model);

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
		}

		[Fact]
		public void MapEntityToModel()
		{
			var mapper = new DALTestAllFieldTypeMapper();
			TestAllFieldType item = new TestAllFieldType();
			item.SetProperties(1, 1, BitConverter.GetBytes(1), true, "A", DateTime.Parse("1/1/1987 12:00:00 AM"), DateTime.Parse("1/1/1987 12:00:00 AM"), DateTime.Parse("1/1/1987 12:00:00 AM"), DateTimeOffset.Parse("1/1/1987 12:00:00 AM"), 1m, 1, 1, 1, Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"), BitConverter.GetBytes(1), 1m, "A", "A", 1m, "A", 1m, DateTime.Parse("1/1/1987 12:00:00 AM"), 1, 1m, "A", TimeSpan.Parse("01:00:00"), BitConverter.GetBytes(1), 1, Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"), BitConverter.GetBytes(1), "A", "A", "A");
			ApiTestAllFieldTypeServerResponseModel response = mapper.MapEntityToModel(item);

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
		public void MapEntityToModelList()
		{
			var mapper = new DALTestAllFieldTypeMapper();
			TestAllFieldType item = new TestAllFieldType();
			item.SetProperties(1, 1, BitConverter.GetBytes(1), true, "A", DateTime.Parse("1/1/1987 12:00:00 AM"), DateTime.Parse("1/1/1987 12:00:00 AM"), DateTime.Parse("1/1/1987 12:00:00 AM"), DateTimeOffset.Parse("1/1/1987 12:00:00 AM"), 1m, 1, 1, 1, Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"), BitConverter.GetBytes(1), 1m, "A", "A", 1m, "A", 1m, DateTime.Parse("1/1/1987 12:00:00 AM"), 1, 1m, "A", TimeSpan.Parse("01:00:00"), BitConverter.GetBytes(1), 1, Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"), BitConverter.GetBytes(1), "A", "A", "A");
			List<ApiTestAllFieldTypeServerResponseModel> response = mapper.MapEntityToModel(new List<TestAllFieldType>() { { item} });

			response.Count.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>21a90935ab723cb65a879837bb675705</Hash>
</Codenesium>*/