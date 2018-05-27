using System;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.BusinessObjects
{
	public abstract class AbstractBOLPersonMapper
	{
		public virtual DTOPerson MapModelToDTO(
			int businessEntityID,
			ApiPersonRequestModel model
			)
		{
			DTOPerson dtoPerson = new DTOPerson();

			dtoPerson.SetProperties(
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
			return dtoPerson;
		}

		public virtual ApiPersonResponseModel MapDTOToModel(
			DTOPerson dtoPerson)
		{
			if (dtoPerson == null)
			{
				return null;
			}

			var model = new ApiPersonResponseModel();

			model.SetProperties(dtoPerson.AdditionalContactInfo, dtoPerson.BusinessEntityID, dtoPerson.Demographics, dtoPerson.EmailPromotion, dtoPerson.FirstName, dtoPerson.LastName, dtoPerson.MiddleName, dtoPerson.ModifiedDate, dtoPerson.NameStyle, dtoPerson.PersonType, dtoPerson.Rowguid, dtoPerson.Suffix, dtoPerson.Title);

			return model;
		}

		public virtual List<ApiPersonResponseModel> MapDTOToModel(
			List<DTOPerson> dtos)
		{
			List<ApiPersonResponseModel> response = new List<ApiPersonResponseModel>();

			dtos.ForEach(d =>
			{
				response.Add(this.MapDTOToModel(d));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>ba10474dc712e4a6d1aa923a8fa23e19</Hash>
</Codenesium>*/