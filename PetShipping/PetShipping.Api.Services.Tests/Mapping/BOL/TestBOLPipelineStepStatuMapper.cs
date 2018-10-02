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
	[Trait("Table", "PipelineStepStatu")]
	[Trait("Area", "BOLMapper")]
	public class TestBOLPipelineStepStatuMapper
	{
		[Fact]
		public void MapModelToBO()
		{
			var mapper = new BOLPipelineStepStatuMapper();
			ApiPipelineStepStatuRequestModel model = new ApiPipelineStepStatuRequestModel();
			model.SetProperties("A");
			BOPipelineStepStatu response = mapper.MapModelToBO(1, model);

			response.Name.Should().Be("A");
		}

		[Fact]
		public void MapBOToModel()
		{
			var mapper = new BOLPipelineStepStatuMapper();
			BOPipelineStepStatu bo = new BOPipelineStepStatu();
			bo.SetProperties(1, "A");
			ApiPipelineStepStatuResponseModel response = mapper.MapBOToModel(bo);

			response.Id.Should().Be(1);
			response.Name.Should().Be("A");
		}

		[Fact]
		public void MapBOToModelList()
		{
			var mapper = new BOLPipelineStepStatuMapper();
			BOPipelineStepStatu bo = new BOPipelineStepStatu();
			bo.SetProperties(1, "A");
			List<ApiPipelineStepStatuResponseModel> response = mapper.MapBOToModel(new List<BOPipelineStepStatu>() { { bo } });

			response.Count.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>507d23f60f532b202a3929d47e847435</Hash>
</Codenesium>*/