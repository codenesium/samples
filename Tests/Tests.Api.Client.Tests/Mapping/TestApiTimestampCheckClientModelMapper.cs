using FluentAssertions;
using System;
using System.Collections.Generic;
using Xunit;

namespace TestsNS.Api.Client.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "TimestampCheck")]
	[Trait("Area", "ApiModel")]
	public class TestApiTimestampCheckModelMapper
	{
		[Fact]
		public void MapClientRequestToResponse()
		{
			var mapper = new ApiTimestampCheckModelMapper();
			var model = new ApiTimestampCheckClientRequestModel();
			model.SetProperties("A", BitConverter.GetBytes(1));
			ApiTimestampCheckClientResponseModel response = mapper.MapClientRequestToResponse(1, model);
			response.Should().NotBeNull();
			response.Name.Should().Be("A");
			response.Timestamp.Should().BeEquivalentTo(BitConverter.GetBytes(1));
		}

		[Fact]
		public void MapClientResponseToRequest()
		{
			var mapper = new ApiTimestampCheckModelMapper();
			var model = new ApiTimestampCheckClientResponseModel();
			model.SetProperties(1, "A", BitConverter.GetBytes(1));
			ApiTimestampCheckClientRequestModel response = mapper.MapClientResponseToRequest(model);
			response.Should().NotBeNull();
			response.Name.Should().Be("A");
			response.Timestamp.Should().BeEquivalentTo(BitConverter.GetBytes(1));
		}
	}
}

/*<Codenesium>
    <Hash>bb0afa96faf9952711887eaca0684884</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/