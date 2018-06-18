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
        [Trait("Table", "Feed")]
        [Trait("Area", "BOLMapper")]
        public class TestBOLFeedActionMapper
        {
                [Fact]
                public void MapModelToBO()
                {
                        var mapper = new BOLFeedMapper();

                        ApiFeedRequestModel model = new ApiFeedRequestModel();

                        model.SetProperties("A", "A", "A", "A");
                        BOFeed response = mapper.MapModelToBO("A", model);

                        response.FeedType.Should().Be("A");
                        response.FeedUri.Should().Be("A");
                        response.JSON.Should().Be("A");
                        response.Name.Should().Be("A");
                }

                [Fact]
                public void MapBOToModel()
                {
                        var mapper = new BOLFeedMapper();

                        BOFeed bo = new BOFeed();

                        bo.SetProperties("A", "A", "A", "A", "A");
                        ApiFeedResponseModel response = mapper.MapBOToModel(bo);

                        response.FeedType.Should().Be("A");
                        response.FeedUri.Should().Be("A");
                        response.Id.Should().Be("A");
                        response.JSON.Should().Be("A");
                        response.Name.Should().Be("A");
                }

                [Fact]
                public void MapBOToModelList()
                {
                        var mapper = new BOLFeedMapper();

                        BOFeed bo = new BOFeed();

                        bo.SetProperties("A", "A", "A", "A", "A");
                        List<ApiFeedResponseModel> response = mapper.MapBOToModel(new List<BOFeed>() { { bo } });

                        response.Count.Should().Be(1);
                }
        }
}

/*<Codenesium>
    <Hash>1831615e5ce24b912159870a70587134</Hash>
</Codenesium>*/