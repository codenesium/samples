using FluentAssertions;
using Microsoft.AspNetCore.JsonPatch;
using StudioResourceManagerNS.Api.Contracts;
using System;
using System.Collections.Generic;
using Xunit;

namespace StudioResourceManagerNS.Api.Contracts.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "Family")]
	[Trait("Area", "ApiModel")]
	public class TestApiFamilyModelMapper
	{
		[Fact]
		public void MapRequestToResponse()
		{
			var mapper = new ApiFamilyModelMapper();
			var model = new ApiFamilyRequestModel();
			model.SetProperties("A", "A", "A", "A", "A");
			ApiFamilyResponseModel response = mapper.MapRequestToResponse(1, model);

			response.Id.Should().Be(1);
			response.Note.Should().Be("A");
			response.PrimaryContactEmail.Should().Be("A");
			response.PrimaryContactFirstName.Should().Be("A");
			response.PrimaryContactLastName.Should().Be("A");
			response.PrimaryContactPhone.Should().Be("A");
		}

		[Fact]
		public void MapResponseToRequest()
		{
			var mapper = new ApiFamilyModelMapper();
			var model = new ApiFamilyResponseModel();
			model.SetProperties(1, "A", "A", "A", "A", "A");
			ApiFamilyRequestModel response = mapper.MapResponseToRequest(model);

			response.Note.Should().Be("A");
			response.PrimaryContactEmail.Should().Be("A");
			response.PrimaryContactFirstName.Should().Be("A");
			response.PrimaryContactLastName.Should().Be("A");
			response.PrimaryContactPhone.Should().Be("A");
		}

		[Fact]
		public void CreatePatch()
		{
			var mapper = new ApiFamilyModelMapper();
			var model = new ApiFamilyRequestModel();
			model.SetProperties("A", "A", "A", "A", "A");

			JsonPatchDocument<ApiFamilyRequestModel> patch = mapper.CreatePatch(model);
			var response = new ApiFamilyRequestModel();
			patch.ApplyTo(response);
			response.Note.Should().Be("A");
			response.PrimaryContactEmail.Should().Be("A");
			response.PrimaryContactFirstName.Should().Be("A");
			response.PrimaryContactLastName.Should().Be("A");
			response.PrimaryContactPhone.Should().Be("A");
		}
	}
}

/*<Codenesium>
    <Hash>794f89a71c799ba20ed6f02d9155ceee</Hash>
</Codenesium>*/