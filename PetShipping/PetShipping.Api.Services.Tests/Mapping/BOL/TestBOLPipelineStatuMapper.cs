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
	[Trait("Table", "PipelineStatu")]
	[Trait("Area", "BOLMapper")]
	public class TestBOLPipelineStatuMapper
	{
		[Fact]
		public void MapModelToBO()
		{
			var mapper = new BOLPipelineStatuMapper();
			ApiPipelineStatuServerRequestModel model = new ApiPipelineStatuServerRequestModel();
			model.SetProperties("A");
			BOPipelineStatu response = mapper.MapModelToBO(1, model);

			response.Name.Should().Be("A");
		}

		[Fact]
		public void MapBOToModel()
		{
			var mapper = new BOLPipelineStatuMapper();
			BOPipelineStatu bo = new BOPipelineStatu();
			bo.SetProperties(1, "A");
			ApiPipelineStatuServerResponseModel response = mapper.MapBOToModel(bo);

			response.Id.Should().Be(1);
			response.Name.Should().Be("A");
		}

		[Fact]
		public void MapBOToModelList()
		{
			var mapper = new BOLPipelineStatuMapper();
			BOPipelineStatu bo = new BOPipelineStatu();
			bo.SetProperties(1, "A");
			List<ApiPipelineStatuServerResponseModel> response = mapper.MapBOToModel(new List<BOPipelineStatu>() { { bo } });

			response.Count.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>7c01a932f7c07894f154e5cb8a25c2a0</Hash>
</Codenesium>*/