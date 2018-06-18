using System;
using System.Collections.Generic;
using FluentAssertions;
using Xunit;
using PetStoreNS.Api.DataAccess;
using PetStoreNS.Api.Services;

namespace PetStoreNS.Api.Services.Tests
{
        [Trait("Type", "Unit")]
        [Trait("Table", "PaymentType")]
        [Trait("Area", "DALMapper")]
        public class TestDALPaymentTypeActionMapper
        {
                [Fact]
                public void MapBOToEF()
                {
                        var mapper = new DALPaymentTypeMapper();

                        var bo = new BOPaymentType();

                        bo.SetProperties(1, "A");

                        PaymentType response = mapper.MapBOToEF(bo);

                        response.Id.Should().Be(1);
                        response.Name.Should().Be("A");
                }

                [Fact]
                public void MapEFToBO()
                {
                        var mapper = new DALPaymentTypeMapper();

                        PaymentType entity = new PaymentType();

                        entity.SetProperties(1, "A");

                        BOPaymentType  response = mapper.MapEFToBO(entity);

                        response.Id.Should().Be(1);
                        response.Name.Should().Be("A");
                }

                [Fact]
                public void MapEFToBOList()
                {
                        var mapper = new DALPaymentTypeMapper();

                        PaymentType entity = new PaymentType();

                        entity.SetProperties(1, "A");

                        List<BOPaymentType> response = mapper.MapEFToBO(new List<PaymentType>() { entity });

                        response.Count.Should().Be(1);
                }
        }
}

/*<Codenesium>
    <Hash>3ad302b2732aae80bf2b126a6299cab6</Hash>
</Codenesium>*/