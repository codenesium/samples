using FluentAssertions;
using StackOverflowNS.Api.Contracts;
using StackOverflowNS.Api.DataAccess;
using StackOverflowNS.Api.Services;
using System;
using System.Collections.Generic;
using Xunit;

namespace StackOverflowNS.Api.Services.Tests
{
        [Trait("Type", "Unit")]
        [Trait("Table", "Tags")]
        [Trait("Area", "BOLMapper")]
        public class TestBOLTagsMapper
        {
                [Fact]
                public void MapModelToBO()
                {
                        var mapper = new BOLTagsMapper();
                        ApiTagsRequestModel model = new ApiTagsRequestModel();
                        model.SetProperties(1, 1, "A", 1);
                        BOTags response = mapper.MapModelToBO(1, model);

                        response.Count.Should().Be(1);
                        response.ExcerptPostId.Should().Be(1);
                        response.TagName.Should().Be("A");
                        response.WikiPostId.Should().Be(1);
                }

                [Fact]
                public void MapBOToModel()
                {
                        var mapper = new BOLTagsMapper();
                        BOTags bo = new BOTags();
                        bo.SetProperties(1, 1, 1, "A", 1);
                        ApiTagsResponseModel response = mapper.MapBOToModel(bo);

                        response.Count.Should().Be(1);
                        response.ExcerptPostId.Should().Be(1);
                        response.Id.Should().Be(1);
                        response.TagName.Should().Be("A");
                        response.WikiPostId.Should().Be(1);
                }

                [Fact]
                public void MapBOToModelList()
                {
                        var mapper = new BOLTagsMapper();
                        BOTags bo = new BOTags();
                        bo.SetProperties(1, 1, 1, "A", 1);
                        List<ApiTagsResponseModel> response = mapper.MapBOToModel(new List<BOTags>() { { bo } });

                        response.Count.Should().Be(1);
                }
        }
}

/*<Codenesium>
    <Hash>7bb0d0faa5e8b72d7f8880b9d29815ad</Hash>
</Codenesium>*/