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
        [Trait("Table", "Vendor")]
        [Trait("Area", "BOLMapper")]
        public class TestBOLVendorMapper
        {
                [Fact]
                public void MapModelToBO()
                {
                        var mapper = new BOLVendorMapper();
                        ApiVendorRequestModel model = new ApiVendorRequestModel();
                        model.SetProperties("A", true, 1, DateTime.Parse("1/1/1987 12:00:00 AM"), "A", true, "A");
                        BOVendor response = mapper.MapModelToBO(1, model);

                        response.AccountNumber.Should().Be("A");
                        response.ActiveFlag.Should().Be(true);
                        response.CreditRating.Should().Be(1);
                        response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
                        response.Name.Should().Be("A");
                        response.PreferredVendorStatus.Should().Be(true);
                        response.PurchasingWebServiceURL.Should().Be("A");
                }

                [Fact]
                public void MapBOToModel()
                {
                        var mapper = new BOLVendorMapper();
                        BOVendor bo = new BOVendor();
                        bo.SetProperties(1, "A", true, 1, DateTime.Parse("1/1/1987 12:00:00 AM"), "A", true, "A");
                        ApiVendorResponseModel response = mapper.MapBOToModel(bo);

                        response.AccountNumber.Should().Be("A");
                        response.ActiveFlag.Should().Be(true);
                        response.BusinessEntityID.Should().Be(1);
                        response.CreditRating.Should().Be(1);
                        response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
                        response.Name.Should().Be("A");
                        response.PreferredVendorStatus.Should().Be(true);
                        response.PurchasingWebServiceURL.Should().Be("A");
                }

                [Fact]
                public void MapBOToModelList()
                {
                        var mapper = new BOLVendorMapper();
                        BOVendor bo = new BOVendor();
                        bo.SetProperties(1, "A", true, 1, DateTime.Parse("1/1/1987 12:00:00 AM"), "A", true, "A");
                        List<ApiVendorResponseModel> response = mapper.MapBOToModel(new List<BOVendor>() { { bo } });

                        response.Count.Should().Be(1);
                }
        }
}

/*<Codenesium>
    <Hash>5e6e96fd799e68f0848fd3fc178a46c7</Hash>
</Codenesium>*/