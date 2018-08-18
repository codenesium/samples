using FluentAssertions;
using OctopusDeployNS.Api.DataAccess;
using OctopusDeployNS.Api.Services;
using System;
using System.Collections.Generic;
using Xunit;

namespace OctopusDeployNS.Api.Services.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "ExtensionConfiguration")]
	[Trait("Area", "DALMapper")]
	public class TestDALExtensionConfigurationMapper
	{
		[Fact]
		public void MapBOToEF()
		{
			var mapper = new DALExtensionConfigurationMapper();
			var bo = new BOExtensionConfiguration();
			bo.SetProperties("A", "A", "A", "A");

			ExtensionConfiguration response = mapper.MapBOToEF(bo);

			response.ExtensionAuthor.Should().Be("A");
			response.Id.Should().Be("A");
			response.JSON.Should().Be("A");
			response.Name.Should().Be("A");
		}

		[Fact]
		public void MapEFToBO()
		{
			var mapper = new DALExtensionConfigurationMapper();
			ExtensionConfiguration entity = new ExtensionConfiguration();
			entity.SetProperties("A", "A", "A", "A");

			BOExtensionConfiguration response = mapper.MapEFToBO(entity);

			response.ExtensionAuthor.Should().Be("A");
			response.Id.Should().Be("A");
			response.JSON.Should().Be("A");
			response.Name.Should().Be("A");
		}

		[Fact]
		public void MapEFToBOList()
		{
			var mapper = new DALExtensionConfigurationMapper();
			ExtensionConfiguration entity = new ExtensionConfiguration();
			entity.SetProperties("A", "A", "A", "A");

			List<BOExtensionConfiguration> response = mapper.MapEFToBO(new List<ExtensionConfiguration>() { entity });

			response.Count.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>9e942706edb1c3b786e739032672d178</Hash>
</Codenesium>*/