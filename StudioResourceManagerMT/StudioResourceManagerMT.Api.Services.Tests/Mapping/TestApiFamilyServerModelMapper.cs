using FluentAssertions;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using Xunit;

namespace StudioResourceManagerMTNS.Api.Services.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "Family")]
	[Trait("Area", "ApiModel")]
	public class TestApiFamilyServerModelMapper
	{
		[Fact]
		public void MapServerRequestToResponse()
		{
			var mapper = new ApiFamilyServerModelMapper();
			var model = new ApiFamilyServerRequestModel();
			model.SetProperties("A", "A", "A", "A", "A");
			ApiFamilyServerResponseModel response = mapper.MapServerRequestToResponse(1, model);
			response.Should().NotBeNull();
			response.Notes.Should().Be("A");
			response.PrimaryContactEmail.Should().Be("A");
			response.PrimaryContactFirstName.Should().Be("A");
			response.PrimaryContactLastName.Should().Be("A");
			response.PrimaryContactPhone.Should().Be("A");
		}

		[Fact]
		public void MapServerResponseToRequest()
		{
			var mapper = new ApiFamilyServerModelMapper();
			var model = new ApiFamilyServerResponseModel();
			model.SetProperties(1, "A", "A", "A", "A", "A");
			ApiFamilyServerRequestModel response = mapper.MapServerResponseToRequest(model);
			response.Should().NotBeNull();
			response.Notes.Should().Be("A");
			response.PrimaryContactEmail.Should().Be("A");
			response.PrimaryContactFirstName.Should().Be("A");
			response.PrimaryContactLastName.Should().Be("A");
			response.PrimaryContactPhone.Should().Be("A");
		}

		[Fact]
		public void CreatePatch()
		{
			var mapper = new ApiFamilyServerModelMapper();
			var model = new ApiFamilyServerRequestModel();
			model.SetProperties("A", "A", "A", "A", "A");

			JsonPatchDocument<ApiFamilyServerRequestModel> patch = mapper.CreatePatch(model);
			var response = new ApiFamilyServerRequestModel();
			patch.ApplyTo(response);
			response.Notes.Should().Be("A");
			response.PrimaryContactEmail.Should().Be("A");
			response.PrimaryContactFirstName.Should().Be("A");
			response.PrimaryContactLastName.Should().Be("A");
			response.PrimaryContactPhone.Should().Be("A");
		}
	}
}

/*<Codenesium>
    <Hash>b1fb5afc244c4b3427d8741e422cbb8c</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/