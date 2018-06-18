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
        [Trait("Table", "Organization")]
        [Trait("Area", "BOLMapper")]
        public class TestBOLOrganizationActionMapper
        {
                [Fact]
                public void MapModelToBO()
                {
                        var mapper = new BOLOrganizationMapper();

                        ApiOrganizationRequestModel model = new ApiOrganizationRequestModel();

                        model.SetProperties("A");
                        BOOrganization response = mapper.MapModelToBO(1, model);

                        response.Name.Should().Be("A");
                }

                [Fact]
                public void MapBOToModel()
                {
                        var mapper = new BOLOrganizationMapper();

                        BOOrganization bo = new BOOrganization();

                        bo.SetProperties(1, "A");
                        ApiOrganizationResponseModel response = mapper.MapBOToModel(bo);

                        response.Id.Should().Be(1);
                        response.Name.Should().Be("A");
                }

                [Fact]
                public void MapBOToModelList()
                {
                        var mapper = new BOLOrganizationMapper();

                        BOOrganization bo = new BOOrganization();

                        bo.SetProperties(1, "A");
                        List<ApiOrganizationResponseModel> response = mapper.MapBOToModel(new List<BOOrganization>() { { bo } });

                        response.Count.Should().Be(1);
                }
        }
}

/*<Codenesium>
    <Hash>077aafc5ece20e43a8cebd320920a571</Hash>
</Codenesium>*/