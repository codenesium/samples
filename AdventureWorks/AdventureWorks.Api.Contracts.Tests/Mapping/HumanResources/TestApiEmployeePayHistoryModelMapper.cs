using AdventureWorksNS.Api.Contracts;
using FluentAssertions;
using System;
using System.Collections.Generic;
using Xunit;

namespace AdventureWorksNS.Api.Contracts.Tests
{
        [Trait("Type", "Unit")]
        [Trait("Table", "EmployeePayHistory")]
        [Trait("Area", "ApiModel")]
        public class TestApiEmployeePayHistoryModelMapper
        {
                [Fact]
                public void MapRequestToResponse()
                {
                        var mapper = new ApiEmployeePayHistoryModelMapper();
                        var model = new ApiEmployeePayHistoryRequestModel();
                        model.SetProperties(DateTime.Parse("1/1/1987 12:00:00 AM"), 1, 1, DateTime.Parse("1/1/1987 12:00:00 AM"));
                        ApiEmployeePayHistoryResponseModel response = mapper.MapRequestToResponse(1, model);

                        response.BusinessEntityID.Should().Be(1);
                        response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
                        response.PayFrequency.Should().Be(1);
                        response.Rate.Should().Be(1);
                        response.RateChangeDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
                }

                [Fact]
                public void MapResponseToRequest()
                {
                        var mapper = new ApiEmployeePayHistoryModelMapper();
                        var model = new ApiEmployeePayHistoryResponseModel();
                        model.SetProperties(1, DateTime.Parse("1/1/1987 12:00:00 AM"), 1, 1, DateTime.Parse("1/1/1987 12:00:00 AM"));
                        ApiEmployeePayHistoryRequestModel response = mapper.MapResponseToRequest(model);

                        response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
                        response.PayFrequency.Should().Be(1);
                        response.Rate.Should().Be(1);
                        response.RateChangeDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
                }
        }
}

/*<Codenesium>
    <Hash>ccb8ff2eb031da08341bad38e289d170</Hash>
</Codenesium>*/