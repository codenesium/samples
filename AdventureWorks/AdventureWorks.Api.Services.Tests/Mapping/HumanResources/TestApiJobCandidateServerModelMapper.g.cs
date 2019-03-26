using FluentAssertions;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using Xunit;

namespace AdventureWorksNS.Api.Services.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "JobCandidate")]
	[Trait("Area", "ApiModel")]
	public class TestApiJobCandidateServerModelMapper
	{
		[Fact]
		public void MapServerRequestToResponse()
		{
			var mapper = new ApiJobCandidateServerModelMapper();
			var model = new ApiJobCandidateServerRequestModel();
			model.SetProperties(1, DateTime.Parse("1/1/1987 12:00:00 AM"), "A");
			ApiJobCandidateServerResponseModel response = mapper.MapServerRequestToResponse(1, model);
			response.Should().NotBeNull();
			response.BusinessEntityID.Should().Be(1);
			response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.Resume.Should().Be("A");
		}

		[Fact]
		public void MapServerResponseToRequest()
		{
			var mapper = new ApiJobCandidateServerModelMapper();
			var model = new ApiJobCandidateServerResponseModel();
			model.SetProperties(1, 1, DateTime.Parse("1/1/1987 12:00:00 AM"), "A");
			ApiJobCandidateServerRequestModel response = mapper.MapServerResponseToRequest(model);
			response.Should().NotBeNull();
			response.BusinessEntityID.Should().Be(1);
			response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.Resume.Should().Be("A");
		}

		[Fact]
		public void CreatePatch()
		{
			var mapper = new ApiJobCandidateServerModelMapper();
			var model = new ApiJobCandidateServerRequestModel();
			model.SetProperties(1, DateTime.Parse("1/1/1987 12:00:00 AM"), "A");

			JsonPatchDocument<ApiJobCandidateServerRequestModel> patch = mapper.CreatePatch(model);
			var response = new ApiJobCandidateServerRequestModel();
			patch.ApplyTo(response);
			response.BusinessEntityID.Should().Be(1);
			response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.Resume.Should().Be("A");
		}
	}
}

/*<Codenesium>
    <Hash>ce678ef032aeb3fd29b094c8165a2562</Hash>
</Codenesium>*/