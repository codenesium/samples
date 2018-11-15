using FluentAssertions;
using System;
using System.Collections.Generic;
using Xunit;

namespace NebulaNS.Api.Client.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "VersionInfo")]
	[Trait("Area", "ApiModel")]
	public class TestApiVersionInfoModelMapper
	{
		[Fact]
		public void MapClientRequestToResponse()
		{
			var mapper = new ApiVersionInfoModelMapper();
			var model = new ApiVersionInfoClientRequestModel();
			model.SetProperties(DateTime.Parse("1/1/1987 12:00:00 AM"), "A");
			ApiVersionInfoClientResponseModel response = mapper.MapClientRequestToResponse(1, model);
			response.Should().NotBeNull();
			response.AppliedOn.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.Description.Should().Be("A");
		}

		[Fact]
		public void MapClientResponseToRequest()
		{
			var mapper = new ApiVersionInfoModelMapper();
			var model = new ApiVersionInfoClientResponseModel();
			model.SetProperties(1, DateTime.Parse("1/1/1987 12:00:00 AM"), "A");
			ApiVersionInfoClientRequestModel response = mapper.MapClientResponseToRequest(model);
			response.Should().NotBeNull();
			response.AppliedOn.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.Description.Should().Be("A");
		}
	}
}

/*<Codenesium>
    <Hash>8f7ad7fc622b6e3bd703ef3c0b9a2f3c</Hash>
</Codenesium>*/