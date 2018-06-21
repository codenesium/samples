using FluentAssertions;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using OctopusDeployNS.Api.Services;
using System;
using System.Collections.Generic;
using Xunit;

namespace OctopusDeployNS.Api.Services.Tests
{
        [Trait("Type", "Unit")]
        [Trait("Table", "ProjectTrigger")]
        [Trait("Area", "BOLMapper")]
        public class TestBOLProjectTriggerMapper
        {
                [Fact]
                public void MapModelToBO()
                {
                        var mapper = new BOLProjectTriggerMapper();
                        ApiProjectTriggerRequestModel model = new ApiProjectTriggerRequestModel();
                        model.SetProperties(true, "A", "A", "A", "A");
                        BOProjectTrigger response = mapper.MapModelToBO("A", model);

                        response.IsDisabled.Should().Be(true);
                        response.JSON.Should().Be("A");
                        response.Name.Should().Be("A");
                        response.ProjectId.Should().Be("A");
                        response.TriggerType.Should().Be("A");
                }

                [Fact]
                public void MapBOToModel()
                {
                        var mapper = new BOLProjectTriggerMapper();
                        BOProjectTrigger bo = new BOProjectTrigger();
                        bo.SetProperties("A", true, "A", "A", "A", "A");
                        ApiProjectTriggerResponseModel response = mapper.MapBOToModel(bo);

                        response.Id.Should().Be("A");
                        response.IsDisabled.Should().Be(true);
                        response.JSON.Should().Be("A");
                        response.Name.Should().Be("A");
                        response.ProjectId.Should().Be("A");
                        response.TriggerType.Should().Be("A");
                }

                [Fact]
                public void MapBOToModelList()
                {
                        var mapper = new BOLProjectTriggerMapper();
                        BOProjectTrigger bo = new BOProjectTrigger();
                        bo.SetProperties("A", true, "A", "A", "A", "A");
                        List<ApiProjectTriggerResponseModel> response = mapper.MapBOToModel(new List<BOProjectTrigger>() { { bo } });

                        response.Count.Should().Be(1);
                }
        }
}

/*<Codenesium>
    <Hash>3e77a6b22ab8bb8c8004a0a1081e77b1</Hash>
</Codenesium>*/