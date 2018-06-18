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
        [Trait("Table", "Shift")]
        [Trait("Area", "BOLMapper")]
        public class TestBOLShiftActionMapper
        {
                [Fact]
                public void MapModelToBO()
                {
                        var mapper = new BOLShiftMapper();

                        ApiShiftRequestModel model = new ApiShiftRequestModel();

                        model.SetProperties(TimeSpan.Parse("0"), DateTime.Parse("1/1/1987 12:00:00 AM"), "A", TimeSpan.Parse("0"));
                        BOShift response = mapper.MapModelToBO(1, model);

                        response.EndTime.Should().Be(TimeSpan.Parse("0"));
                        response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
                        response.Name.Should().Be("A");
                        response.StartTime.Should().Be(TimeSpan.Parse("0"));
                }

                [Fact]
                public void MapBOToModel()
                {
                        var mapper = new BOLShiftMapper();

                        BOShift bo = new BOShift();

                        bo.SetProperties(1, TimeSpan.Parse("0"), DateTime.Parse("1/1/1987 12:00:00 AM"), "A", TimeSpan.Parse("0"));
                        ApiShiftResponseModel response = mapper.MapBOToModel(bo);

                        response.EndTime.Should().Be(TimeSpan.Parse("0"));
                        response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
                        response.Name.Should().Be("A");
                        response.ShiftID.Should().Be(1);
                        response.StartTime.Should().Be(TimeSpan.Parse("0"));
                }

                [Fact]
                public void MapBOToModelList()
                {
                        var mapper = new BOLShiftMapper();

                        BOShift bo = new BOShift();

                        bo.SetProperties(1, TimeSpan.Parse("0"), DateTime.Parse("1/1/1987 12:00:00 AM"), "A", TimeSpan.Parse("0"));
                        List<ApiShiftResponseModel> response = mapper.MapBOToModel(new List<BOShift>() { { bo } });

                        response.Count.Should().Be(1);
                }
        }
}

/*<Codenesium>
    <Hash>a4b05f5e2f47bc9f730e97ae5049cafd</Hash>
</Codenesium>*/