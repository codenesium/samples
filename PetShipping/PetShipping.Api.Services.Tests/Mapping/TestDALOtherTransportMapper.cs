using FluentAssertions;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using Xunit;

namespace PetShippingNS.Api.Services
{
	[Trait("Type", "Unit")]
	[Trait("Table", "OtherTransport")]
	[Trait("Area", "DALMapper")]
	public class TestDALOtherTransportMapper
	{
		[Fact]
		public void MapModelToEntity()
		{
			var mapper = new DALOtherTransportMapper();
			ApiOtherTransportServerRequestModel model = new ApiOtherTransportServerRequestModel();
			model.SetProperties(1, 1);
			OtherTransport response = mapper.MapModelToEntity(1, model);

			response.HandlerId.Should().Be(1);
			response.PipelineStepId.Should().Be(1);
		}

		[Fact]
		public void MapEntityToModel()
		{
			var mapper = new DALOtherTransportMapper();
			OtherTransport item = new OtherTransport();
			item.SetProperties(1, 1, 1);
			ApiOtherTransportServerResponseModel response = mapper.MapEntityToModel(item);

			response.HandlerId.Should().Be(1);
			response.Id.Should().Be(1);
			response.PipelineStepId.Should().Be(1);
		}

		[Fact]
		public void MapEntityToModelList()
		{
			var mapper = new DALOtherTransportMapper();
			OtherTransport item = new OtherTransport();
			item.SetProperties(1, 1, 1);
			List<ApiOtherTransportServerResponseModel> response = mapper.MapEntityToModel(new List<OtherTransport>() { { item} });

			response.Count.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>e1dd05074ee2b6328ee809d1bab4112e</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/