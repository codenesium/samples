using FluentAssertions;
using System;
using System.Collections.Generic;
using Xunit;

namespace CADNS.Api.Client.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "UnitOfficer")]
	[Trait("Area", "ApiModel")]
	public class TestApiUnitOfficerModelMapper
	{
		[Fact]
		public void MapClientRequestToResponse()
		{
			var mapper = new ApiUnitOfficerModelMapper();
			var model = new ApiUnitOfficerClientRequestModel();
			model.SetProperties(1, 1);
			ApiUnitOfficerClientResponseModel response = mapper.MapClientRequestToResponse(1, model);
			response.Should().NotBeNull();
			response.OfficerId.Should().Be(1);
			response.UnitId.Should().Be(1);
		}

		[Fact]
		public void MapClientResponseToRequest()
		{
			var mapper = new ApiUnitOfficerModelMapper();
			var model = new ApiUnitOfficerClientResponseModel();
			model.SetProperties(1, 1, 1);
			ApiUnitOfficerClientRequestModel response = mapper.MapClientResponseToRequest(model);
			response.Should().NotBeNull();
			response.OfficerId.Should().Be(1);
			response.UnitId.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>f07eb657f52e36c80abc36b3721b33b0</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/