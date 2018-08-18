using FluentAssertions;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using OctopusDeployNS.Api.Services;
using System;
using System.Collections.Generic;
using Xunit;

namespace OctopusDeployNS.Api.Services.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "TenantVariable")]
	[Trait("Area", "BOLMapper")]
	public class TestBOLTenantVariableMapper
	{
		[Fact]
		public void MapModelToBO()
		{
			var mapper = new BOLTenantVariableMapper();
			ApiTenantVariableRequestModel model = new ApiTenantVariableRequestModel();
			model.SetProperties("A", "A", "A", "A", "A", "A");
			BOTenantVariable response = mapper.MapModelToBO("A", model);

			response.EnvironmentId.Should().Be("A");
			response.JSON.Should().Be("A");
			response.OwnerId.Should().Be("A");
			response.RelatedDocumentId.Should().Be("A");
			response.TenantId.Should().Be("A");
			response.VariableTemplateId.Should().Be("A");
		}

		[Fact]
		public void MapBOToModel()
		{
			var mapper = new BOLTenantVariableMapper();
			BOTenantVariable bo = new BOTenantVariable();
			bo.SetProperties("A", "A", "A", "A", "A", "A", "A");
			ApiTenantVariableResponseModel response = mapper.MapBOToModel(bo);

			response.EnvironmentId.Should().Be("A");
			response.Id.Should().Be("A");
			response.JSON.Should().Be("A");
			response.OwnerId.Should().Be("A");
			response.RelatedDocumentId.Should().Be("A");
			response.TenantId.Should().Be("A");
			response.VariableTemplateId.Should().Be("A");
		}

		[Fact]
		public void MapBOToModelList()
		{
			var mapper = new BOLTenantVariableMapper();
			BOTenantVariable bo = new BOTenantVariable();
			bo.SetProperties("A", "A", "A", "A", "A", "A", "A");
			List<ApiTenantVariableResponseModel> response = mapper.MapBOToModel(new List<BOTenantVariable>() { { bo } });

			response.Count.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>c3c5eacc0672bdba38b2428d13dbef93</Hash>
</Codenesium>*/