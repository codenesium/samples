using FluentAssertions;
using Microsoft.AspNetCore.JsonPatch;
using StudioResourceManagerNS.Api.Contracts;
using System;
using System.Collections.Generic;
using Xunit;

namespace StudioResourceManagerNS.Api.Contracts.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "Studio")]
	[Trait("Area", "ApiModel")]
	public class TestApiStudioModelMapper
	{
		[Fact]
		public void MapRequestToResponse()
		{
			var mapper = new ApiStudioModelMapper();
			var model = new ApiStudioRequestModel();
			model.SetProperties("A", "A", "A", "A", "A", "A", "A");
			ApiStudioResponseModel response = mapper.MapRequestToResponse(1, model);

			response.Address1.Should().Be("A");
			response.Address2.Should().Be("A");
			response.City.Should().Be("A");
			response.Id.Should().Be(1);
			response.Name.Should().Be("A");
			response.Province.Should().Be("A");
			response.Website.Should().Be("A");
			response.Zip.Should().Be("A");
		}

		[Fact]
		public void MapResponseToRequest()
		{
			var mapper = new ApiStudioModelMapper();
			var model = new ApiStudioResponseModel();
			model.SetProperties(1, "A", "A", "A", "A", "A", "A", "A");
			ApiStudioRequestModel response = mapper.MapResponseToRequest(model);

			response.Address1.Should().Be("A");
			response.Address2.Should().Be("A");
			response.City.Should().Be("A");
			response.Name.Should().Be("A");
			response.Province.Should().Be("A");
			response.Website.Should().Be("A");
			response.Zip.Should().Be("A");
		}

		[Fact]
		public void CreatePatch()
		{
			var mapper = new ApiStudioModelMapper();
			var model = new ApiStudioRequestModel();
			model.SetProperties("A", "A", "A", "A", "A", "A", "A");

			JsonPatchDocument<ApiStudioRequestModel> patch = mapper.CreatePatch(model);
			var response = new ApiStudioRequestModel();
			patch.ApplyTo(response);
			response.Address1.Should().Be("A");
			response.Address2.Should().Be("A");
			response.City.Should().Be("A");
			response.Name.Should().Be("A");
			response.Province.Should().Be("A");
			response.Website.Should().Be("A");
			response.Zip.Should().Be("A");
		}
	}
}

/*<Codenesium>
    <Hash>d6682818a026a91963093a987210e9b9</Hash>
</Codenesium>*/