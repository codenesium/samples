using AdventureWorksNS.Api.DataAccess;
using AdventureWorksNS.Api.Services;
using FluentAssertions;
using System;
using System.Collections.Generic;
using Xunit;

namespace AdventureWorksNS.Api.Services.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "ProductListPriceHistory")]
	[Trait("Area", "DALMapper")]
	public class TestDALProductListPriceHistoryMapper
	{
		[Fact]
		public void MapBOToEF()
		{
			var mapper = new DALProductListPriceHistoryMapper();
			var bo = new BOProductListPriceHistory();
			bo.SetProperties(1, DateTime.Parse("1/1/1987 12:00:00 AM"), 1m, DateTime.Parse("1/1/1987 12:00:00 AM"), DateTime.Parse("1/1/1987 12:00:00 AM"));

			ProductListPriceHistory response = mapper.MapBOToEF(bo);

			response.EndDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.ListPrice.Should().Be(1m);
			response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.ProductID.Should().Be(1);
			response.StartDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
		}

		[Fact]
		public void MapEFToBO()
		{
			var mapper = new DALProductListPriceHistoryMapper();
			ProductListPriceHistory entity = new ProductListPriceHistory();
			entity.SetProperties(DateTime.Parse("1/1/1987 12:00:00 AM"), 1m, DateTime.Parse("1/1/1987 12:00:00 AM"), 1, DateTime.Parse("1/1/1987 12:00:00 AM"));

			BOProductListPriceHistory response = mapper.MapEFToBO(entity);

			response.EndDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.ListPrice.Should().Be(1m);
			response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.ProductID.Should().Be(1);
			response.StartDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
		}

		[Fact]
		public void MapEFToBOList()
		{
			var mapper = new DALProductListPriceHistoryMapper();
			ProductListPriceHistory entity = new ProductListPriceHistory();
			entity.SetProperties(DateTime.Parse("1/1/1987 12:00:00 AM"), 1m, DateTime.Parse("1/1/1987 12:00:00 AM"), 1, DateTime.Parse("1/1/1987 12:00:00 AM"));

			List<BOProductListPriceHistory> response = mapper.MapEFToBO(new List<ProductListPriceHistory>() { entity });

			response.Count.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>40a304af767ba1320a00f3702c240c04</Hash>
</Codenesium>*/