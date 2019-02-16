using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using FluentAssertions;
using System;
using System.Collections.Generic;
using Xunit;

namespace AdventureWorksNS.Api.Services
{
	[Trait("Type", "Unit")]
	[Trait("Table", "PhoneNumberType")]
	[Trait("Area", "DALMapper")]
	public class TestDALPhoneNumberTypeMapper
	{
		[Fact]
		public void MapModelToBO()
		{
			var mapper = new DALPhoneNumberTypeMapper();
			ApiPhoneNumberTypeServerRequestModel model = new ApiPhoneNumberTypeServerRequestModel();
			model.SetProperties(DateTime.Parse("1/1/1987 12:00:00 AM"), "A");
			PhoneNumberType response = mapper.MapModelToBO(1, model);

			response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.Name.Should().Be("A");
		}

		[Fact]
		public void MapBOToModel()
		{
			var mapper = new DALPhoneNumberTypeMapper();
			PhoneNumberType item = new PhoneNumberType();
			item.SetProperties(1, DateTime.Parse("1/1/1987 12:00:00 AM"), "A");
			ApiPhoneNumberTypeServerResponseModel response = mapper.MapBOToModel(item);

			response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.Name.Should().Be("A");
			response.PhoneNumberTypeID.Should().Be(1);
		}

		[Fact]
		public void MapBOToModelList()
		{
			var mapper = new DALPhoneNumberTypeMapper();
			PhoneNumberType item = new PhoneNumberType();
			item.SetProperties(1, DateTime.Parse("1/1/1987 12:00:00 AM"), "A");
			List<ApiPhoneNumberTypeServerResponseModel> response = mapper.MapBOToModel(new List<PhoneNumberType>() { { item} });

			response.Count.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>1533990700ddfa7d4b7b9f686574911a</Hash>
</Codenesium>*/