using System;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.BusinessObjects
{
	public abstract class AbstractBOLPasswordMapper
	{
		public virtual DTOPassword MapModelToDTO(
			int businessEntityID,
			ApiPasswordRequestModel model
			)
		{
			DTOPassword dtoPassword = new DTOPassword();

			dtoPassword.SetProperties(
				businessEntityID,
				model.ModifiedDate,
				model.PasswordHash,
				model.PasswordSalt,
				model.Rowguid);
			return dtoPassword;
		}

		public virtual ApiPasswordResponseModel MapDTOToModel(
			DTOPassword dtoPassword)
		{
			if (dtoPassword == null)
			{
				return null;
			}

			var model = new ApiPasswordResponseModel();

			model.SetProperties(dtoPassword.BusinessEntityID, dtoPassword.ModifiedDate, dtoPassword.PasswordHash, dtoPassword.PasswordSalt, dtoPassword.Rowguid);

			return model;
		}

		public virtual List<ApiPasswordResponseModel> MapDTOToModel(
			List<DTOPassword> dtos)
		{
			List<ApiPasswordResponseModel> response = new List<ApiPasswordResponseModel>();

			dtos.ForEach(d =>
			{
				response.Add(this.MapDTOToModel(d));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>582cde92930aeb24add9cff4b95f049c</Hash>
</Codenesium>*/