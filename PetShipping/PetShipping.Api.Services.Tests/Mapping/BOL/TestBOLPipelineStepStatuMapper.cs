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
			ApiPipelineStepStatuServerRequestModel model = new ApiPipelineStepStatuServerRequestModel();
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
			ApiPipelineStepStatuServerResponseModel response = mapper.MapBOToModel(bo);

			response.Id.Should().Be(1);
			response.Name.Should().Be("A");
		}

		[Fact]
		public void MapBOToModelList()
		{
			var mapper = new BOLPipelineStepStatuMapper();
			BOPipelineStepStatu bo = new BOPipelineStepStatu();
			bo.SetProperties(1, "A");
			List<ApiPipelineStepStatuServerResponseModel> response = mapper.MapBOToModel(new List<BOPipelineStepStatu>() { { bo } });

			response.Count.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>71ac35de5a75fc76cf834643448c8277</Hash>
</Codenesium>*/