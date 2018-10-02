using FluentAssertions;
using System;
using System.Collections.Generic;
using TestsNS.Api.DataAccess;
using TestsNS.Api.Services;
using Xunit;

namespace TestsNS.Api.Services.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "CompositePrimaryKey")]
	[Trait("Area", "DALMapper")]
	public class TestDALCompositePrimaryKeyMapper
	{
		[Fact]
		public void MapBOToEF()
		{
			var mapper = new DALCompositePrimaryKeyMapper();
			var bo = new BOCompositePrimaryKey();
			bo.SetProperties(1, 1);

			CompositePrimaryKey response = mapper.MapBOToEF(bo);

			response.Id.Should().Be(1);
			response.Id2.Should().Be(1);
		}

		[Fact]
		public void MapEFToBO()
		{
			var mapper = new DALCompositePrimaryKeyMapper();
			CompositePrimaryKey entity = new CompositePrimaryKey();
			entity.SetProperties(1, 1);

			BOCompositePrimaryKey response = mapper.MapEFToBO(entity);

			response.Id.Should().Be(1);
			response.Id2.Should().Be(1);
		}

		[Fact]
		public void MapEFToBOList()
		{
			var mapper = new DALCompositePrimaryKeyMapper();
			CompositePrimaryKey entity = new CompositePrimaryKey();
			entity.SetProperties(1, 1);

			List<BOCompositePrimaryKey> response = mapper.MapEFToBO(new List<CompositePrimaryKey>() { entity });

			response.Count.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>937317373b359a83bceff7509a6330b9</Hash>
</Codenesium>*/