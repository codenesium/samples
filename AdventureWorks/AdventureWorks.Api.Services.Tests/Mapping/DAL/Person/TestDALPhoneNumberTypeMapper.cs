using AdventureWorksNS.Api.DataAccess;
using AdventureWorksNS.Api.Services;
using FluentAssertions;
using System;
using System.Collections.Generic;
using Xunit;

namespace AdventureWorksNS.Api.Services.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "PhoneNumberType")]
	[Trait("Area", "DALMapper")]
	public class TestDALPhoneNumberTypeMapper
	{
		[Fact]
		public void MapBOToEF()
		{
			var mapper = new DALPhoneNumberTypeMapper();
			var bo = new BOPhoneNumberType();
			bo.SetProperties(1, DateTime.Parse("1/1/1987 12:00:00 AM"), "A");

			PhoneNumberType response = mapper.MapBOToEF(bo);

			response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.Name.Should().Be("A");
			response.PhoneNumberTypeID.Should().Be(1);
		}

		[Fact]
		public void MapEFToBO()
		{
			var mapper = new DALPhoneNumberTypeMapper();
			PhoneNumberType entity = new PhoneNumberType();
			entity.SetProperties(DateTime.Parse("1/1/1987 12:00:00 AM"), "A", 1);

			BOPhoneNumberType response = mapper.MapEFToBO(entity);

			response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.Name.Should().Be("A");
			response.PhoneNumberTypeID.Should().Be(1);
		}

		[Fact]
		public void MapEFToBOList()
		{
			var mapper = new DALPhoneNumberTypeMapper();
			PhoneNumberType entity = new PhoneNumberType();
			entity.SetProperties(DateTime.Parse("1/1/1987 12:00:00 AM"), "A", 1);

			List<BOPhoneNumberType> response = mapper.MapEFToBO(new List<PhoneNumberType>() { entity });

			response.Count.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>51a85abda2a08a6e7da898957a3344b4</Hash>
</Codenesium>*/