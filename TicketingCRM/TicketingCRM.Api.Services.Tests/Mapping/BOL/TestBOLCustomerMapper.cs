using System;
using System.Collections.Generic;
using FluentAssertions;
using Xunit;
using TicketingCRMNS.Api.Contracts;
using TicketingCRMNS.Api.DataAccess;
using TicketingCRMNS.Api.Services;

namespace TicketingCRMNS.Api.Services.Tests
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

                        model.SetProperties("A", "A", "A", "A");
                        BOCustomer response = mapper.MapModelToBO(1, model);

                        response.Email.Should().Be("A");
                        response.FirstName.Should().Be("A");
                        response.LastName.Should().Be("A");
                        response.Phone.Should().Be("A");
                }

                [Fact]
                public void MapBOToModel()
                {
                        var mapper = new BOLCustomerMapper();

                        BOCustomer bo = new BOCustomer();

                        bo.SetProperties(1, "A", "A", "A", "A");
                        ApiCustomerResponseModel response = mapper.MapBOToModel(bo);

                        response.Email.Should().Be("A");
                        response.FirstName.Should().Be("A");
                        response.Id.Should().Be(1);
                        response.LastName.Should().Be("A");
                        response.Phone.Should().Be("A");
                }

                [Fact]
                public void MapBOToModelList()
                {
                        var mapper = new BOLCustomerMapper();

                        BOCustomer bo = new BOCustomer();

                        bo.SetProperties(1, "A", "A", "A", "A");
                        List<ApiCustomerResponseModel> response = mapper.MapBOToModel(new List<BOCustomer>() { { bo } });

                        response.Count.Should().Be(1);
                }
        }
}

/*<Codenesium>
    <Hash>7ed80c79c3e3057efb8faf73d8de99af</Hash>
</Codenesium>*/