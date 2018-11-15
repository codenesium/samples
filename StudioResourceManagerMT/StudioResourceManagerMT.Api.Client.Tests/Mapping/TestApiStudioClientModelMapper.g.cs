using FluentAssertions;
using System;
using System.Collections.Generic;
using Xunit;

namespace StudioResourceManagerMTNS.Api.Client.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "Studio")]
	[Trait("Area", "ApiModel")]
	public class TestApiStudioModelMapper
	{
		[Fact]
		public void MapClientRequestToResponse()
		{
			var mapper = new ApiStudioModelMapper();
			var model = new ApiStudioClientRequestModel();
			model.SetProperties("A", "A", "A", "A", "A", "A", "A");
			ApiStudioClientResponseModel response = mapper.MapClientRequestToResponse(1, model);
			response.Should().NotBeNull();
			response.Address1.Should().Be("A");
			response.Address2.Should().Be("A");
			response.City.Should().Be("A");
			response.Name.Should().Be("A");
			response.Province.Should().Be("A");
			response.Website.Should().Be("A");
			response.Zip.Should().Be("A");
		}

		[Fact]
		public void MapClientResponseToRequest()
		{
			var mapper = new ApiStudioModelMapper();
			var model = new ApiStudioClientResponseModel();
			model.SetProperties(1, "A", "A", "A", "A", "A", "A", "A");
			ApiStudioClientRequestModel response = mapper.MapClientResponseToRequest(model);
			response.Should().NotBeNull();
			response.Address1.Should().Be("A");
			response.Address2.Should().Be("A");
			response.City.Should().Be("A");
			response.Name.Should().Be("A");
			response.Province.Should().Be("A");
			response.Website.Should().Be("A");
			response.Zip.Should().Be("A");
		}
	}
}

/*<Codenesium>
    <Hash>2fb39f27551f455c6f5f543ec2a4269d</Hash>
</Codenesium>*/