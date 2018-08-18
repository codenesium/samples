using AdventureWorksNS.Api.Contracts;
using FluentAssertions;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using Xunit;

namespace AdventureWorksNS.Api.Contracts.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "ProductModelIllustration")]
	[Trait("Area", "ApiModel")]
	public class TestApiProductModelIllustrationModelMapper
	{
		[Fact]
		public void MapRequestToResponse()
		{
			var mapper = new ApiProductModelIllustrationModelMapper();
			var model = new ApiProductModelIllustrationRequestModel();
			model.SetProperties(1, DateTime.Parse("1/1/1987 12:00:00 AM"));
			ApiProductModelIllustrationResponseModel response = mapper.MapRequestToResponse(1, model);

			response.IllustrationID.Should().Be(1);
			response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.ProductModelID.Should().Be(1);
		}

		[Fact]
		public void MapResponseToRequest()
		{
			var mapper = new ApiProductModelIllustrationModelMapper();
			var model = new ApiProductModelIllustrationResponseModel();
			model.SetProperties(1, 1, DateTime.Parse("1/1/1987 12:00:00 AM"));
			ApiProductModelIllustrationRequestModel response = mapper.MapResponseToRequest(model);

			response.IllustrationID.Should().Be(1);
			response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
		}

		[Fact]
		public void CreatePatch()
		{
			var mapper = new ApiProductModelIllustrationModelMapper();
			var model = new ApiProductModelIllustrationRequestModel();
			model.SetProperties(1, DateTime.Parse("1/1/1987 12:00:00 AM"));

			JsonPatchDocument<ApiProductModelIllustrationRequestModel> patch = mapper.CreatePatch(model);
			var response = new ApiProductModelIllustrationRequestModel();
			patch.ApplyTo(response);
			response.IllustrationID.Should().Be(1);
			response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
		}
	}
}

/*<Codenesium>
    <Hash>31881b75e3d0f334387bed371aa7c812</Hash>
</Codenesium>*/