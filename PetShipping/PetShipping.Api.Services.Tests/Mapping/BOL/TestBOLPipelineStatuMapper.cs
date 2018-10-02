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
			ApiPipelineStatuRequestModel model = new ApiPipelineStatuRequestModel();
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
			ApiPipelineStatuResponseModel response = mapper.MapBOToModel(bo);

			response.Id.Should().Be(1);
			response.Name.Should().Be("A");
		}

		[Fact]
		public void MapBOToModelList()
		{
			var mapper = new BOLPipelineStatuMapper();
			BOPipelineStatu bo = new BOPipelineStatu();
			bo.SetProperties(1, "A");
			List<ApiPipelineStatuResponseModel> response = mapper.MapBOToModel(new List<BOPipelineStatu>() { { bo } });

			response.Count.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>59f6de94f036b022c22011aaa12487f4</Hash>
</Codenesium>*/