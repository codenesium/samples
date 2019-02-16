using FluentAssertions;
using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using Xunit;

namespace NebulaNS.Api.Services
{
	[Trait("Type", "Unit")]
	[Trait("Table", "Team")]
	[Trait("Area", "DALMapper")]
	public class TestDALTeamMapper
	{
		[Fact]
		public void MapModelToEntity()
		{
			var mapper = new DALTeamMapper();
			ApiTeamServerRequestModel model = new ApiTeamServerRequestModel();
			model.SetProperties("A", 1);
			Team response = mapper.MapModelToEntity(1, model);

			response.Name.Should().Be("A");
			response.OrganizationId.Should().Be(1);
		}

		[Fact]
		public void MapEntityToModel()
		{
			var mapper = new DALTeamMapper();
			Team item = new Team();
			item.SetProperties(1, "A", 1);
			ApiTeamServerResponseModel response = mapper.MapEntityToModel(item);

			response.Id.Should().Be(1);
			response.Name.Should().Be("A");
			response.OrganizationId.Should().Be(1);
		}

		[Fact]
		public void MapEntityToModelList()
		{
			var mapper = new DALTeamMapper();
			Team item = new Team();
			item.SetProperties(1, "A", 1);
			List<ApiTeamServerResponseModel> response = mapper.MapEntityToModel(new List<Team>() { { item} });

			response.Count.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>23a5f22d2d6836791abd13d81209a21f</Hash>
</Codenesium>*/