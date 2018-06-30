using FluentAssertions;
using StackOverflowNS.Api.DataAccess;
using StackOverflowNS.Api.Services;
using System;
using System.Collections.Generic;
using Xunit;

namespace StackOverflowNS.Api.Services.Tests
{
        [Trait("Type", "Unit")]
        [Trait("Table", "Users")]
        [Trait("Area", "DALMapper")]
        public class TestDALUsersMapper
        {
                [Fact]
                public void MapBOToEF()
                {
                        var mapper = new DALUsersMapper();
                        var bo = new BOUsers();
                        bo.SetProperties(1, "A", 1, 1, DateTime.Parse("1/1/1987 12:00:00 AM"), "A", 1, "A", DateTime.Parse("1/1/1987 12:00:00 AM"), "A", 1, 1, 1, "A");

                        Users response = mapper.MapBOToEF(bo);

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
                public void MapEFToBO()
                {
                        var mapper = new DALUsersMapper();
                        Users entity = new Users();
                        entity.SetProperties("A", 1, 1, DateTime.Parse("1/1/1987 12:00:00 AM"), "A", 1, "A", 1, DateTime.Parse("1/1/1987 12:00:00 AM"), "A", 1, 1, 1, "A");

                        BOUsers response = mapper.MapEFToBO(entity);

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
                public void MapEFToBOList()
                {
                        var mapper = new DALUsersMapper();
                        Users entity = new Users();
                        entity.SetProperties("A", 1, 1, DateTime.Parse("1/1/1987 12:00:00 AM"), "A", 1, "A", 1, DateTime.Parse("1/1/1987 12:00:00 AM"), "A", 1, 1, 1, "A");

                        List<BOUsers> response = mapper.MapEFToBO(new List<Users>() { entity });

                        response.Count.Should().Be(1);
                }
        }
}

/*<Codenesium>
    <Hash>cc07a0bc04cff64e8f905339f622be70</Hash>
</Codenesium>*/