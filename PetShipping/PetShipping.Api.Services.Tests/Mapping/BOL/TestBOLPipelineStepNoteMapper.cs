using System;
using System.Collections.Generic;
using FluentAssertions;
using Xunit;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
using PetShippingNS.Api.Services;

namespace PetShippingNS.Api.Services.Tests
{
        [Trait("Type", "Unit")]
        [Trait("Table", "PipelineStepNote")]
        [Trait("Area", "BOLMapper")]
        public class TestBOLPipelineStepNoteActionMapper
        {
                [Fact]
                public void MapModelToBO()
                {
                        var mapper = new BOLPipelineStepNoteMapper();

                        ApiPipelineStepNoteRequestModel model = new ApiPipelineStepNoteRequestModel();

                        model.SetProperties(1, "A", 1);
                        BOPipelineStepNote response = mapper.MapModelToBO(1, model);

                        response.EmployeeId.Should().Be(1);
                        response.Note.Should().Be("A");
                        response.PipelineStepId.Should().Be(1);
                }

                [Fact]
                public void MapBOToModel()
                {
                        var mapper = new BOLPipelineStepNoteMapper();

                        BOPipelineStepNote bo = new BOPipelineStepNote();

                        bo.SetProperties(1, 1, "A", 1);
                        ApiPipelineStepNoteResponseModel response = mapper.MapBOToModel(bo);

                        response.EmployeeId.Should().Be(1);
                        response.Id.Should().Be(1);
                        response.Note.Should().Be("A");
                        response.PipelineStepId.Should().Be(1);
                }

                [Fact]
                public void MapBOToModelList()
                {
                        var mapper = new BOLPipelineStepNoteMapper();

                        BOPipelineStepNote bo = new BOPipelineStepNote();

                        bo.SetProperties(1, 1, "A", 1);
                        List<ApiPipelineStepNoteResponseModel> response = mapper.MapBOToModel(new List<BOPipelineStepNote>() { { bo } });

                        response.Count.Should().Be(1);
                }
        }
}

/*<Codenesium>
    <Hash>bb481a4c4aeae8c140ed342a73320042</Hash>
</Codenesium>*/