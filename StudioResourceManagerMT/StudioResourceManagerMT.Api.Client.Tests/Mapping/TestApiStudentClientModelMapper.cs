using FluentAssertions;
using System;
using System.Collections.Generic;
using Xunit;

namespace StudioResourceManagerMTNS.Api.Client.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "Student")]
	[Trait("Area", "ApiModel")]
	public class TestApiStudentModelMapper
	{
		[Fact]
		public void MapClientRequestToResponse()
		{
			var mapper = new ApiStudentModelMapper();
			var model = new ApiStudentClientRequestModel();
			model.SetProperties(DateTime.Parse("1/1/1987 12:00:00 AM"), "A", true, 1, "A", true, "A", "A", true, 1);
			ApiStudentClientResponseModel response = mapper.MapClientRequestToResponse(1, model);
			response.Should().NotBeNull();
			response.Birthday.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.Email.Should().Be("A");
			response.EmailRemindersEnabled.Should().Be(true);
			response.FamilyId.Should().Be(1);
			response.FirstName.Should().Be("A");
			response.IsAdult.Should().Be(true);
			response.LastName.Should().Be("A");
			response.Phone.Should().Be("A");
			response.SmsRemindersEnabled.Should().Be(true);
			response.UserId.Should().Be(1);
		}

		[Fact]
		public void MapClientResponseToRequest()
		{
			var mapper = new ApiStudentModelMapper();
			var model = new ApiStudentClientResponseModel();
			model.SetProperties(1, DateTime.Parse("1/1/1987 12:00:00 AM"), "A", true, 1, "A", true, "A", "A", true, 1);
			ApiStudentClientRequestModel response = mapper.MapClientResponseToRequest(model);
			response.Should().NotBeNull();
			response.Birthday.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.Email.Should().Be("A");
			response.EmailRemindersEnabled.Should().Be(true);
			response.FamilyId.Should().Be(1);
			response.FirstName.Should().Be("A");
			response.IsAdult.Should().Be(true);
			response.LastName.Should().Be("A");
			response.Phone.Should().Be("A");
			response.SmsRemindersEnabled.Should().Be(true);
			response.UserId.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>a770877699ed693a94dce856ba7b2e40</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/