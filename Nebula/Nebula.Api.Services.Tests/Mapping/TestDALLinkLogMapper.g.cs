using FluentAssertions;
using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using Xunit;

namespace NebulaNS.Api.Services
{
	[Trait("Type", "Unit")]
	[Trait("Table", "LinkLog")]
	[Trait("Area", "DALMapper")]
	public class TestDALLinkLogMapper
	{
		[Fact]
		public void MapModelToEntity()
		{
			var mapper = new DALLinkLogMapper();
			ApiLinkLogServerRequestModel model = new ApiLinkLogServerRequestModel();
			model.SetProperties(DateTime.Parse("1/1/1987 12:00:00 AM"), 1, "A");
			LinkLog response = mapper.MapModelToEntity(1, model);

			response.DateEntered.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.LinkId.Should().Be(1);
			response.Log.Should().Be("A");
		}

		[Fact]
		public void MapEntityToModel()
		{
			var mapper = new DALLinkLogMapper();
			LinkLog item = new LinkLog();
			item.SetProperties(1, DateTime.Parse("1/1/1987 12:00:00 AM"), 1, "A");
			ApiLinkLogServerResponseModel response = mapper.MapEntityToModel(item);

			response.DateEntered.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.Id.Should().Be(1);
			response.LinkId.Should().Be(1);
			response.Log.Should().Be("A");
		}

		[Fact]
		public void MapEntityToModelList()
		{
			var mapper = new DALLinkLogMapper();
			LinkLog item = new LinkLog();
			item.SetProperties(1, DateTime.Parse("1/1/1987 12:00:00 AM"), 1, "A");
			List<ApiLinkLogServerResponseModel> response = mapper.MapEntityToModel(new List<LinkLog>() { { item} });

			response.Count.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>40dce743584c5267cb86ef46e846547f</Hash>
</Codenesium>*/