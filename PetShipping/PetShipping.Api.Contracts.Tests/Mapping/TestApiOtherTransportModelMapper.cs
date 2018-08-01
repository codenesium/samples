using FluentAssertions;
using Microsoft.AspNetCore.JsonPatch;
using PetShippingNS.Api.Contracts;
using System;
using System.Collections.Generic;
using Xunit;

namespace PetShippingNS.Api.Contracts.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "OtherTransport")]
	[Trait("Area", "ApiModel")]
	public class TestApiOtherTransportModelMapper
	{
		[Fact]
		public void MapRequestToResponse()
		{
			var mapper = new ApiOtherTransportModelMapper();
			var model = new ApiOtherTransportRequestModel();
			model.SetProperties(1, 1);
			ApiOtherTransportResponseModel response = mapper.MapRequestToResponse(1, model);

			response.HandlerId.Should().Be(1);
			response.Id.Should().Be(1);
			response.PipelineStepId.Should().Be(1);
		}

		[Fact]
		public void MapResponseToRequest()
		{
			var mapper = new ApiOtherTransportModelMapper();
			var model = new ApiOtherTransportResponseModel();
			model.SetProperties(1, 1, 1);
			ApiOtherTransportRequestModel response = mapper.MapResponseToRequest(model);

			response.HandlerId.Should().Be(1);
			response.PipelineStepId.Should().Be(1);
		}

		[Fact]
		public void CreatePatch()
		{
			var mapper = new ApiOtherTransportModelMapper();
			var model = new ApiOtherTransportRequestModel();
			model.SetProperties(1, 1);

			JsonPatchDocument<ApiOtherTransportRequestModel> patch = mapper.CreatePatch(model);
			var response = new ApiOtherTransportRequestModel();
			patch.ApplyTo(response);
			response.HandlerId.Should().Be(1);
			response.PipelineStepId.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>b29b5064fb10c73ff546cc0ce22c10b8</Hash>
</Codenesium>*/