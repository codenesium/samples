using FluentAssertions;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using TestsNS.Api.Contracts;
using Xunit;

namespace TestsNS.Api.Contracts.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "TimestampCheck")]
	[Trait("Area", "ApiModel")]
	public class TestApiTimestampCheckModelMapper
	{
		[Fact]
		public void MapRequestToResponse()
		{
			var mapper = new ApiTimestampCheckModelMapper();
			var model = new ApiTimestampCheckRequestModel();
			model.SetProperties("A", BitConverter.GetBytes(1));
			ApiTimestampCheckResponseModel response = mapper.MapRequestToResponse(1, model);

			response.Id.Should().Be(1);
			response.Name.Should().Be("A");
			response.Timestamp.Should().BeEquivalentTo(BitConverter.GetBytes(1));
		}

		[Fact]
		public void MapResponseToRequest()
		{
			var mapper = new ApiTimestampCheckModelMapper();
			var model = new ApiTimestampCheckResponseModel();
			model.SetProperties(1, "A", BitConverter.GetBytes(1));
			ApiTimestampCheckRequestModel response = mapper.MapResponseToRequest(model);

			response.Name.Should().Be("A");
			response.Timestamp.Should().BeEquivalentTo(BitConverter.GetBytes(1));
		}

		[Fact]
		public void CreatePatch()
		{
			var mapper = new ApiTimestampCheckModelMapper();
			var model = new ApiTimestampCheckRequestModel();
			model.SetProperties("A", BitConverter.GetBytes(1));

			JsonPatchDocument<ApiTimestampCheckRequestModel> patch = mapper.CreatePatch(model);
			var response = new ApiTimestampCheckRequestModel();
			patch.ApplyTo(response);
			response.Name.Should().Be("A");
			response.Timestamp.Should().BeEquivalentTo(BitConverter.GetBytes(1));
		}
	}
}

/*<Codenesium>
    <Hash>d15c120f21ef4b22b30f72f10366e620</Hash>
</Codenesium>*/