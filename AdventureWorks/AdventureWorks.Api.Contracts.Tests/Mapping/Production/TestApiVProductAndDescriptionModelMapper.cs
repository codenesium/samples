using AdventureWorksNS.Api.Contracts;
using FluentAssertions;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using Xunit;

namespace AdventureWorksNS.Api.Contracts.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "VProductAndDescription")]
	[Trait("Area", "ApiModel")]
	public class TestApiVProductAndDescriptionModelMapper
	{
		[Fact]
		public void MapRequestToResponse()
		{
			var mapper = new ApiVProductAndDescriptionModelMapper();
			var model = new ApiVProductAndDescriptionRequestModel();
			model.SetProperties("A", "A", 1, "A");
			ApiVProductAndDescriptionResponseModel response = mapper.MapRequestToResponse("A", model);

			response.CultureID.Should().Be("A");
			response.Description.Should().Be("A");
			response.Name.Should().Be("A");
			response.ProductID.Should().Be(1);
			response.ProductModel.Should().Be("A");
		}

		[Fact]
		public void MapResponseToRequest()
		{
			var mapper = new ApiVProductAndDescriptionModelMapper();
			var model = new ApiVProductAndDescriptionResponseModel();
			model.SetProperties("A", "A", "A", 1, "A");
			ApiVProductAndDescriptionRequestModel response = mapper.MapResponseToRequest(model);

			response.Description.Should().Be("A");
			response.Name.Should().Be("A");
			response.ProductID.Should().Be(1);
			response.ProductModel.Should().Be("A");
		}

		[Fact]
		public void CreatePatch()
		{
			var mapper = new ApiVProductAndDescriptionModelMapper();
			var model = new ApiVProductAndDescriptionRequestModel();
			model.SetProperties("A", "A", 1, "A");

			JsonPatchDocument<ApiVProductAndDescriptionRequestModel> patch = mapper.CreatePatch(model);
			var response = new ApiVProductAndDescriptionRequestModel();
			patch.ApplyTo(response);
			response.Description.Should().Be("A");
			response.Name.Should().Be("A");
			response.ProductID.Should().Be(1);
			response.ProductModel.Should().Be("A");
		}
	}
}

/*<Codenesium>
    <Hash>acd13d0297dc88744b4bb50206702279</Hash>
</Codenesium>*/