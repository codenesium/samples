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
	[Trait("Table", "ContactType")]
	[Trait("Area", "BOLMapper")]
	public class TestBOLContactTypeMapper
	{
		[Fact]
		public void MapModelToBO()
		{
			var mapper = new BOLContactTypeMapper();
			ApiContactTypeServerRequestModel model = new ApiContactTypeServerRequestModel();
			model.SetProperties(DateTime.Parse("1/1/1987 12:00:00 AM"), "A");
			BOContactType response = mapper.MapModelToBO(1, model);

			response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.Name.Should().Be("A");
		}

		[Fact]
		public void MapBOToModel()
		{
			var mapper = new BOLContactTypeMapper();
			BOContactType bo = new BOContactType();
			bo.SetProperties(1, DateTime.Parse("1/1/1987 12:00:00 AM"), "A");
			ApiContactTypeServerResponseModel response = mapper.MapBOToModel(bo);

			response.ContactTypeID.Should().Be(1);
			response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.Name.Should().Be("A");
		}

		[Fact]
		public void MapBOToModelList()
		{
			var mapper = new BOLContactTypeMapper();
			BOContactType bo = new BOContactType();
			bo.SetProperties(1, DateTime.Parse("1/1/1987 12:00:00 AM"), "A");
			List<ApiContactTypeServerResponseModel> response = mapper.MapBOToModel(new List<BOContactType>() { { bo } });

			response.Count.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>2c833ac83c7f767e20c18a2841ad1783</Hash>
</Codenesium>*/