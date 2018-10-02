using FluentAssertions;
using StudioResourceManagerNS.Api.DataAccess;
using StudioResourceManagerNS.Api.Services;
using System;
using System.Collections.Generic;
using Xunit;

namespace StudioResourceManagerNS.Api.Services.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "Tenant")]
	[Trait("Area", "DALMapper")]
	public class TestDALTenantMapper
	{
		[Fact]
		public void MapBOToEF()
		{
			var mapper = new DALTenantMapper();
			var bo = new BOTenant();
			bo.SetProperties(1, "A");

			Tenant response = mapper.MapBOToEF(bo);

			response.Id.Should().Be(1);
			response.Name.Should().Be("A");
		}

		[Fact]
		public void MapEFToBO()
		{
			var mapper = new DALTenantMapper();
			Tenant entity = new Tenant();
			entity.SetProperties(1, "A");

			BOTenant response = mapper.MapEFToBO(entity);

			response.Id.Should().Be(1);
			response.Name.Should().Be("A");
		}

		[Fact]
		public void MapEFToBOList()
		{
			var mapper = new DALTenantMapper();
			Tenant entity = new Tenant();
			entity.SetProperties(1, "A");

			List<BOTenant> response = mapper.MapEFToBO(new List<Tenant>() { entity });

			response.Count.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>a596a3d76aabbfa7d6363859dad87592</Hash>
</Codenesium>*/