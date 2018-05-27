using System;
using Microsoft.EntityFrameworkCore;
using AdventureWorksNS.Api.Contracts;
namespace AdventureWorksNS.Api.DataAccess
{
	public abstract class AbstractDALDepartmentMapper
	{
		public virtual void MapDTOToEF(
			short departmentID,
			DTODepartment dto,
			Department efDepartment)
		{
			efDepartment.SetProperties(
				departmentID,
				dto.GroupName,
				dto.ModifiedDate,
				dto.Name);
		}

		public virtual DTODepartment MapEFToDTO(
			Department ef)
		{
			if (ef == null)
			{
				return null;
			}

			var dto = new DTODepartment();

			dto.SetProperties(
				ef.DepartmentID,
				ef.GroupName,
				ef.ModifiedDate,
				ef.Name);
			return dto;
		}
	}
}

/*<Codenesium>
    <Hash>1a5aa6e169daef47a9e43f4d78c663fe</Hash>
</Codenesium>*/