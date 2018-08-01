using FermataFishNS.Api.Contracts;
using FluentAssertions;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using Xunit;

namespace FermataFishNS.Api.Contracts.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "LessonXTeacher")]
	[Trait("Area", "ApiModel")]
	public class TestApiLessonXTeacherModelMapper
	{
		[Fact]
		public void MapRequestToResponse()
		{
			var mapper = new ApiLessonXTeacherModelMapper();
			var model = new ApiLessonXTeacherRequestModel();
			model.SetProperties(1, 1);
			ApiLessonXTeacherResponseModel response = mapper.MapRequestToResponse(1, model);

			response.Id.Should().Be(1);
			response.LessonId.Should().Be(1);
			response.StudentId.Should().Be(1);
		}

		[Fact]
		public void MapResponseToRequest()
		{
			var mapper = new ApiLessonXTeacherModelMapper();
			var model = new ApiLessonXTeacherResponseModel();
			model.SetProperties(1, 1, 1);
			ApiLessonXTeacherRequestModel response = mapper.MapResponseToRequest(model);

			response.LessonId.Should().Be(1);
			response.StudentId.Should().Be(1);
		}

		[Fact]
		public void CreatePatch()
		{
			var mapper = new ApiLessonXTeacherModelMapper();
			var model = new ApiLessonXTeacherRequestModel();
			model.SetProperties(1, 1);

			JsonPatchDocument<ApiLessonXTeacherRequestModel> patch = mapper.CreatePatch(model);
			var response = new ApiLessonXTeacherRequestModel();
			patch.ApplyTo(response);
			response.LessonId.Should().Be(1);
			response.StudentId.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>2d66d73ad3f3cecaa85aab304df51c54</Hash>
</Codenesium>*/