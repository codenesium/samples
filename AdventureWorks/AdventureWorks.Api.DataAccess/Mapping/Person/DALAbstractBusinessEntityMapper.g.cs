using System;
using Microsoft.EntityFrameworkCore;
using AdventureWorksNS.Api.Contracts;
namespace AdventureWorksNS.Api.DataAccess
{
	public abstract class AbstractDALBusinessEntityMapper
	{
		public virtual void MapDTOToEF(
			int businessEntityID,
			DTOBusinessEntity dto,
			BusinessEntity efBusinessEntity)
		{
			efBusinessEntity.SetProperties(
				businessEntityID,
				dto.ModifiedDate,
				dto.Rowguid);
		}

		public virtual DTOBusinessEntity MapEFToDTO(
			BusinessEntity ef)
		{
			if (ef == null)
			{
				return null;
			}

			var dto = new DTOBusinessEntity();

			dto.SetProperties(
				ef.BusinessEntityID,
				ef.ModifiedDate,
				ef.Rowguid);
			return dto;
		}
	}
}

/*<Codenesium>
    <Hash>f4fc555c7fa42e79e1e86f181432383a</Hash>
</Codenesium>*/