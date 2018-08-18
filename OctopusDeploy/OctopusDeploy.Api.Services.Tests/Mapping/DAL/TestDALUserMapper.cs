using FluentAssertions;
using OctopusDeployNS.Api.DataAccess;
using OctopusDeployNS.Api.Services;
using System;
using System.Collections.Generic;
using Xunit;

namespace OctopusDeployNS.Api.Services.Tests
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
			bo.SetProperties("A", "A", "A", "A", "A", Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"), true, true, "A", "A");

			User response = mapper.MapBOToEF(bo);

			response.DisplayName.Should().Be("A");
			response.EmailAddress.Should().Be("A");
			response.ExternalId.Should().Be("A");
			response.ExternalIdentifiers.Should().Be("A");
			response.Id.Should().Be("A");
			response.IdentificationToken.Should().Be(Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));
			response.IsActive.Should().Be(true);
			response.IsService.Should().Be(true);
			response.JSON.Should().Be("A");
			response.Username.Should().Be("A");
		}

		[Fact]
		public void MapEFToBO()
		{
			var mapper = new DALUserMapper();
			User entity = new User();
			entity.SetProperties("A", "A", "A", "A", "A", Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"), true, true, "A", "A");

			BOUser response = mapper.MapEFToBO(entity);

			response.DisplayName.Should().Be("A");
			response.EmailAddress.Should().Be("A");
			response.ExternalId.Should().Be("A");
			response.ExternalIdentifiers.Should().Be("A");
			response.Id.Should().Be("A");
			response.IdentificationToken.Should().Be(Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));
			response.IsActive.Should().Be(true);
			response.IsService.Should().Be(true);
			response.JSON.Should().Be("A");
			response.Username.Should().Be("A");
		}

		[Fact]
		public void MapEFToBOList()
		{
			var mapper = new DALUserMapper();
			User entity = new User();
			entity.SetProperties("A", "A", "A", "A", "A", Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"), true, true, "A", "A");

			List<BOUser> response = mapper.MapEFToBO(new List<User>() { entity });

			response.Count.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>6348b70eca569e0de8f1036972634650</Hash>
</Codenesium>*/