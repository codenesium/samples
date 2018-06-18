using System;
using System.Collections.Generic;
using FluentAssertions;
using Xunit;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using OctopusDeployNS.Api.Services;

namespace OctopusDeployNS.Api.Services.Tests
{
        [Trait("Type", "Unit")]
        [Trait("Table", "ProjectGroup")]
        [Trait("Area", "BOLMapper")]
        public class TestBOLProjectGroupActionMapper
        {
                [Fact]
                public void MapModelToBO()
                {
                        var mapper = new BOLProjectGroupMapper();

                        ApiProjectGroupRequestModel model = new ApiProjectGroupRequestModel();

                        model.SetProperties(BitConverter.GetBytes(1), "A", "A");
                        BOProjectGroup response = mapper.MapModelToBO("A", model);

                        response.DataVersion.Should().BeEquivalentTo(BitConverter.GetBytes(1));
                        response.JSON.Should().Be("A");
                        response.Name.Should().Be("A");
                }

                [Fact]
                public void MapBOToModel()
                {
                        var mapper = new BOLProjectGroupMapper();

                        BOProjectGroup bo = new BOProjectGroup();

                        bo.SetProperties("A", BitConverter.GetBytes(1), "A", "A");
                        ApiProjectGroupResponseModel response = mapper.MapBOToModel(bo);

                        response.DataVersion.Should().BeEquivalentTo(BitConverter.GetBytes(1));
                        response.Id.Should().Be("A");
                        response.JSON.Should().Be("A");
                        response.Name.Should().Be("A");
                }

                [Fact]
                public void MapBOToModelList()
                {
                        var mapper = new BOLProjectGroupMapper();

                        BOProjectGroup bo = new BOProjectGroup();

                        bo.SetProperties("A", BitConverter.GetBytes(1), "A", "A");
                        List<ApiProjectGroupResponseModel> response = mapper.MapBOToModel(new List<BOProjectGroup>() { { bo } });

                        response.Count.Should().Be(1);
                }
        }
}

/*<Codenesium>
    <Hash>894b3989d8e194e90ba61151ac9c2e08</Hash>
</Codenesium>*/