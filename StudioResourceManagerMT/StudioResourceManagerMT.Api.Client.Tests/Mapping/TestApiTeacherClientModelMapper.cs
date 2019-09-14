using FluentAssertions;
using System;
using System.Collections.Generic;
using Xunit;

namespace StudioResourceManagerMTNS.Api.Client.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "Teacher")]
	[Trait("Area", "ApiModel")]
	public class TestApiTeacherModelMapper
	{
		[Fact]
		public void MapClientRequestToResponse()
		{
			var mapper = new ApiTeacherModelMapper();
			var model = new ApiTeacherClientRequestModel();
			model.SetProperties(DateTime.Parse("1/1/1987 12:00:00 AM"), "A", "A", "A", "A", 1);
			ApiTeacherClientResponseModel response = mapper.MapClientRequestToResponse(1, model);
			response.Should().NotBeNull();
			response.Birthday.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.Email.Should().Be("A");
			response.FirstName.Should().Be("A");
			response.LastName.Should().Be("A");
			response.Phone.Should().Be("A");
			response.UserId.Should().Be(1);
		}

		[Fact]
		public void MapClientResponseToRequest()
		{
			var mapper = new ApiTeacherModelMapper();
			var model = new ApiTeacherClientResponseModel();
			model.SetProperties(1, DateTime.Parse("1/1/1987 12:00:00 AM"), "A", "A", "A", "A", 1);
			ApiTeacherClientRequestModel response = mapper.MapClientResponseToRequest(model);
			response.Should().NotBeNull();
			response.Birthday.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.Email.Should().Be("A");
			response.FirstName.Should().Be("A");
			response.LastName.Should().Be("A");
			response.Phone.Should().Be("A");
			response.UserId.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>35670c7c5c6cb8cebdf9d7c3e43abfcd</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/