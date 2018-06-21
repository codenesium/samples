using AdventureWorksNS.Api.DataAccess;
using AdventureWorksNS.Api.Services;
using FluentAssertions;
using System;
using System.Collections.Generic;
using Xunit;

namespace AdventureWorksNS.Api.Services.Tests
{
        [Trait("Type", "Unit")]
        [Trait("Table", "PersonPhone")]
        [Trait("Area", "DALMapper")]
        public class TestDALPersonPhoneMapper
        {
                [Fact]
                public void MapBOToEF()
                {
                        var mapper = new DALPersonPhoneMapper();
                        var bo = new BOPersonPhone();
                        bo.SetProperties(1, DateTime.Parse("1/1/1987 12:00:00 AM"), "A", 1);

                        PersonPhone response = mapper.MapBOToEF(bo);

                        response.BusinessEntityID.Should().Be(1);
                        response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
                        response.PhoneNumber.Should().Be("A");
                        response.PhoneNumberTypeID.Should().Be(1);
                }

                [Fact]
                public void MapEFToBO()
                {
                        var mapper = new DALPersonPhoneMapper();
                        PersonPhone entity = new PersonPhone();
                        entity.SetProperties(1, DateTime.Parse("1/1/1987 12:00:00 AM"), "A", 1);

                        BOPersonPhone response = mapper.MapEFToBO(entity);

                        response.BusinessEntityID.Should().Be(1);
                        response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
                        response.PhoneNumber.Should().Be("A");
                        response.PhoneNumberTypeID.Should().Be(1);
                }

                [Fact]
                public void MapEFToBOList()
                {
                        var mapper = new DALPersonPhoneMapper();
                        PersonPhone entity = new PersonPhone();
                        entity.SetProperties(1, DateTime.Parse("1/1/1987 12:00:00 AM"), "A", 1);

                        List<BOPersonPhone> response = mapper.MapEFToBO(new List<PersonPhone>() { entity });

                        response.Count.Should().Be(1);
                }
        }
}

/*<Codenesium>
    <Hash>190e581a25f58f21117ee511f8b7d0dc</Hash>
</Codenesium>*/