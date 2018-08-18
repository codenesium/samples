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
	[Trait("Table", "Release")]
	[Trait("Area", "BOLMapper")]
	public class TestBOLReleaseMapper
	{
		[Fact]
		public void MapModelToBO()
		{
			var mapper = new BOLReleaseMapper();
			ApiReleaseRequestModel model = new ApiReleaseRequestModel();
			model.SetProperties(DateTimeOffset.Parse("1/1/1987 12:00:00 AM"), "A", "A", "A", "A", "A", "A");
			BORelease response = mapper.MapModelToBO("A", model);

			response.Assembled.Should().Be(DateTimeOffset.Parse("1/1/1987 12:00:00 AM"));
			response.ChannelId.Should().Be("A");
			response.JSON.Should().Be("A");
			response.ProjectDeploymentProcessSnapshotId.Should().Be("A");
			response.ProjectId.Should().Be("A");
			response.ProjectVariableSetSnapshotId.Should().Be("A");
			response.Version.Should().Be("A");
		}

		[Fact]
		public void MapBOToModel()
		{
			var mapper = new BOLReleaseMapper();
			BORelease bo = new BORelease();
			bo.SetProperties("A", DateTimeOffset.Parse("1/1/1987 12:00:00 AM"), "A", "A", "A", "A", "A", "A");
			ApiReleaseResponseModel response = mapper.MapBOToModel(bo);

			response.Assembled.Should().Be(DateTimeOffset.Parse("1/1/1987 12:00:00 AM"));
			response.ChannelId.Should().Be("A");
			response.Id.Should().Be("A");
			response.JSON.Should().Be("A");
			response.ProjectDeploymentProcessSnapshotId.Should().Be("A");
			response.ProjectId.Should().Be("A");
			response.ProjectVariableSetSnapshotId.Should().Be("A");
			response.Version.Should().Be("A");
		}

		[Fact]
		public void MapBOToModelList()
		{
			var mapper = new BOLReleaseMapper();
			BORelease bo = new BORelease();
			bo.SetProperties("A", DateTimeOffset.Parse("1/1/1987 12:00:00 AM"), "A", "A", "A", "A", "A", "A");
			List<ApiReleaseResponseModel> response = mapper.MapBOToModel(new List<BORelease>() { { bo } });

			response.Count.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>b24159cc50db32780fdf056d1f2e506b</Hash>
</Codenesium>*/