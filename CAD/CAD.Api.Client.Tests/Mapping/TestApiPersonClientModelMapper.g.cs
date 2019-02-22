using FluentAssertions;
using System;
using System.Collections.Generic;
using Xunit;

namespace CADNS.Api.Client.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "Person")]
	[Trait("Area", "ApiModel")]
	public class TestApiPersonModelMapper
	{
		[Fact]
		public void MapClientRequestToResponse()
		{
			var mapper = new ApiPersonModelMapper();
			var model = new ApiPersonClientRequestModel();
			model.SetProperties("A", "A", "A", "A");
			ApiPersonClientResponseModel response = mapper.MapClientRequestToResponse(1, model);
			response.Should().NotBeNull();
			response.FirstName.Should().Be("A");
			response.LastName.Should().Be("A");
			response.Phone.Should().Be("A");
			response.Ssn.Should().Be("A");
		}

		[Fact]
		public void MapClientResponseToRequest()
		{
			var mapper = new ApiPersonModelMapper();
			var model = new ApiPersonClientResponseModel();
			model.SetProperties(1, "A", "A", "A", "A");
			ApiPersonClientRequestModel response = mapper.MapClientResponseToRequest(model);
			response.Should().NotBeNull();
			response.FirstName.Should().Be("A");
			response.LastName.Should().Be("A");
			response.Phone.Should().Be("A");
			response.Ssn.Should().Be("A");
		}
	}
}

/*<Codenesium>
    <Hash>27939c4ad019203bf712fd204b2e0d89</Hash>
</Codenesium>*/