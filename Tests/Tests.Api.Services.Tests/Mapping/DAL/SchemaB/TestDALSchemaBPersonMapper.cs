using FluentAssertions;
using System;
using System.Collections.Generic;
using TestsNS.Api.DataAccess;
using TestsNS.Api.Services;
using Xunit;

namespace TestsNS.Api.Services.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "SchemaBPerson")]
	[Trait("Area", "DALMapper")]
	public class TestDALSchemaBPersonMapper
	{
		[Fact]
		public void MapBOToEF()
		{
			var mapper = new DALSchemaBPersonMapper();
			var bo = new BOSchemaBPerson();
			bo.SetProperties(1, "A");

			SchemaBPerson response = mapper.MapBOToEF(bo);

			response.Id.Should().Be(1);
			response.Name.Should().Be("A");
		}

		[Fact]
		public void MapEFToBO()
		{
			var mapper = new DALSchemaBPersonMapper();
			SchemaBPerson entity = new SchemaBPerson();
			entity.SetProperties(1, "A");

			BOSchemaBPerson response = mapper.MapEFToBO(entity);

			response.Id.Should().Be(1);
			response.Name.Should().Be("A");
		}

		[Fact]
		public void MapEFToBOList()
		{
			var mapper = new DALSchemaBPersonMapper();
			SchemaBPerson entity = new SchemaBPerson();
			entity.SetProperties(1, "A");

			List<BOSchemaBPerson> response = mapper.MapEFToBO(new List<SchemaBPerson>() { entity });

			response.Count.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>87120be9cc9fb393a881d9e81b3685c7</Hash>
</Codenesium>*/