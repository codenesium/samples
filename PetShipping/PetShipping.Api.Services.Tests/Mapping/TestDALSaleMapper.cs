using FluentAssertions;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using Xunit;

namespace PetShippingNS.Api.Services
{
	[Trait("Type", "Unit")]
	[Trait("Table", "Sale")]
	[Trait("Area", "DALMapper")]
	public class TestDALSaleMapper
	{
		[Fact]
		public void MapModelToEntity()
		{
			var mapper = new DALSaleMapper();
			ApiSaleServerRequestModel model = new ApiSaleServerRequestModel();
			model.SetProperties(1m, 1, "A", 1, DateTime.Parse("1/1/1987 12:00:00 AM"), 1);
			Sale response = mapper.MapModelToEntity(1, model);

			response.Amount.Should().Be(1m);
			response.CutomerId.Should().Be(1);
			response.Note.Should().Be("A");
			response.PetId.Should().Be(1);
			response.SaleDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.SalesPersonId.Should().Be(1);
		}

		[Fact]
		public void MapEntityToModel()
		{
			var mapper = new DALSaleMapper();
			Sale item = new Sale();
			item.SetProperties(1, 1m, 1, "A", 1, DateTime.Parse("1/1/1987 12:00:00 AM"), 1);
			ApiSaleServerResponseModel response = mapper.MapEntityToModel(item);

			response.Amount.Should().Be(1m);
			response.CutomerId.Should().Be(1);
			response.Id.Should().Be(1);
			response.Note.Should().Be("A");
			response.PetId.Should().Be(1);
			response.SaleDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.SalesPersonId.Should().Be(1);
		}

		[Fact]
		public void MapEntityToModelList()
		{
			var mapper = new DALSaleMapper();
			Sale item = new Sale();
			item.SetProperties(1, 1m, 1, "A", 1, DateTime.Parse("1/1/1987 12:00:00 AM"), 1);
			List<ApiSaleServerResponseModel> response = mapper.MapEntityToModel(new List<Sale>() { { item} });

			response.Count.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>25cc03c65f95514208733a4f1ad6d400</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/