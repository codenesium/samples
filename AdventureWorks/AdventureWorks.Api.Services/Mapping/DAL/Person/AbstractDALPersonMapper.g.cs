using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
	public abstract class AbstractDALPersonMapper
	{
		public virtual Person MapModelToEntity(
			int businessEntityID,
			ApiPersonServerRequestModel model
			)
		{
			Person item = new Person();
			item.SetProperties(
				businessEntityID,
				model.AdditionalContactInfo,
				model.Demographic,
				model.EmailPromotion,
				model.FirstName,
				model.LastName,
				model.MiddleName,
				model.ModifiedDate,
				model.NameStyle,
				model.PersonType,
				model.Rowguid,
				model.Suffix,
				model.Title);
			return item;
		}

		public virtual ApiPersonServerResponseModel MapEntityToModel(
			Person item)
		{
			var model = new ApiPersonServerResponseModel();

			model.SetProperties(item.BusinessEntityID,
			                    item.AdditionalContactInfo,
			                    item.Demographic,
			                    item.EmailPromotion,
			                    item.FirstName,
			                    item.LastName,
			                    item.MiddleName,
			                    item.ModifiedDate,
			                    item.NameStyle,
			                    item.PersonType,
			                    item.Rowguid,
			                    item.Suffix,
			                    item.Title);
			if (item.BusinessEntityIDNavigation != null)
			{
				var businessEntityIDModel = new ApiBusinessEntityServerResponseModel();
				businessEntityIDModel.SetProperties(
					item.BusinessEntityIDNavigation.BusinessEntityID,
					item.BusinessEntityIDNavigation.ModifiedDate,
					item.BusinessEntityIDNavigation.Rowguid);

				model.SetBusinessEntityIDNavigation(businessEntityIDModel);
			}

			return model;
		}

		public virtual List<ApiPersonServerResponseModel> MapEntityToModel(
			List<Person> items)
		{
			List<ApiPersonServerResponseModel> response = new List<ApiPersonServerResponseModel>();

			items.ForEach(x =>
			{
				response.Add(this.MapEntityToModel(x));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>0976c9e8ab441f78713c8678ad7fa5f7</Hash>
</Codenesium>*/