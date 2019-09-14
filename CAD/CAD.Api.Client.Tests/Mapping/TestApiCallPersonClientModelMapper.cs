using FluentAssertions;
using System;
using System.Collections.Generic;
using Xunit;

namespace CADNS.Api.Client.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "CallPerson")]
	[Trait("Area", "ApiModel")]
	public class TestApiCallPersonModelMapper
	{
		[Fact]
		public void MapClientRequestToResponse()
		{
			var mapper = new ApiCallPersonModelMapper();
			var model = new ApiCallPersonClientRequestModel();
			model.SetProperties("A", 1, 1);
			ApiCallPersonClientResponseModel response = mapper.MapClientRequestToResponse(1, model);
			response.Should().NotBeNull();
			response.Note.Should().Be("A");
			response.PersonId.Should().Be(1);
			response.PersonTypeId.Should().Be(1);
		}

		[Fact]
		public void MapClientResponseToRequest()
		{
			var mapper = new ApiCallPersonModelMapper();
			var model = new ApiCallPersonClientResponseModel();
			model.SetProperties(1, "A", 1, 1);
			ApiCallPersonClientRequestModel response = mapper.MapClientResponseToRequest(model);
			response.Should().NotBeNull();
			response.Note.Should().Be("A");
			response.PersonId.Should().Be(1);
			response.PersonTypeId.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>a23f77c39a6da6305a8afaa1e27074aa</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/