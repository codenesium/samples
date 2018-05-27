using System;
using Microsoft.EntityFrameworkCore;
using AdventureWorksNS.Api.Contracts;
namespace AdventureWorksNS.Api.DataAccess
{
	public abstract class AbstractDALStoreMapper
	{
		public virtual void MapDTOToEF(
			int businessEntityID,
			DTOStore dto,
			Store efStore)
		{
			efStore.SetProperties(
				businessEntityID,
				dto.Demographics,
				dto.ModifiedDate,
				dto.Name,
				dto.Rowguid,
				dto.SalesPersonID);
		}

		public virtual DTOStore MapEFToDTO(
			Store ef)
		{
			if (ef == null)
			{
				return null;
			}

			var dto = new DTOStore();

			dto.SetProperties(
				ef.BusinessEntityID,
				ef.Demographics,
				ef.ModifiedDate,
				ef.Name,
				ef.Rowguid,
				ef.SalesPersonID);
			return dto;
		}
	}
}

/*<Codenesium>
    <Hash>1453b26ec66daf8f3011eebc3676ca23</Hash>
</Codenesium>*/