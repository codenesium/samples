using AdventureWorksNS.Api.Contracts;
using FluentAssertions;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using Xunit;

namespace AdventureWorksNS.Api.Contracts.Tests
{
        [Trait("Type", "Unit")]
        [Trait("Table", "Employee")]
        [Trait("Area", "ApiModel")]
        public class TestApiEmployeeModelMapper
        {
                [Fact]
                public void MapRequestToResponse()
                {
                        var mapper = new ApiEmployeeModelMapper();
                        var model = new ApiEmployeeRequestModel();
                        model.SetProperties(DateTime.Parse("1/1/1987 12:00:00 AM"), true, "A", DateTime.Parse("1/1/1987 12:00:00 AM"), "A", "A", "A", DateTime.Parse("1/1/1987 12:00:00 AM"), "A", 1, Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"), true, 1, 1);
                        ApiEmployeeResponseModel response = mapper.MapRequestToResponse(1, model);

                        response.BirthDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
                        response.BusinessEntityID.Should().Be(1);
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
                public void MapResponseToRequest()
                {
                        var mapper = new ApiEmployeeModelMapper();
                        var model = new ApiEmployeeResponseModel();
                        model.SetProperties(1, DateTime.Parse("1/1/1987 12:00:00 AM"), true, "A", DateTime.Parse("1/1/1987 12:00:00 AM"), "A", "A", "A", DateTime.Parse("1/1/1987 12:00:00 AM"), "A", 1, Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"), true, 1, 1);
                        ApiEmployeeRequestModel response = mapper.MapResponseToRequest(model);

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
                        var mapper = new ApiEmployeeModelMapper();
                        var model = new ApiEmployeeRequestModel();
                        model.SetProperties(DateTime.Parse("1/1/1987 12:00:00 AM"), true, "A", DateTime.Parse("1/1/1987 12:00:00 AM"), "A", "A", "A", DateTime.Parse("1/1/1987 12:00:00 AM"), "A", 1, Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"), true, 1, 1);

                        JsonPatchDocument<ApiEmployeeRequestModel> patch = mapper.CreatePatch(model);
                        var response = new ApiEmployeeRequestModel();
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
    <Hash>91123c2ac0fb6921e42461de4273a3f7</Hash>
</Codenesium>*/