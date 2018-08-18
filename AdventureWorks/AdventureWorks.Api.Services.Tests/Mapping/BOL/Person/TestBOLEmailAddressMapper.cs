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
	[Trait("Table", "EmailAddress")]
	[Trait("Area", "BOLMapper")]
	public class TestBOLEmailAddressMapper
	{
		[Fact]
		public void MapModelToBO()
		{
			var mapper = new BOLEmailAddressMapper();
			ApiEmailAddressRequestModel model = new ApiEmailAddressRequestModel();
			model.SetProperties("A", 1, DateTime.Parse("1/1/1987 12:00:00 AM"), Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));
			BOEmailAddress response = mapper.MapModelToBO(1, model);

			response.EmailAddress1.Should().Be("A");
			response.EmailAddressID.Should().Be(1);
			response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.Rowguid.Should().Be(Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));
		}

		[Fact]
		public void MapBOToModel()
		{
			var mapper = new BOLEmailAddressMapper();
			BOEmailAddress bo = new BOEmailAddress();
			bo.SetProperties(1, "A", 1, DateTime.Parse("1/1/1987 12:00:00 AM"), Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));
			ApiEmailAddressResponseModel response = mapper.MapBOToModel(bo);

			response.BusinessEntityID.Should().Be(1);
			response.EmailAddress1.Should().Be("A");
			response.EmailAddressID.Should().Be(1);
			response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.Rowguid.Should().Be(Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));
		}

		[Fact]
		public void MapBOToModelList()
		{
			var mapper = new BOLEmailAddressMapper();
			BOEmailAddress bo = new BOEmailAddress();
			bo.SetProperties(1, "A", 1, DateTime.Parse("1/1/1987 12:00:00 AM"), Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));
			List<ApiEmailAddressResponseModel> response = mapper.MapBOToModel(new List<BOEmailAddress>() { { bo } });

			response.Count.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>a0a0e76951234ae81c684740ea9af72a</Hash>
</Codenesium>*/