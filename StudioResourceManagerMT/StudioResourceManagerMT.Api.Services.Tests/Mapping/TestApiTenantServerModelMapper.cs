using FluentAssertions;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using Xunit;

namespace StudioResourceManagerMTNS.Api.Services.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "Tenant")]
	[Trait("Area", "ApiModel")]
	public class TestApiTenantServerModelMapper
	{
		[Fact]
		public void MapServerRequestToResponse()
		{
			var mapper = new ApiTenantServerModelMapper();
			var model = new ApiTenantServerRequestModel();
			model.SetProperties("A");
			ApiTenantServerResponseModel response = mapper.MapServerRequestToResponse(1, model);
			response.Should().NotBeNull();
			response.Name.Should().Be("A");
		}

		[Fact]
		public void MapServerResponseToRequest()
		{
			var mapper = new ApiTenantServerModelMapper();
			var model = new ApiTenantServerResponseModel();
			model.SetProperties(1, "A");
			ApiTenantServerRequestModel response = mapper.MapServerResponseToRequest(model);
			response.Should().NotBeNull();
			response.Name.Should().Be("A");
		}

		[Fact]
		public void CreatePatch()
		{
			var mapper = new ApiTenantServerModelMapper();
			var model = new ApiTenantServerRequestModel();
			model.SetProperties("A");

			JsonPatchDocument<ApiTenantServerRequestModel> patch = mapper.CreatePatch(model);
			var response = new ApiTenantServerRequestModel();
			patch.ApplyTo(response);
			response.Name.Should().Be("A");
		}
	}
}

/*<Codenesium>
    <Hash>0cba128df9d71f2c9fd5a64e986d7ac8</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/