using FluentAssertions;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using Xunit;

namespace TwitterNS.Api.Services.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "QuoteTweet")]
	[Trait("Area", "ApiModel")]
	public class TestApiQuoteTweetServerModelMapper
	{
		[Fact]
		public void MapServerRequestToResponse()
		{
			var mapper = new ApiQuoteTweetServerModelMapper();
			var model = new ApiQuoteTweetServerRequestModel();
			model.SetProperties("A", DateTime.Parse("1/1/1987 12:00:00 AM"), 1, 1, TimeSpan.Parse("01:00:00"));
			ApiQuoteTweetServerResponseModel response = mapper.MapServerRequestToResponse(1, model);
			response.Should().NotBeNull();
			response.Content.Should().Be("A");
			response.Date.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.RetweeterUserId.Should().Be(1);
			response.SourceTweetId.Should().Be(1);
			response.Time.Should().Be(TimeSpan.Parse("01:00:00"));
		}

		[Fact]
		public void MapServerResponseToRequest()
		{
			var mapper = new ApiQuoteTweetServerModelMapper();
			var model = new ApiQuoteTweetServerResponseModel();
			model.SetProperties(1, "A", DateTime.Parse("1/1/1987 12:00:00 AM"), 1, 1, TimeSpan.Parse("01:00:00"));
			ApiQuoteTweetServerRequestModel response = mapper.MapServerResponseToRequest(model);
			response.Should().NotBeNull();
			response.Content.Should().Be("A");
			response.Date.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.RetweeterUserId.Should().Be(1);
			response.SourceTweetId.Should().Be(1);
			response.Time.Should().Be(TimeSpan.Parse("01:00:00"));
		}

		[Fact]
		public void CreatePatch()
		{
			var mapper = new ApiQuoteTweetServerModelMapper();
			var model = new ApiQuoteTweetServerRequestModel();
			model.SetProperties("A", DateTime.Parse("1/1/1987 12:00:00 AM"), 1, 1, TimeSpan.Parse("01:00:00"));

			JsonPatchDocument<ApiQuoteTweetServerRequestModel> patch = mapper.CreatePatch(model);
			var response = new ApiQuoteTweetServerRequestModel();
			patch.ApplyTo(response);
			response.Content.Should().Be("A");
			response.Date.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.RetweeterUserId.Should().Be(1);
			response.SourceTweetId.Should().Be(1);
			response.Time.Should().Be(TimeSpan.Parse("01:00:00"));
		}
	}
}

/*<Codenesium>
    <Hash>9e05b8c4e2be1f14b4ddb90040c5892a</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/