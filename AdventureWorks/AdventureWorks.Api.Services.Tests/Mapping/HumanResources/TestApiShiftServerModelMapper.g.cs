using FluentAssertions;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using Xunit;

namespace AdventureWorksNS.Api.Services.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "Shift")]
	[Trait("Area", "ApiModel")]
	public class TestApiShiftServerModelMapper
	{
		[Fact]
		public void MapServerRequestToResponse()
		{
			var mapper = new ApiShiftServerModelMapper();
			var model = new ApiShiftServerRequestModel();
			model.SetProperties(TimeSpan.Parse("01:00:00"), DateTime.Parse("1/1/1987 12:00:00 AM"), "A", TimeSpan.Parse("01:00:00"));
			ApiShiftServerResponseModel response = mapper.MapServerRequestToResponse(1, model);
			response.Should().NotBeNull();
			response.EndTime.Should().Be(TimeSpan.Parse("01:00:00"));
			response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.Name.Should().Be("A");
			response.StartTime.Should().Be(TimeSpan.Parse("01:00:00"));
		}

		[Fact]
		public void MapServerResponseToRequest()
		{
			var mapper = new ApiShiftServerModelMapper();
			var model = new ApiShiftServerResponseModel();
			model.SetProperties(1, TimeSpan.Parse("01:00:00"), DateTime.Parse("1/1/1987 12:00:00 AM"), "A", TimeSpan.Parse("01:00:00"));
			ApiShiftServerRequestModel response = mapper.MapServerResponseToRequest(model);
			response.Should().NotBeNull();
			response.EndTime.Should().Be(TimeSpan.Parse("01:00:00"));
			response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.Name.Should().Be("A");
			response.StartTime.Should().Be(TimeSpan.Parse("01:00:00"));
		}

		[Fact]
		public void CreatePatch()
		{
			var mapper = new ApiShiftServerModelMapper();
			var model = new ApiShiftServerRequestModel();
			model.SetProperties(TimeSpan.Parse("01:00:00"), DateTime.Parse("1/1/1987 12:00:00 AM"), "A", TimeSpan.Parse("01:00:00"));

			JsonPatchDocument<ApiShiftServerRequestModel> patch = mapper.CreatePatch(model);
			var response = new ApiShiftServerRequestModel();
			patch.ApplyTo(response);
			response.EndTime.Should().Be(TimeSpan.Parse("01:00:00"));
			response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.Name.Should().Be("A");
			response.StartTime.Should().Be(TimeSpan.Parse("01:00:00"));
		}
	}
}

/*<Codenesium>
    <Hash>eb030e847d1590f21e8c45b0c2e20901</Hash>
</Codenesium>*/