using System;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.BusinessObjects
{
	public abstract class AbstractBOLBusinessEntityContactMapper
	{
		public virtual DTOBusinessEntityContact MapModelToDTO(
			int businessEntityID,
			ApiBusinessEntityContactRequestModel model
			)
		{
			DTOBusinessEntityContact dtoBusinessEntityContact = new DTOBusinessEntityContact();

			dtoBusinessEntityContact.SetProperties(
				businessEntityID,
				model.ContactTypeID,
				model.ModifiedDate,
				model.PersonID,
				model.Rowguid);
			return dtoBusinessEntityContact;
		}

		public virtual ApiBusinessEntityContactResponseModel MapDTOToModel(
			DTOBusinessEntityContact dtoBusinessEntityContact)
		{
			if (dtoBusinessEntityContact == null)
			{
				return null;
			}

			var model = new ApiBusinessEntityContactResponseModel();

			model.SetProperties(dtoBusinessEntityContact.BusinessEntityID, dtoBusinessEntityContact.ContactTypeID, dtoBusinessEntityContact.ModifiedDate, dtoBusinessEntityContact.PersonID, dtoBusinessEntityContact.Rowguid);

			return model;
		}

		public virtual List<ApiBusinessEntityContactResponseModel> MapDTOToModel(
			List<DTOBusinessEntityContact> dtos)
		{
			List<ApiBusinessEntityContactResponseModel> response = new List<ApiBusinessEntityContactResponseModel>();

			dtos.ForEach(d =>
			{
				response.Add(this.MapDTOToModel(d));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>fbe448826f75d503d9e12d06de313036</Hash>
</Codenesium>*/