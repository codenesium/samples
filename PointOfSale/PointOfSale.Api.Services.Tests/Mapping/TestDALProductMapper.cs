using FluentAssertions;
using PointOfSaleNS.Api.Contracts;
using PointOfSaleNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using Xunit;

namespace PointOfSaleNS.Api.Services
{
	[Trait("Type", "Unit")]
	[Trait("Table", "Product")]
	[Trait("Area", "DALMapper")]
	public class TestDALProductMapper
	{
		[Fact]
		public void MapModelToEntity()
		{
			var mapper = new DALProductMapper();
			ApiProductServerRequestModel model = new ApiProductServerRequestModel();
			model.SetProperties(true, "A", "A", 1m, 1);
			Product response = mapper.MapModelToEntity(1, model);

			response.Active.Should().Be(true);
			response.Description.Should().Be("A");
			response.Name.Should().Be("A");
			response.Price.Should().Be(1m);
			response.Quantity.Should().Be(1);
		}

		[Fact]
		public void MapEntityToModel()
		{
			var mapper = new DALProductMapper();
			Product item = new Product();
			item.SetProperties(1, true, "A", "A", 1m, 1);
			ApiProductServerResponseModel response = mapper.MapEntityToModel(item);

			response.Active.Should().Be(true);
			response.Description.Should().Be("A");
			response.Id.Should().Be(1);
			response.Name.Should().Be("A");
			response.Price.Should().Be(1m);
			response.Quantity.Should().Be(1);
		}

		[Fact]
		public void MapEntityToModelList()
		{
			var mapper = new DALProductMapper();
			Product item = new Product();
			item.SetProperties(1, true, "A", "A", 1m, 1);
			List<ApiProductServerResponseModel> response = mapper.MapEntityToModel(new List<Product>() { { item} });

			response.Count.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>6b66747db29b0e75fd6ab0bde89cb4aa</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/