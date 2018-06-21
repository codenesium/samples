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
        [Trait("Table", "OctopusServerNode")]
        [Trait("Area", "BOLMapper")]
        public class TestBOLOctopusServerNodeMapper
        {
                [Fact]
                public void MapModelToBO()
                {
                        var mapper = new BOLOctopusServerNodeMapper();
                        ApiOctopusServerNodeRequestModel model = new ApiOctopusServerNodeRequestModel();
                        model.SetProperties(true, "A", DateTimeOffset.Parse("1/1/1987 12:00:00 AM"), 1, "A", "A");
                        BOOctopusServerNode response = mapper.MapModelToBO("A", model);

                        response.IsInMaintenanceMode.Should().Be(true);
                        response.JSON.Should().Be("A");
                        response.LastSeen.Should().Be(DateTimeOffset.Parse("1/1/1987 12:00:00 AM"));
                        response.MaxConcurrentTasks.Should().Be(1);
                        response.Name.Should().Be("A");
                        response.Rank.Should().Be("A");
                }

                [Fact]
                public void MapBOToModel()
                {
                        var mapper = new BOLOctopusServerNodeMapper();
                        BOOctopusServerNode bo = new BOOctopusServerNode();
                        bo.SetProperties("A", true, "A", DateTimeOffset.Parse("1/1/1987 12:00:00 AM"), 1, "A", "A");
                        ApiOctopusServerNodeResponseModel response = mapper.MapBOToModel(bo);

                        response.Id.Should().Be("A");
                        response.IsInMaintenanceMode.Should().Be(true);
                        response.JSON.Should().Be("A");
                        response.LastSeen.Should().Be(DateTimeOffset.Parse("1/1/1987 12:00:00 AM"));
                        response.MaxConcurrentTasks.Should().Be(1);
                        response.Name.Should().Be("A");
                        response.Rank.Should().Be("A");
                }

                [Fact]
                public void MapBOToModelList()
                {
                        var mapper = new BOLOctopusServerNodeMapper();
                        BOOctopusServerNode bo = new BOOctopusServerNode();
                        bo.SetProperties("A", true, "A", DateTimeOffset.Parse("1/1/1987 12:00:00 AM"), 1, "A", "A");
                        List<ApiOctopusServerNodeResponseModel> response = mapper.MapBOToModel(new List<BOOctopusServerNode>() { { bo } });

                        response.Count.Should().Be(1);
                }
        }
}

/*<Codenesium>
    <Hash>340e1cd57ea63da5521a3db6246731ae</Hash>
</Codenesium>*/