using FluentAssertions;
using OctopusDeployNS.Api.DataAccess;
using OctopusDeployNS.Api.Services;
using System;
using System.Collections.Generic;
using Xunit;

namespace OctopusDeployNS.Api.Services.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "Invitation")]
	[Trait("Area", "DALMapper")]
	public class TestDALInvitationMapper
	{
		[Fact]
		public void MapBOToEF()
		{
			var mapper = new DALInvitationMapper();
			var bo = new BOInvitation();
			bo.SetProperties("A", "A", "A");

			Invitation response = mapper.MapBOToEF(bo);

			response.Id.Should().Be("A");
			response.InvitationCode.Should().Be("A");
			response.JSON.Should().Be("A");
		}

		[Fact]
		public void MapEFToBO()
		{
			var mapper = new DALInvitationMapper();
			Invitation entity = new Invitation();
			entity.SetProperties("A", "A", "A");

			BOInvitation response = mapper.MapEFToBO(entity);

			response.Id.Should().Be("A");
			response.InvitationCode.Should().Be("A");
			response.JSON.Should().Be("A");
		}

		[Fact]
		public void MapEFToBOList()
		{
			var mapper = new DALInvitationMapper();
			Invitation entity = new Invitation();
			entity.SetProperties("A", "A", "A");

			List<BOInvitation> response = mapper.MapEFToBO(new List<Invitation>() { entity });

			response.Count.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>94136fbf3e129a4ace1967e8398d770a</Hash>
</Codenesium>*/