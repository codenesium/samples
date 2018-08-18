using AdventureWorksNS.Api.DataAccess;
using AdventureWorksNS.Api.Services;
using FluentAssertions;
using System;
using System.Collections.Generic;
using Xunit;

namespace AdventureWorksNS.Api.Services.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "SalesPersonQuotaHistory")]
	[Trait("Area", "DALMapper")]
	public class TestDALSalesPersonQuotaHistoryMapper
	{
		[Fact]
		public void MapBOToEF()
		{
			var mapper = new DALSalesPersonQuotaHistoryMapper();
			var bo = new BOSalesPersonQuotaHistory();
			bo.SetProperties(1, DateTime.Parse("1/1/1987 12:00:00 AM"), DateTime.Parse("1/1/1987 12:00:00 AM"), Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"), 1m);

			SalesPersonQuotaHistory response = mapper.MapBOToEF(bo);

			response.BusinessEntityID.Should().Be(1);
			response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.QuotaDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.Rowguid.Should().Be(Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));
			response.SalesQuota.Should().Be(1m);
		}

		[Fact]
		public void MapEFToBO()
		{
			var mapper = new DALSalesPersonQuotaHistoryMapper();
			SalesPersonQuotaHistory entity = new SalesPersonQuotaHistory();
			entity.SetProperties(1, DateTime.Parse("1/1/1987 12:00:00 AM"), DateTime.Parse("1/1/1987 12:00:00 AM"), Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"), 1m);

			BOSalesPersonQuotaHistory response = mapper.MapEFToBO(entity);

			response.BusinessEntityID.Should().Be(1);
			response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.QuotaDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.Rowguid.Should().Be(Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));
			response.SalesQuota.Should().Be(1m);
		}

		[Fact]
		public void MapEFToBOList()
		{
			var mapper = new DALSalesPersonQuotaHistoryMapper();
			SalesPersonQuotaHistory entity = new SalesPersonQuotaHistory();
			entity.SetProperties(1, DateTime.Parse("1/1/1987 12:00:00 AM"), DateTime.Parse("1/1/1987 12:00:00 AM"), Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"), 1m);

			List<BOSalesPersonQuotaHistory> response = mapper.MapEFToBO(new List<SalesPersonQuotaHistory>() { entity });

			response.Count.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>4b385d2cceaaf003f1e673e1dedf251b</Hash>
</Codenesium>*/