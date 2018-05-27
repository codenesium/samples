using System;
using Microsoft.EntityFrameworkCore;
using AdventureWorksNS.Api.Contracts;
namespace AdventureWorksNS.Api.DataAccess
{
	public interface IDALUnitMeasureMapper
	{
		void MapDTOToEF(
			string unitMeasureCode,
			DTOUnitMeasure dto,
			UnitMeasure efUnitMeasure);

		DTOUnitMeasure MapEFToDTO(
			UnitMeasure efUnitMeasure);
	}
}

/*<Codenesium>
    <Hash>7dcef506ed3567c3ef6462b30b782cb6</Hash>
</Codenesium>*/