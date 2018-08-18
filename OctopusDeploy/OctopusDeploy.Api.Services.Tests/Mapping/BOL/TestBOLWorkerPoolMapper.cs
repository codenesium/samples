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
	[Trait("Table", "WorkerPool")]
	[Trait("Area", "BOLMapper")]
	public class TestBOLWorkerPoolMapper
	{
		[Fact]
		public void MapModelToBO()
		{
			var mapper = new BOLWorkerPoolMapper();
			ApiWorkerPoolRequestModel model = new ApiWorkerPoolRequestModel();
			model.SetProperties(true, "A", "A", 1);
			BOWorkerPool response = mapper.MapModelToBO("A", model);

			response.IsDefault.Should().Be(true);
			response.JSON.Should().Be("A");
			response.Name.Should().Be("A");
			response.SortOrder.Should().Be(1);
		}

		[Fact]
		public void MapBOToModel()
		{
			var mapper = new BOLWorkerPoolMapper();
			BOWorkerPool bo = new BOWorkerPool();
			bo.SetProperties("A", true, "A", "A", 1);
			ApiWorkerPoolResponseModel response = mapper.MapBOToModel(bo);

			response.Id.Should().Be("A");
			response.IsDefault.Should().Be(true);
			response.JSON.Should().Be("A");
			response.Name.Should().Be("A");
			response.SortOrder.Should().Be(1);
		}

		[Fact]
		public void MapBOToModelList()
		{
			var mapper = new BOLWorkerPoolMapper();
			BOWorkerPool bo = new BOWorkerPool();
			bo.SetProperties("A", true, "A", "A", 1);
			List<ApiWorkerPoolResponseModel> response = mapper.MapBOToModel(new List<BOWorkerPool>() { { bo } });

			response.Count.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>9b1f04815f8bfbfec5b2e0a3c98d93ed</Hash>
</Codenesium>*/