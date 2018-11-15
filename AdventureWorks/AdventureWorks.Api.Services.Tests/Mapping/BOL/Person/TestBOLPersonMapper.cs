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
	[Trait("Table", "Person")]
	[Trait("Area", "BOLMapper")]
	public class TestBOLPersonMapper
	{
		[Fact]
		public void MapModelToBO()
		{
			var mapper = new BOLPersonMapper();
			ApiPersonServerRequestModel model = new ApiPersonServerRequestModel();
			model.SetProperties("A", "A", 1, "A", "A", "A", DateTime.Parse("1/1/1987 12:00:00 AM"), true, "A", Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"), "A", "A");
			BOPerson response = mapper.MapModelToBO(1, model);

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
		public void MapBOToModel()
		{
			var mapper = new BOLPersonMapper();
			BOPerson bo = new BOPerson();
			bo.SetProperties(1, "A", "A", 1, "A", "A", "A", DateTime.Parse("1/1/1987 12:00:00 AM"), true, "A", Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"), "A", "A");
			ApiPersonServerResponseModel response = mapper.MapBOToModel(bo);

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
		public void MapBOToModelList()
		{
			var mapper = new BOLPersonMapper();
			BOPerson bo = new BOPerson();
			bo.SetProperties(1, "A", "A", 1, "A", "A", "A", DateTime.Parse("1/1/1987 12:00:00 AM"), true, "A", Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"), "A", "A");
			List<ApiPersonServerResponseModel> response = mapper.MapBOToModel(new List<BOPerson>() { { bo } });

			response.Count.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>ad19c2f9f5439fbff8915163584d3061</Hash>
</Codenesium>*/