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
        [Trait("Table", "EmployeePayHistory")]
        [Trait("Area", "BOLMapper")]
        public class TestBOLEmployeePayHistoryActionMapper
        {
                [Fact]
                public void MapModelToBO()
                {
                        var mapper = new BOLEmployeePayHistoryMapper();

                        ApiEmployeePayHistoryRequestModel model = new ApiEmployeePayHistoryRequestModel();

                        model.SetProperties(DateTime.Parse("1/1/1987 12:00:00 AM"), 1, 1, DateTime.Parse("1/1/1987 12:00:00 AM"));
                        BOEmployeePayHistory response = mapper.MapModelToBO(1, model);

                        response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
                        response.PayFrequency.Should().Be(1);
                        response.Rate.Should().Be(1);
                        response.RateChangeDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
                }

                [Fact]
                public void MapBOToModel()
                {
                        var mapper = new BOLEmployeePayHistoryMapper();

                        BOEmployeePayHistory bo = new BOEmployeePayHistory();

                        bo.SetProperties(1, DateTime.Parse("1/1/1987 12:00:00 AM"), 1, 1, DateTime.Parse("1/1/1987 12:00:00 AM"));
                        ApiEmployeePayHistoryResponseModel response = mapper.MapBOToModel(bo);

                        response.BusinessEntityID.Should().Be(1);
                        response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
                        response.PayFrequency.Should().Be(1);
                        response.Rate.Should().Be(1);
                        response.RateChangeDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
                }

                [Fact]
                public void MapBOToModelList()
                {
                        var mapper = new BOLEmployeePayHistoryMapper();

                        BOEmployeePayHistory bo = new BOEmployeePayHistory();

                        bo.SetProperties(1, DateTime.Parse("1/1/1987 12:00:00 AM"), 1, 1, DateTime.Parse("1/1/1987 12:00:00 AM"));
                        List<ApiEmployeePayHistoryResponseModel> response = mapper.MapBOToModel(new List<BOEmployeePayHistory>() { { bo } });

                        response.Count.Should().Be(1);
                }
        }
}

/*<Codenesium>
    <Hash>2cb38ffad20585e4d5bb205eacf28e3e</Hash>
</Codenesium>*/