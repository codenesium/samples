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
			ApiPipelineStepDestinationServerRequestModel model = new ApiPipelineStepDestinationServerRequestModel();
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
			ApiPipelineStepDestinationServerResponseModel response = mapper.MapBOToModel(bo);

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
			List<ApiPipelineStepDestinationServerResponseModel> response = mapper.MapBOToModel(new List<BOPipelineStepDestination>() { { bo } });

			response.Count.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>238a72dc3365503e49a1cbc02c8328a1</Hash>
</Codenesium>*/