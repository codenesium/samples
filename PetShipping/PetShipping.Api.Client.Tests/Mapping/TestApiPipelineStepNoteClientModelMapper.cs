using FluentAssertions;
using System;
using System.Collections.Generic;
using Xunit;

namespace PetShippingNS.Api.Client.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "PipelineStepNote")]
	[Trait("Area", "ApiModel")]
	public class TestApiPipelineStepNoteModelMapper
	{
		[Fact]
		public void MapClientRequestToResponse()
		{
			var mapper = new ApiPipelineStepNoteModelMapper();
			var model = new ApiPipelineStepNoteClientRequestModel();
			model.SetProperties(1, "A", 1);
			ApiPipelineStepNoteClientResponseModel response = mapper.MapClientRequestToResponse(1, model);
			response.Should().NotBeNull();
			response.EmployeeId.Should().Be(1);
			response.Note.Should().Be("A");
			response.PipelineStepId.Should().Be(1);
		}

		[Fact]
		public void MapClientResponseToRequest()
		{
			var mapper = new ApiPipelineStepNoteModelMapper();
			var model = new ApiPipelineStepNoteClientResponseModel();
			model.SetProperties(1, 1, "A", 1);
			ApiPipelineStepNoteClientRequestModel response = mapper.MapClientResponseToRequest(model);
			response.Should().NotBeNull();
			response.EmployeeId.Should().Be(1);
			response.Note.Should().Be("A");
			response.PipelineStepId.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>079a850c964a9640d61e90f85057dd7a</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/