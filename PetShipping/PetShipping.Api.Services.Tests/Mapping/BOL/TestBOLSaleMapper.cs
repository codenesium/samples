using FluentAssertions;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
using PetShippingNS.Api.Services;
using System;
using System.Collections.Generic;
using Xunit;

namespace PetShippingNS.Api.Services.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "Sale")]
	[Trait("Area", "BOLMapper")]
	public class TestBOLSaleMapper
	{
		[Fact]
		public void MapModelToBO()
		{
			var mapper = new BOLSaleMapper();
			ApiSaleServerRequestModel model = new ApiSaleServerRequestModel();
			model.SetProperties(1m, 1, "A", 1, DateTime.Parse("1/1/1987 12:00:00 AM"), 1);
			BOSale response = mapper.MapModelToBO(1, model);

			response.Amount.Should().Be(1m);
			response.CutomerId.Should().Be(1);
			response.Note.Should().Be("A");
			response.PetId.Should().Be(1);
			response.SaleDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.SalesPersonId.Should().Be(1);
		}

		[Fact]
		public void MapBOToModel()
		{
			var mapper = new BOLSaleMapper();
			BOSale bo = new BOSale();
			bo.SetProperties(1, 1m, 1, "A", 1, DateTime.Parse("1/1/1987 12:00:00 AM"), 1);
			ApiSaleServerResponseModel response = mapper.MapBOToModel(bo);

			response.Amount.Should().Be(1m);
			response.CutomerId.Should().Be(1);
			response.Id.Should().Be(1);
			response.Note.Should().Be("A");
			response.PetId.Should().Be(1);
			response.SaleDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.SalesPersonId.Should().Be(1);
		}

		[Fact]
		public void MapBOToModelList()
		{
			var mapper = new BOLSaleMapper();
			BOSale bo = new BOSale();
			bo.SetProperties(1, 1m, 1, "A", 1, DateTime.Parse("1/1/1987 12:00:00 AM"), 1);
			List<ApiSaleServerResponseModel> response = mapper.MapBOToModel(new List<BOSale>() { { bo } });

			response.Count.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>ecbbe419803777262bdf58fb5ea8415e</Hash>
</Codenesium>*/