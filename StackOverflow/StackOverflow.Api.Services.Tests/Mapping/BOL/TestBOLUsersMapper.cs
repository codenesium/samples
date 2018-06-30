using FluentAssertions;
using StackOverflowNS.Api.Contracts;
using StackOverflowNS.Api.DataAccess;
using StackOverflowNS.Api.Services;
using System;
using System.Collections.Generic;
using Xunit;

namespace StackOverflowNS.Api.Services.Tests
{
        [Trait("Type", "Unit")]
        [Trait("Table", "Users")]
        [Trait("Area", "BOLMapper")]
        public class TestBOLUsersMapper
        {
                [Fact]
                public void MapModelToBO()
                {
                        var mapper = new BOLUsersMapper();
                        ApiUsersRequestModel model = new ApiUsersRequestModel();
                        model.SetProperties("A", 1, 1, DateTime.Parse("1/1/1987 12:00:00 AM"), "A", 1, "A", DateTime.Parse("1/1/1987 12:00:00 AM"), "A", 1, 1, 1, "A");
                        BOUsers response = mapper.MapModelToBO(1, model);

                        response.AboutMe.Should().Be("A");
                        response.AccountId.Should().Be(1);
                        response.Age.Should().Be(1);
                        response.CreationDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
                        response.DisplayName.Should().Be("A");
                        response.DownVotes.Should().Be(1);
                        response.EmailHash.Should().Be("A");
                        response.LastAccessDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
                        response.Location.Should().Be("A");
                        response.Reputation.Should().Be(1);
                        response.UpVotes.Should().Be(1);
                        response.Views.Should().Be(1);
                        response.WebsiteUrl.Should().Be("A");
                }

                [Fact]
                public void MapBOToModel()
                {
                        var mapper = new BOLUsersMapper();
                        BOUsers bo = new BOUsers();
                        bo.SetProperties(1, "A", 1, 1, DateTime.Parse("1/1/1987 12:00:00 AM"), "A", 1, "A", DateTime.Parse("1/1/1987 12:00:00 AM"), "A", 1, 1, 1, "A");
                        ApiUsersResponseModel response = mapper.MapBOToModel(bo);

                        response.AboutMe.Should().Be("A");
                        response.AccountId.Should().Be(1);
                        response.Age.Should().Be(1);
                        response.CreationDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
                        response.DisplayName.Should().Be("A");
                        response.DownVotes.Should().Be(1);
                        response.EmailHash.Should().Be("A");
                        response.Id.Should().Be(1);
                        response.LastAccessDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
                        response.Location.Should().Be("A");
                        response.Reputation.Should().Be(1);
                        response.UpVotes.Should().Be(1);
                        response.Views.Should().Be(1);
                        response.WebsiteUrl.Should().Be("A");
                }

                [Fact]
                public void MapBOToModelList()
                {
                        var mapper = new BOLUsersMapper();
                        BOUsers bo = new BOUsers();
                        bo.SetProperties(1, "A", 1, 1, DateTime.Parse("1/1/1987 12:00:00 AM"), "A", 1, "A", DateTime.Parse("1/1/1987 12:00:00 AM"), "A", 1, 1, 1, "A");
                        List<ApiUsersResponseModel> response = mapper.MapBOToModel(new List<BOUsers>() { { bo } });

                        response.Count.Should().Be(1);
                }
        }
}

/*<Codenesium>
    <Hash>6a43bb3f91fbc49bfcb39917e6a81ab7</Hash>
</Codenesium>*/