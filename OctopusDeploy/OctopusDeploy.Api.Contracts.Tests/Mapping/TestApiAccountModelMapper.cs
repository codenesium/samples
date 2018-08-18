using FluentAssertions;
using Microsoft.AspNetCore.JsonPatch;
using OctopusDeployNS.Api.Contracts;
using System;
using System.Collections.Generic;
using Xunit;

namespace OctopusDeployNS.Api.Contracts.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "Account")]
	[Trait("Area", "ApiModel")]
	public class TestApiAccountModelMapper
	{
		[Fact]
		public void MapRequestToResponse()
		{
			var mapper = new ApiAccountModelMapper();
			var model = new ApiAccountRequestModel();
			model.SetProperties("A", "A", "A", "A", "A", "A");
			ApiAccountResponseModel response = mapper.MapRequestToResponse("A", model);

			response.AccountType.Should().Be("A");
			response.EnvironmentIds.Should().Be("A");
			response.Id.Should().Be("A");
			response.JSON.Should().Be("A");
			response.Name.Should().Be("A");
			response.TenantIds.Should().Be("A");
			response.TenantTags.Should().Be("A");
		}

		[Fact]
		public void MapResponseToRequest()
		{
			var mapper = new ApiAccountModelMapper();
			var model = new ApiAccountResponseModel();
			model.SetProperties("A", "A", "A", "A", "A", "A", "A");
			ApiAccountRequestModel response = mapper.MapResponseToRequest(model);

			response.AccountType.Should().Be("A");
			response.EnvironmentIds.Should().Be("A");
			response.JSON.Should().Be("A");
			response.Name.Should().Be("A");
			response.TenantIds.Should().Be("A");
			response.TenantTags.Should().Be("A");
		}

		[Fact]
		public void CreatePatch()
		{
			var mapper = new ApiAccountModelMapper();
			var model = new ApiAccountRequestModel();
			model.SetProperties("A", "A", "A", "A", "A", "A");

			JsonPatchDocument<ApiAccountRequestModel> patch = mapper.CreatePatch(model);
			var response = new ApiAccountRequestModel();
			patch.ApplyTo(response);
			response.AccountType.Should().Be("A");
			response.EnvironmentIds.Should().Be("A");
			response.JSON.Should().Be("A");
			response.Name.Should().Be("A");
			response.TenantIds.Should().Be("A");
			response.TenantTags.Should().Be("A");
		}
	}
}

/*<Codenesium>
    <Hash>faf1d73eebeec0b34a1bc68964ac9acc</Hash>
</Codenesium>*/