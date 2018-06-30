using FluentAssertions;
using PetShippingNS.Api.Contracts;
using System;
using System.Collections.Generic;
using Xunit;

namespace PetShippingNS.Api.Contracts.Tests
{
        [Trait("Type", "Unit")]
        [Trait("Table", "PipelineStatus")]
        [Trait("Area", "ApiModel")]
        public class TestApiPipelineStatusModelMapper
        {
                [Fact]
                public void MapRequestToResponse()
                {
                        var mapper = new ApiPipelineStatusModelMapper();
                        var model = new ApiPipelineStatusRequestModel();
                        model.SetProperties("A");
                        ApiPipelineStatusResponseModel response = mapper.MapRequestToResponse(1, model);

                        response.Id.Should().Be(1);
                        response.Name.Should().Be("A");
                }

                [Fact]
                public void MapResponseToRequest()
                {
                        var mapper = new ApiPipelineStatusModelMapper();
                        var model = new ApiPipelineStatusResponseModel();
                        model.SetProperties(1, "A");
                        ApiPipelineStatusRequestModel response = mapper.MapResponseToRequest(model);

                        response.Name.Should().Be("A");
                }
        }
}

/*<Codenesium>
    <Hash>32b4e88fec80d6f60c32ded03bcb4b62</Hash>
</Codenesium>*/