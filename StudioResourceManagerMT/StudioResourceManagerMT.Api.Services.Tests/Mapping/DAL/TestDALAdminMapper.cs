using FluentAssertions;
using StudioResourceManagerMTNS.Api.DataAccess;
using StudioResourceManagerMTNS.Api.Services;
using System;
using System.Collections.Generic;
using Xunit;

namespace StudioResourceManagerMTNS.Api.Services.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "Admin")]
	[Trait("Area", "DALMapper")]
	public class TestDALAdminMapper
	{
		[Fact]
		public void MapBOToEF()
		{
			var mapper = new DALAdminMapper();
			var bo = new BOAdmin();
			bo.SetProperties(1, DateTime.Parse("1/1/1987 12:00:00 AM"), "A", "A", "A", "A", 1);

			Admin response = mapper.MapBOToEF(bo);

			response.Birthday.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.Email.Should().Be("A");
			response.FirstName.Should().Be("A");
			response.Id.Should().Be(1);
			response.LastName.Should().Be("A");
			response.Phone.Should().Be("A");
			response.UserId.Should().Be(1);
		}

		[Fact]
		public void MapEFToBO()
		{
			var mapper = new DALAdminMapper();
			Admin entity = new Admin();
			entity.SetProperties(DateTime.Parse("1/1/1987 12:00:00 AM"), "A", "A", 1, "A", "A", 1);

			BOAdmin response = mapper.MapEFToBO(entity);

			response.Birthday.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.Email.Should().Be("A");
			response.FirstName.Should().Be("A");
			response.Id.Should().Be(1);
			response.LastName.Should().Be("A");
			response.Phone.Should().Be("A");
			response.UserId.Should().Be(1);
		}

		[Fact]
		public void MapEFToBOList()
		{
			var mapper = new DALAdminMapper();
			Admin entity = new Admin();
			entity.SetProperties(DateTime.Parse("1/1/1987 12:00:00 AM"), "A", "A", 1, "A", "A", 1);

			List<BOAdmin> response = mapper.MapEFToBO(new List<Admin>() { entity });

			response.Count.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>f5bbefaa422455967d3ef531579753dc</Hash>
</Codenesium>*/