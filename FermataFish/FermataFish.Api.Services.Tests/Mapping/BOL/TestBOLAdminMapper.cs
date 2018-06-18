using System;
using System.Collections.Generic;
using FluentAssertions;
using Xunit;
using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;
using FermataFishNS.Api.Services;

namespace FermataFishNS.Api.Services.Tests
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

                        model.SetProperties(DateTime.Parse("1/1/1987 12:00:00 AM"), "A", "A", "A", "A", 1);
                        BOAdmin response = mapper.MapModelToBO(1, model);

                        response.Birthday.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
                        response.Email.Should().Be("A");
                        response.FirstName.Should().Be("A");
                        response.LastName.Should().Be("A");
                        response.Phone.Should().Be("A");
                        response.StudioId.Should().Be(1);
                }

                [Fact]
                public void MapBOToModel()
                {
                        var mapper = new BOLAdminMapper();

                        BOAdmin bo = new BOAdmin();

                        bo.SetProperties(1, DateTime.Parse("1/1/1987 12:00:00 AM"), "A", "A", "A", "A", 1);
                        ApiAdminResponseModel response = mapper.MapBOToModel(bo);

                        response.Birthday.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
                        response.Email.Should().Be("A");
                        response.FirstName.Should().Be("A");
                        response.Id.Should().Be(1);
                        response.LastName.Should().Be("A");
                        response.Phone.Should().Be("A");
                        response.StudioId.Should().Be(1);
                }

                [Fact]
                public void MapBOToModelList()
                {
                        var mapper = new BOLAdminMapper();

                        BOAdmin bo = new BOAdmin();

                        bo.SetProperties(1, DateTime.Parse("1/1/1987 12:00:00 AM"), "A", "A", "A", "A", 1);
                        List<ApiAdminResponseModel> response = mapper.MapBOToModel(new List<BOAdmin>() { { bo } });

                        response.Count.Should().Be(1);
                }
        }
}

/*<Codenesium>
    <Hash>b663f4e8221af955a070669a782bbe93</Hash>
</Codenesium>*/