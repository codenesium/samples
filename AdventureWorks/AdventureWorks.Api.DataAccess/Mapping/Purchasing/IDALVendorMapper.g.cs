using System;
using Microsoft.EntityFrameworkCore;
using AdventureWorksNS.Api.Contracts;
namespace AdventureWorksNS.Api.DataAccess
{
	public interface IDALVendorMapper
	{
		void MapDTOToEF(
			int businessEntityID,
			DTOVendor dto,
			Vendor efVendor);

		DTOVendor MapEFToDTO(
			Vendor efVendor);
	}
}

/*<Codenesium>
    <Hash>835fe27d329b39e3319f0724bf17b2c4</Hash>
</Codenesium>*/