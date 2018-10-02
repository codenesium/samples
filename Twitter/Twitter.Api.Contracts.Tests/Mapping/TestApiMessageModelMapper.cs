using FluentAssertions;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using TwitterNS.Api.Contracts;
using Xunit;

namespace TwitterNS.Api.Contracts.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "Message")]
	[Trait("Area", "ApiModel")]
	public class TestApiMessageModelMapper
	{
		[Fact]
		public void MapRequestToResponse()
		{
			var mapper = new ApiMessageModelMapper();
			var model = new ApiMessageRequestModel();
			model.SetProperties("A", 1);
			ApiMessageResponseModel response = mapper.MapRequestToResponse(1, model);

			response.Content.Should().Be("A");
			response.MessageId.Should().Be(1);
			response.SenderUserId.Should().Be(1);
		}

		[Fact]
		public void MapResponseToRequest()
		{
			var mapper = new ApiMessageModelMapper();
			var model = new ApiMessageResponseModel();
			model.SetProperties(1, "A", 1);
			ApiMessageRequestModel response = mapper.MapResponseToRequest(model);

			response.Content.Should().Be("A");
			response.SenderUserId.Should().Be(1);
		}

		[Fact]
		public void CreatePatch()
		{
			var mapper = new ApiMessageModelMapper();
			var model = new ApiMessageRequestModel();
			model.SetProperties("A", 1);

			JsonPatchDocument<ApiMessageRequestModel> patch = mapper.CreatePatch(model);
			var response = new ApiMessageRequestModel();
			patch.ApplyTo(response);
			response.Content.Should().Be("A");
			response.SenderUserId.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>e5c9b7c0b08e1e4a81b817deabe231fe</Hash>
</Codenesium>*/