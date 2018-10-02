using FluentAssertions;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using TwitterNS.Api.Contracts;
using Xunit;

namespace TwitterNS.Api.Contracts.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "Reply")]
	[Trait("Area", "ApiModel")]
	public class TestApiReplyModelMapper
	{
		[Fact]
		public void MapRequestToResponse()
		{
			var mapper = new ApiReplyModelMapper();
			var model = new ApiReplyRequestModel();
			model.SetProperties("A", DateTime.Parse("1/1/1987 12:00:00 AM"), 1, TimeSpan.Parse("0"));
			ApiReplyResponseModel response = mapper.MapRequestToResponse(1, model);

			response.Content.Should().Be("A");
			response.Date.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.ReplierUserId.Should().Be(1);
			response.ReplyId.Should().Be(1);
			response.Time.Should().Be(TimeSpan.Parse("0"));
		}

		[Fact]
		public void MapResponseToRequest()
		{
			var mapper = new ApiReplyModelMapper();
			var model = new ApiReplyResponseModel();
			model.SetProperties(1, "A", DateTime.Parse("1/1/1987 12:00:00 AM"), 1, TimeSpan.Parse("0"));
			ApiReplyRequestModel response = mapper.MapResponseToRequest(model);

			response.Content.Should().Be("A");
			response.Date.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.ReplierUserId.Should().Be(1);
			response.Time.Should().Be(TimeSpan.Parse("0"));
		}

		[Fact]
		public void CreatePatch()
		{
			var mapper = new ApiReplyModelMapper();
			var model = new ApiReplyRequestModel();
			model.SetProperties("A", DateTime.Parse("1/1/1987 12:00:00 AM"), 1, TimeSpan.Parse("0"));

			JsonPatchDocument<ApiReplyRequestModel> patch = mapper.CreatePatch(model);
			var response = new ApiReplyRequestModel();
			patch.ApplyTo(response);
			response.Content.Should().Be("A");
			response.Date.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.ReplierUserId.Should().Be(1);
			response.Time.Should().Be(TimeSpan.Parse("0"));
		}
	}
}

/*<Codenesium>
    <Hash>d4afe43fc3cb341cd62a8966ffc85559</Hash>
</Codenesium>*/