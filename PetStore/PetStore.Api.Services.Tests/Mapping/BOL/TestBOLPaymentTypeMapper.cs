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
        [Trait("Table", "PaymentType")]
        [Trait("Area", "BOLMapper")]
        public class TestBOLPaymentTypeMapper
        {
                [Fact]
                public void MapModelToBO()
                {
                        var mapper = new BOLPaymentTypeMapper();
                        ApiPaymentTypeRequestModel model = new ApiPaymentTypeRequestModel();
                        model.SetProperties("A");
                        BOPaymentType response = mapper.MapModelToBO(1, model);

                        response.Name.Should().Be("A");
                }

                [Fact]
                public void MapBOToModel()
                {
                        var mapper = new BOLPaymentTypeMapper();
                        BOPaymentType bo = new BOPaymentType();
                        bo.SetProperties(1, "A");
                        ApiPaymentTypeResponseModel response = mapper.MapBOToModel(bo);

                        response.Id.Should().Be(1);
                        response.Name.Should().Be("A");
                }

                [Fact]
                public void MapBOToModelList()
                {
                        var mapper = new BOLPaymentTypeMapper();
                        BOPaymentType bo = new BOPaymentType();
                        bo.SetProperties(1, "A");
                        List<ApiPaymentTypeResponseModel> response = mapper.MapBOToModel(new List<BOPaymentType>() { { bo } });

                        response.Count.Should().Be(1);
                }
        }
}

/*<Codenesium>
    <Hash>2b1320d6c41b0433f3e89678b390ae21</Hash>
</Codenesium>*/