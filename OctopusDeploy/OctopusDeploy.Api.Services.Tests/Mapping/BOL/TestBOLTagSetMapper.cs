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
        [Trait("Table", "TagSet")]
        [Trait("Area", "BOLMapper")]
        public class TestBOLTagSetActionMapper
        {
                [Fact]
                public void MapModelToBO()
                {
                        var mapper = new BOLTagSetMapper();

                        ApiTagSetRequestModel model = new ApiTagSetRequestModel();

                        model.SetProperties(BitConverter.GetBytes(1), "A", "A", 1);
                        BOTagSet response = mapper.MapModelToBO("A", model);

                        response.DataVersion.Should().BeEquivalentTo(BitConverter.GetBytes(1));
                        response.JSON.Should().Be("A");
                        response.Name.Should().Be("A");
                        response.SortOrder.Should().Be(1);
                }

                [Fact]
                public void MapBOToModel()
                {
                        var mapper = new BOLTagSetMapper();

                        BOTagSet bo = new BOTagSet();

                        bo.SetProperties("A", BitConverter.GetBytes(1), "A", "A", 1);
                        ApiTagSetResponseModel response = mapper.MapBOToModel(bo);

                        response.DataVersion.Should().BeEquivalentTo(BitConverter.GetBytes(1));
                        response.Id.Should().Be("A");
                        response.JSON.Should().Be("A");
                        response.Name.Should().Be("A");
                        response.SortOrder.Should().Be(1);
                }

                [Fact]
                public void MapBOToModelList()
                {
                        var mapper = new BOLTagSetMapper();

                        BOTagSet bo = new BOTagSet();

                        bo.SetProperties("A", BitConverter.GetBytes(1), "A", "A", 1);
                        List<ApiTagSetResponseModel> response = mapper.MapBOToModel(new List<BOTagSet>() { { bo } });

                        response.Count.Should().Be(1);
                }
        }
}

/*<Codenesium>
    <Hash>9b60b3dc147939ace3caf1330dab9f8e</Hash>
</Codenesium>*/