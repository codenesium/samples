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
        [Trait("Table", "DeploymentEnvironment")]
        [Trait("Area", "BOLMapper")]
        public class TestBOLDeploymentEnvironmentActionMapper
        {
                [Fact]
                public void MapModelToBO()
                {
                        var mapper = new BOLDeploymentEnvironmentMapper();

                        ApiDeploymentEnvironmentRequestModel model = new ApiDeploymentEnvironmentRequestModel();

                        model.SetProperties(BitConverter.GetBytes(1), "A", "A", 1);
                        BODeploymentEnvironment response = mapper.MapModelToBO("A", model);

                        response.DataVersion.Should().BeEquivalentTo(BitConverter.GetBytes(1));
                        response.JSON.Should().Be("A");
                        response.Name.Should().Be("A");
                        response.SortOrder.Should().Be(1);
                }

                [Fact]
                public void MapBOToModel()
                {
                        var mapper = new BOLDeploymentEnvironmentMapper();

                        BODeploymentEnvironment bo = new BODeploymentEnvironment();

                        bo.SetProperties("A", BitConverter.GetBytes(1), "A", "A", 1);
                        ApiDeploymentEnvironmentResponseModel response = mapper.MapBOToModel(bo);

                        response.DataVersion.Should().BeEquivalentTo(BitConverter.GetBytes(1));
                        response.Id.Should().Be("A");
                        response.JSON.Should().Be("A");
                        response.Name.Should().Be("A");
                        response.SortOrder.Should().Be(1);
                }

                [Fact]
                public void MapBOToModelList()
                {
                        var mapper = new BOLDeploymentEnvironmentMapper();

                        BODeploymentEnvironment bo = new BODeploymentEnvironment();

                        bo.SetProperties("A", BitConverter.GetBytes(1), "A", "A", 1);
                        List<ApiDeploymentEnvironmentResponseModel> response = mapper.MapBOToModel(new List<BODeploymentEnvironment>() { { bo } });

                        response.Count.Should().Be(1);
                }
        }
}

/*<Codenesium>
    <Hash>8f01ec399a4ef9a65fd77b8d6041e89d</Hash>
</Codenesium>*/