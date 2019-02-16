using FluentAssertions;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using Xunit;

namespace PetShippingNS.Api.Services
{
	[Trait("Type", "Unit")]
	[Trait("Table", "PipelineStepStatu")]
	[Trait("Area", "DALMapper")]
	public class TestDALPipelineStepStatuMapper
	{
		[Fact]
		public void MapModelToEntity()
		{
			var mapper = new DALPipelineStepStatuMapper();
			ApiPipelineStepStatuServerRequestModel model = new ApiPipelineStepStatuServerRequestModel();
			model.SetProperties("A");
			PipelineStepStatu response = mapper.MapModelToEntity(1, model);

			response.Name.Should().Be("A");
		}

		[Fact]
		public void MapEntityToModel()
		{
			var mapper = new DALPipelineStepStatuMapper();
			PipelineStepStatu item = new PipelineStepStatu();
			item.SetProperties(1, "A");
			ApiPipelineStepStatuServerResponseModel response = mapper.MapEntityToModel(item);

			response.Id.Should().Be(1);
			response.Name.Should().Be("A");
		}

		[Fact]
		public void MapEntityToModelList()
		{
			var mapper = new DALPipelineStepStatuMapper();
			PipelineStepStatu item = new PipelineStepStatu();
			item.SetProperties(1, "A");
			List<ApiPipelineStepStatuServerResponseModel> response = mapper.MapEntityToModel(new List<PipelineStepStatu>() { { item} });

			response.Count.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>c6f395fd3d472de433f2eb01ef93954e</Hash>
</Codenesium>*/