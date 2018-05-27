using System;
using Microsoft.EntityFrameworkCore;
using AdventureWorksNS.Api.Contracts;
namespace AdventureWorksNS.Api.DataAccess
{
	public abstract class AbstractDALStateProvinceMapper
	{
		public virtual void MapDTOToEF(
			int stateProvinceID,
			DTOStateProvince dto,
			StateProvince efStateProvince)
		{
			efStateProvince.SetProperties(
				stateProvinceID,
				dto.CountryRegionCode,
				dto.IsOnlyStateProvinceFlag,
				dto.ModifiedDate,
				dto.Name,
				dto.Rowguid,
				dto.StateProvinceCode,
				dto.TerritoryID);
		}

		public virtual DTOStateProvince MapEFToDTO(
			StateProvince ef)
		{
			if (ef == null)
			{
				return null;
			}

			var dto = new DTOStateProvince();

			dto.SetProperties(
				ef.StateProvinceID,
				ef.CountryRegionCode,
				ef.IsOnlyStateProvinceFlag,
				ef.ModifiedDate,
				ef.Name,
				ef.Rowguid,
				ef.StateProvinceCode,
				ef.TerritoryID);
			return dto;
		}
	}
}

/*<Codenesium>
    <Hash>53ae19f299d5edd88eb88a00ad161d68</Hash>
</Codenesium>*/