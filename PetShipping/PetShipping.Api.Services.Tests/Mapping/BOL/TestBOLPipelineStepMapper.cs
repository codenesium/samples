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
	[Trait("Table", "PipelineStep")]
	[Trait("Area", "BOLMapper")]
	public class TestBOLPipelineStepMapper
	{
		[Fact]
		public void MapModelToBO()
		{
			var mapper = new BOLPipelineStepMapper();
			ApiPipelineStepRequestModel model = new ApiPipelineStepRequestModel();
			model.SetProperties("A", 1, 1);
			BOPipelineStep response = mapper.MapModelToBO(1, model);

			response.Name.Should().Be("A");
			response.PipelineStepStatusId.Should().Be(1);
			response.ShipperId.Should().Be(1);
		}

		[Fact]
		public void MapBOToModel()
		{
			var mapper = new BOLPipelineStepMapper();
			BOPipelineStep bo = new BOPipelineStep();
			bo.SetProperties(1, "A", 1, 1);
			ApiPipelineStepResponseModel response = mapper.MapBOToModel(bo);

			response.Id.Should().Be(1);
			response.Name.Should().Be("A");
			response.PipelineStepStatusId.Should().Be(1);
			response.ShipperId.Should().Be(1);
		}

		[Fact]
		public void MapBOToModelList()
		{
			var mapper = new BOLPipelineStepMapper();
			BOPipelineStep bo = new BOPipelineStep();
			bo.SetProperties(1, "A", 1, 1);
			List<ApiPipelineStepResponseModel> response = mapper.MapBOToModel(new List<BOPipelineStep>() { { bo } });

			response.Count.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>5967b4334946771dd05d7fc59ee91801</Hash>
</Codenesium>*/