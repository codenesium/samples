using FluentAssertions;
using System;
using System.Collections.Generic;
using Xunit;

namespace StackOverflowNS.Api.Client.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "Comment")]
	[Trait("Area", "ApiModel")]
	public class TestApiCommentModelMapper
	{
		[Fact]
		public void MapClientRequestToResponse()
		{
			var mapper = new ApiCommentModelMapper();
			var model = new ApiCommentClientRequestModel();
			model.SetProperties(DateTime.Parse("1/1/1987 12:00:00 AM"), 1, 1, "A", 1);
			ApiCommentClientResponseModel response = mapper.MapClientRequestToResponse(1, model);
			response.Should().NotBeNull();
			response.CreationDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.PostId.Should().Be(1);
			response.Score.Should().Be(1);
			response.Text.Should().Be("A");
			response.UserId.Should().Be(1);
		}

		[Fact]
		public void MapClientResponseToRequest()
		{
			var mapper = new ApiCommentModelMapper();
			var model = new ApiCommentClientResponseModel();
			model.SetProperties(1, DateTime.Parse("1/1/1987 12:00:00 AM"), 1, 1, "A", 1);
			ApiCommentClientRequestModel response = mapper.MapClientResponseToRequest(model);
			response.Should().NotBeNull();
			response.CreationDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.PostId.Should().Be(1);
			response.Score.Should().Be(1);
			response.Text.Should().Be("A");
			response.UserId.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>34803b0861a50d6781ab910c0fcb0875</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/