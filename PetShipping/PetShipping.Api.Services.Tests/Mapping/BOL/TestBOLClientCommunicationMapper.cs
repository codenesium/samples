using FluentAssertions;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
using PetShippingNS.Api.Services;
using System;
using System.Collections.Generic;
using Xunit;

namespace PetShippingNS.Api.Services.Tests
{
        [Trait("Type", "Unit")]
        [Trait("Table", "ClientCommunication")]
        [Trait("Area", "BOLMapper")]
        public class TestBOLClientCommunicationMapper
        {
                [Fact]
                public void MapModelToBO()
                {
                        var mapper = new BOLClientCommunicationMapper();
                        ApiClientCommunicationRequestModel model = new ApiClientCommunicationRequestModel();
                        model.SetProperties(1, DateTime.Parse("1/1/1987 12:00:00 AM"), 1, "A");
                        BOClientCommunication response = mapper.MapModelToBO(1, model);

                        response.ClientId.Should().Be(1);
                        response.DateCreated.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
                        response.EmployeeId.Should().Be(1);
                        response.Notes.Should().Be("A");
                }

                [Fact]
                public void MapBOToModel()
                {
                        var mapper = new BOLClientCommunicationMapper();
                        BOClientCommunication bo = new BOClientCommunication();
                        bo.SetProperties(1, 1, DateTime.Parse("1/1/1987 12:00:00 AM"), 1, "A");
                        ApiClientCommunicationResponseModel response = mapper.MapBOToModel(bo);

                        response.ClientId.Should().Be(1);
                        response.DateCreated.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
                        response.EmployeeId.Should().Be(1);
                        response.Id.Should().Be(1);
                        response.Notes.Should().Be("A");
                }

                [Fact]
                public void MapBOToModelList()
                {
                        var mapper = new BOLClientCommunicationMapper();
                        BOClientCommunication bo = new BOClientCommunication();
                        bo.SetProperties(1, 1, DateTime.Parse("1/1/1987 12:00:00 AM"), 1, "A");
                        List<ApiClientCommunicationResponseModel> response = mapper.MapBOToModel(new List<BOClientCommunication>() { { bo } });

                        response.Count.Should().Be(1);
                }
        }
}

/*<Codenesium>
    <Hash>21bb5d71e4d40a9c743bfffa7d456083</Hash>
</Codenesium>*/