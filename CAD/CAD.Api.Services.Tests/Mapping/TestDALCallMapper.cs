using CADNS.Api.Contracts;
using CADNS.Api.DataAccess;
using FluentAssertions;
using System;
using System.Collections.Generic;
using Xunit;

namespace CADNS.Api.Services
{
	[Trait("Type", "Unit")]
	[Trait("Table", "Call")]
	[Trait("Area", "DALMapper")]
	public class TestDALCallMapper
	{
		[Fact]
		public void MapModelToEntity()
		{
			var mapper = new DALCallMapper();
			ApiCallServerRequestModel model = new ApiCallServerRequestModel();
			model.SetProperties(1, 1, 1, "A", 1, DateTime.Parse("1/1/1987 12:00:00 AM"), DateTime.Parse("1/1/1987 12:00:00 AM"), DateTime.Parse("1/1/1987 12:00:00 AM"), 1);
			Call response = mapper.MapModelToEntity(1, model);

			response.AddressId.Should().Be(1);
			response.CallDispositionId.Should().Be(1);
			response.CallStatusId.Should().Be(1);
			response.CallString.Should().Be("A");
			response.CallTypeId.Should().Be(1);
			response.DateCleared.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.DateCreated.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.DateDispatched.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.QuickCallNumber.Should().Be(1);
		}

		[Fact]
		public void MapEntityToModel()
		{
			var mapper = new DALCallMapper();
			Call item = new Call();
			item.SetProperties(1, 1, 1, 1, "A", 1, DateTime.Parse("1/1/1987 12:00:00 AM"), DateTime.Parse("1/1/1987 12:00:00 AM"), DateTime.Parse("1/1/1987 12:00:00 AM"), 1);
			ApiCallServerResponseModel response = mapper.MapEntityToModel(item);

			response.AddressId.Should().Be(1);
			response.CallDispositionId.Should().Be(1);
			response.CallStatusId.Should().Be(1);
			response.CallString.Should().Be("A");
			response.CallTypeId.Should().Be(1);
			response.DateCleared.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.DateCreated.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.DateDispatched.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.Id.Should().Be(1);
			response.QuickCallNumber.Should().Be(1);
		}

		[Fact]
		public void MapEntityToModelList()
		{
			var mapper = new DALCallMapper();
			Call item = new Call();
			item.SetProperties(1, 1, 1, 1, "A", 1, DateTime.Parse("1/1/1987 12:00:00 AM"), DateTime.Parse("1/1/1987 12:00:00 AM"), DateTime.Parse("1/1/1987 12:00:00 AM"), 1);
			List<ApiCallServerResponseModel> response = mapper.MapEntityToModel(new List<Call>() { { item} });

			response.Count.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>0745dd44792930e723a76354dc5e1d0e</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/