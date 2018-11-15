using FluentAssertions;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using Xunit;

namespace TwitterNS.Api.Services.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "Reply")]
	[Trait("Area", "ApiModel")]
	public class TestApiReplyServerModelMapper
	{
		[Fact]
		public void MapServerRequestToResponse()
		{
			var mapper = new ApiReplyServerModelMapper();
			var model = new ApiReplyServerRequestModel();
			model.SetProperties("A", DateTime.Parse("1/1/1987 12:00:00 AM"), 1, TimeSpan.Parse("01:00:00"));
			ApiReplyServerResponseModel response = mapper.MapServerRequestToResponse(1, model);
			response.Should().NotBeNull();
			response.Content.Should().Be("A");
			response.Date.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.ReplierUserId.Should().Be(1);
			response.Time.Should().Be(TimeSpan.Parse("01:00:00"));
		}

		[Fact]
		public void MapServerResponseToRequest()
		{
			var mapper = new ApiReplyServerModelMapper();
			var model = new ApiReplyServerResponseModel();
			model.SetProperties(1, "A", DateTime.Parse("1/1/1987 12:00:00 AM"), 1, TimeSpan.Parse("01:00:00"));
			ApiReplyServerRequestModel response = mapper.MapServerResponseToRequest(model);
			response.Should().NotBeNull();
			response.Content.Should().Be("A");
			response.Date.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.ReplierUserId.Should().Be(1);
			response.Time.Should().Be(TimeSpan.Parse("01:00:00"));
		}

		[Fact]
		public void CreatePatch()
		{
			var mapper = new ApiReplyServerModelMapper();
			var model = new ApiReplyServerRequestModel();
			model.SetProperties("A", DateTime.Parse("1/1/1987 12:00:00 AM"), 1, TimeSpan.Parse("01:00:00"));

			JsonPatchDocument<ApiReplyServerRequestModel> patch = mapper.CreatePatch(model);
			var response = new ApiReplyServerRequestModel();
			patch.ApplyTo(response);
			response.Content.Should().Be("A");
			response.Date.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.ReplierUserId.Should().Be(1);
			response.Time.Should().Be(TimeSpan.Parse("01:00:00"));
		}
	}
}

/*<Codenesium>
    <Hash>e0d922a80d587a94bd81ee24bb66a53c</Hash>
</Codenesium>*/