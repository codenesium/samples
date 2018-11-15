using FluentAssertions;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using Xunit;

namespace PetShippingNS.Api.Services.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "Employee")]
	[Trait("Area", "ApiModel")]
	public class TestApiEmployeeServerModelMapper
	{
		[Fact]
		public void MapServerRequestToResponse()
		{
			var mapper = new ApiEmployeeServerModelMapper();
			var model = new ApiEmployeeServerRequestModel();
			model.SetProperties("A", true, true, "A");
			ApiEmployeeServerResponseModel response = mapper.MapServerRequestToResponse(1, model);
			response.Should().NotBeNull();
			response.FirstName.Should().Be("A");
			response.IsSalesPerson.Should().Be(true);
			response.IsShipper.Should().Be(true);
			response.LastName.Should().Be("A");
		}

		[Fact]
		public void MapServerResponseToRequest()
		{
			var mapper = new ApiEmployeeServerModelMapper();
			var model = new ApiEmployeeServerResponseModel();
			model.SetProperties(1, "A", true, true, "A");
			ApiEmployeeServerRequestModel response = mapper.MapServerResponseToRequest(model);
			response.Should().NotBeNull();
			response.FirstName.Should().Be("A");
			response.IsSalesPerson.Should().Be(true);
			response.IsShipper.Should().Be(true);
			response.LastName.Should().Be("A");
		}

		[Fact]
		public void CreatePatch()
		{
			var mapper = new ApiEmployeeServerModelMapper();
			var model = new ApiEmployeeServerRequestModel();
			model.SetProperties("A", true, true, "A");

			JsonPatchDocument<ApiEmployeeServerRequestModel> patch = mapper.CreatePatch(model);
			var response = new ApiEmployeeServerRequestModel();
			patch.ApplyTo(response);
			response.FirstName.Should().Be("A");
			response.IsSalesPerson.Should().Be(true);
			response.IsShipper.Should().Be(true);
			response.LastName.Should().Be("A");
		}
	}
}

/*<Codenesium>
    <Hash>ed5366c156963cb66b21c9f62c2fa4ee</Hash>
</Codenesium>*/