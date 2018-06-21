using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using AdventureWorksNS.Api.Services;
using FluentAssertions;
using System;
using System.Collections.Generic;
using Xunit;

namespace AdventureWorksNS.Api.Services.Tests
{
        [Trait("Type", "Unit")]
        [Trait("Table", "ErrorLog")]
        [Trait("Area", "BOLMapper")]
        public class TestBOLErrorLogMapper
        {
                [Fact]
                public void MapModelToBO()
                {
                        var mapper = new BOLErrorLogMapper();
                        ApiErrorLogRequestModel model = new ApiErrorLogRequestModel();
                        model.SetProperties(1, "A", 1, "A", 1, 1, DateTime.Parse("1/1/1987 12:00:00 AM"), "A");
                        BOErrorLog response = mapper.MapModelToBO(1, model);

                        response.ErrorLine.Should().Be(1);
                        response.ErrorMessage.Should().Be("A");
                        response.ErrorNumber.Should().Be(1);
                        response.ErrorProcedure.Should().Be("A");
                        response.ErrorSeverity.Should().Be(1);
                        response.ErrorState.Should().Be(1);
                        response.ErrorTime.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
                        response.UserName.Should().Be("A");
                }

                [Fact]
                public void MapBOToModel()
                {
                        var mapper = new BOLErrorLogMapper();
                        BOErrorLog bo = new BOErrorLog();
                        bo.SetProperties(1, 1, "A", 1, "A", 1, 1, DateTime.Parse("1/1/1987 12:00:00 AM"), "A");
                        ApiErrorLogResponseModel response = mapper.MapBOToModel(bo);

                        response.ErrorLine.Should().Be(1);
                        response.ErrorLogID.Should().Be(1);
                        response.ErrorMessage.Should().Be("A");
                        response.ErrorNumber.Should().Be(1);
                        response.ErrorProcedure.Should().Be("A");
                        response.ErrorSeverity.Should().Be(1);
                        response.ErrorState.Should().Be(1);
                        response.ErrorTime.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
                        response.UserName.Should().Be("A");
                }

                [Fact]
                public void MapBOToModelList()
                {
                        var mapper = new BOLErrorLogMapper();
                        BOErrorLog bo = new BOErrorLog();
                        bo.SetProperties(1, 1, "A", 1, "A", 1, 1, DateTime.Parse("1/1/1987 12:00:00 AM"), "A");
                        List<ApiErrorLogResponseModel> response = mapper.MapBOToModel(new List<BOErrorLog>() { { bo } });

                        response.Count.Should().Be(1);
                }
        }
}

/*<Codenesium>
    <Hash>1632d4f3abb561d69b6b7b935afd5f45</Hash>
</Codenesium>*/