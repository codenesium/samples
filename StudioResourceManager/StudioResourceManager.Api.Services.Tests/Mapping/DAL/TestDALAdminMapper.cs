using FluentAssertions;
using StudioResourceManagerNS.Api.DataAccess;
using StudioResourceManagerNS.Api.Services;
using System;
using System.Collections.Generic;
using Xunit;

namespace StudioResourceManagerNS.Api.Services.Tests
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
			bo.SetProperties(1, DateTime.Parse("1/1/1987 12:00:00 AM"), "A", "A", "A", "A", 1, true);

			Admin response = mapper.MapBOToEF(bo);

			response.Birthday.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.Email.Should().Be("A");
			response.FirstName.Should().Be("A");
			response.Id.Should().Be(1);
			response.LastName.Should().Be("A");
			response.Phone.Should().Be("A");
			response.UserId.Should().Be(1);
			response.IsDeleted.Should().Be(true);
		}

		[Fact]
		public void MapEFToBO()
		{
			var mapper = new DALAdminMapper();
			Admin entity = new Admin();
			entity.SetProperties(DateTime.Parse("1/1/1987 12:00:00 AM"), "A", "A", 1, "A", "A", 1, true);

			BOAdmin response = mapper.MapEFToBO(entity);

			response.Birthday.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.Email.Should().Be("A");
			response.FirstName.Should().Be("A");
			response.Id.Should().Be(1);
			response.LastName.Should().Be("A");
			response.Phone.Should().Be("A");
			response.UserId.Should().Be(1);
			response.IsDeleted.Should().Be(true);
		}

		[Fact]
		public void MapEFToBOList()
		{
			var mapper = new DALAdminMapper();
			Admin entity = new Admin();
			entity.SetProperties(DateTime.Parse("1/1/1987 12:00:00 AM"), "A", "A", 1, "A", "A", 1, true);

			List<BOAdmin> response = mapper.MapEFToBO(new List<Admin>() { entity });

			response.Count.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>02d69b9824e61da95b2ee78c77ec4000</Hash>
</Codenesium>*/