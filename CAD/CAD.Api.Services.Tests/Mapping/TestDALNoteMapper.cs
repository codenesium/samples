using CADNS.Api.Contracts;
using CADNS.Api.DataAccess;
using FluentAssertions;
using System;
using System.Collections.Generic;
using Xunit;

namespace CADNS.Api.Services
{
	[Trait("Type", "Unit")]
	[Trait("Table", "Note")]
	[Trait("Area", "DALMapper")]
	public class TestDALNoteMapper
	{
		[Fact]
		public void MapModelToEntity()
		{
			var mapper = new DALNoteMapper();
			ApiNoteServerRequestModel model = new ApiNoteServerRequestModel();
			model.SetProperties(1, DateTime.Parse("1/1/1987 12:00:00 AM"), "A", 1);
			Note response = mapper.MapModelToEntity(1, model);

			response.CallId.Should().Be(1);
			response.DateCreated.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.NoteText.Should().Be("A");
			response.OfficerId.Should().Be(1);
		}

		[Fact]
		public void MapEntityToModel()
		{
			var mapper = new DALNoteMapper();
			Note item = new Note();
			item.SetProperties(1, 1, DateTime.Parse("1/1/1987 12:00:00 AM"), "A", 1);
			ApiNoteServerResponseModel response = mapper.MapEntityToModel(item);

			response.CallId.Should().Be(1);
			response.DateCreated.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.Id.Should().Be(1);
			response.NoteText.Should().Be("A");
			response.OfficerId.Should().Be(1);
		}

		[Fact]
		public void MapEntityToModelList()
		{
			var mapper = new DALNoteMapper();
			Note item = new Note();
			item.SetProperties(1, 1, DateTime.Parse("1/1/1987 12:00:00 AM"), "A", 1);
			List<ApiNoteServerResponseModel> response = mapper.MapEntityToModel(new List<Note>() { { item} });

			response.Count.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>0bcc2b27eeba7631d8dfa363231a79e5</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/