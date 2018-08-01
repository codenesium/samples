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
	[Trait("Table", "Channel")]
	[Trait("Area", "BOLMapper")]
	public class TestBOLChannelMapper
	{
		[Fact]
		public void MapModelToBO()
		{
			var mapper = new BOLChannelMapper();
			ApiChannelRequestModel model = new ApiChannelRequestModel();
			model.SetProperties(BitConverter.GetBytes(1), "A", "A", "A", "A", "A");
			BOChannel response = mapper.MapModelToBO("A", model);

			response.DataVersion.Should().BeEquivalentTo(BitConverter.GetBytes(1));
			response.JSON.Should().Be("A");
			response.LifecycleId.Should().Be("A");
			response.Name.Should().Be("A");
			response.ProjectId.Should().Be("A");
			response.TenantTags.Should().Be("A");
		}

		[Fact]
		public void MapBOToModel()
		{
			var mapper = new BOLChannelMapper();
			BOChannel bo = new BOChannel();
			bo.SetProperties("A", BitConverter.GetBytes(1), "A", "A", "A", "A", "A");
			ApiChannelResponseModel response = mapper.MapBOToModel(bo);

			response.DataVersion.Should().BeEquivalentTo(BitConverter.GetBytes(1));
			response.Id.Should().Be("A");
			response.JSON.Should().Be("A");
			response.LifecycleId.Should().Be("A");
			response.Name.Should().Be("A");
			response.ProjectId.Should().Be("A");
			response.TenantTags.Should().Be("A");
		}

		[Fact]
		public void MapBOToModelList()
		{
			var mapper = new BOLChannelMapper();
			BOChannel bo = new BOChannel();
			bo.SetProperties("A", BitConverter.GetBytes(1), "A", "A", "A", "A", "A");
			List<ApiChannelResponseModel> response = mapper.MapBOToModel(new List<BOChannel>() { { bo } });

			response.Count.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>e34b1b5c13f4db86ae8fc248b8a7f5e7</Hash>
</Codenesium>*/