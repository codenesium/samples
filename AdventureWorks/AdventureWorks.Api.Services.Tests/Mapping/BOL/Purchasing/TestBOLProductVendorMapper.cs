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
	[Trait("Table", "ProductVendor")]
	[Trait("Area", "BOLMapper")]
	public class TestBOLProductVendorMapper
	{
		[Fact]
		public void MapModelToBO()
		{
			var mapper = new BOLProductVendorMapper();
			ApiProductVendorRequestModel model = new ApiProductVendorRequestModel();
			model.SetProperties(1, 1, 1m, DateTime.Parse("1/1/1987 12:00:00 AM"), 1, 1, DateTime.Parse("1/1/1987 12:00:00 AM"), 1, 1m, "A");
			BOProductVendor response = mapper.MapModelToBO(1, model);

			response.AverageLeadTime.Should().Be(1);
			response.BusinessEntityID.Should().Be(1);
			response.LastReceiptCost.Should().Be(1m);
			response.LastReceiptDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.MaxOrderQty.Should().Be(1);
			response.MinOrderQty.Should().Be(1);
			response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.OnOrderQty.Should().Be(1);
			response.StandardPrice.Should().Be(1m);
			response.UnitMeasureCode.Should().Be("A");
		}

		[Fact]
		public void MapBOToModel()
		{
			var mapper = new BOLProductVendorMapper();
			BOProductVendor bo = new BOProductVendor();
			bo.SetProperties(1, 1, 1, 1m, DateTime.Parse("1/1/1987 12:00:00 AM"), 1, 1, DateTime.Parse("1/1/1987 12:00:00 AM"), 1, 1m, "A");
			ApiProductVendorResponseModel response = mapper.MapBOToModel(bo);

			response.AverageLeadTime.Should().Be(1);
			response.BusinessEntityID.Should().Be(1);
			response.LastReceiptCost.Should().Be(1m);
			response.LastReceiptDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.MaxOrderQty.Should().Be(1);
			response.MinOrderQty.Should().Be(1);
			response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.OnOrderQty.Should().Be(1);
			response.ProductID.Should().Be(1);
			response.StandardPrice.Should().Be(1m);
			response.UnitMeasureCode.Should().Be("A");
		}

		[Fact]
		public void MapBOToModelList()
		{
			var mapper = new BOLProductVendorMapper();
			BOProductVendor bo = new BOProductVendor();
			bo.SetProperties(1, 1, 1, 1m, DateTime.Parse("1/1/1987 12:00:00 AM"), 1, 1, DateTime.Parse("1/1/1987 12:00:00 AM"), 1, 1m, "A");
			List<ApiProductVendorResponseModel> response = mapper.MapBOToModel(new List<BOProductVendor>() { { bo } });

			response.Count.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>023b41ce17fb60073372babdaccaeb42</Hash>
</Codenesium>*/