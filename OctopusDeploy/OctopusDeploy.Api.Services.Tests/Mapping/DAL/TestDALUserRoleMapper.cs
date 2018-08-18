using FluentAssertions;
using OctopusDeployNS.Api.DataAccess;
using OctopusDeployNS.Api.Services;
using System;
using System.Collections.Generic;
using Xunit;

namespace OctopusDeployNS.Api.Services.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "UserRole")]
	[Trait("Area", "DALMapper")]
	public class TestDALUserRoleMapper
	{
		[Fact]
		public void MapBOToEF()
		{
			var mapper = new DALUserRoleMapper();
			var bo = new BOUserRole();
			bo.SetProperties("A", "A", "A");

			UserRole response = mapper.MapBOToEF(bo);

			response.Id.Should().Be("A");
			response.JSON.Should().Be("A");
			response.Name.Should().Be("A");
		}

		[Fact]
		public void MapEFToBO()
		{
			var mapper = new DALUserRoleMapper();
			UserRole entity = new UserRole();
			entity.SetProperties("A", "A", "A");

			BOUserRole response = mapper.MapEFToBO(entity);

			response.Id.Should().Be("A");
			response.JSON.Should().Be("A");
			response.Name.Should().Be("A");
		}

		[Fact]
		public void MapEFToBOList()
		{
			var mapper = new DALUserRoleMapper();
			UserRole entity = new UserRole();
			entity.SetProperties("A", "A", "A");

			List<BOUserRole> response = mapper.MapEFToBO(new List<UserRole>() { entity });

			response.Count.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>8ead55af6d04f7e4978e8d365b24cddf</Hash>
</Codenesium>*/