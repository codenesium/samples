using FluentAssertions;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using TestsNS.Api.Contracts;
using Xunit;

namespace TestsNS.Api.Contracts.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "CompositePrimaryKey")]
	[Trait("Area", "ApiModel")]
	public class TestApiCompositePrimaryKeyModelMapper
	{
		[Fact]
		public void MapRequestToResponse()
		{
			var mapper = new ApiCompositePrimaryKeyModelMapper();
			var model = new ApiCompositePrimaryKeyRequestModel();
			model.SetProperties(1);
			ApiCompositePrimaryKeyResponseModel response = mapper.MapRequestToResponse(1, model);

			response.Id.Should().Be(1);
			response.Id2.Should().Be(1);
		}

		[Fact]
		public void MapResponseToRequest()
		{
			var mapper = new ApiCompositePrimaryKeyModelMapper();
			var model = new ApiCompositePrimaryKeyResponseModel();
			model.SetProperties(1, 1);
			ApiCompositePrimaryKeyRequestModel response = mapper.MapResponseToRequest(model);

			response.Id2.Should().Be(1);
		}

		[Fact]
		public void CreatePatch()
		{
			var mapper = new ApiCompositePrimaryKeyModelMapper();
			var model = new ApiCompositePrimaryKeyRequestModel();
			model.SetProperties(1);

			JsonPatchDocument<ApiCompositePrimaryKeyRequestModel> patch = mapper.CreatePatch(model);
			var response = new ApiCompositePrimaryKeyRequestModel();
			patch.ApplyTo(response);
			response.Id2.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>77b06d4a41a9dd8f24e7b580c811c59d</Hash>
</Codenesium>*/