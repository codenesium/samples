using AdventureWorksNS.Api.Contracts;
using FluentAssertions;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using Xunit;

namespace AdventureWorksNS.Api.Contracts.Tests
{
        [Trait("Type", "Unit")]
        [Trait("Table", "SalesPersonQuotaHistory")]
        [Trait("Area", "ApiModel")]
        public class TestApiSalesPersonQuotaHistoryModelMapper
        {
                [Fact]
                public void MapRequestToResponse()
                {
                        var mapper = new ApiSalesPersonQuotaHistoryModelMapper();
                        var model = new ApiSalesPersonQuotaHistoryRequestModel();
                        model.SetProperties(DateTime.Parse("1/1/1987 12:00:00 AM"), DateTime.Parse("1/1/1987 12:00:00 AM"), Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"), 1m);
                        ApiSalesPersonQuotaHistoryResponseModel response = mapper.MapRequestToResponse(1, model);

                        response.BusinessEntityID.Should().Be(1);
                        response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
                        response.QuotaDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
                        response.Rowguid.Should().Be(Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));
                        response.SalesQuota.Should().Be(1m);
                }

                [Fact]
                public void MapResponseToRequest()
                {
                        var mapper = new ApiSalesPersonQuotaHistoryModelMapper();
                        var model = new ApiSalesPersonQuotaHistoryResponseModel();
                        model.SetProperties(1, DateTime.Parse("1/1/1987 12:00:00 AM"), DateTime.Parse("1/1/1987 12:00:00 AM"), Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"), 1m);
                        ApiSalesPersonQuotaHistoryRequestModel response = mapper.MapResponseToRequest(model);

                        response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
                        response.QuotaDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
                        response.Rowguid.Should().Be(Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));
                        response.SalesQuota.Should().Be(1m);
                }

                [Fact]
                public void CreatePatch()
                {
                        var mapper = new ApiSalesPersonQuotaHistoryModelMapper();
                        var model = new ApiSalesPersonQuotaHistoryRequestModel();
                        model.SetProperties(DateTime.Parse("1/1/1987 12:00:00 AM"), DateTime.Parse("1/1/1987 12:00:00 AM"), Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"), 1m);

                        JsonPatchDocument<ApiSalesPersonQuotaHistoryRequestModel> patch = mapper.CreatePatch(model);
                        var response = new ApiSalesPersonQuotaHistoryRequestModel();
                        patch.ApplyTo(response);

                        response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
                        response.QuotaDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
                        response.Rowguid.Should().Be(Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));
                        response.SalesQuota.Should().Be(1m);
                }
        }
}

/*<Codenesium>
    <Hash>1db406257bd48295cd4f40dcf1accb18</Hash>
</Codenesium>*/