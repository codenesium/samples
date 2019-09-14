using FluentAssertions;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using Xunit;

namespace NebulaNS.Api.Services.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "Organization")]
	[Trait("Area", "ApiModel")]
	public class TestApiOrganizationServerModelMapper
	{
		[Fact]
		public void MapServerRequestToResponse()
		{
			var mapper = new ApiOrganizationServerModelMapper();
			var model = new ApiOrganizationServerRequestModel();
			model.SetProperties("A");
			ApiOrganizationServerResponseModel response = mapper.MapServerRequestToResponse(1, model);
			response.Should().NotBeNull();
			response.Name.Should().Be("A");
		}

		[Fact]
		public void MapServerResponseToRequest()
		{
			var mapper = new ApiOrganizationServerModelMapper();
			var model = new ApiOrganizationServerResponseModel();
			model.SetProperties(1, "A");
			ApiOrganizationServerRequestModel response = mapper.MapServerResponseToRequest(model);
			response.Should().NotBeNull();
			response.Name.Should().Be("A");
		}

		[Fact]
		public void CreatePatch()
		{
			var mapper = new ApiOrganizationServerModelMapper();
			var model = new ApiOrganizationServerRequestModel();
			model.SetProperties("A");

			JsonPatchDocument<ApiOrganizationServerRequestModel> patch = mapper.CreatePatch(model);
			var response = new ApiOrganizationServerRequestModel();
			patch.ApplyTo(response);
			response.Name.Should().Be("A");
		}
	}
}

/*<Codenesium>
    <Hash>1914137b263c851f3109d4df41bd72a4</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/