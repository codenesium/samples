using FluentAssertions;
using System;
using System.Collections.Generic;
using Xunit;

namespace TwitterNS.Api.Client.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "Reply")]
	[Trait("Area", "ApiModel")]
	public class TestApiReplyModelMapper
	{
		[Fact]
		public void MapClientRequestToResponse()
		{
			var mapper = new ApiReplyModelMapper();
			var model = new ApiReplyClientRequestModel();
			model.SetProperties("A", DateTime.Parse("1/1/1987 12:00:00 AM"), 1, TimeSpan.Parse("01:00:00"));
			ApiReplyClientResponseModel response = mapper.MapClientRequestToResponse(1, model);
			response.Should().NotBeNull();
			response.Content.Should().Be("A");
			response.Date.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.ReplierUserId.Should().Be(1);
			response.Time.Should().Be(TimeSpan.Parse("01:00:00"));
		}

		[Fact]
		public void MapClientResponseToRequest()
		{
			var mapper = new ApiReplyModelMapper();
			var model = new ApiReplyClientResponseModel();
			model.SetProperties(1, "A", DateTime.Parse("1/1/1987 12:00:00 AM"), 1, TimeSpan.Parse("01:00:00"));
			ApiReplyClientRequestModel response = mapper.MapClientResponseToRequest(model);
			response.Should().NotBeNull();
			response.Content.Should().Be("A");
			response.Date.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.ReplierUserId.Should().Be(1);
			response.Time.Should().Be(TimeSpan.Parse("01:00:00"));
		}
	}
}

/*<Codenesium>
    <Hash>cd2b65f5211574f0b56eab4acfc4deec</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/