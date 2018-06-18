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
        [Trait("Table", "DeploymentProcess")]
        [Trait("Area", "BOLMapper")]
        public class TestBOLDeploymentProcessActionMapper
        {
                [Fact]
                public void MapModelToBO()
                {
                        var mapper = new BOLDeploymentProcessMapper();

                        ApiDeploymentProcessRequestModel model = new ApiDeploymentProcessRequestModel();

                        model.SetProperties(true, "A", "A", "A", 1);
                        BODeploymentProcess response = mapper.MapModelToBO("A", model);

                        response.IsFrozen.Should().Be(true);
                        response.JSON.Should().Be("A");
                        response.OwnerId.Should().Be("A");
                        response.RelatedDocumentIds.Should().Be("A");
                        response.Version.Should().Be(1);
                }

                [Fact]
                public void MapBOToModel()
                {
                        var mapper = new BOLDeploymentProcessMapper();

                        BODeploymentProcess bo = new BODeploymentProcess();

                        bo.SetProperties("A", true, "A", "A", "A", 1);
                        ApiDeploymentProcessResponseModel response = mapper.MapBOToModel(bo);

                        response.Id.Should().Be("A");
                        response.IsFrozen.Should().Be(true);
                        response.JSON.Should().Be("A");
                        response.OwnerId.Should().Be("A");
                        response.RelatedDocumentIds.Should().Be("A");
                        response.Version.Should().Be(1);
                }

                [Fact]
                public void MapBOToModelList()
                {
                        var mapper = new BOLDeploymentProcessMapper();

                        BODeploymentProcess bo = new BODeploymentProcess();

                        bo.SetProperties("A", true, "A", "A", "A", 1);
                        List<ApiDeploymentProcessResponseModel> response = mapper.MapBOToModel(new List<BODeploymentProcess>() { { bo } });

                        response.Count.Should().Be(1);
                }
        }
}

/*<Codenesium>
    <Hash>40ab8216c0c7e2e6d3b4854a8cf4fcf8</Hash>
</Codenesium>*/