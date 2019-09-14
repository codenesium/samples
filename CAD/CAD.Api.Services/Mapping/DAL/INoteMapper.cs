using CADNS.Api.Contracts;
using CADNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace CADNS.Api.Services
{
	public partial interface IDALNoteMapper
	{
		Note MapModelToEntity(
			int id,
			ApiNoteServerRequestModel model);

		ApiNoteServerResponseModel MapEntityToModel(
			Note item);

		List<ApiNoteServerResponseModel> MapEntityToModel(
			List<Note> items);
	}
}

/*<Codenesium>
    <Hash>243a85222cde510a68ef0eac90431b50</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/