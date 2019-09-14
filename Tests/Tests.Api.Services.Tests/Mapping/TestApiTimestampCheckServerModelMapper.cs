using FluentAssertions;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using Xunit;

namespace TestsNS.Api.Services.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "TimestampCheck")]
	[Trait("Area", "ApiModel")]
	public class TestApiTimestampCheckServerModelMapper
	{
		[Fact]
		public void MapServerRequestToResponse()
		{
			var mapper = new ApiTimestampCheckServerModelMapper();
			var model = new ApiTimestampCheckServerRequestModel();
			model.SetProperties("A", BitConverter.GetBytes(1));
			ApiTimestampCheckServerResponseModel response = mapper.MapServerRequestToResponse(1, model);
			response.Should().NotBeNull();
			response.Name.Should().Be("A");
			response.Timestamp.Should().BeEquivalentTo(BitConverter.GetBytes(1));
		}

		[Fact]
		public void MapServerResponseToRequest()
		{
			var mapper = new ApiTimestampCheckServerModelMapper();
			var model = new ApiTimestampCheckServerResponseModel();
			model.SetProperties(1, "A", BitConverter.GetBytes(1));
			ApiTimestampCheckServerRequestModel response = mapper.MapServerResponseToRequest(model);
			response.Should().NotBeNull();
			response.Name.Should().Be("A");
			response.Timestamp.Should().BeEquivalentTo(BitConverter.GetBytes(1));
		}

		[Fact]
		public void CreatePatch()
		{
			var mapper = new ApiTimestampCheckServerModelMapper();
			var model = new ApiTimestampCheckServerRequestModel();
			model.SetProperties("A", BitConverter.GetBytes(1));

			JsonPatchDocument<ApiTimestampCheckServerRequestModel> patch = mapper.CreatePatch(model);
			var response = new ApiTimestampCheckServerRequestModel();
			patch.ApplyTo(response);
			response.Name.Should().Be("A");
			response.Timestamp.Should().BeEquivalentTo(BitConverter.GetBytes(1));
		}
	}
}

/*<Codenesium>
    <Hash>1e752108ce86f4f0aa3461e4e590f299</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/