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
			ApiOtherTransportServerRequestModel model = new ApiOtherTransportServerRequestModel();
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
			ApiOtherTransportServerResponseModel response = mapper.MapBOToModel(bo);

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
			List<ApiOtherTransportServerResponseModel> response = mapper.MapBOToModel(new List<BOOtherTransport>() { { bo } });

			response.Count.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>15ebe42cbbe6bbc3fde796a48df14201</Hash>
</Codenesium>*/