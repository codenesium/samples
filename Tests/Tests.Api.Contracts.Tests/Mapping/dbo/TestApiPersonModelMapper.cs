using FluentAssertions;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using TestsNS.Api.Contracts;
using Xunit;

namespace TestsNS.Api.Contracts.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "Person")]
	[Trait("Area", "ApiModel")]
	public class TestApiPersonModelMapper
	{
		[Fact]
		public void MapRequestToResponse()
		{
			var mapper = new ApiPersonModelMapper();
			var model = new ApiPersonRequestModel();
			model.SetProperties("A");
			ApiPersonResponseModel response = mapper.MapRequestToResponse(1, model);

			response.PersonId.Should().Be(1);
			response.PersonName.Should().Be("A");
		}

		[Fact]
		public void MapResponseToRequest()
		{
			var mapper = new ApiPersonModelMapper();
			var model = new ApiPersonResponseModel();
			model.SetProperties(1, "A");
			ApiPersonRequestModel response = mapper.MapResponseToRequest(model);

			response.PersonName.Should().Be("A");
		}

		[Fact]
		public void CreatePatch()
		{
			var mapper = new ApiPersonModelMapper();
			var model = new ApiPersonRequestModel();
			model.SetProperties("A");

			JsonPatchDocument<ApiPersonRequestModel> patch = mapper.CreatePatch(model);
			var response = new ApiPersonRequestModel();
			patch.ApplyTo(response);
			response.PersonName.Should().Be("A");
		}
	}
}

/*<Codenesium>
    <Hash>bd22d80be8d5fff1e24a5096700f9265</Hash>
</Codenesium>*/