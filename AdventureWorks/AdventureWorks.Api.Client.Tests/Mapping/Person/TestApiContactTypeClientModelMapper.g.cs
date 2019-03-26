using FluentAssertions;
using System;
using System.Collections.Generic;
using Xunit;

namespace AdventureWorksNS.Api.Client.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "ContactType")]
	[Trait("Area", "ApiModel")]
	public class TestApiContactTypeModelMapper
	{
		[Fact]
		public void MapClientRequestToResponse()
		{
			var mapper = new ApiContactTypeModelMapper();
			var model = new ApiContactTypeClientRequestModel();
			model.SetProperties(DateTime.Parse("1/1/1987 12:00:00 AM"), "A");
			ApiContactTypeClientResponseModel response = mapper.MapClientRequestToResponse(1, model);
			response.Should().NotBeNull();
			response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.Name.Should().Be("A");
		}

		[Fact]
		public void MapClientResponseToRequest()
		{
			var mapper = new ApiContactTypeModelMapper();
			var model = new ApiContactTypeClientResponseModel();
			model.SetProperties(1, DateTime.Parse("1/1/1987 12:00:00 AM"), "A");
			ApiContactTypeClientRequestModel response = mapper.MapClientResponseToRequest(model);
			response.Should().NotBeNull();
			response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.Name.Should().Be("A");
		}
	}
}

/*<Codenesium>
    <Hash>5e096f791c9303509f73cacd3eec510e</Hash>
</Codenesium>*/