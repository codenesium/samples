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
        [Trait("Table", "PersonCreditCard")]
        [Trait("Area", "BOLMapper")]
        public class TestBOLPersonCreditCardMapper
        {
                [Fact]
                public void MapModelToBO()
                {
                        var mapper = new BOLPersonCreditCardMapper();
                        ApiPersonCreditCardRequestModel model = new ApiPersonCreditCardRequestModel();
                        model.SetProperties(1, DateTime.Parse("1/1/1987 12:00:00 AM"));
                        BOPersonCreditCard response = mapper.MapModelToBO(1, model);

                        response.CreditCardID.Should().Be(1);
                        response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
                }

                [Fact]
                public void MapBOToModel()
                {
                        var mapper = new BOLPersonCreditCardMapper();
                        BOPersonCreditCard bo = new BOPersonCreditCard();
                        bo.SetProperties(1, 1, DateTime.Parse("1/1/1987 12:00:00 AM"));
                        ApiPersonCreditCardResponseModel response = mapper.MapBOToModel(bo);

                        response.BusinessEntityID.Should().Be(1);
                        response.CreditCardID.Should().Be(1);
                        response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
                }

                [Fact]
                public void MapBOToModelList()
                {
                        var mapper = new BOLPersonCreditCardMapper();
                        BOPersonCreditCard bo = new BOPersonCreditCard();
                        bo.SetProperties(1, 1, DateTime.Parse("1/1/1987 12:00:00 AM"));
                        List<ApiPersonCreditCardResponseModel> response = mapper.MapBOToModel(new List<BOPersonCreditCard>() { { bo } });

                        response.Count.Should().Be(1);
                }
        }
}

/*<Codenesium>
    <Hash>0e2702cdedc23f64b8baa2f2eefe5f41</Hash>
</Codenesium>*/