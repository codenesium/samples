using System;
using System.Collections.Generic;
using FluentAssertions;
using Xunit;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
using PetShippingNS.Api.Services;

namespace PetShippingNS.Api.Services.Tests
{
        [Trait("Type", "Unit")]
        [Trait("Table", "Handler")]
        [Trait("Area", "BOLMapper")]
        public class TestBOLHandlerActionMapper
        {
                [Fact]
                public void MapModelToBO()
                {
                        var mapper = new BOLHandlerMapper();

                        ApiHandlerRequestModel model = new ApiHandlerRequestModel();

                        model.SetProperties(1, "A", "A", "A", "A");
                        BOHandler response = mapper.MapModelToBO(1, model);

                        response.CountryId.Should().Be(1);
                        response.Email.Should().Be("A");
                        response.FirstName.Should().Be("A");
                        response.LastName.Should().Be("A");
                        response.Phone.Should().Be("A");
                }

                [Fact]
                public void MapBOToModel()
                {
                        var mapper = new BOLHandlerMapper();

                        BOHandler bo = new BOHandler();

                        bo.SetProperties(1, 1, "A", "A", "A", "A");
                        ApiHandlerResponseModel response = mapper.MapBOToModel(bo);

                        response.CountryId.Should().Be(1);
                        response.Email.Should().Be("A");
                        response.FirstName.Should().Be("A");
                        response.Id.Should().Be(1);
                        response.LastName.Should().Be("A");
                        response.Phone.Should().Be("A");
                }

                [Fact]
                public void MapBOToModelList()
                {
                        var mapper = new BOLHandlerMapper();

                        BOHandler bo = new BOHandler();

                        bo.SetProperties(1, 1, "A", "A", "A", "A");
                        List<ApiHandlerResponseModel> response = mapper.MapBOToModel(new List<BOHandler>() { { bo } });

                        response.Count.Should().Be(1);
                }
        }
}

/*<Codenesium>
    <Hash>888c0924c2596e738180c6fe42895e5e</Hash>
</Codenesium>*/