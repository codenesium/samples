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
        [Trait("Table", "Customer")]
        [Trait("Area", "BOLMapper")]
        public class TestBOLCustomerActionMapper
        {
                [Fact]
                public void MapModelToBO()
                {
                        var mapper = new BOLCustomerMapper();

                        ApiCustomerRequestModel model = new ApiCustomerRequestModel();

                        model.SetProperties("A", DateTime.Parse("1/1/1987 12:00:00 AM"), 1, Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"), 1, 1);
                        BOCustomer response = mapper.MapModelToBO(1, model);

                        response.AccountNumber.Should().Be("A");
                        response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
                        response.PersonID.Should().Be(1);
                        response.Rowguid.Should().Be(Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));
                        response.StoreID.Should().Be(1);
                        response.TerritoryID.Should().Be(1);
                }

                [Fact]
                public void MapBOToModel()
                {
                        var mapper = new BOLCustomerMapper();

                        BOCustomer bo = new BOCustomer();

                        bo.SetProperties(1, "A", DateTime.Parse("1/1/1987 12:00:00 AM"), 1, Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"), 1, 1);
                        ApiCustomerResponseModel response = mapper.MapBOToModel(bo);

                        response.AccountNumber.Should().Be("A");
                        response.CustomerID.Should().Be(1);
                        response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
                        response.PersonID.Should().Be(1);
                        response.Rowguid.Should().Be(Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));
                        response.StoreID.Should().Be(1);
                        response.TerritoryID.Should().Be(1);
                }

                [Fact]
                public void MapBOToModelList()
                {
                        var mapper = new BOLCustomerMapper();

                        BOCustomer bo = new BOCustomer();

                        bo.SetProperties(1, "A", DateTime.Parse("1/1/1987 12:00:00 AM"), 1, Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"), 1, 1);
                        List<ApiCustomerResponseModel> response = mapper.MapBOToModel(new List<BOCustomer>() { { bo } });

                        response.Count.Should().Be(1);
                }
        }
}

/*<Codenesium>
    <Hash>5feeb31f758197000eb0a99dd67f35a8</Hash>
</Codenesium>*/