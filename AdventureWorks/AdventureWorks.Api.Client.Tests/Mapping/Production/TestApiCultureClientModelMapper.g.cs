using FluentAssertions;
using System;
using System.Collections.Generic;
using Xunit;

namespace AdventureWorksNS.Api.Client.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "Culture")]
	[Trait("Area", "ApiModel")]
	public class TestApiCultureModelMapper
	{
		[Fact]
		public void MapClientRequestToResponse()
		{
			var mapper = new ApiCultureModelMapper();
			var model = new ApiCultureClientRequestModel();
			model.SetProperties(DateTime.Parse("1/1/1987 12:00:00 AM"), "A");
			ApiCultureClientResponseModel response = mapper.MapClientRequestToResponse("A", model);
			response.Should().NotBeNull();
			response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.Name.Should().Be("A");
		}

		[Fact]
		public void MapClientResponseToRequest()
		{
			var mapper = new ApiCultureModelMapper();
			var model = new ApiCultureClientResponseModel();
			model.SetProperties("A", DateTime.Parse("1/1/1987 12:00:00 AM"), "A");
			ApiCultureClientRequestModel response = mapper.MapClientResponseToRequest(model);
			response.Should().NotBeNull();
			response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.Name.Should().Be("A");
		}
	}
}

/*<Codenesium>
    <Hash>c1d11e71183ce20a9978a22e11c2b977</Hash>
</Codenesium>*/