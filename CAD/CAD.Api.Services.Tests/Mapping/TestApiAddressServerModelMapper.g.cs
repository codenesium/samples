using FluentAssertions;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using Xunit;

namespace CADNS.Api.Services.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "Address")]
	[Trait("Area", "ApiModel")]
	public class TestApiAddressServerModelMapper
	{
		[Fact]
		public void MapServerRequestToResponse()
		{
			var mapper = new ApiAddressServerModelMapper();
			var model = new ApiAddressServerRequestModel();
			model.SetProperties("A", "A", "A", "A", "A");
			ApiAddressServerResponseModel response = mapper.MapServerRequestToResponse(1, model);
			response.Should().NotBeNull();
			response.Address1.Should().Be("A");
			response.Address2.Should().Be("A");
			response.City.Should().Be("A");
			response.State.Should().Be("A");
			response.Zip.Should().Be("A");
		}

		[Fact]
		public void MapServerResponseToRequest()
		{
			var mapper = new ApiAddressServerModelMapper();
			var model = new ApiAddressServerResponseModel();
			model.SetProperties(1, "A", "A", "A", "A", "A");
			ApiAddressServerRequestModel response = mapper.MapServerResponseToRequest(model);
			response.Should().NotBeNull();
			response.Address1.Should().Be("A");
			response.Address2.Should().Be("A");
			response.City.Should().Be("A");
			response.State.Should().Be("A");
			response.Zip.Should().Be("A");
		}

		[Fact]
		public void CreatePatch()
		{
			var mapper = new ApiAddressServerModelMapper();
			var model = new ApiAddressServerRequestModel();
			model.SetProperties("A", "A", "A", "A", "A");

			JsonPatchDocument<ApiAddressServerRequestModel> patch = mapper.CreatePatch(model);
			var response = new ApiAddressServerRequestModel();
			patch.ApplyTo(response);
			response.Address1.Should().Be("A");
			response.Address2.Should().Be("A");
			response.City.Should().Be("A");
			response.State.Should().Be("A");
			response.Zip.Should().Be("A");
		}
	}
}

/*<Codenesium>
    <Hash>498c9f293b0d4358e45152cb7ce40efa</Hash>
</Codenesium>*/