using FluentAssertions;
using Microsoft.AspNetCore.JsonPatch;
using StackOverflowNS.Api.Contracts;
using System;
using System.Collections.Generic;
using Xunit;

namespace StackOverflowNS.Api.Contracts.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "Badges")]
	[Trait("Area", "ApiModel")]
	public class TestApiBadgesModelMapper
	{
		[Fact]
		public void MapRequestToResponse()
		{
			var mapper = new ApiBadgesModelMapper();
			var model = new ApiBadgesRequestModel();
			model.SetProperties(DateTime.Parse("1/1/1987 12:00:00 AM"), "A", 1);
			ApiBadgesResponseModel response = mapper.MapRequestToResponse(1, model);

			response.Date.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.Id.Should().Be(1);
			response.Name.Should().Be("A");
			response.UserId.Should().Be(1);
		}

		[Fact]
		public void MapResponseToRequest()
		{
			var mapper = new ApiBadgesModelMapper();
			var model = new ApiBadgesResponseModel();
			model.SetProperties(1, DateTime.Parse("1/1/1987 12:00:00 AM"), "A", 1);
			ApiBadgesRequestModel response = mapper.MapResponseToRequest(model);

			response.Date.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.Name.Should().Be("A");
			response.UserId.Should().Be(1);
		}

		[Fact]
		public void CreatePatch()
		{
			var mapper = new ApiBadgesModelMapper();
			var model = new ApiBadgesRequestModel();
			model.SetProperties(DateTime.Parse("1/1/1987 12:00:00 AM"), "A", 1);

			JsonPatchDocument<ApiBadgesRequestModel> patch = mapper.CreatePatch(model);
			var response = new ApiBadgesRequestModel();
			patch.ApplyTo(response);
			response.Date.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.Name.Should().Be("A");
			response.UserId.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>b8f2527d44724e61f7722d88ba37b5aa</Hash>
</Codenesium>*/