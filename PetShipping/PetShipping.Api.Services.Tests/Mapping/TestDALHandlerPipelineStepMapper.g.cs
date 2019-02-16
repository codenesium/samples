using FluentAssertions;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using Xunit;

namespace PetShippingNS.Api.Services
{
	[Trait("Type", "Unit")]
	[Trait("Table", "HandlerPipelineStep")]
	[Trait("Area", "DALMapper")]
	public class TestDALHandlerPipelineStepMapper
	{
		[Fact]
		public void MapModelToEntity()
		{
			var mapper = new DALHandlerPipelineStepMapper();
			ApiHandlerPipelineStepServerRequestModel model = new ApiHandlerPipelineStepServerRequestModel();
			model.SetProperties(1, 1);
			HandlerPipelineStep response = mapper.MapModelToEntity(1, model);

			response.HandlerId.Should().Be(1);
			response.PipelineStepId.Should().Be(1);
		}

		[Fact]
		public void MapEntityToModel()
		{
			var mapper = new DALHandlerPipelineStepMapper();
			HandlerPipelineStep item = new HandlerPipelineStep();
			item.SetProperties(1, 1, 1);
			ApiHandlerPipelineStepServerResponseModel response = mapper.MapEntityToModel(item);

			response.HandlerId.Should().Be(1);
			response.Id.Should().Be(1);
			response.PipelineStepId.Should().Be(1);
		}

		[Fact]
		public void MapEntityToModelList()
		{
			var mapper = new DALHandlerPipelineStepMapper();
			HandlerPipelineStep item = new HandlerPipelineStep();
			item.SetProperties(1, 1, 1);
			List<ApiHandlerPipelineStepServerResponseModel> response = mapper.MapEntityToModel(new List<HandlerPipelineStep>() { { item} });

			response.Count.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>4f3529459bc32a76ca34efd3b7d08126</Hash>
</Codenesium>*/