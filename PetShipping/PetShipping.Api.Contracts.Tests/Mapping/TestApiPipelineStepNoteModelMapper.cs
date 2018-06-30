using FluentAssertions;
using PetShippingNS.Api.Contracts;
using System;
using System.Collections.Generic;
using Xunit;

namespace PetShippingNS.Api.Contracts.Tests
{
        [Trait("Type", "Unit")]
        [Trait("Table", "PipelineStepNote")]
        [Trait("Area", "ApiModel")]
        public class TestApiPipelineStepNoteModelMapper
        {
                [Fact]
                public void MapRequestToResponse()
                {
                        var mapper = new ApiPipelineStepNoteModelMapper();
                        var model = new ApiPipelineStepNoteRequestModel();
                        model.SetProperties(1, "A", 1);
                        ApiPipelineStepNoteResponseModel response = mapper.MapRequestToResponse(1, model);

                        response.EmployeeId.Should().Be(1);
                        response.Id.Should().Be(1);
                        response.Note.Should().Be("A");
                        response.PipelineStepId.Should().Be(1);
                }

                [Fact]
                public void MapResponseToRequest()
                {
                        var mapper = new ApiPipelineStepNoteModelMapper();
                        var model = new ApiPipelineStepNoteResponseModel();
                        model.SetProperties(1, 1, "A", 1);
                        ApiPipelineStepNoteRequestModel response = mapper.MapResponseToRequest(model);

                        response.EmployeeId.Should().Be(1);
                        response.Note.Should().Be("A");
                        response.PipelineStepId.Should().Be(1);
                }
        }
}

/*<Codenesium>
    <Hash>883d252eed0b933500cc1a963ba26e04</Hash>
</Codenesium>*/