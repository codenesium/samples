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
			ApiPhoneNumberTypeServerRequestModel model = new ApiPhoneNumberTypeServerRequestModel();
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
			ApiPhoneNumberTypeServerResponseModel response = mapper.MapBOToModel(bo);

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
			List<ApiPhoneNumberTypeServerResponseModel> response = mapper.MapBOToModel(new List<BOPhoneNumberType>() { { bo } });

			response.Count.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>e958d0f1b029604445d7dbf1a5a462d3</Hash>
</Codenesium>*/