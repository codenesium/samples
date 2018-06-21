using AdventureWorksNS.Api.DataAccess;
using AdventureWorksNS.Api.Services;
using FluentAssertions;
using System;
using System.Collections.Generic;
using Xunit;

namespace AdventureWorksNS.Api.Services.Tests
{
        [Trait("Type", "Unit")]
        [Trait("Table", "EmployeePayHistory")]
        [Trait("Area", "DALMapper")]
        public class TestDALEmployeePayHistoryMapper
        {
                [Fact]
                public void MapBOToEF()
                {
                        var mapper = new DALEmployeePayHistoryMapper();
                        var bo = new BOEmployeePayHistory();
                        bo.SetProperties(1, DateTime.Parse("1/1/1987 12:00:00 AM"), 1, 1, DateTime.Parse("1/1/1987 12:00:00 AM"));

                        EmployeePayHistory response = mapper.MapBOToEF(bo);

                        response.BusinessEntityID.Should().Be(1);
                        response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
                        response.PayFrequency.Should().Be(1);
                        response.Rate.Should().Be(1);
                        response.RateChangeDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
                }

                [Fact]
                public void MapEFToBO()
                {
                        var mapper = new DALEmployeePayHistoryMapper();
                        EmployeePayHistory entity = new EmployeePayHistory();
                        entity.SetProperties(1, DateTime.Parse("1/1/1987 12:00:00 AM"), 1, 1, DateTime.Parse("1/1/1987 12:00:00 AM"));

                        BOEmployeePayHistory response = mapper.MapEFToBO(entity);

                        response.BusinessEntityID.Should().Be(1);
                        response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
                        response.PayFrequency.Should().Be(1);
                        response.Rate.Should().Be(1);
                        response.RateChangeDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
                }

                [Fact]
                public void MapEFToBOList()
                {
                        var mapper = new DALEmployeePayHistoryMapper();
                        EmployeePayHistory entity = new EmployeePayHistory();
                        entity.SetProperties(1, DateTime.Parse("1/1/1987 12:00:00 AM"), 1, 1, DateTime.Parse("1/1/1987 12:00:00 AM"));

                        List<BOEmployeePayHistory> response = mapper.MapEFToBO(new List<EmployeePayHistory>() { entity });

                        response.Count.Should().Be(1);
                }
        }
}

/*<Codenesium>
    <Hash>9b30b74c7a96e311c55230dd3938e1a5</Hash>
</Codenesium>*/