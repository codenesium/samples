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
    <Hash>7e79b7a7135797b150b4cf5d05ddedc6</Hash>
</Codenesium>*/