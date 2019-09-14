using FluentAssertions;
using System;
using System.Collections.Generic;
using Xunit;

namespace TestsNS.Api.Client.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "ColumnSameAsFKTable")]
	[Trait("Area", "ApiModel")]
	public class TestApiColumnSameAsFKTableModelMapper
	{
		[Fact]
		public void MapClientRequestToResponse()
		{
			var mapper = new ApiColumnSameAsFKTableModelMapper();
			var model = new ApiColumnSameAsFKTableClientRequestModel();
			model.SetProperties(1, 1);
			ApiColumnSameAsFKTableClientResponseModel response = mapper.MapClientRequestToResponse(1, model);
			response.Should().NotBeNull();
			response.Person.Should().Be(1);
			response.PersonId.Should().Be(1);
		}

		[Fact]
		public void MapClientResponseToRequest()
		{
			var mapper = new ApiColumnSameAsFKTableModelMapper();
			var model = new ApiColumnSameAsFKTableClientResponseModel();
			model.SetProperties(1, 1, 1);
			ApiColumnSameAsFKTableClientRequestModel response = mapper.MapClientResponseToRequest(model);
			response.Should().NotBeNull();
			response.Person.Should().Be(1);
			response.PersonId.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>408fe23aa0e136b436493c33dd3c410e</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/