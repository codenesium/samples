using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
	public abstract class AbstractDALPasswordMapper
	{
		public virtual Password MapModelToEntity(
			int businessEntityID,
			ApiPasswordServerRequestModel model
			)
		{
			Password item = new Password();
			item.SetProperties(
				businessEntityID,
				model.ModifiedDate,
				model.PasswordHash,
				model.PasswordSalt,
				model.Rowguid);
			return item;
		}

		public virtual ApiPasswordServerResponseModel MapEntityToModel(
			Password item)
		{
			var model = new ApiPasswordServerResponseModel();

			model.SetProperties(item.BusinessEntityID,
			                    item.ModifiedDate,
			                    item.PasswordHash,
			                    item.PasswordSalt,
			                    item.Rowguid);
			if (item.BusinessEntityIDNavigation != null)
			{
				var businessEntityIDModel = new ApiPersonServerResponseModel();
				businessEntityIDModel.SetProperties(
					item.BusinessEntityIDNavigation.BusinessEntityID,
					item.BusinessEntityIDNavigation.AdditionalContactInfo,
					item.BusinessEntityIDNavigation.Demographic,
					item.BusinessEntityIDNavigation.EmailPromotion,
					item.BusinessEntityIDNavigation.FirstName,
					item.BusinessEntityIDNavigation.LastName,
					item.BusinessEntityIDNavigation.MiddleName,
					item.BusinessEntityIDNavigation.ModifiedDate,
					item.BusinessEntityIDNavigation.NameStyle,
					item.BusinessEntityIDNavigation.PersonType,
					item.BusinessEntityIDNavigation.Rowguid,
					item.BusinessEntityIDNavigation.Suffix,
					item.BusinessEntityIDNavigation.Title);

				model.SetBusinessEntityIDNavigation(businessEntityIDModel);
			}

			return model;
		}

		public virtual List<ApiPasswordServerResponseModel> MapEntityToModel(
			List<Password> items)
		{
			List<ApiPasswordServerResponseModel> response = new List<ApiPasswordServerResponseModel>();

			items.ForEach(x =>
			{
				response.Add(this.MapEntityToModel(x));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>d90b6762acb75a2ad98a70c0fddae964</Hash>
</Codenesium>*/