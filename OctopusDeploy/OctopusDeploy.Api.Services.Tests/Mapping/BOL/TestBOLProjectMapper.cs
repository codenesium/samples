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
        [Trait("Table", "Project")]
        [Trait("Area", "BOLMapper")]
        public class TestBOLProjectMapper
        {
                [Fact]
                public void MapModelToBO()
                {
                        var mapper = new BOLProjectMapper();
                        ApiProjectRequestModel model = new ApiProjectRequestModel();
                        model.SetProperties(true, BitConverter.GetBytes(1), "A", true, "A", true, "A", "A", "A", "A", "A", "A");
                        BOProject response = mapper.MapModelToBO("A", model);

                        response.AutoCreateRelease.Should().Be(true);
                        response.DataVersion.Should().BeEquivalentTo(BitConverter.GetBytes(1));
                        response.DeploymentProcessId.Should().Be("A");
                        response.DiscreteChannelRelease.Should().Be(true);
                        response.IncludedLibraryVariableSetIds.Should().Be("A");
                        response.IsDisabled.Should().Be(true);
                        response.JSON.Should().Be("A");
                        response.LifecycleId.Should().Be("A");
                        response.Name.Should().Be("A");
                        response.ProjectGroupId.Should().Be("A");
                        response.Slug.Should().Be("A");
                        response.VariableSetId.Should().Be("A");
                }

                [Fact]
                public void MapBOToModel()
                {
                        var mapper = new BOLProjectMapper();
                        BOProject bo = new BOProject();
                        bo.SetProperties("A", true, BitConverter.GetBytes(1), "A", true, "A", true, "A", "A", "A", "A", "A", "A");
                        ApiProjectResponseModel response = mapper.MapBOToModel(bo);

                        response.AutoCreateRelease.Should().Be(true);
                        response.DataVersion.Should().BeEquivalentTo(BitConverter.GetBytes(1));
                        response.DeploymentProcessId.Should().Be("A");
                        response.DiscreteChannelRelease.Should().Be(true);
                        response.Id.Should().Be("A");
                        response.IncludedLibraryVariableSetIds.Should().Be("A");
                        response.IsDisabled.Should().Be(true);
                        response.JSON.Should().Be("A");
                        response.LifecycleId.Should().Be("A");
                        response.Name.Should().Be("A");
                        response.ProjectGroupId.Should().Be("A");
                        response.Slug.Should().Be("A");
                        response.VariableSetId.Should().Be("A");
                }

                [Fact]
                public void MapBOToModelList()
                {
                        var mapper = new BOLProjectMapper();
                        BOProject bo = new BOProject();
                        bo.SetProperties("A", true, BitConverter.GetBytes(1), "A", true, "A", true, "A", "A", "A", "A", "A", "A");
                        List<ApiProjectResponseModel> response = mapper.MapBOToModel(new List<BOProject>() { { bo } });

                        response.Count.Should().Be(1);
                }
        }
}

/*<Codenesium>
    <Hash>edd5a2832abc599acddf0a4f45fdbc74</Hash>
</Codenesium>*/