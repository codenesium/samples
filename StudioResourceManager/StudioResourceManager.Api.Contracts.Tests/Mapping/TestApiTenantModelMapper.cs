using FluentAssertions;
using Microsoft.AspNetCore.JsonPatch;
using StudioResourceManagerNS.Api.Contracts;
using System;
using System.Collections.Generic;
using Xunit;

namespace StudioResourceManagerNS.Api.Contracts.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "Tenant")]
	[Trait("Area", "ApiModel")]
	public class TestApiTenantModelMapper
	{
		[Fact]
		public void MapRequestToResponse()
		{
			var mapper = new ApiTenantModelMapper();
			var model = new ApiTenantRequestModel();
			model.SetProperties("A");
			ApiTenantResponseModel response = mapper.MapRequestToResponse(1, model);

			response.Id.Should().Be(1);
			response.Name.Should().Be("A");
		}

		[Fact]
		public void MapResponseToRequest()
		{
			var mapper = new ApiTenantModelMapper();
			var model = new ApiTenantResponseModel();
			model.SetProperties(1, "A");
			ApiTenantRequestModel response = mapper.MapResponseToRequest(model);

			response.Name.Should().Be("A");
		}

		[Fact]
		public void CreatePatch()
		{
			var mapper = new ApiTenantModelMapper();
			var model = new ApiTenantRequestModel();
			model.SetProperties("A");

			JsonPatchDocument<ApiTenantRequestModel> patch = mapper.CreatePatch(model);
			var response = new ApiTenantRequestModel();
			patch.ApplyTo(response);
			response.Name.Should().Be("A");
		}
	}
}

/*<Codenesium>
    <Hash>25f2f6efd22831f4d5f0bcc6a4f058f5</Hash>
</Codenesium>*/