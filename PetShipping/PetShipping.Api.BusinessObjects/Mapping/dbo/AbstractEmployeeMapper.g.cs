using System;
using System.Collections.Generic;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
namespace PetShippingNS.Api.BusinessObjects
{
	public abstract class AbstractBOLEmployeeMapper
	{
		public virtual DTOEmployee MapModelToDTO(
			int id,
			ApiEmployeeRequestModel model
			)
		{
			DTOEmployee dtoEmployee = new DTOEmployee();

			dtoEmployee.SetProperties(
				id,
				model.FirstName,
				model.IsSalesPerson,
				model.IsShipper,
				model.LastName);
			return dtoEmployee;
		}

		public virtual ApiEmployeeResponseModel MapDTOToModel(
			DTOEmployee dtoEmployee)
		{
			if (dtoEmployee == null)
			{
				return null;
			}

			var model = new ApiEmployeeResponseModel();

			model.SetProperties(dtoEmployee.FirstName, dtoEmployee.Id, dtoEmployee.IsSalesPerson, dtoEmployee.IsShipper, dtoEmployee.LastName);

			return model;
		}

		public virtual List<ApiEmployeeResponseModel> MapDTOToModel(
			List<DTOEmployee> dtos)
		{
			List<ApiEmployeeResponseModel> response = new List<ApiEmployeeResponseModel>();

			dtos.ForEach(d =>
			{
				response.Add(this.MapDTOToModel(d));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>0403e813e616c295696bf8e60b5d5ecf</Hash>
</Codenesium>*/