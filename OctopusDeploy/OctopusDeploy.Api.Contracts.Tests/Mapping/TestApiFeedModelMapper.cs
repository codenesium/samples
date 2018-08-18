using FluentAssertions;
using Microsoft.AspNetCore.JsonPatch;
using OctopusDeployNS.Api.Contracts;
using System;
using System.Collections.Generic;
using Xunit;

namespace OctopusDeployNS.Api.Contracts.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "Feed")]
	[Trait("Area", "ApiModel")]
	public class TestApiFeedModelMapper
	{
		[Fact]
		public void MapRequestToResponse()
		{
			var mapper = new ApiFeedModelMapper();
			var model = new ApiFeedRequestModel();
			model.SetProperties("A", "A", "A", "A");
			ApiFeedResponseModel response = mapper.MapRequestToResponse("A", model);

			response.FeedType.Should().Be("A");
			response.FeedUri.Should().Be("A");
			response.Id.Should().Be("A");
			response.JSON.Should().Be("A");
			response.Name.Should().Be("A");
		}

		[Fact]
		public void MapResponseToRequest()
		{
			var mapper = new ApiFeedModelMapper();
			var model = new ApiFeedResponseModel();
			model.SetProperties("A", "A", "A", "A", "A");
			ApiFeedRequestModel response = mapper.MapResponseToRequest(model);

			response.FeedType.Should().Be("A");
			response.FeedUri.Should().Be("A");
			response.JSON.Should().Be("A");
			response.Name.Should().Be("A");
		}

		[Fact]
		public void CreatePatch()
		{
			var mapper = new ApiFeedModelMapper();
			var model = new ApiFeedRequestModel();
			model.SetProperties("A", "A", "A", "A");

			JsonPatchDocument<ApiFeedRequestModel> patch = mapper.CreatePatch(model);
			var response = new ApiFeedRequestModel();
			patch.ApplyTo(response);
			response.FeedType.Should().Be("A");
			response.FeedUri.Should().Be("A");
			response.JSON.Should().Be("A");
			response.Name.Should().Be("A");
		}
	}
}

/*<Codenesium>
    <Hash>5ad0045481c87dcd23df82a163cd5e57</Hash>
</Codenesium>*/