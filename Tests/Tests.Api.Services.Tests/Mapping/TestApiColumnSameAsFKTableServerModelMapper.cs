using FluentAssertions;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using Xunit;

namespace TestsNS.Api.Services.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "ColumnSameAsFKTable")]
	[Trait("Area", "ApiModel")]
	public class TestApiColumnSameAsFKTableServerModelMapper
	{
		[Fact]
		public void MapServerRequestToResponse()
		{
			var mapper = new ApiColumnSameAsFKTableServerModelMapper();
			var model = new ApiColumnSameAsFKTableServerRequestModel();
			model.SetProperties(1, 1);
			ApiColumnSameAsFKTableServerResponseModel response = mapper.MapServerRequestToResponse(1, model);
			response.Should().NotBeNull();
			response.Person.Should().Be(1);
			response.PersonId.Should().Be(1);
		}

		[Fact]
		public void MapServerResponseToRequest()
		{
			var mapper = new ApiColumnSameAsFKTableServerModelMapper();
			var model = new ApiColumnSameAsFKTableServerResponseModel();
			model.SetProperties(1, 1, 1);
			ApiColumnSameAsFKTableServerRequestModel response = mapper.MapServerResponseToRequest(model);
			response.Should().NotBeNull();
			response.Person.Should().Be(1);
			response.PersonId.Should().Be(1);
		}

		[Fact]
		public void CreatePatch()
		{
			var mapper = new ApiColumnSameAsFKTableServerModelMapper();
			var model = new ApiColumnSameAsFKTableServerRequestModel();
			model.SetProperties(1, 1);

			JsonPatchDocument<ApiColumnSameAsFKTableServerRequestModel> patch = mapper.CreatePatch(model);
			var response = new ApiColumnSameAsFKTableServerRequestModel();
			patch.ApplyTo(response);
			response.Person.Should().Be(1);
			response.PersonId.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>ef214ce75bfd31c9ef27b46bb7ff5057</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/