using FluentAssertions;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using Xunit;

namespace PetShippingNS.Api.Services
{
	[Trait("Type", "Unit")]
	[Trait("Table", "PipelineStatu")]
	[Trait("Area", "DALMapper")]
	public class TestDALPipelineStatuMapper
	{
		[Fact]
		public void MapModelToEntity()
		{
			var mapper = new DALPipelineStatuMapper();
			ApiPipelineStatuServerRequestModel model = new ApiPipelineStatuServerRequestModel();
			model.SetProperties("A");
			PipelineStatu response = mapper.MapModelToEntity(1, model);

			response.Name.Should().Be("A");
		}

		[Fact]
		public void MapEntityToModel()
		{
			var mapper = new DALPipelineStatuMapper();
			PipelineStatu item = new PipelineStatu();
			item.SetProperties(1, "A");
			ApiPipelineStatuServerResponseModel response = mapper.MapEntityToModel(item);

			response.Id.Should().Be(1);
			response.Name.Should().Be("A");
		}

		[Fact]
		public void MapEntityToModelList()
		{
			var mapper = new DALPipelineStatuMapper();
			PipelineStatu item = new PipelineStatu();
			item.SetProperties(1, "A");
			List<ApiPipelineStatuServerResponseModel> response = mapper.MapEntityToModel(new List<PipelineStatu>() { { item} });

			response.Count.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>1dface76421f096b47be4588522f6e4b</Hash>
</Codenesium>*/