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
        [Trait("Table", "SalesPersonQuotaHistory")]
        [Trait("Area", "BOLMapper")]
        public class TestBOLSalesPersonQuotaHistoryMapper
        {
                [Fact]
                public void MapModelToBO()
                {
                        var mapper = new BOLSalesPersonQuotaHistoryMapper();
                        ApiSalesPersonQuotaHistoryRequestModel model = new ApiSalesPersonQuotaHistoryRequestModel();
                        model.SetProperties(DateTime.Parse("1/1/1987 12:00:00 AM"), DateTime.Parse("1/1/1987 12:00:00 AM"), Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"), 1m);
                        BOSalesPersonQuotaHistory response = mapper.MapModelToBO(1, model);

                        response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
                        response.QuotaDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
                        response.Rowguid.Should().Be(Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));
                        response.SalesQuota.Should().Be(1m);
                }

                [Fact]
                public void MapBOToModel()
                {
                        var mapper = new BOLSalesPersonQuotaHistoryMapper();
                        BOSalesPersonQuotaHistory bo = new BOSalesPersonQuotaHistory();
                        bo.SetProperties(1, DateTime.Parse("1/1/1987 12:00:00 AM"), DateTime.Parse("1/1/1987 12:00:00 AM"), Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"), 1m);
                        ApiSalesPersonQuotaHistoryResponseModel response = mapper.MapBOToModel(bo);

                        response.BusinessEntityID.Should().Be(1);
                        response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
                        response.QuotaDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
                        response.Rowguid.Should().Be(Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));
                        response.SalesQuota.Should().Be(1m);
                }

                [Fact]
                public void MapBOToModelList()
                {
                        var mapper = new BOLSalesPersonQuotaHistoryMapper();
                        BOSalesPersonQuotaHistory bo = new BOSalesPersonQuotaHistory();
                        bo.SetProperties(1, DateTime.Parse("1/1/1987 12:00:00 AM"), DateTime.Parse("1/1/1987 12:00:00 AM"), Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"), 1m);
                        List<ApiSalesPersonQuotaHistoryResponseModel> response = mapper.MapBOToModel(new List<BOSalesPersonQuotaHistory>() { { bo } });

                        response.Count.Should().Be(1);
                }
        }
}

/*<Codenesium>
    <Hash>a76b02ec2e93e2939af98146089d778a</Hash>
</Codenesium>*/