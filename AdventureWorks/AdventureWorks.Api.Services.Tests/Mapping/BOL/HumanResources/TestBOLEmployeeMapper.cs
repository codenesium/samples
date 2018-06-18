using System;
using System.Collections.Generic;
using FluentAssertions;
using Xunit;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using AdventureWorksNS.Api.Services;

namespace AdventureWorksNS.Api.Services.Tests
{
        [Trait("Type", "Unit")]
        [Trait("Table", "Employee")]
        [Trait("Area", "BOLMapper")]
        public class TestBOLEmployeeActionMapper
        {
                [Fact]
                public void MapModelToBO()
                {
                        var mapper = new BOLEmployeeMapper();

                        ApiEmployeeRequestModel model = new ApiEmployeeRequestModel();

                        model.SetProperties(DateTime.Parse("1/1/1987 12:00:00 AM"), true, "A", DateTime.Parse("1/1/1987 12:00:00 AM"), "A", "A", "A", DateTime.Parse("1/1/1987 12:00:00 AM"), "A", 1, Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"), true, 1, 1);
                        BOEmployee response = mapper.MapModelToBO(1, model);

                        response.BirthDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
                        response.CurrentFlag.Should().Be(true);
                        response.Gender.Should().Be("A");
                        response.HireDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
                        response.JobTitle.Should().Be("A");
                        response.LoginID.Should().Be("A");
                        response.MaritalStatus.Should().Be("A");
                        response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
                        response.NationalIDNumber.Should().Be("A");
                        response.OrganizationLevel.Should().Be(1);
                        response.Rowguid.Should().Be(Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));
                        response.SalariedFlag.Should().Be(true);
                        response.SickLeaveHours.Should().Be(1);
                        response.VacationHours.Should().Be(1);
                }

                [Fact]
                public void MapBOToModel()
                {
                        var mapper = new BOLEmployeeMapper();

                        BOEmployee bo = new BOEmployee();

                        bo.SetProperties(1, DateTime.Parse("1/1/1987 12:00:00 AM"), true, "A", DateTime.Parse("1/1/1987 12:00:00 AM"), "A", "A", "A", DateTime.Parse("1/1/1987 12:00:00 AM"), "A", 1, Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"), true, 1, 1);
                        ApiEmployeeResponseModel response = mapper.MapBOToModel(bo);

                        response.BirthDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
                        response.BusinessEntityID.Should().Be(1);
                        response.CurrentFlag.Should().Be(true);
                        response.Gender.Should().Be("A");
                        response.HireDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
                        response.JobTitle.Should().Be("A");
                        response.LoginID.Should().Be("A");
                        response.MaritalStatus.Should().Be("A");
                        response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
                        response.NationalIDNumber.Should().Be("A");
                        response.OrganizationLevel.Should().Be(1);
                        response.Rowguid.Should().Be(Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));
                        response.SalariedFlag.Should().Be(true);
                        response.SickLeaveHours.Should().Be(1);
                        response.VacationHours.Should().Be(1);
                }

                [Fact]
                public void MapBOToModelList()
                {
                        var mapper = new BOLEmployeeMapper();

                        BOEmployee bo = new BOEmployee();

                        bo.SetProperties(1, DateTime.Parse("1/1/1987 12:00:00 AM"), true, "A", DateTime.Parse("1/1/1987 12:00:00 AM"), "A", "A", "A", DateTime.Parse("1/1/1987 12:00:00 AM"), "A", 1, Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"), true, 1, 1);
                        List<ApiEmployeeResponseModel> response = mapper.MapBOToModel(new List<BOEmployee>() { { bo } });

                        response.Count.Should().Be(1);
                }
        }
}

/*<Codenesium>
    <Hash>d9dd60ce8e3a7e3fe4a51c649af5c969</Hash>
</Codenesium>*/