using FileServiceNS.Api.Contracts;
using FluentAssertions;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using Xunit;

namespace FileServiceNS.Api.Contracts.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "VersionInfo")]
	[Trait("Area", "ApiModel")]
	public class TestApiVersionInfoModelMapper
	{
		[Fact]
		public void MapRequestToResponse()
		{
			var mapper = new ApiVersionInfoModelMapper();
			var model = new ApiVersionInfoRequestModel();
			model.SetProperties(DateTime.Parse("1/1/1987 12:00:00 AM"), "A");
			ApiVersionInfoResponseModel response = mapper.MapRequestToResponse(1, model);

			response.AppliedOn.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.Description.Should().Be("A");
			response.Version.Should().Be(1);
		}

		[Fact]
		public void MapResponseToRequest()
		{
			var mapper = new ApiVersionInfoModelMapper();
			var model = new ApiVersionInfoResponseModel();
			model.SetProperties(1, DateTime.Parse("1/1/1987 12:00:00 AM"), "A");
			ApiVersionInfoRequestModel response = mapper.MapResponseToRequest(model);

			response.AppliedOn.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.Description.Should().Be("A");
		}

		[Fact]
		public void CreatePatch()
		{
			var mapper = new ApiVersionInfoModelMapper();
			var model = new ApiVersionInfoRequestModel();
			model.SetProperties(DateTime.Parse("1/1/1987 12:00:00 AM"), "A");

			JsonPatchDocument<ApiVersionInfoRequestModel> patch = mapper.CreatePatch(model);
			var response = new ApiVersionInfoRequestModel();
			patch.ApplyTo(response);
			response.AppliedOn.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.Description.Should().Be("A");
		}
	}
}

/*<Codenesium>
    <Hash>458100deb53dcd7482a04340a5030d11</Hash>
</Codenesium>*/