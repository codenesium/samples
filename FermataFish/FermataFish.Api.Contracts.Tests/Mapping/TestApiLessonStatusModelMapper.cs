using FermataFishNS.Api.Contracts;
using FluentAssertions;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using Xunit;

namespace FermataFishNS.Api.Contracts.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "LessonStatus")]
	[Trait("Area", "ApiModel")]
	public class TestApiLessonStatusModelMapper
	{
		[Fact]
		public void MapRequestToResponse()
		{
			var mapper = new ApiLessonStatusModelMapper();
			var model = new ApiLessonStatusRequestModel();
			model.SetProperties("A", 1);
			ApiLessonStatusResponseModel response = mapper.MapRequestToResponse(1, model);

			response.Id.Should().Be(1);
			response.Name.Should().Be("A");
			response.StudioId.Should().Be(1);
		}

		[Fact]
		public void MapResponseToRequest()
		{
			var mapper = new ApiLessonStatusModelMapper();
			var model = new ApiLessonStatusResponseModel();
			model.SetProperties(1, "A", 1);
			ApiLessonStatusRequestModel response = mapper.MapResponseToRequest(model);

			response.Name.Should().Be("A");
			response.StudioId.Should().Be(1);
		}

		[Fact]
		public void CreatePatch()
		{
			var mapper = new ApiLessonStatusModelMapper();
			var model = new ApiLessonStatusRequestModel();
			model.SetProperties("A", 1);

			JsonPatchDocument<ApiLessonStatusRequestModel> patch = mapper.CreatePatch(model);
			var response = new ApiLessonStatusRequestModel();
			patch.ApplyTo(response);
			response.Name.Should().Be("A");
			response.StudioId.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>81a0e565a067fc36bf8b2a527b9b1234</Hash>
</Codenesium>*/