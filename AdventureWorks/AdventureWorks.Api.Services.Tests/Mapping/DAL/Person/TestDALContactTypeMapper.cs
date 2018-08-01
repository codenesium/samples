using AdventureWorksNS.Api.DataAccess;
using AdventureWorksNS.Api.Services;
using FluentAssertions;
using System;
using System.Collections.Generic;
using Xunit;

namespace AdventureWorksNS.Api.Services.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "ContactType")]
	[Trait("Area", "DALMapper")]
	public class TestDALContactTypeMapper
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

			BOContactType response = mapper.MapEFToBO(entity);

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
    <Hash>caa83ec8bfe1604797d4bc39a3360efe</Hash>
</Codenesium>*/