using System;
using System.Collections.Generic;
using FluentAssertions;
using Xunit;
using AdventureWorksNS.Api.DataAccess;
using AdventureWorksNS.Api.Services;

namespace AdventureWorksNS.Api.Services.Tests
{
        [Trait("Type", "Unit")]
        [Trait("Table", "ContactType")]
        [Trait("Area", "DALMapper")]
        public class TestDALContactTypeActionMapper
        {
                [Fact]
                public void MapBOToEF()
                {
                        var mapper = new DALContactTypeMapper();

                        var bo = new BOContactType();

                        bo.SetProperties(1, DateTime.Parse("1/1/1987 12:00:00 AM"), "A");

                        ContactType response = mapper.MapBOToEF(bo);

                        response.ContactTypeID.Should().Be(1);
                        response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
                        response.Name.Should().Be("A");
                }

                [Fact]
                public void MapEFToBO()
                {
                        var mapper = new DALContactTypeMapper();

                        ContactType entity = new ContactType();

                        entity.SetProperties(1, DateTime.Parse("1/1/1987 12:00:00 AM"), "A");

                        BOContactType  response = mapper.MapEFToBO(entity);

                        response.ContactTypeID.Should().Be(1);
                        response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
                        response.Name.Should().Be("A");
                }

                [Fact]
                public void MapEFToBOList()
                {
                        var mapper = new DALContactTypeMapper();

                        ContactType entity = new ContactType();

                        entity.SetProperties(1, DateTime.Parse("1/1/1987 12:00:00 AM"), "A");

                        List<BOContactType> response = mapper.MapEFToBO(new List<ContactType>() { entity });

                        response.Count.Should().Be(1);
                }
        }
}

/*<Codenesium>
    <Hash>75a51d46e6b8fea5fa19eea224ba594a</Hash>
</Codenesium>*/