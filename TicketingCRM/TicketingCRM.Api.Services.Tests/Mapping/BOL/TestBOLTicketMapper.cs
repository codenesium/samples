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
        [Trait("Table", "Ticket")]
        [Trait("Area", "BOLMapper")]
        public class TestBOLTicketActionMapper
        {
                [Fact]
                public void MapModelToBO()
                {
                        var mapper = new BOLTicketMapper();

                        ApiTicketRequestModel model = new ApiTicketRequestModel();

                        model.SetProperties("A", 1);
                        BOTicket response = mapper.MapModelToBO(1, model);

                        response.PublicId.Should().Be("A");
                        response.TicketStatusId.Should().Be(1);
                }

                [Fact]
                public void MapBOToModel()
                {
                        var mapper = new BOLTicketMapper();

                        BOTicket bo = new BOTicket();

                        bo.SetProperties(1, "A", 1);
                        ApiTicketResponseModel response = mapper.MapBOToModel(bo);

                        response.Id.Should().Be(1);
                        response.PublicId.Should().Be("A");
                        response.TicketStatusId.Should().Be(1);
                }

                [Fact]
                public void MapBOToModelList()
                {
                        var mapper = new BOLTicketMapper();

                        BOTicket bo = new BOTicket();

                        bo.SetProperties(1, "A", 1);
                        List<ApiTicketResponseModel> response = mapper.MapBOToModel(new List<BOTicket>() { { bo } });

                        response.Count.Should().Be(1);
                }
        }
}

/*<Codenesium>
    <Hash>d379414948d0fbf724439ef4136416d6</Hash>
</Codenesium>*/