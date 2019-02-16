using FluentAssertions;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using Xunit;

namespace PetShippingNS.Api.Services
{
	[Trait("Type", "Unit")]
	[Trait("Table", "PipelineStep")]
	[Trait("Area", "DALMapper")]
	public class TestDALPipelineStepMapper
	{
		[Fact]
		public void MapModelToEntity()
		{
			var mapper = new DALPipelineStepMapper();
			ApiPipelineStepServerRequestModel model = new ApiPipelineStepServerRequestModel();
			model.SetProperties("A", 1, 1);
			PipelineStep response = mapper.MapModelToEntity(1, model);

			response.Name.Should().Be("A");
			response.PipelineStepStatusId.Should().Be(1);
			response.ShipperId.Should().Be(1);
		}

		[Fact]
		public void MapEntityToModel()
		{
			var mapper = new DALPipelineStepMapper();
			PipelineStep item = new PipelineStep();
			item.SetProperties(1, "A", 1, 1);
			ApiPipelineStepServerResponseModel response = mapper.MapEntityToModel(item);

			response.Id.Should().Be(1);
			response.Name.Should().Be("A");
			response.PipelineStepStatusId.Should().Be(1);
			response.ShipperId.Should().Be(1);
		}

		[Fact]
		public void MapEntityToModelList()
		{
			var mapper = new DALPipelineStepMapper();
			PipelineStep item = new PipelineStep();
			item.SetProperties(1, "A", 1, 1);
			List<ApiPipelineStepServerResponseModel> response = mapper.MapEntityToModel(new List<PipelineStep>() { { item} });

			response.Count.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>8ddf45fe320c144c26a7ca793e1ae80c</Hash>
</Codenesium>*/