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
	[Trait("Table", "ProductCostHistory")]
	[Trait("Area", "BOLMapper")]
	public class TestBOLProductCostHistoryMapper
	{
		[Fact]
		public void MapModelToBO()
		{
			var mapper = new BOLProductCostHistoryMapper();
			ApiProductCostHistoryRequestModel model = new ApiProductCostHistoryRequestModel();
			model.SetProperties(DateTime.Parse("1/1/1987 12:00:00 AM"), DateTime.Parse("1/1/1987 12:00:00 AM"), 1m, DateTime.Parse("1/1/1987 12:00:00 AM"));
			BOProductCostHistory response = mapper.MapModelToBO(1, model);

			response.EndDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.StandardCost.Should().Be(1m);
			response.StartDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
		}

		[Fact]
		public void MapBOToModel()
		{
			var mapper = new BOLProductCostHistoryMapper();
			BOProductCostHistory bo = new BOProductCostHistory();
			bo.SetProperties(1, DateTime.Parse("1/1/1987 12:00:00 AM"), DateTime.Parse("1/1/1987 12:00:00 AM"), 1m, DateTime.Parse("1/1/1987 12:00:00 AM"));
			ApiProductCostHistoryResponseModel response = mapper.MapBOToModel(bo);

			response.EndDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.ProductID.Should().Be(1);
			response.StandardCost.Should().Be(1m);
			response.StartDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
		}

		[Fact]
		public void MapBOToModelList()
		{
			var mapper = new BOLProductCostHistoryMapper();
			BOProductCostHistory bo = new BOProductCostHistory();
			bo.SetProperties(1, DateTime.Parse("1/1/1987 12:00:00 AM"), DateTime.Parse("1/1/1987 12:00:00 AM"), 1m, DateTime.Parse("1/1/1987 12:00:00 AM"));
			List<ApiProductCostHistoryResponseModel> response = mapper.MapBOToModel(new List<BOProductCostHistory>() { { bo } });

			response.Count.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>178599ec84245b960b302d7b30c10b4d</Hash>
</Codenesium>*/