using FluentAssertions;
using System;
using System.Collections.Generic;
using Xunit;

namespace TwitterNS.Api.Client.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "Messenger")]
	[Trait("Area", "ApiModel")]
	public class TestApiMessengerModelMapper
	{
		[Fact]
		public void MapClientRequestToResponse()
		{
			var mapper = new ApiMessengerModelMapper();
			var model = new ApiMessengerClientRequestModel();
			model.SetProperties(DateTime.Parse("1/1/1987 12:00:00 AM"), 1, 1, TimeSpan.Parse("01:00:00"), 1, 1);
			ApiMessengerClientResponseModel response = mapper.MapClientRequestToResponse(1, model);
			response.Should().NotBeNull();
			response.Date.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.FromUserId.Should().Be(1);
			response.MessageId.Should().Be(1);
			response.Time.Should().Be(TimeSpan.Parse("01:00:00"));
			response.ToUserId.Should().Be(1);
			response.UserId.Should().Be(1);
		}

		[Fact]
		public void MapClientResponseToRequest()
		{
			var mapper = new ApiMessengerModelMapper();
			var model = new ApiMessengerClientResponseModel();
			model.SetProperties(1, DateTime.Parse("1/1/1987 12:00:00 AM"), 1, 1, TimeSpan.Parse("01:00:00"), 1, 1);
			ApiMessengerClientRequestModel response = mapper.MapClientResponseToRequest(model);
			response.Should().NotBeNull();
			response.Date.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.FromUserId.Should().Be(1);
			response.MessageId.Should().Be(1);
			response.Time.Should().Be(TimeSpan.Parse("01:00:00"));
			response.ToUserId.Should().Be(1);
			response.UserId.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>87bbf3fec892bcfedab287d32b334897</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/