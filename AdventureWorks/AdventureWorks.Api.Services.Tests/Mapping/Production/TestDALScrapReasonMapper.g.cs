using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using FluentAssertions;
using System;
using System.Collections.Generic;
using Xunit;

namespace AdventureWorksNS.Api.Services
{
	[Trait("Type", "Unit")]
	[Trait("Table", "ScrapReason")]
	[Trait("Area", "DALMapper")]
	public class TestDALScrapReasonMapper
	{
		[Fact]
		public void MapModelToBO()
		{
			var mapper = new DALScrapReasonMapper();
			ApiScrapReasonServerRequestModel model = new ApiScrapReasonServerRequestModel();
			model.SetProperties(DateTime.Parse("1/1/1987 12:00:00 AM"), "A");
			ScrapReason response = mapper.MapModelToBO(1, model);

			response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.Name.Should().Be("A");
		}

		[Fact]
		public void MapBOToModel()
		{
			var mapper = new DALScrapReasonMapper();
			ScrapReason item = new ScrapReason();
			item.SetProperties(1, DateTime.Parse("1/1/1987 12:00:00 AM"), "A");
			ApiScrapReasonServerResponseModel response = mapper.MapBOToModel(item);

			response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.Name.Should().Be("A");
			response.ScrapReasonID.Should().Be(1);
		}

		[Fact]
		public void MapBOToModelList()
		{
			var mapper = new DALScrapReasonMapper();
			ScrapReason item = new ScrapReason();
			item.SetProperties(1, DateTime.Parse("1/1/1987 12:00:00 AM"), "A");
			List<ApiScrapReasonServerResponseModel> response = mapper.MapBOToModel(new List<ScrapReason>() { { item} });

			response.Count.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>c72afc7301964d3b7b6f1796396761d2</Hash>
</Codenesium>*/