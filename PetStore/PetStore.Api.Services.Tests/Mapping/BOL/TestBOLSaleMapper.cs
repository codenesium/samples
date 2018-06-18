using System;
using System.Collections.Generic;
using FluentAssertions;
using Xunit;
using PetStoreNS.Api.Contracts;
using PetStoreNS.Api.DataAccess;
using PetStoreNS.Api.Services;

namespace PetStoreNS.Api.Services.Tests
{
        [Trait("Type", "Unit")]
        [Trait("Table", "Sale")]
        [Trait("Area", "BOLMapper")]
        public class TestBOLSaleActionMapper
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
    <Hash>940316b13ceb6d409d91c99d73c3fdd4</Hash>
</Codenesium>*/