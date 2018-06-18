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
        [Trait("Table", "CountryRegion")]
        [Trait("Area", "BOLMapper")]
        public class TestBOLCountryRegionActionMapper
        {
                [Fact]
                public void MapModelToBO()
                {
                        var mapper = new BOLCountryRegionMapper();

                        ApiCountryRegionRequestModel model = new ApiCountryRegionRequestModel();

                        model.SetProperties(DateTime.Parse("1/1/1987 12:00:00 AM"), "A");
                        BOCountryRegion response = mapper.MapModelToBO("A", model);

                        response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
                        response.Name.Should().Be("A");
                }

                [Fact]
                public void MapBOToModel()
                {
                        var mapper = new BOLCountryRegionMapper();

                        BOCountryRegion bo = new BOCountryRegion();

                        bo.SetProperties("A", DateTime.Parse("1/1/1987 12:00:00 AM"), "A");
                        ApiCountryRegionResponseModel response = mapper.MapBOToModel(bo);

                        response.CountryRegionCode.Should().Be("A");
                        response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
                        response.Name.Should().Be("A");
                }

                [Fact]
                public void MapBOToModelList()
                {
                        var mapper = new BOLCountryRegionMapper();

                        BOCountryRegion bo = new BOCountryRegion();

                        bo.SetProperties("A", DateTime.Parse("1/1/1987 12:00:00 AM"), "A");
                        List<ApiCountryRegionResponseModel> response = mapper.MapBOToModel(new List<BOCountryRegion>() { { bo } });

                        response.Count.Should().Be(1);
                }
        }
}

/*<Codenesium>
    <Hash>1bbbb954257dffb36cabb8ad1f14e7ea</Hash>
</Codenesium>*/