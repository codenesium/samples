using FluentAssertions;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using Xunit;

namespace CADNS.Api.Services.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "UnitDisposition")]
	[Trait("Area", "ApiModel")]
	public class TestApiUnitDispositionServerModelMapper
	{
		[Fact]
		public void MapServerRequestToResponse()
		{
			var mapper = new ApiUnitDispositionServerModelMapper();
			var model = new ApiUnitDispositionServerRequestModel();
			model.SetProperties("A");
			ApiUnitDispositionServerResponseModel response = mapper.MapServerRequestToResponse(1, model);
			response.Should().NotBeNull();
			response.Name.Should().Be("A");
		}

		[Fact]
		public void MapServerResponseToRequest()
		{
			var mapper = new ApiUnitDispositionServerModelMapper();
			var model = new ApiUnitDispositionServerResponseModel();
			model.SetProperties(1, "A");
			ApiUnitDispositionServerRequestModel response = mapper.MapServerResponseToRequest(model);
			response.Should().NotBeNull();
			response.Name.Should().Be("A");
		}

		[Fact]
		public void CreatePatch()
		{
			var mapper = new ApiUnitDispositionServerModelMapper();
			var model = new ApiUnitDispositionServerRequestModel();
			model.SetProperties("A");

			JsonPatchDocument<ApiUnitDispositionServerRequestModel> patch = mapper.CreatePatch(model);
			var response = new ApiUnitDispositionServerRequestModel();
			patch.ApplyTo(response);
			response.Name.Should().Be("A");
		}
	}
}

/*<Codenesium>
    <Hash>f88008503290fd062eae7568aba93081</Hash>
</Codenesium>*/