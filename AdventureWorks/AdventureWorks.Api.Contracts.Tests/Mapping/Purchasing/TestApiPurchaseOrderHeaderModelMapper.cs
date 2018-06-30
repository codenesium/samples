using AdventureWorksNS.Api.Contracts;
using FluentAssertions;
using System;
using System.Collections.Generic;
using Xunit;

namespace AdventureWorksNS.Api.Contracts.Tests
{
        [Trait("Type", "Unit")]
        [Trait("Table", "PurchaseOrderHeader")]
        [Trait("Area", "ApiModel")]
        public class TestApiPurchaseOrderHeaderModelMapper
        {
                [Fact]
                public void MapRequestToResponse()
                {
                        var mapper = new ApiPurchaseOrderHeaderModelMapper();
                        var model = new ApiPurchaseOrderHeaderRequestModel();
                        model.SetProperties(1, 1, DateTime.Parse("1/1/1987 12:00:00 AM"), DateTime.Parse("1/1/1987 12:00:00 AM"), 1, DateTime.Parse("1/1/1987 12:00:00 AM"), 1, 1, 1, 1, 1, 1);
                        ApiPurchaseOrderHeaderResponseModel response = mapper.MapRequestToResponse(1, model);

                        response.EmployeeID.Should().Be(1);
                        response.Freight.Should().Be(1);
                        response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
                        response.OrderDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
                        response.PurchaseOrderID.Should().Be(1);
                        response.RevisionNumber.Should().Be(1);
                        response.ShipDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
                        response.ShipMethodID.Should().Be(1);
                        response.Status.Should().Be(1);
                        response.SubTotal.Should().Be(1);
                        response.TaxAmt.Should().Be(1);
                        response.TotalDue.Should().Be(1);
                        response.VendorID.Should().Be(1);
                }

                [Fact]
                public void MapResponseToRequest()
                {
                        var mapper = new ApiPurchaseOrderHeaderModelMapper();
                        var model = new ApiPurchaseOrderHeaderResponseModel();
                        model.SetProperties(1, 1, 1, DateTime.Parse("1/1/1987 12:00:00 AM"), DateTime.Parse("1/1/1987 12:00:00 AM"), 1, DateTime.Parse("1/1/1987 12:00:00 AM"), 1, 1, 1, 1, 1, 1);
                        ApiPurchaseOrderHeaderRequestModel response = mapper.MapResponseToRequest(model);

                        response.EmployeeID.Should().Be(1);
                        response.Freight.Should().Be(1);
                        response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
                        response.OrderDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
                        response.RevisionNumber.Should().Be(1);
                        response.ShipDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
                        response.ShipMethodID.Should().Be(1);
                        response.Status.Should().Be(1);
                        response.SubTotal.Should().Be(1);
                        response.TaxAmt.Should().Be(1);
                        response.TotalDue.Should().Be(1);
                        response.VendorID.Should().Be(1);
                }
        }
}

/*<Codenesium>
    <Hash>8ada3f06423abe4abdcfddd3eaf06f15</Hash>
</Codenesium>*/