using FluentAssertions;
using PetStoreNS.Api.Contracts;
using PetStoreNS.Api.DataAccess;
using PetStoreNS.Api.Services;
using System;
using System.Collections.Generic;
using Xunit;

namespace PetStoreNS.Api.Services.Tests
{
        [Trait("Type", "Unit")]
        [Trait("Table", "Sale")]
        [Trait("Area", "BOLMapper")]
        public class TestBOLSaleMapper
        {
                [Fact]
                public void MapModelToBO()
                {
                        var mapper = new BOLSaleMapper();
                        ApiSaleRequestModel model = new ApiSaleRequestModel();
                        model.SetProperties(1, "A", "A", 1, 1, "A");
                        BOSale response = mapper.MapModelToBO(1, model);

                        response.Amount.Should().Be(1);
                        response.FirstName.Should().Be("A");
                        response.LastName.Should().Be("A");
                        response.PaymentTypeId.Should().Be(1);
                        response.PetId.Should().Be(1);
                        response.Phone.Should().Be("A");
                }

                [Fact]
                public void MapBOToModel()
                {
                        var mapper = new BOLSaleMapper();
                        BOSale bo = new BOSale();
                        bo.SetProperties(1, 1, "A", "A", 1, 1, "A");
                        ApiSaleResponseModel response = mapper.MapBOToModel(bo);

                        response.Amount.Should().Be(1);
                        response.FirstName.Should().Be("A");
                        response.Id.Should().Be(1);
                        response.LastName.Should().Be("A");
                        response.PaymentTypeId.Should().Be(1);
                        response.PetId.Should().Be(1);
                        response.Phone.Should().Be("A");
                }

                [Fact]
                public void MapBOToModelList()
                {
                        var mapper = new BOLSaleMapper();
                        BOSale bo = new BOSale();
                        bo.SetProperties(1, 1, "A", "A", 1, 1, "A");
                        List<ApiSaleResponseModel> response = mapper.MapBOToModel(new List<BOSale>() { { bo } });

                        response.Count.Should().Be(1);
                }
        }
}

/*<Codenesium>
    <Hash>1e1d5ee903dacac29ef013c03ddc5006</Hash>
</Codenesium>*/