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
        [Trait("Table", "Admin")]
        [Trait("Area", "BOLMapper")]
        public class TestBOLAdminActionMapper
        {
                [Fact]
                public void MapModelToBO()
                {
                        var mapper = new BOLAdminMapper();

                        ApiAdminRequestModel model = new ApiAdminRequestModel();

                        model.SetProperties("A", "A", "A", "A", "A", "A");
                        BOAdmin response = mapper.MapModelToBO(1, model);

                        response.Email.Should().Be("A");
                        response.FirstName.Should().Be("A");
                        response.LastName.Should().Be("A");
                        response.Password.Should().Be("A");
                        response.Phone.Should().Be("A");
                        response.Username.Should().Be("A");
                }

                [Fact]
                public void MapBOToModel()
                {
                        var mapper = new BOLAdminMapper();

                        BOAdmin bo = new BOAdmin();

                        bo.SetProperties(1, "A", "A", "A", "A", "A", "A");
                        ApiAdminResponseModel response = mapper.MapBOToModel(bo);

                        response.Email.Should().Be("A");
                        response.FirstName.Should().Be("A");
                        response.Id.Should().Be(1);
                        response.LastName.Should().Be("A");
                        response.Password.Should().Be("A");
                        response.Phone.Should().Be("A");
                        response.Username.Should().Be("A");
                }

                [Fact]
                public void MapBOToModelList()
                {
                        var mapper = new BOLAdminMapper();

                        BOAdmin bo = new BOAdmin();

                        bo.SetProperties(1, "A", "A", "A", "A", "A", "A");
                        List<ApiAdminResponseModel> response = mapper.MapBOToModel(new List<BOAdmin>() { { bo } });

                        response.Count.Should().Be(1);
                }
        }
}

/*<Codenesium>
    <Hash>4c801ce2858abf83910400b9998d52a0</Hash>
</Codenesium>*/