using FluentAssertions;
using System;
using System.Collections.Generic;
using Xunit;

namespace AdventureWorksNS.Api.Client.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "Employee")]
	[Trait("Area", "ApiModel")]
	public class TestApiEmployeeModelMapper
	{
		[Fact]
		public void MapClientRequestToResponse()
		{
			var mapper = new ApiEmployeeModelMapper();
			var model = new ApiEmployeeClientRequestModel();
			model.SetProperties(DateTime.Parse("1/1/1987 12:00:00 AM"), true, "A", DateTime.Parse("1/1/1987 12:00:00 AM"), "A", "A", "A", DateTime.Parse("1/1/1987 12:00:00 AM"), "A", 1, Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"), true, 1, 1);
			ApiEmployeeClientResponseModel response = mapper.MapClientRequestToResponse(1, model);
			response.Should().NotBeNull();
			response.BirthDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.CurrentFlag.Should().Be(true);
			response.Gender.Should().Be("A");
			response.HireDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.JobTitle.Should().Be("A");
			response.LoginID.Should().Be("A");
			response.MaritalStatu.Should().Be("A");
			response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.NationalIDNumber.Should().Be("A");
			response.OrganizationLevel.Should().Be(1);
			response.Rowguid.Should().Be(Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));
			response.SalariedFlag.Should().Be(true);
			response.SickLeaveHour.Should().Be(1);
			response.VacationHour.Should().Be(1);
		}

		[Fact]
		public void MapClientResponseToRequest()
		{
			var mapper = new ApiEmployeeModelMapper();
			var model = new ApiEmployeeClientResponseModel();
			model.SetProperties(1, DateTime.Parse("1/1/1987 12:00:00 AM"), true, "A", DateTime.Parse("1/1/1987 12:00:00 AM"), "A", "A", "A", DateTime.Parse("1/1/1987 12:00:00 AM"), "A", 1, Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"), true, 1, 1);
			ApiEmployeeClientRequestModel response = mapper.MapClientResponseToRequest(model);
			response.Should().NotBeNull();
			response.BirthDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.CurrentFlag.Should().Be(true);
			response.Gender.Should().Be("A");
			response.HireDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.JobTitle.Should().Be("A");
			response.LoginID.Should().Be("A");
			response.MaritalStatu.Should().Be("A");
			response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.NationalIDNumber.Should().Be("A");
			response.OrganizationLevel.Should().Be(1);
			response.Rowguid.Should().Be(Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));
			response.SalariedFlag.Should().Be(true);
			response.SickLeaveHour.Should().Be(1);
			response.VacationHour.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>d2f9db244282e8a4ae24b1e3e4bd660b</Hash>
</Codenesium>*/