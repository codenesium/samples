using System;
using System.Collections.Generic;
using FluentAssertions;
using Xunit;
using TicketingCRMNS.Api.DataAccess;
using TicketingCRMNS.Api.Services;

namespace TicketingCRMNS.Api.Services.Tests
{
        [Trait("Type", "Unit")]
        [Trait("Table", "Customer")]
        [Trait("Area", "DALMapper")]
        public class TestDALCustomerActionMapper
        {
                [Fact]
                public void MapBOToEF()
                {
                        var mapper = new DALCustomerMapper();

                        var bo = new BOCustomer();

                        bo.SetProperties(1, "A", "A", "A", "A");

                        Customer response = mapper.MapBOToEF(bo);

                        response.Email.Should().Be("A");
                        response.FirstName.Should().Be("A");
                        response.Id.Should().Be(1);
                        response.LastName.Should().Be("A");
                        response.Phone.Should().Be("A");
                }

                [Fact]
                public void MapEFToBO()
                {
                        var mapper = new DALCustomerMapper();

                        Customer entity = new Customer();

                        entity.SetProperties("A", "A", 1, "A", "A");

                        BOCustomer  response = mapper.MapEFToBO(entity);

                        response.Email.Should().Be("A");
                        response.FirstName.Should().Be("A");
                        response.Id.Should().Be(1);
                        response.LastName.Should().Be("A");
                        response.Phone.Should().Be("A");
                }

                [Fact]
                public void MapEFToBOList()
                {
                        var mapper = new DALCustomerMapper();

                        Customer entity = new Customer();

                        entity.SetProperties("A", "A", 1, "A", "A");

                        List<BOCustomer> response = mapper.MapEFToBO(new List<Customer>() { entity });

                        response.Count.Should().Be(1);
                }
        }
}

/*<Codenesium>
    <Hash>a2b643c388be7815d6176356d3374cf2</Hash>
</Codenesium>*/