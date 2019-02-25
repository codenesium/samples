using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using FluentAssertions;
using System;
using System.Collections.Generic;
using Xunit;

namespace AdventureWorksNS.Api.Services
{
	[Trait("Type", "Unit")]
	[Trait("Table", "Person")]
	[Trait("Area", "DALMapper")]
	public class TestDALPersonMapper
	{
		[Fact]
		public void MapModelToEntity()
		{
			var mapper = new DALPersonMapper();
			ApiPersonServerRequestModel model = new ApiPersonServerRequestModel();
			model.SetProperties("A", "A", 1, "A", "A", "A", DateTime.Parse("1/1/1987 12:00:00 AM"), true, "A", Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"), "A", "A");
			Person response = mapper.MapModelToEntity(1, model);

			response.AdditionalContactInfo.Should().Be("A");
			response.Demographic.Should().Be("A");
			response.EmailPromotion.Should().Be(1);
			response.FirstName.Should().Be("A");
			response.LastName.Should().Be("A");
			response.MiddleName.Should().Be("A");
			response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.NameStyle.Should().Be(true);
			response.PersonType.Should().Be("A");
			response.Rowguid.Should().Be(Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));
			response.Suffix.Should().Be("A");
			response.Title.Should().Be("A");
		}

		[Fact]
		public void MapEntityToModel()
		{
			var mapper = new DALPersonMapper();
			Person item = new Person();
			item.SetProperties(1, "A", "A", 1, "A", "A", "A", DateTime.Parse("1/1/1987 12:00:00 AM"), true, "A", Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"), "A", "A");
			ApiPersonServerResponseModel response = mapper.MapEntityToModel(item);

			response.AdditionalContactInfo.Should().Be("A");
			response.BusinessEntityID.Should().Be(1);
			response.Demographic.Should().Be("A");
			response.EmailPromotion.Should().Be(1);
			response.FirstName.Should().Be("A");
			response.LastName.Should().Be("A");
			response.MiddleName.Should().Be("A");
			response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.NameStyle.Should().Be(true);
			response.PersonType.Should().Be("A");
			response.Rowguid.Should().Be(Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));
			response.Suffix.Should().Be("A");
			response.Title.Should().Be("A");
		}

		[Fact]
		public void MapEntityToModelList()
		{
			var mapper = new DALPersonMapper();
			Person item = new Person();
			item.SetProperties(1, "A", "A", 1, "A", "A", "A", DateTime.Parse("1/1/1987 12:00:00 AM"), true, "A", Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"), "A", "A");
			List<ApiPersonServerResponseModel> response = mapper.MapEntityToModel(new List<Person>() { { item} });

			response.Count.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>2a6f8f1ba861fef97b4acd4505809923</Hash>
</Codenesium>*/