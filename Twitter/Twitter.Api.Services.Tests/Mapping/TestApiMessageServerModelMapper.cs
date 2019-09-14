using FluentAssertions;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using Xunit;

namespace TwitterNS.Api.Services.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "Message")]
	[Trait("Area", "ApiModel")]
	public class TestApiMessageServerModelMapper
	{
		[Fact]
		public void MapServerRequestToResponse()
		{
			var mapper = new ApiMessageServerModelMapper();
			var model = new ApiMessageServerRequestModel();
			model.SetProperties("A", 1);
			ApiMessageServerResponseModel response = mapper.MapServerRequestToResponse(1, model);
			response.Should().NotBeNull();
			response.Content.Should().Be("A");
			response.SenderUserId.Should().Be(1);
		}

		[Fact]
		public void MapServerResponseToRequest()
		{
			var mapper = new ApiMessageServerModelMapper();
			var model = new ApiMessageServerResponseModel();
			model.SetProperties(1, "A", 1);
			ApiMessageServerRequestModel response = mapper.MapServerResponseToRequest(model);
			response.Should().NotBeNull();
			response.Content.Should().Be("A");
			response.SenderUserId.Should().Be(1);
		}

		[Fact]
		public void CreatePatch()
		{
			var mapper = new ApiMessageServerModelMapper();
			var model = new ApiMessageServerRequestModel();
			model.SetProperties("A", 1);

			JsonPatchDocument<ApiMessageServerRequestModel> patch = mapper.CreatePatch(model);
			var response = new ApiMessageServerRequestModel();
			patch.ApplyTo(response);
			response.Content.Should().Be("A");
			response.SenderUserId.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>e0ae05502874be2ca57127b7901421cb</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/