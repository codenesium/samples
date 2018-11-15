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
	[Trait("Table", "HandlerPipelineStep")]
	[Trait("Area", "BOLMapper")]
	public class TestBOLHandlerPipelineStepMapper
	{
		[Fact]
		public void MapModelToBO()
		{
			var mapper = new BOLHandlerPipelineStepMapper();
			ApiHandlerPipelineStepServerRequestModel model = new ApiHandlerPipelineStepServerRequestModel();
			model.SetProperties(1, 1);
			BOHandlerPipelineStep response = mapper.MapModelToBO(1, model);

			response.HandlerId.Should().Be(1);
			response.PipelineStepId.Should().Be(1);
		}

		[Fact]
		public void MapBOToModel()
		{
			var mapper = new BOLHandlerPipelineStepMapper();
			BOHandlerPipelineStep bo = new BOHandlerPipelineStep();
			bo.SetProperties(1, 1, 1);
			ApiHandlerPipelineStepServerResponseModel response = mapper.MapBOToModel(bo);

			response.HandlerId.Should().Be(1);
			response.Id.Should().Be(1);
			response.PipelineStepId.Should().Be(1);
		}

		[Fact]
		public void MapBOToModelList()
		{
			var mapper = new BOLHandlerPipelineStepMapper();
			BOHandlerPipelineStep bo = new BOHandlerPipelineStep();
			bo.SetProperties(1, 1, 1);
			List<ApiHandlerPipelineStepServerResponseModel> response = mapper.MapBOToModel(new List<BOHandlerPipelineStep>() { { bo } });

			response.Count.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>2f9f6a2fac179a9e7e7111b22c59b792</Hash>
</Codenesium>*/