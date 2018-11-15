using FluentAssertions;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
using PetShippingNS.Api.Services;
using System;
using System.Collections.Generic;
using Xunit;

namespace PetShippingNS.Api.Services.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "Pipeline")]
	[Trait("Area", "BOLMapper")]
	public class TestBOLPipelineMapper
	{
		[Fact]
		public void MapModelToBO()
		{
			var mapper = new BOLPipelineMapper();
			ApiPipelineServerRequestModel model = new ApiPipelineServerRequestModel();
			model.SetProperties(1, 1);
			BOPipeline response = mapper.MapModelToBO(1, model);

			response.PipelineStatusId.Should().Be(1);
			response.SaleId.Should().Be(1);
		}

		[Fact]
		public void MapBOToModel()
		{
			var mapper = new BOLPipelineMapper();
			BOPipeline bo = new BOPipeline();
			bo.SetProperties(1, 1, 1);
			ApiPipelineServerResponseModel response = mapper.MapBOToModel(bo);

			response.Id.Should().Be(1);
			response.PipelineStatusId.Should().Be(1);
			response.SaleId.Should().Be(1);
		}

		[Fact]
		public void MapBOToModelList()
		{
			var mapper = new BOLPipelineMapper();
			BOPipeline bo = new BOPipeline();
			bo.SetProperties(1, 1, 1);
			List<ApiPipelineServerResponseModel> response = mapper.MapBOToModel(new List<BOPipeline>() { { bo } });

			response.Count.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>b27ede8998cc1c27ee47e58f8cc04bbd</Hash>
</Codenesium>*/