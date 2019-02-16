using FluentAssertions;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using Xunit;

namespace PetShippingNS.Api.Services
{
	[Trait("Type", "Unit")]
	[Trait("Table", "Pipeline")]
	[Trait("Area", "DALMapper")]
	public class TestDALPipelineMapper
	{
		[Fact]
		public void MapModelToEntity()
		{
			var mapper = new DALPipelineMapper();
			ApiPipelineServerRequestModel model = new ApiPipelineServerRequestModel();
			model.SetProperties(1, 1);
			Pipeline response = mapper.MapModelToEntity(1, model);

			response.PipelineStatusId.Should().Be(1);
			response.SaleId.Should().Be(1);
		}

		[Fact]
		public void MapEntityToModel()
		{
			var mapper = new DALPipelineMapper();
			Pipeline item = new Pipeline();
			item.SetProperties(1, 1, 1);
			ApiPipelineServerResponseModel response = mapper.MapEntityToModel(item);

			response.Id.Should().Be(1);
			response.PipelineStatusId.Should().Be(1);
			response.SaleId.Should().Be(1);
		}

		[Fact]
		public void MapEntityToModelList()
		{
			var mapper = new DALPipelineMapper();
			Pipeline item = new Pipeline();
			item.SetProperties(1, 1, 1);
			List<ApiPipelineServerResponseModel> response = mapper.MapEntityToModel(new List<Pipeline>() { { item} });

			response.Count.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>78d32811f6ef3d253f50547a67bbfd3a</Hash>
</Codenesium>*/