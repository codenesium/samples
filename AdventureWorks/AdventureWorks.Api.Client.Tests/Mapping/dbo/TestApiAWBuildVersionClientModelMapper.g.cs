using FluentAssertions;
using System;
using System.Collections.Generic;
using Xunit;

namespace AdventureWorksNS.Api.Client.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "AWBuildVersion")]
	[Trait("Area", "ApiModel")]
	public class TestApiAWBuildVersionModelMapper
	{
		[Fact]
		public void MapClientRequestToResponse()
		{
			var mapper = new ApiAWBuildVersionModelMapper();
			var model = new ApiAWBuildVersionClientRequestModel();
			model.SetProperties("A", DateTime.Parse("1/1/1987 12:00:00 AM"), DateTime.Parse("1/1/1987 12:00:00 AM"));
			ApiAWBuildVersionClientResponseModel response = mapper.MapClientRequestToResponse(1, model);
			response.Should().NotBeNull();
			response.Database_Version.Should().Be("A");
			response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.VersionDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
		}

		[Fact]
		public void MapClientResponseToRequest()
		{
			var mapper = new ApiAWBuildVersionModelMapper();
			var model = new ApiAWBuildVersionClientResponseModel();
			model.SetProperties(1, "A", DateTime.Parse("1/1/1987 12:00:00 AM"), DateTime.Parse("1/1/1987 12:00:00 AM"));
			ApiAWBuildVersionClientRequestModel response = mapper.MapClientResponseToRequest(model);
			response.Should().NotBeNull();
			response.Database_Version.Should().Be("A");
			response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.VersionDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
		}
	}
}

/*<Codenesium>
    <Hash>adaafd5eb7dec439380b7758e355210f</Hash>
</Codenesium>*/