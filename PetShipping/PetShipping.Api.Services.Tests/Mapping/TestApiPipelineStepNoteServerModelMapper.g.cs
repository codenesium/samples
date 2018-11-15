using FluentAssertions;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using Xunit;

namespace PetShippingNS.Api.Services.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "PipelineStepNote")]
	[Trait("Area", "ApiModel")]
	public class TestApiPipelineStepNoteServerModelMapper
	{
		[Fact]
		public void MapServerRequestToResponse()
		{
			var mapper = new ApiPipelineStepNoteServerModelMapper();
			var model = new ApiPipelineStepNoteServerRequestModel();
			model.SetProperties(1, "A", 1);
			ApiPipelineStepNoteServerResponseModel response = mapper.MapServerRequestToResponse(1, model);
			response.Should().NotBeNull();
			response.EmployeeId.Should().Be(1);
			response.Note.Should().Be("A");
			response.PipelineStepId.Should().Be(1);
		}

		[Fact]
		public void MapServerResponseToRequest()
		{
			var mapper = new ApiPipelineStepNoteServerModelMapper();
			var model = new ApiPipelineStepNoteServerResponseModel();
			model.SetProperties(1, 1, "A", 1);
			ApiPipelineStepNoteServerRequestModel response = mapper.MapServerResponseToRequest(model);
			response.Should().NotBeNull();
			response.EmployeeId.Should().Be(1);
			response.Note.Should().Be("A");
			response.PipelineStepId.Should().Be(1);
		}

		[Fact]
		public void CreatePatch()
		{
			var mapper = new ApiPipelineStepNoteServerModelMapper();
			var model = new ApiPipelineStepNoteServerRequestModel();
			model.SetProperties(1, "A", 1);

			JsonPatchDocument<ApiPipelineStepNoteServerRequestModel> patch = mapper.CreatePatch(model);
			var response = new ApiPipelineStepNoteServerRequestModel();
			patch.ApplyTo(response);
			response.EmployeeId.Should().Be(1);
			response.Note.Should().Be("A");
			response.PipelineStepId.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>7153a8d7487611911174c5461ebe6cac</Hash>
</Codenesium>*/