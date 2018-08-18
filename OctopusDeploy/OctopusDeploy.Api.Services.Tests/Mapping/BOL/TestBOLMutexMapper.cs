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
	[Trait("Table", "Mutex")]
	[Trait("Area", "BOLMapper")]
	public class TestBOLMutexMapper
	{
		[Fact]
		public void MapModelToBO()
		{
			var mapper = new BOLMutexMapper();
			ApiMutexRequestModel model = new ApiMutexRequestModel();
			model.SetProperties("A");
			BOMutex response = mapper.MapModelToBO("A", model);

			response.JSON.Should().Be("A");
		}

		[Fact]
		public void MapBOToModel()
		{
			var mapper = new BOLMutexMapper();
			BOMutex bo = new BOMutex();
			bo.SetProperties("A", "A");
			ApiMutexResponseModel response = mapper.MapBOToModel(bo);

			response.Id.Should().Be("A");
			response.JSON.Should().Be("A");
		}

		[Fact]
		public void MapBOToModelList()
		{
			var mapper = new BOLMutexMapper();
			BOMutex bo = new BOMutex();
			bo.SetProperties("A", "A");
			List<ApiMutexResponseModel> response = mapper.MapBOToModel(new List<BOMutex>() { { bo } });

			response.Count.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>523d61e6b60b83b1d831d5f28a0a309f</Hash>
</Codenesium>*/