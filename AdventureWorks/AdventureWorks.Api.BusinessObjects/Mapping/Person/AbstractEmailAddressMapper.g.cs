using System;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.BusinessObjects
{
	public abstract class AbstractBOLEmailAddressMapper
	{
		public virtual DTOEmailAddress MapModelToDTO(
			int businessEntityID,
			ApiEmailAddressRequestModel model
			)
		{
			DTOEmailAddress dtoEmailAddress = new DTOEmailAddress();

			dtoEmailAddress.SetProperties(
				businessEntityID,
				model.EmailAddress1,
				model.EmailAddressID,
				model.ModifiedDate,
				model.Rowguid);
			return dtoEmailAddress;
		}

		public virtual ApiEmailAddressResponseModel MapDTOToModel(
			DTOEmailAddress dtoEmailAddress)
		{
			if (dtoEmailAddress == null)
			{
				return null;
			}

			var model = new ApiEmailAddressResponseModel();

			model.SetProperties(dtoEmailAddress.BusinessEntityID, dtoEmailAddress.EmailAddress1, dtoEmailAddress.EmailAddressID, dtoEmailAddress.ModifiedDate, dtoEmailAddress.Rowguid);

			return model;
		}

		public virtual List<ApiEmailAddressResponseModel> MapDTOToModel(
			List<DTOEmailAddress> dtos)
		{
			List<ApiEmailAddressResponseModel> response = new List<ApiEmailAddressResponseModel>();

			dtos.ForEach(d =>
			{
				response.Add(this.MapDTOToModel(d));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>b713a704fc46ec9f56e247e430def9ca</Hash>
</Codenesium>*/