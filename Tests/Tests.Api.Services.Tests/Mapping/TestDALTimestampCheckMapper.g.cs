using FluentAssertions;
using System;
using System.Collections.Generic;
using TestsNS.Api.Contracts;
using TestsNS.Api.DataAccess;
using Xunit;

namespace TestsNS.Api.Services
{
	[Trait("Type", "Unit")]
	[Trait("Table", "TimestampCheck")]
	[Trait("Area", "DALMapper")]
	public class TestDALTimestampCheckMapper
	{
		[Fact]
		public void MapModelToEntity()
		{
			var mapper = new DALTimestampCheckMapper();
			ApiTimestampCheckServerRequestModel model = new ApiTimestampCheckServerRequestModel();
			model.SetProperties("A", BitConverter.GetBytes(1));
			TimestampCheck response = mapper.MapModelToEntity(1, model);

			response.Name.Should().Be("A");
			response.Timestamp.Should().BeEquivalentTo(BitConverter.GetBytes(1));
		}

		[Fact]
		public void MapEntityToModel()
		{
			var mapper = new DALTimestampCheckMapper();
			TimestampCheck item = new TimestampCheck();
			item.SetProperties(1, "A", BitConverter.GetBytes(1));
			ApiTimestampCheckServerResponseModel response = mapper.MapEntityToModel(item);

			response.Id.Should().Be(1);
			response.Name.Should().Be("A");
			response.Timestamp.Should().BeEquivalentTo(BitConverter.GetBytes(1));
		}

		[Fact]
		public void MapEntityToModelList()
		{
			var mapper = new DALTimestampCheckMapper();
			TimestampCheck item = new TimestampCheck();
			item.SetProperties(1, "A", BitConverter.GetBytes(1));
			List<ApiTimestampCheckServerResponseModel> response = mapper.MapEntityToModel(new List<TimestampCheck>() { { item} });

			response.Count.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>ef741dbfc8c06084494280c6513c8a62</Hash>
</Codenesium>*/