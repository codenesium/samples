using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using FluentAssertions;
using System;
using System.Collections.Generic;
using Xunit;

namespace AdventureWorksNS.Api.Services
{
	[Trait("Type", "Unit")]
	[Trait("Table", "SalesReason")]
	[Trait("Area", "DALMapper")]
	public class TestDALSalesReasonMapper
	{
		[Fact]
		public void MapModelToEntity()
		{
			var mapper = new DALSalesReasonMapper();
			ApiSalesReasonServerRequestModel model = new ApiSalesReasonServerRequestModel();
			model.SetProperties(DateTime.Parse("1/1/1987 12:00:00 AM"), "A", "A");
			SalesReason response = mapper.MapModelToEntity(1, model);

			response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.Name.Should().Be("A");
			response.ReasonType.Should().Be("A");
		}

		[Fact]
		public void MapEntityToModel()
		{
			var mapper = new DALSalesReasonMapper();
			SalesReason item = new SalesReason();
			item.SetProperties(1, DateTime.Parse("1/1/1987 12:00:00 AM"), "A", "A");
			ApiSalesReasonServerResponseModel response = mapper.MapEntityToModel(item);

			response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.Name.Should().Be("A");
			response.ReasonType.Should().Be("A");
			response.SalesReasonID.Should().Be(1);
		}

		[Fact]
		public void MapEntityToModelList()
		{
			var mapper = new DALSalesReasonMapper();
			SalesReason item = new SalesReason();
			item.SetProperties(1, DateTime.Parse("1/1/1987 12:00:00 AM"), "A", "A");
			List<ApiSalesReasonServerResponseModel> response = mapper.MapEntityToModel(new List<SalesReason>() { { item} });

			response.Count.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>b0907c3e164dd057067548d696f25024</Hash>
</Codenesium>*/