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
	[Trait("Table", "PhoneNumberType")]
	[Trait("Area", "BOLMapper")]
	public class TestBOLPhoneNumberTypeMapper
	{
		[Fact]
		public void MapModelToBO()
		{
			var mapper = new BOLPhoneNumberTypeMapper();
			ApiPhoneNumberTypeRequestModel model = new ApiPhoneNumberTypeRequestModel();
			model.SetProperties(DateTime.Parse("1/1/1987 12:00:00 AM"), "A");
			BOPhoneNumberType response = mapper.MapModelToBO(1, model);

			response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.Name.Should().Be("A");
		}

		[Fact]
		public void MapBOToModel()
		{
			var mapper = new BOLPhoneNumberTypeMapper();
			BOPhoneNumberType bo = new BOPhoneNumberType();
			bo.SetProperties(1, DateTime.Parse("1/1/1987 12:00:00 AM"), "A");
			ApiPhoneNumberTypeResponseModel response = mapper.MapBOToModel(bo);

			response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.Name.Should().Be("A");
			response.PhoneNumberTypeID.Should().Be(1);
		}

		[Fact]
		public void MapBOToModelList()
		{
			var mapper = new BOLPhoneNumberTypeMapper();
			BOPhoneNumberType bo = new BOPhoneNumberType();
			bo.SetProperties(1, DateTime.Parse("1/1/1987 12:00:00 AM"), "A");
			List<ApiPhoneNumberTypeResponseModel> response = mapper.MapBOToModel(new List<BOPhoneNumberType>() { { bo } });

			response.Count.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>48ac502a09ed3b957c25c697b9a39b25</Hash>
</Codenesium>*/