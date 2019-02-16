using FluentAssertions;
using System;
using System.Collections.Generic;
using TwitterNS.Api.Contracts;
using TwitterNS.Api.DataAccess;
using Xunit;

namespace TwitterNS.Api.Services
{
	[Trait("Type", "Unit")]
	[Trait("Table", "User")]
	[Trait("Area", "DALMapper")]
	public class TestDALUserMapper
	{
		[Fact]
		public void MapModelToEntity()
		{
			var mapper = new DALUserMapper();
			ApiUserServerRequestModel model = new ApiUserServerRequestModel();
			model.SetProperties("A", DateTime.Parse("1/1/1987 12:00:00 AM"), "A", "A", "A", "A", "A", 1, "A", "A", "A", "A", "A");
			User response = mapper.MapModelToEntity(1, model);

			response.BioImgUrl.Should().Be("A");
			response.Birthday.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.ContentDescription.Should().Be("A");
			response.Email.Should().Be("A");
			response.FullName.Should().Be("A");
			response.HeaderImgUrl.Should().Be("A");
			response.Interest.Should().Be("A");
			response.LocationLocationId.Should().Be(1);
			response.Password.Should().Be("A");
			response.PhoneNumber.Should().Be("A");
			response.Privacy.Should().Be("A");
			response.Username.Should().Be("A");
			response.Website.Should().Be("A");
		}

		[Fact]
		public void MapEntityToModel()
		{
			var mapper = new DALUserMapper();
			User item = new User();
			item.SetProperties(1, "A", DateTime.Parse("1/1/1987 12:00:00 AM"), "A", "A", "A", "A", "A", 1, "A", "A", "A", "A", "A");
			ApiUserServerResponseModel response = mapper.MapEntityToModel(item);

			response.BioImgUrl.Should().Be("A");
			response.Birthday.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.ContentDescription.Should().Be("A");
			response.Email.Should().Be("A");
			response.FullName.Should().Be("A");
			response.HeaderImgUrl.Should().Be("A");
			response.Interest.Should().Be("A");
			response.LocationLocationId.Should().Be(1);
			response.Password.Should().Be("A");
			response.PhoneNumber.Should().Be("A");
			response.Privacy.Should().Be("A");
			response.UserId.Should().Be(1);
			response.Username.Should().Be("A");
			response.Website.Should().Be("A");
		}

		[Fact]
		public void MapEntityToModelList()
		{
			var mapper = new DALUserMapper();
			User item = new User();
			item.SetProperties(1, "A", DateTime.Parse("1/1/1987 12:00:00 AM"), "A", "A", "A", "A", "A", 1, "A", "A", "A", "A", "A");
			List<ApiUserServerResponseModel> response = mapper.MapEntityToModel(new List<User>() { { item} });

			response.Count.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>de90fd22a9de47e769b15e0c27e94c46</Hash>
</Codenesium>*/