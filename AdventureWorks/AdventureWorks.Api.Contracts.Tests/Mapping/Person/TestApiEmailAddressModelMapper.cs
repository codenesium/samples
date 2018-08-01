using AdventureWorksNS.Api.Contracts;
using FluentAssertions;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using Xunit;

namespace AdventureWorksNS.Api.Contracts.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "EmailAddress")]
	[Trait("Area", "ApiModel")]
	public class TestApiEmailAddressModelMapper
	{
		[Fact]
		public void MapRequestToResponse()
		{
			var mapper = new ApiEmailAddressModelMapper();
			var model = new ApiEmailAddressRequestModel();
			model.SetProperties("A", 1, DateTime.Parse("1/1/1987 12:00:00 AM"), Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));
			ApiEmailAddressResponseModel response = mapper.MapRequestToResponse(1, model);

			response.BusinessEntityID.Should().Be(1);
			response.EmailAddress1.Should().Be("A");
			response.EmailAddressID.Should().Be(1);
			response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.Rowguid.Should().Be(Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));
		}

		[Fact]
		public void MapResponseToRequest()
		{
			var mapper = new ApiEmailAddressModelMapper();
			var model = new ApiEmailAddressResponseModel();
			model.SetProperties(1, "A", 1, DateTime.Parse("1/1/1987 12:00:00 AM"), Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));
			ApiEmailAddressRequestModel response = mapper.MapResponseToRequest(model);

			response.EmailAddress1.Should().Be("A");
			response.EmailAddressID.Should().Be(1);
			response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.Rowguid.Should().Be(Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));
		}

		[Fact]
		public void CreatePatch()
		{
			var mapper = new ApiEmailAddressModelMapper();
			var model = new ApiEmailAddressRequestModel();
			model.SetProperties("A", 1, DateTime.Parse("1/1/1987 12:00:00 AM"), Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));

			JsonPatchDocument<ApiEmailAddressRequestModel> patch = mapper.CreatePatch(model);
			var response = new ApiEmailAddressRequestModel();
			patch.ApplyTo(response);
			response.EmailAddress1.Should().Be("A");
			response.EmailAddressID.Should().Be(1);
			response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.Rowguid.Should().Be(Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));
		}
	}
}

/*<Codenesium>
    <Hash>a72e54f145061403d198afa2333a57e5</Hash>
</Codenesium>*/