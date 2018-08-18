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
	[Trait("Table", "PersonPhone")]
	[Trait("Area", "BOLMapper")]
	public class TestBOLPersonPhoneMapper
	{
		[Fact]
		public void MapModelToBO()
		{
			var mapper = new BOLPersonPhoneMapper();
			ApiPersonPhoneRequestModel model = new ApiPersonPhoneRequestModel();
			model.SetProperties(DateTime.Parse("1/1/1987 12:00:00 AM"), "A", 1);
			BOPersonPhone response = mapper.MapModelToBO(1, model);

			response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.PhoneNumber.Should().Be("A");
			response.PhoneNumberTypeID.Should().Be(1);
		}

		[Fact]
		public void MapBOToModel()
		{
			var mapper = new BOLPersonPhoneMapper();
			BOPersonPhone bo = new BOPersonPhone();
			bo.SetProperties(1, DateTime.Parse("1/1/1987 12:00:00 AM"), "A", 1);
			ApiPersonPhoneResponseModel response = mapper.MapBOToModel(bo);

			response.BusinessEntityID.Should().Be(1);
			response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.PhoneNumber.Should().Be("A");
			response.PhoneNumberTypeID.Should().Be(1);
		}

		[Fact]
		public void MapBOToModelList()
		{
			var mapper = new BOLPersonPhoneMapper();
			BOPersonPhone bo = new BOPersonPhone();
			bo.SetProperties(1, DateTime.Parse("1/1/1987 12:00:00 AM"), "A", 1);
			List<ApiPersonPhoneResponseModel> response = mapper.MapBOToModel(new List<BOPersonPhone>() { { bo } });

			response.Count.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>0a1d6b19f818867230ddb207c8b1b326</Hash>
</Codenesium>*/