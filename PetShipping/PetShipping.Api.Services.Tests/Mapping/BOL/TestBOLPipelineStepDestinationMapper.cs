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
	[Trait("Table", "PipelineStepDestination")]
	[Trait("Area", "BOLMapper")]
	public class TestBOLPipelineStepDestinationMapper
	{
		[Fact]
		public void MapModelToBO()
		{
			var mapper = new BOLPipelineStepDestinationMapper();
			ApiPipelineStepDestinationRequestModel model = new ApiPipelineStepDestinationRequestModel();
			model.SetProperties(1, 1);
			BOPipelineStepDestination response = mapper.MapModelToBO(1, model);

			response.DestinationId.Should().Be(1);
			response.PipelineStepId.Should().Be(1);
		}

		[Fact]
		public void MapBOToModel()
		{
			var mapper = new BOLPipelineStepDestinationMapper();
			BOPipelineStepDestination bo = new BOPipelineStepDestination();
			bo.SetProperties(1, 1, 1);
			ApiPipelineStepDestinationResponseModel response = mapper.MapBOToModel(bo);

			response.DestinationId.Should().Be(1);
			response.Id.Should().Be(1);
			response.PipelineStepId.Should().Be(1);
		}

		[Fact]
		public void MapBOToModelList()
		{
			var mapper = new BOLPipelineStepDestinationMapper();
			BOPipelineStepDestination bo = new BOPipelineStepDestination();
			bo.SetProperties(1, 1, 1);
			List<ApiPipelineStepDestinationResponseModel> response = mapper.MapBOToModel(new List<BOPipelineStepDestination>() { { bo } });

			response.Count.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>99ff546c9a8324d9942c1c76292e0770</Hash>
</Codenesium>*/