using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using FluentAssertions;
using System;
using System.Collections.Generic;
using Xunit;

namespace AdventureWorksNS.Api.Services
{
	[Trait("Type", "Unit")]
	[Trait("Table", "BillOfMaterial")]
	[Trait("Area", "DALMapper")]
	public class TestDALBillOfMaterialMapper
	{
		[Fact]
		public void MapModelToEntity()
		{
			var mapper = new DALBillOfMaterialMapper();
			ApiBillOfMaterialServerRequestModel model = new ApiBillOfMaterialServerRequestModel();
			model.SetProperties(1, 1, DateTime.Parse("1/1/1987 12:00:00 AM"), DateTime.Parse("1/1/1987 12:00:00 AM"), 1, 1, DateTime.Parse("1/1/1987 12:00:00 AM"), "A");
			BillOfMaterial response = mapper.MapModelToEntity(1, model);

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
		public void MapEntityToModel()
		{
			var mapper = new DALBillOfMaterialMapper();
			BillOfMaterial item = new BillOfMaterial();
			item.SetProperties(1, 1, 1, DateTime.Parse("1/1/1987 12:00:00 AM"), DateTime.Parse("1/1/1987 12:00:00 AM"), 1, 1, DateTime.Parse("1/1/1987 12:00:00 AM"), "A");
			ApiBillOfMaterialServerResponseModel response = mapper.MapEntityToModel(item);

			response.BillOfMaterialsID.Should().Be(1);
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
		public void MapEntityToModelList()
		{
			var mapper = new DALBillOfMaterialMapper();
			BillOfMaterial item = new BillOfMaterial();
			item.SetProperties(1, 1, 1, DateTime.Parse("1/1/1987 12:00:00 AM"), DateTime.Parse("1/1/1987 12:00:00 AM"), 1, 1, DateTime.Parse("1/1/1987 12:00:00 AM"), "A");
			List<ApiBillOfMaterialServerResponseModel> response = mapper.MapEntityToModel(new List<BillOfMaterial>() { { item} });

			response.Count.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>67b283d623810ea8fcfeab0da82cb6e9</Hash>
</Codenesium>*/