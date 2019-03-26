using FluentAssertions;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using Xunit;

namespace AdventureWorksNS.Api.Services.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "Employee")]
	[Trait("Area", "ApiModel")]
	public class TestApiEmployeeServerModelMapper
	{
		[Fact]
		public void MapServerRequestToResponse()
		{
			var mapper = new ApiEmployeeServerModelMapper();
			var model = new ApiEmployeeServerRequestModel();
			model.SetProperties(DateTime.Parse("1/1/1987 12:00:00 AM"), true, "A", DateTime.Parse("1/1/1987 12:00:00 AM"), "A", "A", "A", DateTime.Parse("1/1/1987 12:00:00 AM"), "A", 1, Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"), true, 1, 1);
			ApiEmployeeServerResponseModel response = mapper.MapServerRequestToResponse(1, model);
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
		public void MapServerResponseToRequest()
		{
			var mapper = new ApiEmployeeServerModelMapper();
			var model = new ApiEmployeeServerResponseModel();
			model.SetProperties(1, DateTime.Parse("1/1/1987 12:00:00 AM"), true, "A", DateTime.Parse("1/1/1987 12:00:00 AM"), "A", "A", "A", DateTime.Parse("1/1/1987 12:00:00 AM"), "A", 1, Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"), true, 1, 1);
			ApiEmployeeServerRequestModel response = mapper.MapServerResponseToRequest(model);
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
		public void CreatePatch()
		{
			var mapper = new ApiEmployeeServerModelMapper();
			var model = new ApiEmployeeServerRequestModel();
			model.SetProperties(DateTime.Parse("1/1/1987 12:00:00 AM"), true, "A", DateTime.Parse("1/1/1987 12:00:00 AM"), "A", "A", "A", DateTime.Parse("1/1/1987 12:00:00 AM"), "A", 1, Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"), true, 1, 1);

			JsonPatchDocument<ApiEmployeeServerRequestModel> patch = mapper.CreatePatch(model);
			var response = new ApiEmployeeServerRequestModel();
			patch.ApplyTo(response);
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
    <Hash>3d6a903767209bcf4eb8bcea74796c40</Hash>
</Codenesium>*/