using FluentAssertions;
using PointOfSaleNS.Api.Contracts;
using PointOfSaleNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using Xunit;

namespace PointOfSaleNS.Api.Services
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
			model.SetProperties(1, DateTime.Parse("1/1/1987 12:00:00 AM"));
			Sale response = mapper.MapModelToEntity(1, model);

			response.CustomerId.Should().Be(1);
			response.Date.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
		}

		[Fact]
		public void MapEntityToModel()
		{
			var mapper = new DALSaleMapper();
			Sale item = new Sale();
			item.SetProperties(1, 1, DateTime.Parse("1/1/1987 12:00:00 AM"));
			ApiSaleServerResponseModel response = mapper.MapEntityToModel(item);

			response.CustomerId.Should().Be(1);
			response.Date.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.Id.Should().Be(1);
		}

		[Fact]
		public void MapEntityToModelList()
		{
			var mapper = new DALSaleMapper();
			Sale item = new Sale();
			item.SetProperties(1, 1, DateTime.Parse("1/1/1987 12:00:00 AM"));
			List<ApiSaleServerResponseModel> response = mapper.MapEntityToModel(new List<Sale>() { { item} });

			response.Count.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>1f1979abd8cfeec57c9980dd2eeb0025</Hash>
</Codenesium>*/