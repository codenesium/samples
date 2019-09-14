using FluentAssertions;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using Xunit;

namespace PetShippingNS.Api.Services
{
	[Trait("Type", "Unit")]
	[Trait("Table", "PipelineStepStatus")]
	[Trait("Area", "DALMapper")]
	public class TestDALPipelineStepStatusMapper
	{
		[Fact]
		public void MapModelToEntity()
		{
			var mapper = new DALPipelineStepStatusMapper();
			ApiPipelineStepStatusServerRequestModel model = new ApiPipelineStepStatusServerRequestModel();
			model.SetProperties("A");
			PipelineStepStatus response = mapper.MapModelToEntity(1, model);

			response.Name.Should().Be("A");
		}

		[Fact]
		public void MapEntityToModel()
		{
			var mapper = new DALPipelineStepStatusMapper();
			PipelineStepStatus item = new PipelineStepStatus();
			item.SetProperties(1, "A");
			ApiPipelineStepStatusServerResponseModel response = mapper.MapEntityToModel(item);

			response.Id.Should().Be(1);
			response.Name.Should().Be("A");
		}

		[Fact]
		public void MapEntityToModelList()
		{
			var mapper = new DALPipelineStepStatusMapper();
			PipelineStepStatus item = new PipelineStepStatus();
			item.SetProperties(1, "A");
			List<ApiPipelineStepStatusServerResponseModel> response = mapper.MapEntityToModel(new List<PipelineStepStatus>() { { item} });

			response.Count.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>68d79af2058604c365a44e106bd2fe47</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/