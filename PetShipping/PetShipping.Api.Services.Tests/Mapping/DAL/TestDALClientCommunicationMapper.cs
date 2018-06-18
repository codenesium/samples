using System;
using System.Collections.Generic;
using FluentAssertions;
using Xunit;
using PetShippingNS.Api.DataAccess;
using PetShippingNS.Api.Services;

namespace PetShippingNS.Api.Services.Tests
{
        [Trait("Type", "Unit")]
        [Trait("Table", "ClientCommunication")]
        [Trait("Area", "DALMapper")]
        public class TestDALClientCommunicationActionMapper
        {
                [Fact]
                public void MapBOToEF()
                {
                        var mapper = new DALClientCommunicationMapper();

                        var bo = new BOClientCommunication();

                        bo.SetProperties(1, 1, DateTime.Parse("1/1/1987 12:00:00 AM"), 1, "A");

                        ClientCommunication response = mapper.MapBOToEF(bo);

                        response.ClientId.Should().Be(1);
                        response.DateCreated.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
                        response.EmployeeId.Should().Be(1);
                        response.Id.Should().Be(1);
                        response.Notes.Should().Be("A");
                }

                [Fact]
                public void MapEFToBO()
                {
                        var mapper = new DALClientCommunicationMapper();

                        ClientCommunication entity = new ClientCommunication();

                        entity.SetProperties(1, DateTime.Parse("1/1/1987 12:00:00 AM"), 1, 1, "A");

                        BOClientCommunication  response = mapper.MapEFToBO(entity);

                        response.ClientId.Should().Be(1);
                        response.DateCreated.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
                        response.EmployeeId.Should().Be(1);
                        response.Id.Should().Be(1);
                        response.Notes.Should().Be("A");
                }

                [Fact]
                public void MapEFToBOList()
                {
                        var mapper = new DALClientCommunicationMapper();

                        ClientCommunication entity = new ClientCommunication();

                        entity.SetProperties(1, DateTime.Parse("1/1/1987 12:00:00 AM"), 1, 1, "A");

                        List<BOClientCommunication> response = mapper.MapEFToBO(new List<ClientCommunication>() { entity });

                        response.Count.Should().Be(1);
                }
        }
}

/*<Codenesium>
    <Hash>a4eca4ef86e151993a4393004fbb8c86</Hash>
</Codenesium>*/