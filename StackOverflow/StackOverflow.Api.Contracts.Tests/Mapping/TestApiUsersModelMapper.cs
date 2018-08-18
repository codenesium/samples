using FluentAssertions;
using Microsoft.AspNetCore.JsonPatch;
using StackOverflowNS.Api.Contracts;
using System;
using System.Collections.Generic;
using Xunit;

namespace StackOverflowNS.Api.Contracts.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "Users")]
	[Trait("Area", "ApiModel")]
	public class TestApiUsersModelMapper
	{
		[Fact]
		public void MapRequestToResponse()
		{
			var mapper = new ApiUsersModelMapper();
			var model = new ApiUsersRequestModel();
			model.SetProperties("A", 1, 1, DateTime.Parse("1/1/1987 12:00:00 AM"), "A", 1, "A", DateTime.Parse("1/1/1987 12:00:00 AM"), "A", 1, 1, 1, "A");
			ApiUsersResponseModel response = mapper.MapRequestToResponse(1, model);

			response.AboutMe.Should().Be("A");
			response.AccountId.Should().Be(1);
			response.Age.Should().Be(1);
			response.CreationDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.DisplayName.Should().Be("A");
			response.DownVotes.Should().Be(1);
			response.EmailHash.Should().Be("A");
			response.Id.Should().Be(1);
			response.LastAccessDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.Location.Should().Be("A");
			response.Reputation.Should().Be(1);
			response.UpVotes.Should().Be(1);
			response.Views.Should().Be(1);
			response.WebsiteUrl.Should().Be("A");
		}

		[Fact]
		public void MapResponseToRequest()
		{
			var mapper = new ApiUsersModelMapper();
			var model = new ApiUsersResponseModel();
			model.SetProperties(1, "A", 1, 1, DateTime.Parse("1/1/1987 12:00:00 AM"), "A", 1, "A", DateTime.Parse("1/1/1987 12:00:00 AM"), "A", 1, 1, 1, "A");
			ApiUsersRequestModel response = mapper.MapResponseToRequest(model);

			response.AboutMe.Should().Be("A");
			response.AccountId.Should().Be(1);
			response.Age.Should().Be(1);
			response.CreationDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.DisplayName.Should().Be("A");
			response.DownVotes.Should().Be(1);
			response.EmailHash.Should().Be("A");
			response.LastAccessDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.Location.Should().Be("A");
			response.Reputation.Should().Be(1);
			response.UpVotes.Should().Be(1);
			response.Views.Should().Be(1);
			response.WebsiteUrl.Should().Be("A");
		}

		[Fact]
		public void CreatePatch()
		{
			var mapper = new ApiUsersModelMapper();
			var model = new ApiUsersRequestModel();
			model.SetProperties("A", 1, 1, DateTime.Parse("1/1/1987 12:00:00 AM"), "A", 1, "A", DateTime.Parse("1/1/1987 12:00:00 AM"), "A", 1, 1, 1, "A");

			JsonPatchDocument<ApiUsersRequestModel> patch = mapper.CreatePatch(model);
			var response = new ApiUsersRequestModel();
			patch.ApplyTo(response);
			response.AboutMe.Should().Be("A");
			response.AccountId.Should().Be(1);
			response.Age.Should().Be(1);
			response.CreationDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.DisplayName.Should().Be("A");
			response.DownVotes.Should().Be(1);
			response.EmailHash.Should().Be("A");
			response.LastAccessDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.Location.Should().Be("A");
			response.Reputation.Should().Be(1);
			response.UpVotes.Should().Be(1);
			response.Views.Should().Be(1);
			response.WebsiteUrl.Should().Be("A");
		}
	}
}

/*<Codenesium>
    <Hash>5893cd163372017cf127e5992dc0b2b5</Hash>
</Codenesium>*/