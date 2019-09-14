using FluentAssertions;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using Xunit;

namespace TwitterNS.Api.Services.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "Tweet")]
	[Trait("Area", "ApiModel")]
	public class TestApiTweetServerModelMapper
	{
		[Fact]
		public void MapServerRequestToResponse()
		{
			var mapper = new ApiTweetServerModelMapper();
			var model = new ApiTweetServerRequestModel();
			model.SetProperties("A", DateTime.Parse("1/1/1987 12:00:00 AM"), 1, TimeSpan.Parse("01:00:00"), 1);
			ApiTweetServerResponseModel response = mapper.MapServerRequestToResponse(1, model);
			response.Should().NotBeNull();
			response.Content.Should().Be("A");
			response.Date.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.LocationId.Should().Be(1);
			response.Time.Should().Be(TimeSpan.Parse("01:00:00"));
			response.UserUserId.Should().Be(1);
		}

		[Fact]
		public void MapServerResponseToRequest()
		{
			var mapper = new ApiTweetServerModelMapper();
			var model = new ApiTweetServerResponseModel();
			model.SetProperties(1, "A", DateTime.Parse("1/1/1987 12:00:00 AM"), 1, TimeSpan.Parse("01:00:00"), 1);
			ApiTweetServerRequestModel response = mapper.MapServerResponseToRequest(model);
			response.Should().NotBeNull();
			response.Content.Should().Be("A");
			response.Date.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.LocationId.Should().Be(1);
			response.Time.Should().Be(TimeSpan.Parse("01:00:00"));
			response.UserUserId.Should().Be(1);
		}

		[Fact]
		public void CreatePatch()
		{
			var mapper = new ApiTweetServerModelMapper();
			var model = new ApiTweetServerRequestModel();
			model.SetProperties("A", DateTime.Parse("1/1/1987 12:00:00 AM"), 1, TimeSpan.Parse("01:00:00"), 1);

			JsonPatchDocument<ApiTweetServerRequestModel> patch = mapper.CreatePatch(model);
			var response = new ApiTweetServerRequestModel();
			patch.ApplyTo(response);
			response.Content.Should().Be("A");
			response.Date.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.LocationId.Should().Be(1);
			response.Time.Should().Be(TimeSpan.Parse("01:00:00"));
			response.UserUserId.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>d076e0ba0f313e77d7687dc611e792da</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/