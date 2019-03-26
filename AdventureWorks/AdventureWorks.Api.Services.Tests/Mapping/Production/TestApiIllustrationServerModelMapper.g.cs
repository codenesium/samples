using FluentAssertions;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using Xunit;

namespace AdventureWorksNS.Api.Services.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "Illustration")]
	[Trait("Area", "ApiModel")]
	public class TestApiIllustrationServerModelMapper
	{
		[Fact]
		public void MapServerRequestToResponse()
		{
			var mapper = new ApiIllustrationServerModelMapper();
			var model = new ApiIllustrationServerRequestModel();
			model.SetProperties("A", DateTime.Parse("1/1/1987 12:00:00 AM"));
			ApiIllustrationServerResponseModel response = mapper.MapServerRequestToResponse(1, model);
			response.Should().NotBeNull();
			response.Diagram.Should().Be("A");
			response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
		}

		[Fact]
		public void MapServerResponseToRequest()
		{
			var mapper = new ApiIllustrationServerModelMapper();
			var model = new ApiIllustrationServerResponseModel();
			model.SetProperties(1, "A", DateTime.Parse("1/1/1987 12:00:00 AM"));
			ApiIllustrationServerRequestModel response = mapper.MapServerResponseToRequest(model);
			response.Should().NotBeNull();
			response.Diagram.Should().Be("A");
			response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
		}

		[Fact]
		public void CreatePatch()
		{
			var mapper = new ApiIllustrationServerModelMapper();
			var model = new ApiIllustrationServerRequestModel();
			model.SetProperties("A", DateTime.Parse("1/1/1987 12:00:00 AM"));

			JsonPatchDocument<ApiIllustrationServerRequestModel> patch = mapper.CreatePatch(model);
			var response = new ApiIllustrationServerRequestModel();
			patch.ApplyTo(response);
			response.Diagram.Should().Be("A");
			response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
		}
	}
}

/*<Codenesium>
    <Hash>8058b9ee383e126f5a304a961117e2d5</Hash>
</Codenesium>*/