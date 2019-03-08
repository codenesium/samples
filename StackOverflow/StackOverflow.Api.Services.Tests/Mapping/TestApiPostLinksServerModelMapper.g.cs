using FluentAssertions;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using Xunit;

namespace StackOverflowNS.Api.Services.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "PostLinks")]
	[Trait("Area", "ApiModel")]
	public class TestApiPostLinksServerModelMapper
	{
		[Fact]
		public void MapServerRequestToResponse()
		{
			var mapper = new ApiPostLinksServerModelMapper();
			var model = new ApiPostLinksServerRequestModel();
			model.SetProperties(DateTime.Parse("1/1/1987 12:00:00 AM"), 1, 1, 1);
			ApiPostLinksServerResponseModel response = mapper.MapServerRequestToResponse(1, model);
			response.Should().NotBeNull();
			response.CreationDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.LinkTypeId.Should().Be(1);
			response.PostId.Should().Be(1);
			response.RelatedPostId.Should().Be(1);
		}

		[Fact]
		public void MapServerResponseToRequest()
		{
			var mapper = new ApiPostLinksServerModelMapper();
			var model = new ApiPostLinksServerResponseModel();
			model.SetProperties(1, DateTime.Parse("1/1/1987 12:00:00 AM"), 1, 1, 1);
			ApiPostLinksServerRequestModel response = mapper.MapServerResponseToRequest(model);
			response.Should().NotBeNull();
			response.CreationDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.LinkTypeId.Should().Be(1);
			response.PostId.Should().Be(1);
			response.RelatedPostId.Should().Be(1);
		}

		[Fact]
		public void CreatePatch()
		{
			var mapper = new ApiPostLinksServerModelMapper();
			var model = new ApiPostLinksServerRequestModel();
			model.SetProperties(DateTime.Parse("1/1/1987 12:00:00 AM"), 1, 1, 1);

			JsonPatchDocument<ApiPostLinksServerRequestModel> patch = mapper.CreatePatch(model);
			var response = new ApiPostLinksServerRequestModel();
			patch.ApplyTo(response);
			response.CreationDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.LinkTypeId.Should().Be(1);
			response.PostId.Should().Be(1);
			response.RelatedPostId.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>b30e3808341ea5292a9ea5762698eecd</Hash>
</Codenesium>*/