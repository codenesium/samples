using FluentAssertions;
using System;
using System.Collections.Generic;
using Xunit;

namespace StudioResourceManagerMTNS.Api.Client.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "Tenant")]
	[Trait("Area", "ApiModel")]
	public class TestApiTenantModelMapper
	{
		[Fact]
		public void MapClientRequestToResponse()
		{
			var mapper = new ApiTenantModelMapper();
			var model = new ApiTenantClientRequestModel();
			model.SetProperties("A");
			ApiTenantClientResponseModel response = mapper.MapClientRequestToResponse(1, model);
			response.Should().NotBeNull();
			response.Name.Should().Be("A");
		}

		[Fact]
		public void MapClientResponseToRequest()
		{
			var mapper = new ApiTenantModelMapper();
			var model = new ApiTenantClientResponseModel();
			model.SetProperties(1, "A");
			ApiTenantClientRequestModel response = mapper.MapClientResponseToRequest(model);
			response.Should().NotBeNull();
			response.Name.Should().Be("A");
		}
	}
}

/*<Codenesium>
    <Hash>5cc81c8b0f49a4a6c2d40c19c426b260</Hash>
</Codenesium>*/