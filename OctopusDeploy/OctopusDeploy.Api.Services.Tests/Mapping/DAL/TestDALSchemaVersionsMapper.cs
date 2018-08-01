using FluentAssertions;
using OctopusDeployNS.Api.DataAccess;
using OctopusDeployNS.Api.Services;
using System;
using System.Collections.Generic;
using Xunit;

namespace OctopusDeployNS.Api.Services.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "SchemaVersions")]
	[Trait("Area", "DALMapper")]
	public class TestDALSchemaVersionsMapper
	{
		[Fact]
		public void MapBOToEF()
		{
			var mapper = new DALSchemaVersionsMapper();
			var bo = new BOSchemaVersions();
			bo.SetProperties(1, DateTime.Parse("1/1/1987 12:00:00 AM"), "A");

			SchemaVersions response = mapper.MapBOToEF(bo);

			response.Applied.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.Id.Should().Be(1);
			response.ScriptName.Should().Be("A");
		}

		[Fact]
		public void MapEFToBO()
		{
			var mapper = new DALSchemaVersionsMapper();
			SchemaVersions entity = new SchemaVersions();
			entity.SetProperties(DateTime.Parse("1/1/1987 12:00:00 AM"), 1, "A");

			BOSchemaVersions response = mapper.MapEFToBO(entity);

			response.Applied.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.Id.Should().Be(1);
			response.ScriptName.Should().Be("A");
		}

		[Fact]
		public void MapEFToBOList()
		{
			var mapper = new DALSchemaVersionsMapper();
			SchemaVersions entity = new SchemaVersions();
			entity.SetProperties(DateTime.Parse("1/1/1987 12:00:00 AM"), 1, "A");

			List<BOSchemaVersions> response = mapper.MapEFToBO(new List<SchemaVersions>() { entity });

			response.Count.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>606aa1fb17e0282e90920bb10f8400fb</Hash>
</Codenesium>*/