using System;
using System.Collections.Generic;
using FluentAssertions;
using Xunit;
using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;
using NebulaNS.Api.Services;

namespace NebulaNS.Api.Services.Tests
{
    [Trait("Type", "Unit")]
    [Trait("Table", "Team")]
    [Trait("Area", "BOLMapper")]
    public class TestBOLTeamMapper
    {
        [Fact]
        public void MapModelToBO()
        {
            var mapper = new BOLTeamMapper();
            ApiTeamRequestModel model = new ApiTeamRequestModel();
            model.SetProperties("A",1);
            BOTeam response = mapper.MapModelToBO(1, model);

           response.Name.Should().Be("A");
response.OrganizationId.Should().Be(1);

        }

        [Fact]
        public void MapBOToModel()
        {
            var mapper = new BOLTeamMapper();
            BOTeam bo = new BOTeam();
            bo.SetProperties(1,"A",1);
            ApiTeamResponseModel response = mapper.MapBOToModel(bo);

           response.Id.Should().Be(1);
response.Name.Should().Be("A");
response.OrganizationId.Should().Be(1);

        }

        [Fact]
        public void MapBOToModelList()
        {
            var mapper = new BOLTeamMapper();
            BOTeam bo = new BOTeam();
            bo.SetProperties(1,"A",1);
            List<ApiTeamResponseModel> response = mapper.MapBOToModel(new List<BOTeam>() { { bo } });

			response.Count.Should().Be(1);
        }
    }
}

/*<Codenesium>
    <Hash>375b97959de9bafbe95c74b6abf68656</Hash>
</Codenesium>*/