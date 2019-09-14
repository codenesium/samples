using FluentAssertions;
using System;
using System.Collections.Generic;
using Xunit;

namespace StudioResourceManagerMTNS.Api.Client.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "Rate")]
	[Trait("Area", "ApiModel")]
	public class TestApiRateModelMapper
	{
		[Fact]
		public void MapClientRequestToResponse()
		{
			var mapper = new ApiRateModelMapper();
			var model = new ApiRateClientRequestModel();
			model.SetProperties(1m, 1, 1);
			ApiRateClientResponseModel response = mapper.MapClientRequestToResponse(1, model);
			response.Should().NotBeNull();
			response.AmountPerMinute.Should().Be(1m);
			response.TeacherId.Should().Be(1);
			response.TeacherSkillId.Should().Be(1);
		}

		[Fact]
		public void MapClientResponseToRequest()
		{
			var mapper = new ApiRateModelMapper();
			var model = new ApiRateClientResponseModel();
			model.SetProperties(1, 1m, 1, 1);
			ApiRateClientRequestModel response = mapper.MapClientResponseToRequest(model);
			response.Should().NotBeNull();
			response.AmountPerMinute.Should().Be(1m);
			response.TeacherId.Should().Be(1);
			response.TeacherSkillId.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>511b03daa1b2687b2778d46203f75daf</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/