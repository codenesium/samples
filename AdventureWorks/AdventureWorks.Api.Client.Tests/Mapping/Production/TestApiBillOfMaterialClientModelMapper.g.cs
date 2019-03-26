using FluentAssertions;
using System;
using System.Collections.Generic;
using Xunit;

namespace AdventureWorksNS.Api.Client.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "BillOfMaterial")]
	[Trait("Area", "ApiModel")]
	public class TestApiBillOfMaterialModelMapper
	{
		[Fact]
		public void MapClientRequestToResponse()
		{
			var mapper = new ApiBillOfMaterialModelMapper();
			var model = new ApiBillOfMaterialClientRequestModel();
			model.SetProperties(1, 1, DateTime.Parse("1/1/1987 12:00:00 AM"), DateTime.Parse("1/1/1987 12:00:00 AM"), 1, 1, DateTime.Parse("1/1/1987 12:00:00 AM"), "A");
			ApiBillOfMaterialClientResponseModel response = mapper.MapClientRequestToResponse(1, model);
			response.Should().NotBeNull();
			response.BOMLevel.Should().Be(1);
			response.ComponentID.Should().Be(1);
			response.EndDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.PerAssemblyQty.Should().Be(1);
			response.ProductAssemblyID.Should().Be(1);
			response.StartDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.UnitMeasureCode.Should().Be("A");
		}

		[Fact]
		public void MapClientResponseToRequest()
		{
			var mapper = new ApiBillOfMaterialModelMapper();
			var model = new ApiBillOfMaterialClientResponseModel();
			model.SetProperties(1, 1, 1, DateTime.Parse("1/1/1987 12:00:00 AM"), DateTime.Parse("1/1/1987 12:00:00 AM"), 1, 1, DateTime.Parse("1/1/1987 12:00:00 AM"), "A");
			ApiBillOfMaterialClientRequestModel response = mapper.MapClientResponseToRequest(model);
			response.Should().NotBeNull();
			response.BOMLevel.Should().Be(1);
			response.ComponentID.Should().Be(1);
			response.EndDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.PerAssemblyQty.Should().Be(1);
			response.ProductAssemblyID.Should().Be(1);
			response.StartDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.UnitMeasureCode.Should().Be("A");
		}
	}
}

/*<Codenesium>
    <Hash>75ee081c7c14d40e9961bff85ce6ad6b</Hash>
</Codenesium>*/