using FluentAssertions;
using System;
using System.Collections.Generic;
using Xunit;

namespace StackOverflowNS.Api.Client.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "Users")]
	[Trait("Area", "ApiModel")]
	public class TestApiUsersModelMapper
	{
		[Fact]
		public void MapClientRequestToResponse()
		{
			var mapper = new ApiUsersModelMapper();
			var model = new ApiUsersClientRequestModel();
			model.SetProperties("A", 1, 1, DateTime.Parse("1/1/1987 12:00:00 AM"), "A", 1, "A", DateTime.Parse("1/1/1987 12:00:00 AM"), "A", 1, 1, 1, "A");
			ApiUsersClientResponseModel response = mapper.MapClientRequestToResponse(1, model);
			response.Should().NotBeNull();
			response.AboutMe.Should().Be("A");
			response.AccountId.Should().Be(1);
			response.Age.Should().Be(1);
			response.CreationDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.DisplayName.Should().Be("A");
			response.DownVote.Should().Be(1);
			response.EmailHash.Should().Be("A");
			response.LastAccessDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.Location.Should().Be("A");
			response.Reputation.Should().Be(1);
			response.UpVote.Should().Be(1);
			response.View.Should().Be(1);
			response.WebsiteUrl.Should().Be("A");
		}

		[Fact]
		public void MapClientResponseToRequest()
		{
			var mapper = new ApiUsersModelMapper();
			var model = new ApiUsersClientResponseModel();
			model.SetProperties(1, "A", 1, 1, DateTime.Parse("1/1/1987 12:00:00 AM"), "A", 1, "A", DateTime.Parse("1/1/1987 12:00:00 AM"), "A", 1, 1, 1, "A");
			ApiUsersClientRequestModel response = mapper.MapClientResponseToRequest(model);
			response.Should().NotBeNull();
			response.AboutMe.Should().Be("A");
			response.AccountId.Should().Be(1);
			response.Age.Should().Be(1);
			response.CreationDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.DisplayName.Should().Be("A");
			response.DownVote.Should().Be(1);
			response.EmailHash.Should().Be("A");
			response.LastAccessDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.Location.Should().Be("A");
			response.Reputation.Should().Be(1);
			response.UpVote.Should().Be(1);
			response.View.Should().Be(1);
			response.WebsiteUrl.Should().Be("A");
		}
	}
}

/*<Codenesium>
    <Hash>996f82ddc8ca2943649f0b00976a3009</Hash>
</Codenesium>*/