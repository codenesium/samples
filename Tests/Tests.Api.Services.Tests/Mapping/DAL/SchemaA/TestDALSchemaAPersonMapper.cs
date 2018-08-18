using FluentAssertions;
using System;
using System.Collections.Generic;
using TestsNS.Api.DataAccess;
using TestsNS.Api.Services;
using Xunit;

namespace TestsNS.Api.Services.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "SchemaAPerson")]
	[Trait("Area", "DALMapper")]
	public class TestDALSchemaAPersonMapper
	{
		[Fact]
		public void MapBOToEF()
		{
			var mapper = new DALSchemaAPersonMapper();
			var bo = new BOSchemaAPerson();
			bo.SetProperties(1, "A");

			SchemaAPerson response = mapper.MapBOToEF(bo);

			response.Id.Should().Be(1);
			response.Name.Should().Be("A");
		}

		[Fact]
		public void MapEFToBO()
		{
			var mapper = new DALSchemaAPersonMapper();
			SchemaAPerson entity = new SchemaAPerson();
			entity.SetProperties(1, "A");

			BOSchemaAPerson response = mapper.MapEFToBO(entity);

			response.Id.Should().Be(1);
			response.Name.Should().Be("A");
		}

		[Fact]
		public void MapEFToBOList()
		{
			var mapper = new DALSchemaAPersonMapper();
			SchemaAPerson entity = new SchemaAPerson();
			entity.SetProperties(1, "A");

			List<BOSchemaAPerson> response = mapper.MapEFToBO(new List<SchemaAPerson>() { entity });

			response.Count.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>976392f2e576f6e84342e633a9063701</Hash>
</Codenesium>*/