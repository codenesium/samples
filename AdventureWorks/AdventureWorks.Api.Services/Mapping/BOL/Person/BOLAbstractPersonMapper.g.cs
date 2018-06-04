using System;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.Services
{
	public abstract class BOLAbstractPersonMapper
	{
		public virtual BOPerson MapModelToBO(
			int businessEntityID,
			ApiPersonRequestModel model
			)
		{
			BOPerson BOPerson = new BOPerson();

			BOPerson.SetProperties(
				businessEntityID,
				model.AdditionalContactInfo,
				model.Demographics,
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
			return BOPerson;
		}

		public virtual ApiPersonResponseModel MapBOToModel(
			BOPerson BOPerson)
		{
			if (BOPerson == null)
			{
				return null;
			}

			var model = new ApiPersonResponseModel();

			model.SetProperties(BOPerson.AdditionalContactInfo, BOPerson.BusinessEntityID, BOPerson.Demographics, BOPerson.EmailPromotion, BOPerson.FirstName, BOPerson.LastName, BOPerson.MiddleName, BOPerson.ModifiedDate, BOPerson.NameStyle, BOPerson.PersonType, BOPerson.Rowguid, BOPerson.Suffix, BOPerson.Title);

			return model;
		}

		public virtual List<ApiPersonResponseModel> MapBOToModel(
			List<BOPerson> BOs)
		{
			List<ApiPersonResponseModel> response = new List<ApiPersonResponseModel>();

			BOs.ForEach(d =>
			{
				response.Add(this.MapBOToModel(d));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>5be2b5eec88f47cf7d49ef4bba550ded</Hash>
</Codenesium>*/