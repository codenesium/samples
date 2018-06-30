using FermataFishNS.Api.Contracts;
using FluentAssertions;
using System;
using System.Collections.Generic;
using Xunit;

namespace FermataFishNS.Api.Contracts.Tests
{
        [Trait("Type", "Unit")]
        [Trait("Table", "LessonStatus")]
        [Trait("Area", "ApiModel")]
        public class TestApiLessonStatusModelMapper
        {
                [Fact]
                public void MapRequestToResponse()
                {
                        var mapper = new ApiLessonStatusModelMapper();
                        var model = new ApiLessonStatusRequestModel();
                        model.SetProperties("A", 1);
                        ApiLessonStatusResponseModel response = mapper.MapRequestToResponse(1, model);

                        response.Id.Should().Be(1);
                        response.Name.Should().Be("A");
                        response.StudioId.Should().Be(1);
                }

                [Fact]
                public void MapResponseToRequest()
                {
                        var mapper = new ApiLessonStatusModelMapper();
                        var model = new ApiLessonStatusResponseModel();
                        model.SetProperties(1, "A", 1);
                        ApiLessonStatusRequestModel response = mapper.MapResponseToRequest(model);

                        response.Name.Should().Be("A");
                        response.StudioId.Should().Be(1);
                }
        }
}

/*<Codenesium>
    <Hash>6dfec838de2ec9c00fdd379e0ab84aa5</Hash>
</Codenesium>*/