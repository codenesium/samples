using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using AdventureWorksNS.Api.Services;
using FluentAssertions;
using System;
using System.Collections.Generic;
using Xunit;

namespace AdventureWorksNS.Api.Services.Tests
{
        [Trait("Type", "Unit")]
        [Trait("Table", "EmployeeDepartmentHistory")]
        [Trait("Area", "BOLMapper")]
        public class TestBOLEmployeeDepartmentHistoryMapper
        {
                [Fact]
                public void MapModelToBO()
                {
                        var mapper = new BOLEmployeeDepartmentHistoryMapper();
                        ApiEmployeeDepartmentHistoryRequestModel model = new ApiEmployeeDepartmentHistoryRequestModel();
                        model.SetProperties(1, DateTime.Parse("1/1/1987 12:00:00 AM"), DateTime.Parse("1/1/1987 12:00:00 AM"), 1, DateTime.Parse("1/1/1987 12:00:00 AM"));
                        BOEmployeeDepartmentHistory response = mapper.MapModelToBO(1, model);

                        response.DepartmentID.Should().Be(1);
                        response.EndDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
                        response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
                        response.ShiftID.Should().Be(1);
                        response.StartDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
                }

                [Fact]
                public void MapBOToModel()
                {
                        var mapper = new BOLEmployeeDepartmentHistoryMapper();
                        BOEmployeeDepartmentHistory bo = new BOEmployeeDepartmentHistory();
                        bo.SetProperties(1, 1, DateTime.Parse("1/1/1987 12:00:00 AM"), DateTime.Parse("1/1/1987 12:00:00 AM"), 1, DateTime.Parse("1/1/1987 12:00:00 AM"));
                        ApiEmployeeDepartmentHistoryResponseModel response = mapper.MapBOToModel(bo);

                        response.BusinessEntityID.Should().Be(1);
                        response.DepartmentID.Should().Be(1);
                        response.EndDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
                        response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
                        response.ShiftID.Should().Be(1);
                        response.StartDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
                }

                [Fact]
                public void MapBOToModelList()
                {
                        var mapper = new BOLEmployeeDepartmentHistoryMapper();
                        BOEmployeeDepartmentHistory bo = new BOEmployeeDepartmentHistory();
                        bo.SetProperties(1, 1, DateTime.Parse("1/1/1987 12:00:00 AM"), DateTime.Parse("1/1/1987 12:00:00 AM"), 1, DateTime.Parse("1/1/1987 12:00:00 AM"));
                        List<ApiEmployeeDepartmentHistoryResponseModel> response = mapper.MapBOToModel(new List<BOEmployeeDepartmentHistory>() { { bo } });

                        response.Count.Should().Be(1);
                }
        }
}

/*<Codenesium>
    <Hash>9be730fa6b9a47a0ea87a0e2a978e121</Hash>
</Codenesium>*/