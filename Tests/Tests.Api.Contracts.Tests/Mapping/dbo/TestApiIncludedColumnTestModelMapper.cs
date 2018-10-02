using FluentAssertions;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using TestsNS.Api.Contracts;
using Xunit;

namespace TestsNS.Api.Contracts.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "IncludedColumnTest")]
	[Trait("Area", "ApiModel")]
	public class TestApiIncludedColumnTestModelMapper
	{
		[Fact]
		public void MapRequestToResponse()
		{
			var mapper = new ApiIncludedColumnTestModelMapper();
			var model = new ApiIncludedColumnTestRequestModel();
			model.SetProperties("A", "A");
			ApiIncludedColumnTestResponseModel response = mapper.MapRequestToResponse(1, model);

			response.Id.Should().Be(1);
			response.Name.Should().Be("A");
			response.Name2.Should().Be("A");
		}

		[Fact]
		public void MapResponseToRequest()
		{
			var mapper = new ApiIncludedColumnTestModelMapper();
			var model = new ApiIncludedColumnTestResponseModel();
			model.SetProperties(1, "A", "A");
			ApiIncludedColumnTestRequestModel response = mapper.MapResponseToRequest(model);

			response.Name.Should().Be("A");
			response.Name2.Should().Be("A");
		}

		[Fact]
		public void CreatePatch()
		{
			var mapper = new ApiIncludedColumnTestModelMapper();
			var model = new ApiIncludedColumnTestRequestModel();
			model.SetProperties("A", "A");

			JsonPatchDocument<ApiIncludedColumnTestRequestModel> patch = mapper.CreatePatch(model);
			var response = new ApiIncludedColumnTestRequestModel();
			patch.ApplyTo(response);
			response.Name.Should().Be("A");
			response.Name2.Should().Be("A");
		}
	}
}

/*<Codenesium>
    <Hash>0972c2ea9a8247a80f7314fef322c61d</Hash>
</Codenesium>*/