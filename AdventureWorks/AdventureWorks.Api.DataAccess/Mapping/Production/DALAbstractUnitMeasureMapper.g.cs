using System;
using Microsoft.EntityFrameworkCore;
using AdventureWorksNS.Api.Contracts;
namespace AdventureWorksNS.Api.DataAccess
{
	public abstract class AbstractDALUnitMeasureMapper
	{
		public virtual void MapDTOToEF(
			string unitMeasureCode,
			DTOUnitMeasure dto,
			UnitMeasure efUnitMeasure)
		{
			efUnitMeasure.SetProperties(
				unitMeasureCode,
				dto.ModifiedDate,
				dto.Name);
		}

		public virtual DTOUnitMeasure MapEFToDTO(
			UnitMeasure ef)
		{
			if (ef == null)
			{
				return null;
			}

			var dto = new DTOUnitMeasure();

			dto.SetProperties(
				ef.UnitMeasureCode,
				ef.ModifiedDate,
				ef.Name);
			return dto;
		}
	}
}

/*<Codenesium>
    <Hash>7fb4af8eaff71e05f808db93403467b9</Hash>
</Codenesium>*/