using AdventureWorksNS.Api.Contracts;
using FluentAssertions;
using System;
using System.Collections.Generic;
using Xunit;

namespace AdventureWorksNS.Api.Contracts.Tests
{
        [Trait("Type", "Unit")]
        [Trait("Table", "ProductVendor")]
        [Trait("Area", "ApiModel")]
        public class TestApiProductVendorModelMapper
        {
                [Fact]
                public void MapRequestToResponse()
                {
                        var mapper = new ApiProductVendorModelMapper();
                        var model = new ApiProductVendorRequestModel();
                        model.SetProperties(1, 1, 1, DateTime.Parse("1/1/1987 12:00:00 AM"), 1, 1, DateTime.Parse("1/1/1987 12:00:00 AM"), 1, 1, "A");
                        ApiProductVendorResponseModel response = mapper.MapRequestToResponse(1, model);

                        response.AverageLeadTime.Should().Be(1);
                        response.BusinessEntityID.Should().Be(1);
                        response.LastReceiptCost.Should().Be(1);
                        response.LastReceiptDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
                        response.MaxOrderQty.Should().Be(1);
                        response.MinOrderQty.Should().Be(1);
                        response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
                        response.OnOrderQty.Should().Be(1);
                        response.ProductID.Should().Be(1);
                        response.StandardPrice.Should().Be(1);
                        response.UnitMeasureCode.Should().Be("A");
                }

                [Fact]
                public void MapResponseToRequest()
                {
                        var mapper = new ApiProductVendorModelMapper();
                        var model = new ApiProductVendorResponseModel();
                        model.SetProperties(1, 1, 1, 1, DateTime.Parse("1/1/1987 12:00:00 AM"), 1, 1, DateTime.Parse("1/1/1987 12:00:00 AM"), 1, 1, "A");
                        ApiProductVendorRequestModel response = mapper.MapResponseToRequest(model);

                        response.AverageLeadTime.Should().Be(1);
                        response.BusinessEntityID.Should().Be(1);
                        response.LastReceiptCost.Should().Be(1);
                        response.LastReceiptDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
                        response.MaxOrderQty.Should().Be(1);
                        response.MinOrderQty.Should().Be(1);
                        response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
                        response.OnOrderQty.Should().Be(1);
                        response.StandardPrice.Should().Be(1);
                        response.UnitMeasureCode.Should().Be("A");
                }
        }
}

/*<Codenesium>
    <Hash>8749abc9950b25c7d43a4a926336bdb2</Hash>
</Codenesium>*/