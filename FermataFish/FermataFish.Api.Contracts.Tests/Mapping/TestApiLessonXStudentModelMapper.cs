using FermataFishNS.Api.Contracts;
using FluentAssertions;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using Xunit;

namespace FermataFishNS.Api.Contracts.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "LessonXStudent")]
	[Trait("Area", "ApiModel")]
	public class TestApiLessonXStudentModelMapper
	{
		[Fact]
		public void MapRequestToResponse()
		{
			var mapper = new ApiLessonXStudentModelMapper();
			var model = new ApiLessonXStudentRequestModel();
			model.SetProperties(1, 1);
			ApiLessonXStudentResponseModel response = mapper.MapRequestToResponse(1, model);

			response.Id.Should().Be(1);
			response.LessonId.Should().Be(1);
			response.StudentId.Should().Be(1);
		}

		[Fact]
		public void MapResponseToRequest()
		{
			var mapper = new ApiLessonXStudentModelMapper();
			var model = new ApiLessonXStudentResponseModel();
			model.SetProperties(1, 1, 1);
			ApiLessonXStudentRequestModel response = mapper.MapResponseToRequest(model);

			response.LessonId.Should().Be(1);
			response.StudentId.Should().Be(1);
		}

		[Fact]
		public void CreatePatch()
		{
			var mapper = new ApiLessonXStudentModelMapper();
			var model = new ApiLessonXStudentRequestModel();
			model.SetProperties(1, 1);

			JsonPatchDocument<ApiLessonXStudentRequestModel> patch = mapper.CreatePatch(model);
			var response = new ApiLessonXStudentRequestModel();
			patch.ApplyTo(response);
			response.LessonId.Should().Be(1);
			response.StudentId.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>e35f2b3736e9fe3711fa146e388e1f7b</Hash>
</Codenesium>*/