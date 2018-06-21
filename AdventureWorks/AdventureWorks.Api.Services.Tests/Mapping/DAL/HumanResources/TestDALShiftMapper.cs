using AdventureWorksNS.Api.DataAccess;
using AdventureWorksNS.Api.Services;
using FluentAssertions;
using System;
using System.Collections.Generic;
using Xunit;

namespace AdventureWorksNS.Api.Services.Tests
{
        [Trait("Type", "Unit")]
        [Trait("Table", "Shift")]
        [Trait("Area", "DALMapper")]
        public class TestDALShiftMapper
        {
                [Fact]
                public void MapBOToEF()
                {
                        var mapper = new DALShiftMapper();
                        var bo = new BOShift();
                        bo.SetProperties(1, TimeSpan.Parse("0"), DateTime.Parse("1/1/1987 12:00:00 AM"), "A", TimeSpan.Parse("0"));

                        Shift response = mapper.MapBOToEF(bo);

                        response.EndTime.Should().Be(TimeSpan.Parse("0"));
                        response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
                        response.Name.Should().Be("A");
                        response.ShiftID.Should().Be(1);
                        response.StartTime.Should().Be(TimeSpan.Parse("0"));
                }

                [Fact]
                public void MapEFToBO()
                {
                        var mapper = new DALShiftMapper();
                        Shift entity = new Shift();
                        entity.SetProperties(TimeSpan.Parse("0"), DateTime.Parse("1/1/1987 12:00:00 AM"), "A", 1, TimeSpan.Parse("0"));

                        BOShift response = mapper.MapEFToBO(entity);

                        response.EndTime.Should().Be(TimeSpan.Parse("0"));
                        response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
                        response.Name.Should().Be("A");
                        response.ShiftID.Should().Be(1);
                        response.StartTime.Should().Be(TimeSpan.Parse("0"));
                }

                [Fact]
                public void MapEFToBOList()
                {
                        var mapper = new DALShiftMapper();
                        Shift entity = new Shift();
                        entity.SetProperties(TimeSpan.Parse("0"), DateTime.Parse("1/1/1987 12:00:00 AM"), "A", 1, TimeSpan.Parse("0"));

                        List<BOShift> response = mapper.MapEFToBO(new List<Shift>() { entity });

                        response.Count.Should().Be(1);
                }
        }
}

/*<Codenesium>
    <Hash>cac7c92447185d26f75d284ccd858476</Hash>
</Codenesium>*/