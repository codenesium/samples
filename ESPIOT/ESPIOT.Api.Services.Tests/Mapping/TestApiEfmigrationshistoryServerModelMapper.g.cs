using FluentAssertions;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using Xunit;

namespace ESPIOTNS.Api.Services.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "Efmigrationshistory")]
	[Trait("Area", "ApiModel")]
	public class TestApiEfmigrationshistoryServerModelMapper
	{
		[Fact]
		public void MapServerRequestToResponse()
		{
			var mapper = new ApiEfmigrationshistoryServerModelMapper();
			var model = new ApiEfmigrationshistoryServerRequestModel();
			model.SetProperties("A");
			ApiEfmigrationshistoryServerResponseModel response = mapper.MapServerRequestToResponse("A", model);
			response.Should().NotBeNull();
			response.ProductVersion.Should().Be("A");
		}

		[Fact]
		public void MapServerResponseToRequest()
		{
			var mapper = new ApiEfmigrationshistoryServerModelMapper();
			var model = new ApiEfmigrationshistoryServerResponseModel();
			model.SetProperties("A", "A");
			ApiEfmigrationshistoryServerRequestModel response = mapper.MapServerResponseToRequest(model);
			response.Should().NotBeNull();
			response.ProductVersion.Should().Be("A");
		}

		[Fact]
		public void CreatePatch()
		{
			var mapper = new ApiEfmigrationshistoryServerModelMapper();
			var model = new ApiEfmigrationshistoryServerRequestModel();
			model.SetProperties("A");

			JsonPatchDocument<ApiEfmigrationshistoryServerRequestModel> patch = mapper.CreatePatch(model);
			var response = new ApiEfmigrationshistoryServerRequestModel();
			patch.ApplyTo(response);
			response.ProductVersion.Should().Be("A");
		}
	}
}

/*<Codenesium>
    <Hash>5e5f90a4fbd99b625e1e0b6a62b464bc</Hash>
</Codenesium>*/