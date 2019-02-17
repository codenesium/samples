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
		public void MapModelToEntity()
		{
			var mapper = new DALPhoneNumberTypeMapper();
			ApiPhoneNumberTypeServerRequestModel model = new ApiPhoneNumberTypeServerRequestModel();
			model.SetProperties(DateTime.Parse("1/1/1987 12:00:00 AM"), "A");
			PhoneNumberType response = mapper.MapModelToEntity(1, model);

			response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.Name.Should().Be("A");
		}

		[Fact]
		public void MapEntityToModel()
		{
			var mapper = new DALPhoneNumberTypeMapper();
			PhoneNumberType item = new PhoneNumberType();
			item.SetProperties(1, DateTime.Parse("1/1/1987 12:00:00 AM"), "A");
			ApiPhoneNumberTypeServerResponseModel response = mapper.MapEntityToModel(item);

			response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.Name.Should().Be("A");
			response.PhoneNumberTypeID.Should().Be(1);
		}

		[Fact]
		public void MapEntityToModelList()
		{
			var mapper = new DALPhoneNumberTypeMapper();
			PhoneNumberType item = new PhoneNumberType();
			item.SetProperties(1, DateTime.Parse("1/1/1987 12:00:00 AM"), "A");
			List<ApiPhoneNumberTypeServerResponseModel> response = mapper.MapEntityToModel(new List<PhoneNumberType>() { { item} });

			response.Count.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>2017ace22b10ad2baef1859ee76db421</Hash>
</Codenesium>*/