using FluentAssertions;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using Xunit;

namespace TicketingCRMNS.Api.Services.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "Province")]
	[Trait("Area", "ApiModel")]
	public class TestApiProvinceServerModelMapper
	{
		[Fact]
		public void MapServerRequestToResponse()
		{
			var mapper = new ApiProvinceServerModelMapper();
			var model = new ApiProvinceServerRequestModel();
			model.SetProperties(1, "A");
			ApiProvinceServerResponseModel response = mapper.MapServerRequestToResponse(1, model);
			response.Should().NotBeNull();
			response.CountryId.Should().Be(1);
			response.Name.Should().Be("A");
		}

		[Fact]
		public void MapServerResponseToRequest()
		{
			var mapper = new ApiProvinceServerModelMapper();
			var model = new ApiProvinceServerResponseModel();
			model.SetProperties(1, 1, "A");
			ApiProvinceServerRequestModel response = mapper.MapServerResponseToRequest(model);
			response.Should().NotBeNull();
			response.CountryId.Should().Be(1);
			response.Name.Should().Be("A");
		}

		[Fact]
		public void CreatePatch()
		{
			var mapper = new ApiProvinceServerModelMapper();
			var model = new ApiProvinceServerRequestModel();
			model.SetProperties(1, "A");

			JsonPatchDocument<ApiProvinceServerRequestModel> patch = mapper.CreatePatch(model);
			var response = new ApiProvinceServerRequestModel();
			patch.ApplyTo(response);
			response.CountryId.Should().Be(1);
			response.Name.Should().Be("A");
		}
	}
}

/*<Codenesium>
    <Hash>1415250a0189c13891976179708038a5</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/