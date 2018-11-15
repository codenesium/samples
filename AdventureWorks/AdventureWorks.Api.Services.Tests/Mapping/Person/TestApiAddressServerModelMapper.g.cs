using FluentAssertions;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using Xunit;

namespace AdventureWorksNS.Api.Services.Tests
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
			model.SetProperties("A", "A", "A", DateTime.Parse("1/1/1987 12:00:00 AM"), "A", Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"), 1);
			ApiAddressServerResponseModel response = mapper.MapServerRequestToResponse(1, model);
			response.Should().NotBeNull();
			response.AddressLine1.Should().Be("A");
			response.AddressLine2.Should().Be("A");
			response.City.Should().Be("A");
			response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.PostalCode.Should().Be("A");
			response.Rowguid.Should().Be(Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));
			response.StateProvinceID.Should().Be(1);
		}

		[Fact]
		public void MapServerResponseToRequest()
		{
			var mapper = new ApiAddressServerModelMapper();
			var model = new ApiAddressServerResponseModel();
			model.SetProperties(1, "A", "A", "A", DateTime.Parse("1/1/1987 12:00:00 AM"), "A", Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"), 1);
			ApiAddressServerRequestModel response = mapper.MapServerResponseToRequest(model);
			response.Should().NotBeNull();
			response.AddressLine1.Should().Be("A");
			response.AddressLine2.Should().Be("A");
			response.City.Should().Be("A");
			response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.PostalCode.Should().Be("A");
			response.Rowguid.Should().Be(Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));
			response.StateProvinceID.Should().Be(1);
		}

		[Fact]
		public void CreatePatch()
		{
			var mapper = new ApiAddressServerModelMapper();
			var model = new ApiAddressServerRequestModel();
			model.SetProperties("A", "A", "A", DateTime.Parse("1/1/1987 12:00:00 AM"), "A", Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"), 1);

			JsonPatchDocument<ApiAddressServerRequestModel> patch = mapper.CreatePatch(model);
			var response = new ApiAddressServerRequestModel();
			patch.ApplyTo(response);
			response.AddressLine1.Should().Be("A");
			response.AddressLine2.Should().Be("A");
			response.City.Should().Be("A");
			response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.PostalCode.Should().Be("A");
			response.Rowguid.Should().Be(Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));
			response.StateProvinceID.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>bae57b710fa34ed118a8d59db5622f0d</Hash>
</Codenesium>*/