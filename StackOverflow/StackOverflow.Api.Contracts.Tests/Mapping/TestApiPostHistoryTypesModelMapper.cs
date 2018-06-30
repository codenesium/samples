using FluentAssertions;
using StackOverflowNS.Api.Contracts;
using System;
using System.Collections.Generic;
using Xunit;

namespace StackOverflowNS.Api.Contracts.Tests
{
        [Trait("Type", "Unit")]
        [Trait("Table", "PostHistoryTypes")]
        [Trait("Area", "ApiModel")]
        public class TestApiPostHistoryTypesModelMapper
        {
                [Fact]
                public void MapRequestToResponse()
                {
                        var mapper = new ApiPostHistoryTypesModelMapper();
                        var model = new ApiPostHistoryTypesRequestModel();
                        model.SetProperties("A");
                        ApiPostHistoryTypesResponseModel response = mapper.MapRequestToResponse(1, model);

                        response.Id.Should().Be(1);
                        response.Type.Should().Be("A");
                }

                [Fact]
                public void MapResponseToRequest()
                {
                        var mapper = new ApiPostHistoryTypesModelMapper();
                        var model = new ApiPostHistoryTypesResponseModel();
                        model.SetProperties(1, "A");
                        ApiPostHistoryTypesRequestModel response = mapper.MapResponseToRequest(model);

                        response.Type.Should().Be("A");
                }
        }
}

/*<Codenesium>
    <Hash>f585fe60744aba73fd1de53b14fbb0bc</Hash>
</Codenesium>*/