using FluentAssertions;
using System;
using System.Collections.Generic;
using TestsNS.Api.Contracts;
using TestsNS.Api.DataAccess;
using Xunit;

namespace TestsNS.Api.Services
{
	[Trait("Type", "Unit")]
	[Trait("Table", "IncludedColumnTest")]
	[Trait("Area", "DALMapper")]
	public class TestDALIncludedColumnTestMapper
	{
		[Fact]
		public void MapModelToEntity()
		{
			var mapper = new DALIncludedColumnTestMapper();
			ApiIncludedColumnTestServerRequestModel model = new ApiIncludedColumnTestServerRequestModel();
			model.SetProperties("A", "A");
			IncludedColumnTest response = mapper.MapModelToEntity(1, model);

			response.Name.Should().Be("A");
			response.Name2.Should().Be("A");
		}

		[Fact]
		public void MapEntityToModel()
		{
			var mapper = new DALIncludedColumnTestMapper();
			IncludedColumnTest item = new IncludedColumnTest();
			item.SetProperties(1, "A", "A");
			ApiIncludedColumnTestServerResponseModel response = mapper.MapEntityToModel(item);

			response.Id.Should().Be(1);
			response.Name.Should().Be("A");
			response.Name2.Should().Be("A");
		}

		[Fact]
		public void MapEntityToModelList()
		{
			var mapper = new DALIncludedColumnTestMapper();
			IncludedColumnTest item = new IncludedColumnTest();
			item.SetProperties(1, "A", "A");
			List<ApiIncludedColumnTestServerResponseModel> response = mapper.MapEntityToModel(new List<IncludedColumnTest>() { { item} });

			response.Count.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>690780622c797efb88b9471c38dfd0f6</Hash>
</Codenesium>*/