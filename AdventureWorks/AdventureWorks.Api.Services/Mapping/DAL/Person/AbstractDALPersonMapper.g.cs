using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
	public abstract class AbstractDALPersonMapper
	{
		public virtual Person MapModelToBO(
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

		public virtual ApiPersonServerResponseModel MapBOToModel(
			Person item)
		{
			var model = new ApiPersonServerResponseModel();

			model.SetProperties(item.BusinessEntityID, item.AdditionalContactInfo, item.Demographic, item.EmailPromotion, item.FirstName, item.LastName, item.MiddleName, item.ModifiedDate, item.NameStyle, item.PersonType, item.Rowguid, item.Suffix, item.Title);

			return model;
		}

		public virtual List<ApiPersonServerResponseModel> MapBOToModel(
			List<Person> items)
		{
			List<ApiPersonServerResponseModel> response = new List<ApiPersonServerResponseModel>();

			items.ForEach(d =>
			{
				response.Add(this.MapBOToModel(d));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>3f6177d232dbefdc2dcf9b5f7e33692b</Hash>
</Codenesium>*/