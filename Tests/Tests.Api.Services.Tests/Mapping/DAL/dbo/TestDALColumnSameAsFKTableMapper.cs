using FluentAssertions;
using System;
using System.Collections.Generic;
using TestsNS.Api.DataAccess;
using TestsNS.Api.Services;
using Xunit;

namespace TestsNS.Api.Services.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "ColumnSameAsFKTable")]
	[Trait("Area", "DALMapper")]
	public class TestDALColumnSameAsFKTableMapper
	{
		[Fact]
		public void MapBOToEF()
		{
			var mapper = new DALColumnSameAsFKTableMapper();
			var bo = new BOColumnSameAsFKTable();
			bo.SetProperties(1, 1, 1);

			ColumnSameAsFKTable response = mapper.MapBOToEF(bo);

			response.Id.Should().Be(1);
			response.Person.Should().Be(1);
			response.PersonId.Should().Be(1);
		}

		[Fact]
		public void MapEFToBO()
		{
			var mapper = new DALColumnSameAsFKTableMapper();
			ColumnSameAsFKTable entity = new ColumnSameAsFKTable();
			entity.SetProperties(1, 1, 1);

			BOColumnSameAsFKTable response = mapper.MapEFToBO(entity);

			response.Id.Should().Be(1);
			response.Person.Should().Be(1);
			response.PersonId.Should().Be(1);
		}

		[Fact]
		public void MapEFToBOList()
		{
			var mapper = new DALColumnSameAsFKTableMapper();
			ColumnSameAsFKTable entity = new ColumnSameAsFKTable();
			entity.SetProperties(1, 1, 1);

			List<BOColumnSameAsFKTable> response = mapper.MapEFToBO(new List<ColumnSameAsFKTable>() { entity });

			response.Count.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>0d498d989fae0cb7c6cd3141de28f2bb</Hash>
</Codenesium>*/