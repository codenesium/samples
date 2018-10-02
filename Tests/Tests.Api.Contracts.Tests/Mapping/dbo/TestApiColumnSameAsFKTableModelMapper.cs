using FluentAssertions;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using TestsNS.Api.Contracts;
using Xunit;

namespace TestsNS.Api.Contracts.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "ColumnSameAsFKTable")]
	[Trait("Area", "ApiModel")]
	public class TestApiColumnSameAsFKTableModelMapper
	{
		[Fact]
		public void MapRequestToResponse()
		{
			var mapper = new ApiColumnSameAsFKTableModelMapper();
			var model = new ApiColumnSameAsFKTableRequestModel();
			model.SetProperties(1, 1);
			ApiColumnSameAsFKTableResponseModel response = mapper.MapRequestToResponse(1, model);

			response.Id.Should().Be(1);
			response.Person.Should().Be(1);
			response.PersonId.Should().Be(1);
		}

		[Fact]
		public void MapResponseToRequest()
		{
			var mapper = new ApiColumnSameAsFKTableModelMapper();
			var model = new ApiColumnSameAsFKTableResponseModel();
			model.SetProperties(1, 1, 1);
			ApiColumnSameAsFKTableRequestModel response = mapper.MapResponseToRequest(model);

			response.Person.Should().Be(1);
			response.PersonId.Should().Be(1);
		}

		[Fact]
		public void CreatePatch()
		{
			var mapper = new ApiColumnSameAsFKTableModelMapper();
			var model = new ApiColumnSameAsFKTableRequestModel();
			model.SetProperties(1, 1);

			JsonPatchDocument<ApiColumnSameAsFKTableRequestModel> patch = mapper.CreatePatch(model);
			var response = new ApiColumnSameAsFKTableRequestModel();
			patch.ApplyTo(response);
			response.Person.Should().Be(1);
			response.PersonId.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>419eb8a0d3c1cb04dcf471588950e3e8</Hash>
</Codenesium>*/