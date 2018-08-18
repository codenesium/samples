using FermataFishNS.Api.Contracts;
using FluentAssertions;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using Xunit;

namespace FermataFishNS.Api.Contracts.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "Lesson")]
	[Trait("Area", "ApiModel")]
	public class TestApiLessonModelMapper
	{
		[Fact]
		public void MapRequestToResponse()
		{
			var mapper = new ApiLessonModelMapper();
			var model = new ApiLessonRequestModel();
			model.SetProperties(DateTime.Parse("1/1/1987 12:00:00 AM"), DateTime.Parse("1/1/1987 12:00:00 AM"), 1m, 1, DateTime.Parse("1/1/1987 12:00:00 AM"), DateTime.Parse("1/1/1987 12:00:00 AM"), "A", 1, "A");
			ApiLessonResponseModel response = mapper.MapRequestToResponse(1, model);

			response.ActualEndDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.ActualStartDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.BillAmount.Should().Be(1m);
			response.Id.Should().Be(1);
			response.LessonStatusId.Should().Be(1);
			response.ScheduledEndDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.ScheduledStartDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.StudentNotes.Should().Be("A");
			response.StudioId.Should().Be(1);
			response.TeacherNotes.Should().Be("A");
		}

		[Fact]
		public void MapResponseToRequest()
		{
			var mapper = new ApiLessonModelMapper();
			var model = new ApiLessonResponseModel();
			model.SetProperties(1, DateTime.Parse("1/1/1987 12:00:00 AM"), DateTime.Parse("1/1/1987 12:00:00 AM"), 1m, 1, DateTime.Parse("1/1/1987 12:00:00 AM"), DateTime.Parse("1/1/1987 12:00:00 AM"), "A", 1, "A");
			ApiLessonRequestModel response = mapper.MapResponseToRequest(model);

			response.ActualEndDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.ActualStartDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.BillAmount.Should().Be(1m);
			response.LessonStatusId.Should().Be(1);
			response.ScheduledEndDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.ScheduledStartDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.StudentNotes.Should().Be("A");
			response.StudioId.Should().Be(1);
			response.TeacherNotes.Should().Be("A");
		}

		[Fact]
		public void CreatePatch()
		{
			var mapper = new ApiLessonModelMapper();
			var model = new ApiLessonRequestModel();
			model.SetProperties(DateTime.Parse("1/1/1987 12:00:00 AM"), DateTime.Parse("1/1/1987 12:00:00 AM"), 1m, 1, DateTime.Parse("1/1/1987 12:00:00 AM"), DateTime.Parse("1/1/1987 12:00:00 AM"), "A", 1, "A");

			JsonPatchDocument<ApiLessonRequestModel> patch = mapper.CreatePatch(model);
			var response = new ApiLessonRequestModel();
			patch.ApplyTo(response);
			response.ActualEndDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.ActualStartDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.BillAmount.Should().Be(1m);
			response.LessonStatusId.Should().Be(1);
			response.ScheduledEndDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.ScheduledStartDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.StudentNotes.Should().Be("A");
			response.StudioId.Should().Be(1);
			response.TeacherNotes.Should().Be("A");
		}
	}
}

/*<Codenesium>
    <Hash>5648353ce3c1bc024540fde0f3060da2</Hash>
</Codenesium>*/