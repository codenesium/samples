using FluentAssertions;
using Microsoft.AspNetCore.JsonPatch;
using StackOverflowNS.Api.Contracts;
using System;
using System.Collections.Generic;
using Xunit;

namespace StackOverflowNS.Api.Contracts.Tests
{
        [Trait("Type", "Unit")]
        [Trait("Table", "Tags")]
        [Trait("Area", "ApiModel")]
        public class TestApiTagsModelMapper
        {
                [Fact]
                public void MapRequestToResponse()
                {
                        var mapper = new ApiTagsModelMapper();
                        var model = new ApiTagsRequestModel();
                        model.SetProperties(1, 1, "A", 1);
                        ApiTagsResponseModel response = mapper.MapRequestToResponse(1, model);

                        response.Count.Should().Be(1);
                        response.ExcerptPostId.Should().Be(1);
                        response.Id.Should().Be(1);
                        response.TagName.Should().Be("A");
                        response.WikiPostId.Should().Be(1);
                }

                [Fact]
                public void MapResponseToRequest()
                {
                        var mapper = new ApiTagsModelMapper();
                        var model = new ApiTagsResponseModel();
                        model.SetProperties(1, 1, 1, "A", 1);
                        ApiTagsRequestModel response = mapper.MapResponseToRequest(model);

                        response.Count.Should().Be(1);
                        response.ExcerptPostId.Should().Be(1);
                        response.TagName.Should().Be("A");
                        response.WikiPostId.Should().Be(1);
                }

                [Fact]
                public void CreatePatch()
                {
                        var mapper = new ApiTagsModelMapper();
                        var model = new ApiTagsRequestModel();
                        model.SetProperties(1, 1, "A", 1);

                        JsonPatchDocument<ApiTagsRequestModel> patch = mapper.CreatePatch(model);
                        var response = new ApiTagsRequestModel();
                        patch.ApplyTo(response);

                        response.Count.Should().Be(1);
                        response.ExcerptPostId.Should().Be(1);
                        response.TagName.Should().Be("A");
                        response.WikiPostId.Should().Be(1);
                }
        }
}

/*<Codenesium>
    <Hash>6bc69950162f1c3c7e3407d2a651f9de</Hash>
</Codenesium>*/