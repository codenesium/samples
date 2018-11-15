using FluentAssertions;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using Xunit;

namespace TwitterNS.Api.Services.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "Messenger")]
	[Trait("Area", "ApiModel")]
	public class TestApiMessengerServerModelMapper
	{
		[Fact]
		public void MapServerRequestToResponse()
		{
			var mapper = new ApiMessengerServerModelMapper();
			var model = new ApiMessengerServerRequestModel();
			model.SetProperties(DateTime.Parse("1/1/1987 12:00:00 AM"), 1, 1, TimeSpan.Parse("01:00:00"), 1, 1);
			ApiMessengerServerResponseModel response = mapper.MapServerRequestToResponse(1, model);
			response.Should().NotBeNull();
			response.Date.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.FromUserId.Should().Be(1);
			response.MessageId.Should().Be(1);
			response.Time.Should().Be(TimeSpan.Parse("01:00:00"));
			response.ToUserId.Should().Be(1);
			response.UserId.Should().Be(1);
		}

		[Fact]
		public void MapServerResponseToRequest()
		{
			var mapper = new ApiMessengerServerModelMapper();
			var model = new ApiMessengerServerResponseModel();
			model.SetProperties(1, DateTime.Parse("1/1/1987 12:00:00 AM"), 1, 1, TimeSpan.Parse("01:00:00"), 1, 1);
			ApiMessengerServerRequestModel response = mapper.MapServerResponseToRequest(model);
			response.Should().NotBeNull();
			response.Date.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.FromUserId.Should().Be(1);
			response.MessageId.Should().Be(1);
			response.Time.Should().Be(TimeSpan.Parse("01:00:00"));
			response.ToUserId.Should().Be(1);
			response.UserId.Should().Be(1);
		}

		[Fact]
		public void CreatePatch()
		{
			var mapper = new ApiMessengerServerModelMapper();
			var model = new ApiMessengerServerRequestModel();
			model.SetProperties(DateTime.Parse("1/1/1987 12:00:00 AM"), 1, 1, TimeSpan.Parse("01:00:00"), 1, 1);

			JsonPatchDocument<ApiMessengerServerRequestModel> patch = mapper.CreatePatch(model);
			var response = new ApiMessengerServerRequestModel();
			patch.ApplyTo(response);
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
    <Hash>20e65789ad0cf7eb100f0a7c29847b34</Hash>
</Codenesium>*/