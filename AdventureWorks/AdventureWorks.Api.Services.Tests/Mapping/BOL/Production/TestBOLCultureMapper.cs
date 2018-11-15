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
	[Trait("Table", "Culture")]
	[Trait("Area", "BOLMapper")]
	public class TestBOLCultureMapper
	{
		[Fact]
		public void MapModelToBO()
		{
			var mapper = new BOLCultureMapper();
			ApiCultureServerRequestModel model = new ApiCultureServerRequestModel();
			model.SetProperties(DateTime.Parse("1/1/1987 12:00:00 AM"), "A");
			BOCulture response = mapper.MapModelToBO("A", model);

			response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.Name.Should().Be("A");
		}

		[Fact]
		public void MapBOToModel()
		{
			var mapper = new BOLCultureMapper();
			BOCulture bo = new BOCulture();
			bo.SetProperties("A", DateTime.Parse("1/1/1987 12:00:00 AM"), "A");
			ApiCultureServerResponseModel response = mapper.MapBOToModel(bo);

			response.CultureID.Should().Be("A");
			response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.Name.Should().Be("A");
		}

		[Fact]
		public void MapBOToModelList()
		{
			var mapper = new BOLCultureMapper();
			BOCulture bo = new BOCulture();
			bo.SetProperties("A", DateTime.Parse("1/1/1987 12:00:00 AM"), "A");
			List<ApiCultureServerResponseModel> response = mapper.MapBOToModel(new List<BOCulture>() { { bo } });

			response.Count.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>cd9b4edee308fe208744b1488d85b18f</Hash>
</Codenesium>*/