using System;
using Microsoft.EntityFrameworkCore;
using PetShippingNS.Api.Contracts;
namespace PetShippingNS.Api.DataAccess
{
	public abstract class AbstractDALEmployeeMapper
	{
		public virtual void MapDTOToEF(
			int id,
			DTOEmployee dto,
			Employee efEmployee)
		{
			efEmployee.SetProperties(
				id,
				dto.FirstName,
				dto.IsSalesPerson,
				dto.IsShipper,
				dto.LastName);
		}

		public virtual DTOEmployee MapEFToDTO(
			Employee ef)
		{
			if (ef == null)
			{
				return null;
			}

			var dto = new DTOEmployee();

			dto.SetProperties(
				ef.Id,
				ef.FirstName,
				ef.IsSalesPerson,
				ef.IsShipper,
				ef.LastName);
			return dto;
		}
	}
}

/*<Codenesium>
    <Hash>78b2fa52ddd56698aedebcf3eeeeee09</Hash>
</Codenesium>*/