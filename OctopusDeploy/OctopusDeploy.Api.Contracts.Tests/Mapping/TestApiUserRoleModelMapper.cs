using FluentAssertions;
using Microsoft.AspNetCore.JsonPatch;
using OctopusDeployNS.Api.Contracts;
using System;
using System.Collections.Generic;
using Xunit;

namespace OctopusDeployNS.Api.Contracts.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "UserRole")]
	[Trait("Area", "ApiModel")]
	public class TestApiUserRoleModelMapper
	{
		[Fact]
		public void MapRequestToResponse()
		{
			var mapper = new ApiUserRoleModelMapper();
			var model = new ApiUserRoleRequestModel();
			model.SetProperties("A", "A");
			ApiUserRoleResponseModel response = mapper.MapRequestToResponse("A", model);

			response.Id.Should().Be("A");
			response.JSON.Should().Be("A");
			response.Name.Should().Be("A");
		}

		[Fact]
		public void MapResponseToRequest()
		{
			var mapper = new ApiUserRoleModelMapper();
			var model = new ApiUserRoleResponseModel();
			model.SetProperties("A", "A", "A");
			ApiUserRoleRequestModel response = mapper.MapResponseToRequest(model);

			response.JSON.Should().Be("A");
			response.Name.Should().Be("A");
		}

		[Fact]
		public void CreatePatch()
		{
			var mapper = new ApiUserRoleModelMapper();
			var model = new ApiUserRoleRequestModel();
			model.SetProperties("A", "A");

			JsonPatchDocument<ApiUserRoleRequestModel> patch = mapper.CreatePatch(model);
			var response = new ApiUserRoleRequestModel();
			patch.ApplyTo(response);
			response.JSON.Should().Be("A");
			response.Name.Should().Be("A");
		}
	}
}

/*<Codenesium>
    <Hash>89b8970990db6ca45e1d02ff469c37df</Hash>
</Codenesium>*/