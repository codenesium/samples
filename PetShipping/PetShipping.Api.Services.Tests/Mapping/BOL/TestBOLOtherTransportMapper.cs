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
	[Trait("Table", "OtherTransport")]
	[Trait("Area", "BOLMapper")]
	public class TestBOLOtherTransportMapper
	{
		[Fact]
		public void MapModelToBO()
		{
			var mapper = new BOLOtherTransportMapper();
			ApiOtherTransportRequestModel model = new ApiOtherTransportRequestModel();
			model.SetProperties(1, 1);
			BOOtherTransport response = mapper.MapModelToBO(1, model);

			response.HandlerId.Should().Be(1);
			response.PipelineStepId.Should().Be(1);
		}

		[Fact]
		public void MapBOToModel()
		{
			var mapper = new BOLOtherTransportMapper();
			BOOtherTransport bo = new BOOtherTransport();
			bo.SetProperties(1, 1, 1);
			ApiOtherTransportResponseModel response = mapper.MapBOToModel(bo);

			response.HandlerId.Should().Be(1);
			response.Id.Should().Be(1);
			response.PipelineStepId.Should().Be(1);
		}

		[Fact]
		public void MapBOToModelList()
		{
			var mapper = new BOLOtherTransportMapper();
			BOOtherTransport bo = new BOOtherTransport();
			bo.SetProperties(1, 1, 1);
			List<ApiOtherTransportResponseModel> response = mapper.MapBOToModel(new List<BOOtherTransport>() { { bo } });

			response.Count.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>88a9a2ca041b847d85b17ab1c68686a4</Hash>
</Codenesium>*/