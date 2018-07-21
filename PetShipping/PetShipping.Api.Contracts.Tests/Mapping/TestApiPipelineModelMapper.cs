using FluentAssertions;
using Microsoft.AspNetCore.JsonPatch;
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

                [Fact]
                public void CreatePatch()
                {
                        var mapper = new ApiPipelineModelMapper();
                        var model = new ApiPipelineRequestModel();
                        model.SetProperties(1, 1);

                        JsonPatchDocument<ApiPipelineRequestModel> patch = mapper.CreatePatch(model);
                        var response = new ApiPipelineRequestModel();
                        patch.ApplyTo(response);

                        response.PipelineStatusId.Should().Be(1);
                        response.SaleId.Should().Be(1);
                }
        }
}

/*<Codenesium>
    <Hash>0b54ffd7fa831de8b06a32f694ced0f2</Hash>
</Codenesium>*/