using System;
using Microsoft.EntityFrameworkCore;
using AdventureWorksNS.Api.Contracts;
namespace AdventureWorksNS.Api.DataAccess
{
	public interface IDALStateProvinceMapper
	{
		void MapDTOToEF(
			int stateProvinceID,
			DTOStateProvince dto,
			StateProvince efStateProvince);

		DTOStateProvince MapEFToDTO(
			StateProvince efStateProvince);
	}
}

/*<Codenesium>
    <Hash>2b05f189851b1915126b4e12a6df6bca</Hash>
</Codenesium>*/