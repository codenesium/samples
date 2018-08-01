using FermataFishNS.Api.Contracts;
using FluentAssertions;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using Xunit;

namespace FermataFishNS.Api.Contracts.Tests
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
			model.SetProperties("A", "A", "A", "A", "A", 1);
			ApiFamilyResponseModel response = mapper.MapRequestToResponse(1, model);

			response.Id.Should().Be(1);
			response.Notes.Should().Be("A");
			response.PcEmail.Should().Be("A");
			response.PcFirstName.Should().Be("A");
			response.PcLastName.Should().Be("A");
			response.PcPhone.Should().Be("A");
			response.StudioId.Should().Be(1);
		}

		[Fact]
		public void MapResponseToRequest()
		{
			var mapper = new ApiFamilyModelMapper();
			var model = new ApiFamilyResponseModel();
			model.SetProperties(1, "A", "A", "A", "A", "A", 1);
			ApiFamilyRequestModel response = mapper.MapResponseToRequest(model);

			response.Notes.Should().Be("A");
			response.PcEmail.Should().Be("A");
			response.PcFirstName.Should().Be("A");
			response.PcLastName.Should().Be("A");
			response.PcPhone.Should().Be("A");
			response.StudioId.Should().Be(1);
		}

		[Fact]
		public void CreatePatch()
		{
			var mapper = new ApiFamilyModelMapper();
			var model = new ApiFamilyRequestModel();
			model.SetProperties("A", "A", "A", "A", "A", 1);

			JsonPatchDocument<ApiFamilyRequestModel> patch = mapper.CreatePatch(model);
			var response = new ApiFamilyRequestModel();
			patch.ApplyTo(response);
			response.Notes.Should().Be("A");
			response.PcEmail.Should().Be("A");
			response.PcFirstName.Should().Be("A");
			response.PcLastName.Should().Be("A");
			response.PcPhone.Should().Be("A");
			response.StudioId.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>0b7fc24aafb2070a9641b6ce0d6a8d37</Hash>
</Codenesium>*/