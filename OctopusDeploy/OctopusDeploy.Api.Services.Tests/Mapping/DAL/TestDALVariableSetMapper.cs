using FluentAssertions;
using OctopusDeployNS.Api.DataAccess;
using OctopusDeployNS.Api.Services;
using System;
using System.Collections.Generic;
using Xunit;

namespace OctopusDeployNS.Api.Services.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "VariableSet")]
	[Trait("Area", "DALMapper")]
	public class TestDALVariableSetMapper
	{
		[Fact]
		public void MapBOToEF()
		{
			var mapper = new DALVariableSetMapper();
			var bo = new BOVariableSet();
			bo.SetProperties("A", true, "A", "A", "A", 1);

			VariableSet response = mapper.MapBOToEF(bo);

			response.Id.Should().Be("A");
			response.IsFrozen.Should().Be(true);
			response.JSON.Should().Be("A");
			response.OwnerId.Should().Be("A");
			response.RelatedDocumentIds.Should().Be("A");
			response.Version.Should().Be(1);
		}

		[Fact]
		public void MapEFToBO()
		{
			var mapper = new DALVariableSetMapper();
			VariableSet entity = new VariableSet();
			entity.SetProperties("A", true, "A", "A", "A", 1);

			BOVariableSet response = mapper.MapEFToBO(entity);

			response.Id.Should().Be("A");
			response.IsFrozen.Should().Be(true);
			response.JSON.Should().Be("A");
			response.OwnerId.Should().Be("A");
			response.RelatedDocumentIds.Should().Be("A");
			response.Version.Should().Be(1);
		}

		[Fact]
		public void MapEFToBOList()
		{
			var mapper = new DALVariableSetMapper();
			VariableSet entity = new VariableSet();
			entity.SetProperties("A", true, "A", "A", "A", 1);

			List<BOVariableSet> response = mapper.MapEFToBO(new List<VariableSet>() { entity });

			response.Count.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>1c99d490b381fa40f8925242099be169</Hash>
</Codenesium>*/