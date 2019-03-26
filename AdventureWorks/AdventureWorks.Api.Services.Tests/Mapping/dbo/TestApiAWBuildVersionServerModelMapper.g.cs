using FluentAssertions;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using Xunit;

namespace AdventureWorksNS.Api.Services.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "AWBuildVersion")]
	[Trait("Area", "ApiModel")]
	public class TestApiAWBuildVersionServerModelMapper
	{
		[Fact]
		public void MapServerRequestToResponse()
		{
			var mapper = new ApiAWBuildVersionServerModelMapper();
			var model = new ApiAWBuildVersionServerRequestModel();
			model.SetProperties("A", DateTime.Parse("1/1/1987 12:00:00 AM"), DateTime.Parse("1/1/1987 12:00:00 AM"));
			ApiAWBuildVersionServerResponseModel response = mapper.MapServerRequestToResponse(1, model);
			response.Should().NotBeNull();
			response.Database_Version.Should().Be("A");
			response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.VersionDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
		}

		[Fact]
		public void MapServerResponseToRequest()
		{
			var mapper = new ApiAWBuildVersionServerModelMapper();
			var model = new ApiAWBuildVersionServerResponseModel();
			model.SetProperties(1, "A", DateTime.Parse("1/1/1987 12:00:00 AM"), DateTime.Parse("1/1/1987 12:00:00 AM"));
			ApiAWBuildVersionServerRequestModel response = mapper.MapServerResponseToRequest(model);
			response.Should().NotBeNull();
			response.Database_Version.Should().Be("A");
			response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.VersionDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
		}

		[Fact]
		public void CreatePatch()
		{
			var mapper = new ApiAWBuildVersionServerModelMapper();
			var model = new ApiAWBuildVersionServerRequestModel();
			model.SetProperties("A", DateTime.Parse("1/1/1987 12:00:00 AM"), DateTime.Parse("1/1/1987 12:00:00 AM"));

			JsonPatchDocument<ApiAWBuildVersionServerRequestModel> patch = mapper.CreatePatch(model);
			var response = new ApiAWBuildVersionServerRequestModel();
			patch.ApplyTo(response);
			response.Database_Version.Should().Be("A");
			response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.VersionDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
		}
	}
}

/*<Codenesium>
    <Hash>a4dddea0af7761eee66ff4fb9b138d58</Hash>
</Codenesium>*/