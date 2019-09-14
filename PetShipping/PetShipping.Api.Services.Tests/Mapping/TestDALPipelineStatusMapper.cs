using FluentAssertions;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using Xunit;

namespace PetShippingNS.Api.Services
{
	[Trait("Type", "Unit")]
	[Trait("Table", "PipelineStatus")]
	[Trait("Area", "DALMapper")]
	public class TestDALPipelineStatusMapper
	{
		[Fact]
		public void MapModelToEntity()
		{
			var mapper = new DALPipelineStatusMapper();
			ApiPipelineStatusServerRequestModel model = new ApiPipelineStatusServerRequestModel();
			model.SetProperties("A");
			PipelineStatus response = mapper.MapModelToEntity(1, model);

			response.Name.Should().Be("A");
		}

		[Fact]
		public void MapEntityToModel()
		{
			var mapper = new DALPipelineStatusMapper();
			PipelineStatus item = new PipelineStatus();
			item.SetProperties(1, "A");
			ApiPipelineStatusServerResponseModel response = mapper.MapEntityToModel(item);

			response.Id.Should().Be(1);
			response.Name.Should().Be("A");
		}

		[Fact]
		public void MapEntityToModelList()
		{
			var mapper = new DALPipelineStatusMapper();
			PipelineStatus item = new PipelineStatus();
			item.SetProperties(1, "A");
			List<ApiPipelineStatusServerResponseModel> response = mapper.MapEntityToModel(new List<PipelineStatus>() { { item} });

			response.Count.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>62f794fe136381dc28fb02495debde99</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/