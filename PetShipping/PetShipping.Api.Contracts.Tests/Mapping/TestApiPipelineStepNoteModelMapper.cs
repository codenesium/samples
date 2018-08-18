using FluentAssertions;
using Microsoft.AspNetCore.JsonPatch;
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

		[Fact]
		public void CreatePatch()
		{
			var mapper = new ApiPipelineStepNoteModelMapper();
			var model = new ApiPipelineStepNoteRequestModel();
			model.SetProperties(1, "A", 1);

			JsonPatchDocument<ApiPipelineStepNoteRequestModel> patch = mapper.CreatePatch(model);
			var response = new ApiPipelineStepNoteRequestModel();
			patch.ApplyTo(response);
			response.EmployeeId.Should().Be(1);
			response.Note.Should().Be("A");
			response.PipelineStepId.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>2431f9f605e1d77a1569885ea88b14ef</Hash>
</Codenesium>*/