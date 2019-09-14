using CADNS.Api.Contracts;
using CADNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace CADNS.Api.Services
{
	public class DALNoteMapper : IDALNoteMapper
	{
		public virtual Note MapModelToEntity(
			int id,
			ApiNoteServerRequestModel model
			)
		{
			Note item = new Note();
			item.SetProperties(
				id,
				model.CallId,
				model.DateCreated,
				model.NoteText,
				model.OfficerId);
			return item;
		}

		public virtual ApiNoteServerResponseModel MapEntityToModel(
			Note item)
		{
			var model = new ApiNoteServerResponseModel();

			model.SetProperties(item.Id,
			                    item.CallId,
			                    item.DateCreated,
			                    item.NoteText,
			                    item.OfficerId);
			if (item.CallIdNavigation != null)
			{
				var callIdModel = new ApiCallServerResponseModel();
				callIdModel.SetProperties(
					item.CallIdNavigation.Id,
					item.CallIdNavigation.AddressId,
					item.CallIdNavigation.CallDispositionId,
					item.CallIdNavigation.CallStatusId,
					item.CallIdNavigation.CallString,
					item.CallIdNavigation.CallTypeId,
					item.CallIdNavigation.DateCleared,
					item.CallIdNavigation.DateCreated,
					item.CallIdNavigation.DateDispatched,
					item.CallIdNavigation.QuickCallNumber);

				model.SetCallIdNavigation(callIdModel);
			}

			if (item.OfficerIdNavigation != null)
			{
				var officerIdModel = new ApiOfficerServerResponseModel();
				officerIdModel.SetProperties(
					item.OfficerIdNavigation.Id,
					item.OfficerIdNavigation.Badge,
					item.OfficerIdNavigation.Email,
					item.OfficerIdNavigation.FirstName,
					item.OfficerIdNavigation.LastName,
					item.OfficerIdNavigation.Password);

				model.SetOfficerIdNavigation(officerIdModel);
			}

			return model;
		}

		public virtual List<ApiNoteServerResponseModel> MapEntityToModel(
			List<Note> items)
		{
			List<ApiNoteServerResponseModel> response = new List<ApiNoteServerResponseModel>();

			items.ForEach(x =>
			{
				response.Add(this.MapEntityToModel(x));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>87627527c1bb67ec9fd0030be9fa5e92</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/