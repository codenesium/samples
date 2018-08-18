using FluentAssertions;
using OctopusDeployNS.Api.DataAccess;
using OctopusDeployNS.Api.Services;
using System;
using System.Collections.Generic;
using Xunit;

namespace OctopusDeployNS.Api.Services.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "Configuration")]
	[Trait("Area", "DALMapper")]
	public class TestDALConfigurationMapper
	{
		[Fact]
		public void MapBOToEF()
		{
			var mapper = new DALConfigurationMapper();
			var bo = new BOConfiguration();
			bo.SetProperties("A", "A");

			Configuration response = mapper.MapBOToEF(bo);

			response.Id.Should().Be("A");
			response.JSON.Should().Be("A");
		}

		[Fact]
		public void MapEFToBO()
		{
			var mapper = new DALConfigurationMapper();
			Configuration entity = new Configuration();
			entity.SetProperties("A", "A");

			BOConfiguration response = mapper.MapEFToBO(entity);

			response.Id.Should().Be("A");
			response.JSON.Should().Be("A");
		}

		[Fact]
		public void MapEFToBOList()
		{
			var mapper = new DALConfigurationMapper();
			Configuration entity = new Configuration();
			entity.SetProperties("A", "A");

			List<BOConfiguration> response = mapper.MapEFToBO(new List<Configuration>() { entity });

			response.Count.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>8cb5982ed52201301596fa02ab755782</Hash>
</Codenesium>*/