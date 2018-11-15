using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
	public abstract class BOLAbstractPersonMapper
	{
		public virtual BOPerson MapModelToBO(
			int businessEntityID,
			ApiPersonServerRequestModel model
			)
		{
			BOPerson boPerson = new BOPerson();
			boPerson.SetProperties(
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
			return boPerson;
		}

		public virtual ApiPersonServerResponseModel MapBOToModel(
			BOPerson boPerson)
		{
			var model = new ApiPersonServerResponseModel();

			model.SetProperties(boPerson.BusinessEntityID, boPerson.AdditionalContactInfo, boPerson.Demographic, boPerson.EmailPromotion, boPerson.FirstName, boPerson.LastName, boPerson.MiddleName, boPerson.ModifiedDate, boPerson.NameStyle, boPerson.PersonType, boPerson.Rowguid, boPerson.Suffix, boPerson.Title);

			return model;
		}

		public virtual List<ApiPersonServerResponseModel> MapBOToModel(
			List<BOPerson> items)
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
    <Hash>24953e2fda54d64c2a33307206bb7d38</Hash>
</Codenesium>*/