using FluentAssertions;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using Xunit;

namespace PetShippingNS.Api.Services
{
	[Trait("Type", "Unit")]
	[Trait("Table", "PipelineStepDestination")]
	[Trait("Area", "DALMapper")]
	public class TestDALPipelineStepDestinationMapper
	{
		[Fact]
		public void MapModelToEntity()
		{
			var mapper = new DALPipelineStepDestinationMapper();
			ApiPipelineStepDestinationServerRequestModel model = new ApiPipelineStepDestinationServerRequestModel();
			model.SetProperties(1, 1);
			PipelineStepDestination response = mapper.MapModelToEntity(1, model);

			response.DestinationId.Should().Be(1);
			response.PipelineStepId.Should().Be(1);
		}

		[Fact]
		public void MapEntityToModel()
		{
			var mapper = new DALPipelineStepDestinationMapper();
			PipelineStepDestination item = new PipelineStepDestination();
			item.SetProperties(1, 1, 1);
			ApiPipelineStepDestinationServerResponseModel response = mapper.MapEntityToModel(item);

			response.DestinationId.Should().Be(1);
			response.Id.Should().Be(1);
			response.PipelineStepId.Should().Be(1);
		}

		[Fact]
		public void MapEntityToModelList()
		{
			var mapper = new DALPipelineStepDestinationMapper();
			PipelineStepDestination item = new PipelineStepDestination();
			item.SetProperties(1, 1, 1);
			List<ApiPipelineStepDestinationServerResponseModel> response = mapper.MapEntityToModel(new List<PipelineStepDestination>() { { item} });

			response.Count.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>a019bb546fd12a73878902c3a8c6a2df</Hash>
</Codenesium>*/