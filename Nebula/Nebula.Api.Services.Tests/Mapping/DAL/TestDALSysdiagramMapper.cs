using FluentAssertions;
using NebulaNS.Api.DataAccess;
using NebulaNS.Api.Services;
using System;
using System.Collections.Generic;
using Xunit;

namespace NebulaNS.Api.Services.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "Sysdiagram")]
	[Trait("Area", "DALMapper")]
	public class TestDALSysdiagramMapper
	{
		[Fact]
		public void MapBOToEF()
		{
			var mapper = new DALSysdiagramMapper();
			var bo = new BOSysdiagram();
			bo.SetProperties(1, BitConverter.GetBytes(1), "A", 1, 1);

			Sysdiagram response = mapper.MapBOToEF(bo);

			response.Definition.Should().BeEquivalentTo(BitConverter.GetBytes(1));
			response.DiagramId.Should().Be(1);
			response.Name.Should().Be("A");
			response.PrincipalId.Should().Be(1);
			response.Version.Should().Be(1);
		}

		[Fact]
		public void MapEFToBO()
		{
			var mapper = new DALSysdiagramMapper();
			Sysdiagram entity = new Sysdiagram();
			entity.SetProperties(BitConverter.GetBytes(1), 1, "A", 1, 1);

			BOSysdiagram response = mapper.MapEFToBO(entity);

			response.Definition.Should().BeEquivalentTo(BitConverter.GetBytes(1));
			response.DiagramId.Should().Be(1);
			response.Name.Should().Be("A");
			response.PrincipalId.Should().Be(1);
			response.Version.Should().Be(1);
		}

		[Fact]
		public void MapEFToBOList()
		{
			var mapper = new DALSysdiagramMapper();
			Sysdiagram entity = new Sysdiagram();
			entity.SetProperties(BitConverter.GetBytes(1), 1, "A", 1, 1);

			List<BOSysdiagram> response = mapper.MapEFToBO(new List<Sysdiagram>() { entity });

			response.Count.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>f9f998fc509164a3be7da17904d65761</Hash>
</Codenesium>*/