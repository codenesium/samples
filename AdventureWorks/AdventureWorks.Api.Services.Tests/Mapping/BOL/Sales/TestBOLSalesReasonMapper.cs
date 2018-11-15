using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using AdventureWorksNS.Api.Services;
using FluentAssertions;
using System;
using System.Collections.Generic;
using Xunit;

namespace AdventureWorksNS.Api.Services.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "SalesReason")]
	[Trait("Area", "BOLMapper")]
	public class TestBOLSalesReasonMapper
	{
		[Fact]
		public void MapModelToBO()
		{
			var mapper = new BOLSalesReasonMapper();
			ApiSalesReasonServerRequestModel model = new ApiSalesReasonServerRequestModel();
			model.SetProperties(DateTime.Parse("1/1/1987 12:00:00 AM"), "A", "A");
			BOSalesReason response = mapper.MapModelToBO(1, model);

			response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.Name.Should().Be("A");
			response.ReasonType.Should().Be("A");
		}

		[Fact]
		public void MapBOToModel()
		{
			var mapper = new BOLSalesReasonMapper();
			BOSalesReason bo = new BOSalesReason();
			bo.SetProperties(1, DateTime.Parse("1/1/1987 12:00:00 AM"), "A", "A");
			ApiSalesReasonServerResponseModel response = mapper.MapBOToModel(bo);

			response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.Name.Should().Be("A");
			response.ReasonType.Should().Be("A");
			response.SalesReasonID.Should().Be(1);
		}

		[Fact]
		public void MapBOToModelList()
		{
			var mapper = new BOLSalesReasonMapper();
			BOSalesReason bo = new BOSalesReason();
			bo.SetProperties(1, DateTime.Parse("1/1/1987 12:00:00 AM"), "A", "A");
			List<ApiSalesReasonServerResponseModel> response = mapper.MapBOToModel(new List<BOSalesReason>() { { bo } });

			response.Count.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>f19bbdf59f226a838a75121f55c5a2c3</Hash>
</Codenesium>*/