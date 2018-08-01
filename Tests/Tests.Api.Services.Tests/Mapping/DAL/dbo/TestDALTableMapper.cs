using FluentAssertions;
using System;
using System.Collections.Generic;
using TestsNS.Api.DataAccess;
using TestsNS.Api.Services;
using Xunit;

namespace TestsNS.Api.Services.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "Table")]
	[Trait("Area", "DALMapper")]
	public class TestDALTableMapper
	{
		[Fact]
		public void MapBOToEF()
		{
			var mapper = new DALTableMapper();
			var bo = new BOTable();
			bo.SetProperties(1, "A");

			Table response = mapper.MapBOToEF(bo);

			response.Id.Should().Be(1);
			response.Name.Should().Be("A");
		}

		[Fact]
		public void MapEFToBO()
		{
			var mapper = new DALTableMapper();
			Table entity = new Table();
			entity.SetProperties(1, "A");

			BOTable response = mapper.MapEFToBO(entity);

			response.Id.Should().Be(1);
			response.Name.Should().Be("A");
		}

		[Fact]
		public void MapEFToBOList()
		{
			var mapper = new DALTableMapper();
			Table entity = new Table();
			entity.SetProperties(1, "A");

			List<BOTable> response = mapper.MapEFToBO(new List<Table>() { entity });

			response.Count.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>cfbd9cf7a1ecbb1319b84de5ed819a2f</Hash>
</Codenesium>*/