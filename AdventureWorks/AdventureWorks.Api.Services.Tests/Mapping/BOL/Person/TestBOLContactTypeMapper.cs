using System;
using System.Collections.Generic;
using FluentAssertions;
using Xunit;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using AdventureWorksNS.Api.Services;

namespace AdventureWorksNS.Api.Services.Tests
{
        [Trait("Type", "Unit")]
        [Trait("Table", "ContactType")]
        [Trait("Area", "BOLMapper")]
        public class TestBOLContactTypeActionMapper
        {
                [Fact]
                public void MapModelToBO()
                {
                        var mapper = new BOLContactTypeMapper();

                        ApiContactTypeRequestModel model = new ApiContactTypeRequestModel();

                        model.SetProperties(DateTime.Parse("1/1/1987 12:00:00 AM"), "A");
                        BOContactType response = mapper.MapModelToBO(1, model);

                        response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
                        response.Name.Should().Be("A");
                }

                [Fact]
                public void MapBOToModel()
                {
                        var mapper = new BOLContactTypeMapper();

                        BOContactType bo = new BOContactType();

                        bo.SetProperties(1, DateTime.Parse("1/1/1987 12:00:00 AM"), "A");
                        ApiContactTypeResponseModel response = mapper.MapBOToModel(bo);

                        response.ContactTypeID.Should().Be(1);
                        response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
                        response.Name.Should().Be("A");
                }

                [Fact]
                public void MapBOToModelList()
                {
                        var mapper = new BOLContactTypeMapper();

                        BOContactType bo = new BOContactType();

                        bo.SetProperties(1, DateTime.Parse("1/1/1987 12:00:00 AM"), "A");
                        List<ApiContactTypeResponseModel> response = mapper.MapBOToModel(new List<BOContactType>() { { bo } });

                        response.Count.Should().Be(1);
                }
        }
}

/*<Codenesium>
    <Hash>c70a1de0a9479a7571bc8d43d7952917</Hash>
</Codenesium>*/