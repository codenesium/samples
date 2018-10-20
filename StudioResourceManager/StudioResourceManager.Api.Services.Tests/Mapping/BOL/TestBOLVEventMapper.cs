using FluentAssertions;
using StudioResourceManagerNS.Api.Contracts;
using StudioResourceManagerNS.Api.DataAccess;
using StudioResourceManagerNS.Api.Services;
using System;
using System.Collections.Generic;
using Xunit;

namespace StudioResourceManagerNS.Api.Services.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "VEvent")]
	[Trait("Area", "BOLMapper")]
	public class TestBOLVEventMapper
	{
		[Fact]
		public void MapModelToBO()
		{
			var mapper = new BOLVEventMapper();
			ApiVEventRequestModel model = new ApiVEventRequestModel();
			model.SetProperties(DateTime.Parse("1/1/1987 12:00:00 AM"), DateTime.Parse("1/1/1987 12:00:00 AM"), 1m, 1, DateTime.Parse("1/1/1987 12:00:00 AM"), DateTime.Parse("1/1/1987 12:00:00 AM"), true);
			BOVEvent response = mapper.MapModelToBO(1, model);

			response.ActualEndDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.ActualStartDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.BillAmount.Should().Be(1m);
			response.EventStatusId.Should().Be(1);
			response.ScheduledEndDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.ScheduledStartDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.IsDeleted.Should().Be(true);
		}

		[Fact]
		public void MapBOToModel()
		{
			var mapper = new BOLVEventMapper();
			BOVEvent bo = new BOVEvent();
			bo.SetProperties(1, DateTime.Parse("1/1/1987 12:00:00 AM"), DateTime.Parse("1/1/1987 12:00:00 AM"), 1m, 1, DateTime.Parse("1/1/1987 12:00:00 AM"), DateTime.Parse("1/1/1987 12:00:00 AM"), true);
			ApiVEventResponseModel response = mapper.MapBOToModel(bo);

			response.ActualEndDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.ActualStartDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.BillAmount.Should().Be(1m);
			response.EventStatusId.Should().Be(1);
			response.Id.Should().Be(1);
			response.ScheduledEndDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.ScheduledStartDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.IsDeleted.Should().Be(true);
		}

		[Fact]
		public void MapBOToModelList()
		{
			var mapper = new BOLVEventMapper();
			BOVEvent bo = new BOVEvent();
			bo.SetProperties(1, DateTime.Parse("1/1/1987 12:00:00 AM"), DateTime.Parse("1/1/1987 12:00:00 AM"), 1m, 1, DateTime.Parse("1/1/1987 12:00:00 AM"), DateTime.Parse("1/1/1987 12:00:00 AM"), true);
			List<ApiVEventResponseModel> response = mapper.MapBOToModel(new List<BOVEvent>() { { bo } });

			response.Count.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>2324f803c95d2433ba4726f15424199e</Hash>
</Codenesium>*/