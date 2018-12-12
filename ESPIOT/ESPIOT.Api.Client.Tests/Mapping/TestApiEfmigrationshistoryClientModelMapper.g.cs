using FluentAssertions;
using System;
using System.Collections.Generic;
using Xunit;

namespace ESPIOTNS.Api.Client.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "Efmigrationshistory")]
	[Trait("Area", "ApiModel")]
	public class TestApiEfmigrationshistoryModelMapper
	{
		[Fact]
		public void MapClientRequestToResponse()
		{
			var mapper = new ApiEfmigrationshistoryModelMapper();
			var model = new ApiEfmigrationshistoryClientRequestModel();
			model.SetProperties("A");
			ApiEfmigrationshistoryClientResponseModel response = mapper.MapClientRequestToResponse("A", model);
			response.Should().NotBeNull();
			response.ProductVersion.Should().Be("A");
		}

		[Fact]
		public void MapClientResponseToRequest()
		{
			var mapper = new ApiEfmigrationshistoryModelMapper();
			var model = new ApiEfmigrationshistoryClientResponseModel();
			model.SetProperties("A", "A");
			ApiEfmigrationshistoryClientRequestModel response = mapper.MapClientResponseToRequest(model);
			response.Should().NotBeNull();
			response.ProductVersion.Should().Be("A");
		}
	}
}

/*<Codenesium>
    <Hash>ebc91968a8703f2dc4137994237e0809</Hash>
</Codenesium>*/