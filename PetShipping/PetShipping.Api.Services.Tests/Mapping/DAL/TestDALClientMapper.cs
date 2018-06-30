using FluentAssertions;
using PetShippingNS.Api.DataAccess;
using PetShippingNS.Api.Services;
using System;
using System.Collections.Generic;
using Xunit;

namespace PetShippingNS.Api.Services.Tests
{
        [Trait("Type", "Unit")]
        [Trait("Table", "Client")]
        [Trait("Area", "DALMapper")]
        public class TestDALClientMapper
        {
                [Fact]
                public void MapBOToEF()
                {
                        var mapper = new DALClientMapper();
                        var bo = new BOClient();
                        bo.SetProperties(1, "A", "A", "A", "A", "A");

                        Client response = mapper.MapBOToEF(bo);

                        response.Email.Should().Be("A");
                        response.FirstName.Should().Be("A");
                        response.Id.Should().Be(1);
                        response.LastName.Should().Be("A");
                        response.Notes.Should().Be("A");
                        response.Phone.Should().Be("A");
                }

                [Fact]
                public void MapEFToBO()
                {
                        var mapper = new DALClientMapper();
                        Client entity = new Client();
                        entity.SetProperties("A", "A", 1, "A", "A", "A");

                        BOClient response = mapper.MapEFToBO(entity);

                        response.Email.Should().Be("A");
                        response.FirstName.Should().Be("A");
                        response.Id.Should().Be(1);
                        response.LastName.Should().Be("A");
                        response.Notes.Should().Be("A");
                        response.Phone.Should().Be("A");
                }

                [Fact]
                public void MapEFToBOList()
                {
                        var mapper = new DALClientMapper();
                        Client entity = new Client();
                        entity.SetProperties("A", "A", 1, "A", "A", "A");

                        List<BOClient> response = mapper.MapEFToBO(new List<Client>() { entity });

                        response.Count.Should().Be(1);
                }
        }
}

/*<Codenesium>
    <Hash>d96356105093614453b53cf74f0eadd1</Hash>
</Codenesium>*/