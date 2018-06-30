using FluentAssertions;
using PetShippingNS.Api.Contracts;
using System;
using System.Collections.Generic;
using Xunit;

namespace PetShippingNS.Api.Contracts.Tests
{
        [Trait("Type", "Unit")]
        [Trait("Table", "Pipeline")]
        [Trait("Area", "ApiModel")]
        public class TestApiPipelineModelMapper
        {
                [Fact]
                public void MapRequestToResponse()
                {
                        var mapper = new ApiPipelineModelMapper();
                        var model = new ApiPipelineRequestModel();
                        model.SetProperties(1, 1);
                        ApiPipelineResponseModel response = mapper.MapRequestToResponse(1, model);

                        response.Id.Should().Be(1);
                        response.PipelineStatusId.Should().Be(1);
                        response.SaleId.Should().Be(1);
                }

                [Fact]
                public void MapResponseToRequest()
                {
                        var mapper = new ApiPipelineModelMapper();
                        var model = new ApiPipelineResponseModel();
                        model.SetProperties(1, 1, 1);
                        ApiPipelineRequestModel response = mapper.MapResponseToRequest(model);

                        response.PipelineStatusId.Should().Be(1);
                        response.SaleId.Should().Be(1);
                }
        }
}

/*<Codenesium>
    <Hash>8b32763859eb20221acc773f57266321</Hash>
</Codenesium>*/