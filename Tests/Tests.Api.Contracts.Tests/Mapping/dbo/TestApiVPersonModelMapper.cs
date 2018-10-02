using FluentAssertions;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using TestsNS.Api.Contracts;
using Xunit;

namespace TestsNS.Api.Contracts.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "VPerson")]
	[Trait("Area", "ApiModel")]
	public class TestApiVPersonModelMapper
	{
		[Fact]
		public void MapRequestToResponse()
		{
			var mapper = new ApiVPersonModelMapper();
			var model = new ApiVPersonRequestModel();
			model.SetProperties("A");
			ApiVPersonResponseModel response = mapper.MapRequestToResponse(1, model);

			response.PersonId.Should().Be(1);
			response.PersonName.Should().Be("A");
		}

		[Fact]
		public void MapResponseToRequest()
		{
			var mapper = new ApiVPersonModelMapper();
			var model = new ApiVPersonResponseModel();
			model.SetProperties(1, "A");
			ApiVPersonRequestModel response = mapper.MapResponseToRequest(model);

			response.PersonName.Should().Be("A");
		}

		[Fact]
		public void CreatePatch()
		{
			var mapper = new ApiVPersonModelMapper();
			var model = new ApiVPersonRequestModel();
			model.SetProperties("A");

			JsonPatchDocument<ApiVPersonRequestModel> patch = mapper.CreatePatch(model);
			var response = new ApiVPersonRequestModel();
			patch.ApplyTo(response);
			response.PersonName.Should().Be("A");
		}
	}
}

/*<Codenesium>
    <Hash>61e54e5f85db2b7cdd37e881cb741f75</Hash>
</Codenesium>*/