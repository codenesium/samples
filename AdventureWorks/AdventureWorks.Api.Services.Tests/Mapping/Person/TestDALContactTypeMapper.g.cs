using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using FluentAssertions;
using System;
using System.Collections.Generic;
using Xunit;

namespace AdventureWorksNS.Api.Services
{
	[Trait("Type", "Unit")]
	[Trait("Table", "ContactType")]
	[Trait("Area", "DALMapper")]
	public class TestDALContactTypeMapper
	{
		[Fact]
		public void MapModelToBO()
		{
			var mapper = new DALContactTypeMapper();
			ApiContactTypeServerRequestModel model = new ApiContactTypeServerRequestModel();
			model.SetProperties(DateTime.Parse("1/1/1987 12:00:00 AM"), "A");
			ContactType response = mapper.MapModelToBO(1, model);

			response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.Name.Should().Be("A");
		}

		[Fact]
		public void MapBOToModel()
		{
			var mapper = new DALContactTypeMapper();
			ContactType item = new ContactType();
			item.SetProperties(1, DateTime.Parse("1/1/1987 12:00:00 AM"), "A");
			ApiContactTypeServerResponseModel response = mapper.MapBOToModel(item);

			response.ContactTypeID.Should().Be(1);
			response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.Name.Should().Be("A");
		}

		[Fact]
		public void MapBOToModelList()
		{
			var mapper = new DALContactTypeMapper();
			ContactType item = new ContactType();
			item.SetProperties(1, DateTime.Parse("1/1/1987 12:00:00 AM"), "A");
			List<ApiContactTypeServerResponseModel> response = mapper.MapBOToModel(new List<ContactType>() { { item} });

			response.Count.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>4ed3d88434b32ecc9d6f8fbc5d301691</Hash>
</Codenesium>*/