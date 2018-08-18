using FluentAssertions;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using TestsNS.Api.Contracts;
using Xunit;

namespace TestsNS.Api.Contracts.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "RowVersionCheck")]
	[Trait("Area", "ApiModel")]
	public class TestApiRowVersionCheckModelMapper
	{
		[Fact]
		public void MapRequestToResponse()
		{
			var mapper = new ApiRowVersionCheckModelMapper();
			var model = new ApiRowVersionCheckRequestModel();
			model.SetProperties("A", Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));
			ApiRowVersionCheckResponseModel response = mapper.MapRequestToResponse(1, model);

			response.Id.Should().Be(1);
			response.Name.Should().Be("A");
			response.RowVersion.Should().Be(Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));
		}

		[Fact]
		public void MapResponseToRequest()
		{
			var mapper = new ApiRowVersionCheckModelMapper();
			var model = new ApiRowVersionCheckResponseModel();
			model.SetProperties(1, "A", Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));
			ApiRowVersionCheckRequestModel response = mapper.MapResponseToRequest(model);

			response.Name.Should().Be("A");
			response.RowVersion.Should().Be(Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));
		}

		[Fact]
		public void CreatePatch()
		{
			var mapper = new ApiRowVersionCheckModelMapper();
			var model = new ApiRowVersionCheckRequestModel();
			model.SetProperties("A", Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));

			JsonPatchDocument<ApiRowVersionCheckRequestModel> patch = mapper.CreatePatch(model);
			var response = new ApiRowVersionCheckRequestModel();
			patch.ApplyTo(response);
			response.Name.Should().Be("A");
			response.RowVersion.Should().Be(Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));
		}
	}
}

/*<Codenesium>
    <Hash>b5284349ea512dd22aba7d98cdecc671</Hash>
</Codenesium>*/