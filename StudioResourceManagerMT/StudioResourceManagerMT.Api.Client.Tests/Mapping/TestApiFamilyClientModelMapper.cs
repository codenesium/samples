using FluentAssertions;
using System;
using System.Collections.Generic;
using Xunit;

namespace StudioResourceManagerMTNS.Api.Client.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "Family")]
	[Trait("Area", "ApiModel")]
	public class TestApiFamilyModelMapper
	{
		[Fact]
		public void MapClientRequestToResponse()
		{
			var mapper = new ApiFamilyModelMapper();
			var model = new ApiFamilyClientRequestModel();
			model.SetProperties("A", "A", "A", "A", "A");
			ApiFamilyClientResponseModel response = mapper.MapClientRequestToResponse(1, model);
			response.Should().NotBeNull();
			response.Notes.Should().Be("A");
			response.PrimaryContactEmail.Should().Be("A");
			response.PrimaryContactFirstName.Should().Be("A");
			response.PrimaryContactLastName.Should().Be("A");
			response.PrimaryContactPhone.Should().Be("A");
		}

		[Fact]
		public void MapClientResponseToRequest()
		{
			var mapper = new ApiFamilyModelMapper();
			var model = new ApiFamilyClientResponseModel();
			model.SetProperties(1, "A", "A", "A", "A", "A");
			ApiFamilyClientRequestModel response = mapper.MapClientResponseToRequest(model);
			response.Should().NotBeNull();
			response.Notes.Should().Be("A");
			response.PrimaryContactEmail.Should().Be("A");
			response.PrimaryContactFirstName.Should().Be("A");
			response.PrimaryContactLastName.Should().Be("A");
			response.PrimaryContactPhone.Should().Be("A");
		}
	}
}

/*<Codenesium>
    <Hash>d726b12829a598418857347938fcfeb9</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/