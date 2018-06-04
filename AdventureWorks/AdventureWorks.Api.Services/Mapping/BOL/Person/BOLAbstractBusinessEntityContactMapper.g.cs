using System;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.Services
{
	public abstract class BOLAbstractBusinessEntityContactMapper
	{
		public virtual BOBusinessEntityContact MapModelToBO(
			int businessEntityID,
			ApiBusinessEntityContactRequestModel model
			)
		{
			BOBusinessEntityContact BOBusinessEntityContact = new BOBusinessEntityContact();

			BOBusinessEntityContact.SetProperties(
				businessEntityID,
				model.ContactTypeID,
				model.ModifiedDate,
				model.PersonID,
				model.Rowguid);
			return BOBusinessEntityContact;
		}

		public virtual ApiBusinessEntityContactResponseModel MapBOToModel(
			BOBusinessEntityContact BOBusinessEntityContact)
		{
			if (BOBusinessEntityContact == null)
			{
				return null;
			}

			var model = new ApiBusinessEntityContactResponseModel();

			model.SetProperties(BOBusinessEntityContact.BusinessEntityID, BOBusinessEntityContact.ContactTypeID, BOBusinessEntityContact.ModifiedDate, BOBusinessEntityContact.PersonID, BOBusinessEntityContact.Rowguid);

			return model;
		}

		public virtual List<ApiBusinessEntityContactResponseModel> MapBOToModel(
			List<BOBusinessEntityContact> BOs)
		{
			List<ApiBusinessEntityContactResponseModel> response = new List<ApiBusinessEntityContactResponseModel>();

			BOs.ForEach(d =>
			{
				response.Add(this.MapBOToModel(d));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>15e7944c9e8f034994f0c78ba9a09028</Hash>
</Codenesium>*/