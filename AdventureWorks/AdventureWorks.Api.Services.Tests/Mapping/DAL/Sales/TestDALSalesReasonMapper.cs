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
	[Trait("Area", "DALMapper")]
	public class TestDALSalesReasonMapper
	{
		[Fact]
		public void MapBOToEF()
		{
			var mapper = new DALSalesReasonMapper();
			var bo = new BOSalesReason();
			bo.SetProperties(1, DateTime.Parse("1/1/1987 12:00:00 AM"), "A", "A");

			SalesReason response = mapper.MapBOToEF(bo);

			response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.Name.Should().Be("A");
			response.ReasonType.Should().Be("A");
			response.SalesReasonID.Should().Be(1);
		}

		[Fact]
		public void MapEFToBO()
		{
			var mapper = new DALSalesReasonMapper();
			SalesReason entity = new SalesReason();
			entity.SetProperties(DateTime.Parse("1/1/1987 12:00:00 AM"), "A", "A", 1);

			BOSalesReason response = mapper.MapEFToBO(entity);

			response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.Name.Should().Be("A");
			response.ReasonType.Should().Be("A");
			response.SalesReasonID.Should().Be(1);
		}

		[Fact]
		public void MapEFToBOList()
		{
			var mapper = new DALSalesReasonMapper();
			SalesReason entity = new SalesReason();
			entity.SetProperties(DateTime.Parse("1/1/1987 12:00:00 AM"), "A", "A", 1);

			List<BOSalesReason> response = mapper.MapEFToBO(new List<SalesReason>() { entity });

			response.Count.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>3ffb51e80feaa9ee8196fadf77ff0e7b</Hash>
</Codenesium>*/