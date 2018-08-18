using FluentAssertions;
using System;
using System.Collections.Generic;
using TicketingCRMNS.Api.DataAccess;
using TicketingCRMNS.Api.Services;
using Xunit;

namespace TicketingCRMNS.Api.Services.Tests
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
			bo.SetProperties(1, "A", "A", "A", "A", "A", "A");

			Admin response = mapper.MapBOToEF(bo);

			response.Email.Should().Be("A");
			response.FirstName.Should().Be("A");
			response.Id.Should().Be(1);
			response.LastName.Should().Be("A");
			response.Password.Should().Be("A");
			response.Phone.Should().Be("A");
			response.Username.Should().Be("A");
		}

		[Fact]
		public void MapEFToBO()
		{
			var mapper = new DALAdminMapper();
			Admin entity = new Admin();
			entity.SetProperties("A", "A", 1, "A", "A", "A", "A");

			BOAdmin response = mapper.MapEFToBO(entity);

			response.Email.Should().Be("A");
			response.FirstName.Should().Be("A");
			response.Id.Should().Be(1);
			response.LastName.Should().Be("A");
			response.Password.Should().Be("A");
			response.Phone.Should().Be("A");
			response.Username.Should().Be("A");
		}

		[Fact]
		public void MapEFToBOList()
		{
			var mapper = new DALAdminMapper();
			Admin entity = new Admin();
			entity.SetProperties("A", "A", 1, "A", "A", "A", "A");

			List<BOAdmin> response = mapper.MapEFToBO(new List<Admin>() { entity });

			response.Count.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>af2791017ad856e6f8014af975a98247</Hash>
</Codenesium>*/