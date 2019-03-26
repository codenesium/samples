using FluentAssertions;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using Xunit;

namespace AdventureWorksNS.Api.Services.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "BillOfMaterial")]
	[Trait("Area", "ApiModel")]
	public class TestApiBillOfMaterialServerModelMapper
	{
		[Fact]
		public void MapServerRequestToResponse()
		{
			var mapper = new ApiBillOfMaterialServerModelMapper();
			var model = new ApiBillOfMaterialServerRequestModel();
			model.SetProperties(1, 1, DateTime.Parse("1/1/1987 12:00:00 AM"), DateTime.Parse("1/1/1987 12:00:00 AM"), 1, 1, DateTime.Parse("1/1/1987 12:00:00 AM"), "A");
			ApiBillOfMaterialServerResponseModel response = mapper.MapServerRequestToResponse(1, model);
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
		public void MapServerResponseToRequest()
		{
			var mapper = new ApiBillOfMaterialServerModelMapper();
			var model = new ApiBillOfMaterialServerResponseModel();
			model.SetProperties(1, 1, 1, DateTime.Parse("1/1/1987 12:00:00 AM"), DateTime.Parse("1/1/1987 12:00:00 AM"), 1, 1, DateTime.Parse("1/1/1987 12:00:00 AM"), "A");
			ApiBillOfMaterialServerRequestModel response = mapper.MapServerResponseToRequest(model);
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
		public void CreatePatch()
		{
			var mapper = new ApiBillOfMaterialServerModelMapper();
			var model = new ApiBillOfMaterialServerRequestModel();
			model.SetProperties(1, 1, DateTime.Parse("1/1/1987 12:00:00 AM"), DateTime.Parse("1/1/1987 12:00:00 AM"), 1, 1, DateTime.Parse("1/1/1987 12:00:00 AM"), "A");

			JsonPatchDocument<ApiBillOfMaterialServerRequestModel> patch = mapper.CreatePatch(model);
			var response = new ApiBillOfMaterialServerRequestModel();
			patch.ApplyTo(response);
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
    <Hash>78e14db01ffa3a4fe240b81f3ab8123f</Hash>
</Codenesium>*/