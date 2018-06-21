using AdventureWorksNS.Api.DataAccess;
using AdventureWorksNS.Api.Services;
using FluentAssertions;
using System;
using System.Collections.Generic;
using Xunit;

namespace AdventureWorksNS.Api.Services.Tests
{
        [Trait("Type", "Unit")]
        [Trait("Table", "EmailAddress")]
        [Trait("Area", "DALMapper")]
        public class TestDALEmailAddressMapper
        {
                [Fact]
                public void MapBOToEF()
                {
                        var mapper = new DALEmailAddressMapper();
                        var bo = new BOEmailAddress();
                        bo.SetProperties(1, "A", 1, DateTime.Parse("1/1/1987 12:00:00 AM"), Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));

                        EmailAddress response = mapper.MapBOToEF(bo);

                        response.BusinessEntityID.Should().Be(1);
                        response.EmailAddress1.Should().Be("A");
                        response.EmailAddressID.Should().Be(1);
                        response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
                        response.Rowguid.Should().Be(Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));
                }

                [Fact]
                public void MapEFToBO()
                {
                        var mapper = new DALEmailAddressMapper();
                        EmailAddress entity = new EmailAddress();
                        entity.SetProperties(1, "A", 1, DateTime.Parse("1/1/1987 12:00:00 AM"), Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));

                        BOEmailAddress response = mapper.MapEFToBO(entity);

                        response.BusinessEntityID.Should().Be(1);
                        response.EmailAddress1.Should().Be("A");
                        response.EmailAddressID.Should().Be(1);
                        response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
                        response.Rowguid.Should().Be(Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));
                }

                [Fact]
                public void MapEFToBOList()
                {
                        var mapper = new DALEmailAddressMapper();
                        EmailAddress entity = new EmailAddress();
                        entity.SetProperties(1, "A", 1, DateTime.Parse("1/1/1987 12:00:00 AM"), Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));

                        List<BOEmailAddress> response = mapper.MapEFToBO(new List<EmailAddress>() { entity });

                        response.Count.Should().Be(1);
                }
        }
}

/*<Codenesium>
    <Hash>5e32d08aa0e3b195e1a5263ef561ea9e</Hash>
</Codenesium>*/