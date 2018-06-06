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
			BOBusinessEntityContact boBusinessEntityContact = new BOBusinessEntityContact();

			boBusinessEntityContact.SetProperties(
				businessEntityID,
				model.ContactTypeID,
				model.ModifiedDate,
				model.PersonID,
				model.Rowguid);
			return boBusinessEntityContact;
		}

		public virtual ApiBusinessEntityContactResponseModel MapBOToModel(
			BOBusinessEntityContact boBusinessEntityContact)
		{
			var model = new ApiBusinessEntityContactResponseModel();

			model.SetProperties(boBusinessEntityContact.BusinessEntityID, boBusinessEntityContact.ContactTypeID, boBusinessEntityContact.ModifiedDate, boBusinessEntityContact.PersonID, boBusinessEntityContact.Rowguid);

			return model;
		}

		public virtual List<ApiBusinessEntityContactResponseModel> MapBOToModel(
			List<BOBusinessEntityContact> items)
		{
			List<ApiBusinessEntityContactResponseModel> response = new List<ApiBusinessEntityContactResponseModel>();

			items.ForEach(d =>
			{
				response.Add(this.MapBOToModel(d));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>ecb69391c6a2a10204ae8d8aaea7de1c</Hash>
</Codenesium>*/