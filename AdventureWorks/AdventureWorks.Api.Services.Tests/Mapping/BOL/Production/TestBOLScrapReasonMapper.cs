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
	[Trait("Table", "ScrapReason")]
	[Trait("Area", "BOLMapper")]
	public class TestBOLScrapReasonMapper
	{
		[Fact]
		public void MapModelToBO()
		{
			var mapper = new BOLScrapReasonMapper();
			ApiScrapReasonServerRequestModel model = new ApiScrapReasonServerRequestModel();
			model.SetProperties(DateTime.Parse("1/1/1987 12:00:00 AM"), "A");
			BOScrapReason response = mapper.MapModelToBO(1, model);

			response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.Name.Should().Be("A");
		}

		[Fact]
		public void MapBOToModel()
		{
			var mapper = new BOLScrapReasonMapper();
			BOScrapReason bo = new BOScrapReason();
			bo.SetProperties(1, DateTime.Parse("1/1/1987 12:00:00 AM"), "A");
			ApiScrapReasonServerResponseModel response = mapper.MapBOToModel(bo);

			response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.Name.Should().Be("A");
			response.ScrapReasonID.Should().Be(1);
		}

		[Fact]
		public void MapBOToModelList()
		{
			var mapper = new BOLScrapReasonMapper();
			BOScrapReason bo = new BOScrapReason();
			bo.SetProperties(1, DateTime.Parse("1/1/1987 12:00:00 AM"), "A");
			List<ApiScrapReasonServerResponseModel> response = mapper.MapBOToModel(new List<BOScrapReason>() { { bo } });

			response.Count.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>5dd569be342b1eb14d1ce071183a9085</Hash>
</Codenesium>*/