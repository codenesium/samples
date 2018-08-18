using FluentAssertions;
using Microsoft.AspNetCore.JsonPatch;
using OctopusDeployNS.Api.Contracts;
using System;
using System.Collections.Generic;
using Xunit;

namespace OctopusDeployNS.Api.Contracts.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "TenantVariable")]
	[Trait("Area", "ApiModel")]
	public class TestApiTenantVariableModelMapper
	{
		[Fact]
		public void MapRequestToResponse()
		{
			var mapper = new ApiTenantVariableModelMapper();
			var model = new ApiTenantVariableRequestModel();
			model.SetProperties("A", "A", "A", "A", "A", "A");
			ApiTenantVariableResponseModel response = mapper.MapRequestToResponse("A", model);

			response.EnvironmentId.Should().Be("A");
			response.Id.Should().Be("A");
			response.JSON.Should().Be("A");
			response.OwnerId.Should().Be("A");
			response.RelatedDocumentId.Should().Be("A");
			response.TenantId.Should().Be("A");
			response.VariableTemplateId.Should().Be("A");
		}

		[Fact]
		public void MapResponseToRequest()
		{
			var mapper = new ApiTenantVariableModelMapper();
			var model = new ApiTenantVariableResponseModel();
			model.SetProperties("A", "A", "A", "A", "A", "A", "A");
			ApiTenantVariableRequestModel response = mapper.MapResponseToRequest(model);

			response.EnvironmentId.Should().Be("A");
			response.JSON.Should().Be("A");
			response.OwnerId.Should().Be("A");
			response.RelatedDocumentId.Should().Be("A");
			response.TenantId.Should().Be("A");
			response.VariableTemplateId.Should().Be("A");
		}

		[Fact]
		public void CreatePatch()
		{
			var mapper = new ApiTenantVariableModelMapper();
			var model = new ApiTenantVariableRequestModel();
			model.SetProperties("A", "A", "A", "A", "A", "A");

			JsonPatchDocument<ApiTenantVariableRequestModel> patch = mapper.CreatePatch(model);
			var response = new ApiTenantVariableRequestModel();
			patch.ApplyTo(response);
			response.EnvironmentId.Should().Be("A");
			response.JSON.Should().Be("A");
			response.OwnerId.Should().Be("A");
			response.RelatedDocumentId.Should().Be("A");
			response.TenantId.Should().Be("A");
			response.VariableTemplateId.Should().Be("A");
		}
	}
}

/*<Codenesium>
    <Hash>7f9ca8dc1ef8a5c7a95c52d99061f84e</Hash>
</Codenesium>*/