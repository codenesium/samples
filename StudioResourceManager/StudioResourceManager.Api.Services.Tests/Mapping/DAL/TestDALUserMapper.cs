using FluentAssertions;
using StudioResourceManagerNS.Api.DataAccess;
using StudioResourceManagerNS.Api.Services;
using System;
using System.Collections.Generic;
using Xunit;

namespace StudioResourceManagerNS.Api.Services.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "User")]
	[Trait("Area", "DALMapper")]
	public class TestDALUserMapper
	{
		[Fact]
		public void MapBOToEF()
		{
			var mapper = new DALUserMapper();
			var bo = new BOUser();
			bo.SetProperties(1, "A", "A", true);

			User response = mapper.MapBOToEF(bo);

			response.Id.Should().Be(1);
			response.Password.Should().Be("A");
			response.Username.Should().Be("A");
			response.IsDeleted.Should().Be(true);
		}

		[Fact]
		public void MapEFToBO()
		{
			var mapper = new DALUserMapper();
			User entity = new User();
			entity.SetProperties(1, "A", "A", true);

			BOUser response = mapper.MapEFToBO(entity);

			response.Id.Should().Be(1);
			response.Password.Should().Be("A");
			response.Username.Should().Be("A");
			response.IsDeleted.Should().Be(true);
		}

		[Fact]
		public void MapEFToBOList()
		{
			var mapper = new DALUserMapper();
			User entity = new User();
			entity.SetProperties(1, "A", "A", true);

			List<BOUser> response = mapper.MapEFToBO(new List<User>() { entity });

			response.Count.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>2ad4a230e803a378bc3554fec3dd4535</Hash>
</Codenesium>*/