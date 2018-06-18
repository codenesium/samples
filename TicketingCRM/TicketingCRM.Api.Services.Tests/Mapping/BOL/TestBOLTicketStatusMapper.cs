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
        [Trait("Table", "TicketStatus")]
        [Trait("Area", "BOLMapper")]
        public class TestBOLTicketStatusActionMapper
        {
                [Fact]
                public void MapModelToBO()
                {
                        var mapper = new BOLTicketStatusMapper();

                        ApiTicketStatusRequestModel model = new ApiTicketStatusRequestModel();

                        model.SetProperties("A");
                        BOTicketStatus response = mapper.MapModelToBO(1, model);

                        response.Name.Should().Be("A");
                }

                [Fact]
                public void MapBOToModel()
                {
                        var mapper = new BOLTicketStatusMapper();

                        BOTicketStatus bo = new BOTicketStatus();

                        bo.SetProperties(1, "A");
                        ApiTicketStatusResponseModel response = mapper.MapBOToModel(bo);

                        response.Id.Should().Be(1);
                        response.Name.Should().Be("A");
                }

                [Fact]
                public void MapBOToModelList()
                {
                        var mapper = new BOLTicketStatusMapper();

                        BOTicketStatus bo = new BOTicketStatus();

                        bo.SetProperties(1, "A");
                        List<ApiTicketStatusResponseModel> response = mapper.MapBOToModel(new List<BOTicketStatus>() { { bo } });

                        response.Count.Should().Be(1);
                }
        }
}

/*<Codenesium>
    <Hash>613758d73de2a028029d5fa34193aedc</Hash>
</Codenesium>*/