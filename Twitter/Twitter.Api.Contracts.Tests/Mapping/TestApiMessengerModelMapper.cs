using FluentAssertions;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using TwitterNS.Api.Contracts;
using Xunit;

namespace TwitterNS.Api.Contracts.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "Messenger")]
	[Trait("Area", "ApiModel")]
	public class TestApiMessengerModelMapper
	{
		[Fact]
		public void MapRequestToResponse()
		{
			var mapper = new ApiMessengerModelMapper();
			var model = new ApiMessengerRequestModel();
			model.SetProperties(DateTime.Parse("1/1/1987 12:00:00 AM"), 1, 1, TimeSpan.Parse("0"), 1, 1);
			ApiMessengerResponseModel response = mapper.MapRequestToResponse(1, model);

			response.Date.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.FromUserId.Should().Be(1);
			response.Id.Should().Be(1);
			response.MessageId.Should().Be(1);
			response.Time.Should().Be(TimeSpan.Parse("0"));
			response.ToUserId.Should().Be(1);
			response.UserId.Should().Be(1);
		}

		[Fact]
		public void MapResponseToRequest()
		{
			var mapper = new ApiMessengerModelMapper();
			var model = new ApiMessengerResponseModel();
			model.SetProperties(1, DateTime.Parse("1/1/1987 12:00:00 AM"), 1, 1, TimeSpan.Parse("0"), 1, 1);
			ApiMessengerRequestModel response = mapper.MapResponseToRequest(model);

			response.Date.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.FromUserId.Should().Be(1);
			response.MessageId.Should().Be(1);
			response.Time.Should().Be(TimeSpan.Parse("0"));
			response.ToUserId.Should().Be(1);
			response.UserId.Should().Be(1);
		}

		[Fact]
		public void CreatePatch()
		{
			var mapper = new ApiMessengerModelMapper();
			var model = new ApiMessengerRequestModel();
			model.SetProperties(DateTime.Parse("1/1/1987 12:00:00 AM"), 1, 1, TimeSpan.Parse("0"), 1, 1);

			JsonPatchDocument<ApiMessengerRequestModel> patch = mapper.CreatePatch(model);
			var response = new ApiMessengerRequestModel();
			patch.ApplyTo(response);
			response.Date.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.FromUserId.Should().Be(1);
			response.MessageId.Should().Be(1);
			response.Time.Should().Be(TimeSpan.Parse("0"));
			response.ToUserId.Should().Be(1);
			response.UserId.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>6f5136d8d2d13471b27d9b74d981d6a1</Hash>
</Codenesium>*/