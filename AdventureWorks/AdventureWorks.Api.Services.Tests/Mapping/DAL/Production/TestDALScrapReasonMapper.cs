using AdventureWorksNS.Api.DataAccess;
using AdventureWorksNS.Api.Services;
using FluentAssertions;
using System;
using System.Collections.Generic;
using Xunit;

namespace AdventureWorksNS.Api.Services.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "ScrapReason")]
	[Trait("Area", "DALMapper")]
	public class TestDALScrapReasonMapper
	{
		[Fact]
		public void MapBOToEF()
		{
			var mapper = new DALScrapReasonMapper();
			var bo = new BOScrapReason();
			bo.SetProperties(1, DateTime.Parse("1/1/1987 12:00:00 AM"), "A");

			ScrapReason response = mapper.MapBOToEF(bo);

			response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.Name.Should().Be("A");
			response.ScrapReasonID.Should().Be(1);
		}

		[Fact]
		public void MapEFToBO()
		{
			var mapper = new DALScrapReasonMapper();
			ScrapReason entity = new ScrapReason();
			entity.SetProperties(DateTime.Parse("1/1/1987 12:00:00 AM"), "A", 1);

			BOScrapReason response = mapper.MapEFToBO(entity);

			response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.Name.Should().Be("A");
			response.ScrapReasonID.Should().Be(1);
		}

		[Fact]
		public void MapEFToBOList()
		{
			var mapper = new DALScrapReasonMapper();
			ScrapReason entity = new ScrapReason();
			entity.SetProperties(DateTime.Parse("1/1/1987 12:00:00 AM"), "A", 1);

			List<BOScrapReason> response = mapper.MapEFToBO(new List<ScrapReason>() { entity });

			response.Count.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>a4263f8c2c1e7c3c17da6597875195e5</Hash>
</Codenesium>*/