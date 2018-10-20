using FluentAssertions;
using Microsoft.AspNetCore.JsonPatch;
using StudioResourceManagerNS.Api.Contracts;
using System;
using System.Collections.Generic;
using Xunit;

namespace StudioResourceManagerNS.Api.Contracts.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "Event")]
	[Trait("Area", "ApiModel")]
	public class TestApiEventModelMapper
	{
		[Fact]
		public void MapRequestToResponse()
		{
			var mapper = new ApiEventModelMapper();
			var model = new ApiEventRequestModel();
			model.SetProperties(DateTime.Parse("1/1/1987 12:00:00 AM"), DateTime.Parse("1/1/1987 12:00:00 AM"), 1m, 1, DateTime.Parse("1/1/1987 12:00:00 AM"), DateTime.Parse("1/1/1987 12:00:00 AM"), "A", "A", true);
			ApiEventResponseModel response = mapper.MapRequestToResponse(1, model);

			response.ActualEndDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.ActualStartDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.BillAmount.Should().Be(1m);
			response.EventStatusId.Should().Be(1);
			response.Id.Should().Be(1);
			response.ScheduledEndDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.ScheduledStartDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.StudentNote.Should().Be("A");
			response.TeacherNote.Should().Be("A");
			response.IsDeleted.Should().Be(true);
		}

		[Fact]
		public void MapResponseToRequest()
		{
			var mapper = new ApiEventModelMapper();
			var model = new ApiEventResponseModel();
			model.SetProperties(1, DateTime.Parse("1/1/1987 12:00:00 AM"), DateTime.Parse("1/1/1987 12:00:00 AM"), 1m, 1, DateTime.Parse("1/1/1987 12:00:00 AM"), DateTime.Parse("1/1/1987 12:00:00 AM"), "A", "A", true);
			ApiEventRequestModel response = mapper.MapResponseToRequest(model);

			response.ActualEndDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.ActualStartDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.BillAmount.Should().Be(1m);
			response.EventStatusId.Should().Be(1);
			response.ScheduledEndDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.ScheduledStartDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.StudentNote.Should().Be("A");
			response.TeacherNote.Should().Be("A");
			response.IsDeleted.Should().Be(true);
		}

		[Fact]
		public void CreatePatch()
		{
			var mapper = new ApiEventModelMapper();
			var model = new ApiEventRequestModel();
			model.SetProperties(DateTime.Parse("1/1/1987 12:00:00 AM"), DateTime.Parse("1/1/1987 12:00:00 AM"), 1m, 1, DateTime.Parse("1/1/1987 12:00:00 AM"), DateTime.Parse("1/1/1987 12:00:00 AM"), "A", "A", true);

			JsonPatchDocument<ApiEventRequestModel> patch = mapper.CreatePatch(model);
			var response = new ApiEventRequestModel();
			patch.ApplyTo(response);
			response.ActualEndDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.ActualStartDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.BillAmount.Should().Be(1m);
			response.EventStatusId.Should().Be(1);
			response.ScheduledEndDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.ScheduledStartDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.StudentNote.Should().Be("A");
			response.TeacherNote.Should().Be("A");
			response.IsDeleted.Should().Be(true);
		}
	}
}

/*<Codenesium>
    <Hash>6b7b6deca303acfa90e48c7882f976c2</Hash>
</Codenesium>*/