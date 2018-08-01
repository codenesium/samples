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
	[Trait("Table", "ExtensionConfiguration")]
	[Trait("Area", "BOLMapper")]
	public class TestBOLExtensionConfigurationMapper
	{
		[Fact]
		public void MapModelToBO()
		{
			var mapper = new BOLExtensionConfigurationMapper();
			ApiExtensionConfigurationRequestModel model = new ApiExtensionConfigurationRequestModel();
			model.SetProperties("A", "A", "A");
			BOExtensionConfiguration response = mapper.MapModelToBO("A", model);

			response.ExtensionAuthor.Should().Be("A");
			response.JSON.Should().Be("A");
			response.Name.Should().Be("A");
		}

		[Fact]
		public void MapBOToModel()
		{
			var mapper = new BOLExtensionConfigurationMapper();
			BOExtensionConfiguration bo = new BOExtensionConfiguration();
			bo.SetProperties("A", "A", "A", "A");
			ApiExtensionConfigurationResponseModel response = mapper.MapBOToModel(bo);

			response.ExtensionAuthor.Should().Be("A");
			response.Id.Should().Be("A");
			response.JSON.Should().Be("A");
			response.Name.Should().Be("A");
		}

		[Fact]
		public void MapBOToModelList()
		{
			var mapper = new BOLExtensionConfigurationMapper();
			BOExtensionConfiguration bo = new BOExtensionConfiguration();
			bo.SetProperties("A", "A", "A", "A");
			List<ApiExtensionConfigurationResponseModel> response = mapper.MapBOToModel(new List<BOExtensionConfiguration>() { { bo } });

			response.Count.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>48ae9042bd89f0a8f7fa7ee5642516b6</Hash>
</Codenesium>*/