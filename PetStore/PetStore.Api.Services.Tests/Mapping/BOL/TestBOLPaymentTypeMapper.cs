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
        [Trait("Table", "PaymentType")]
        [Trait("Area", "BOLMapper")]
        public class TestBOLPaymentTypeActionMapper
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
    <Hash>94a4366f0f3d724dda9f3cb677efe5f5</Hash>
</Codenesium>*/