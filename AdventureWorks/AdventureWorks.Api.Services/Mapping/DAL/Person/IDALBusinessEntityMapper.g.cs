using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.Services
{
	public interface IDALBusinessEntityMapper
	{
		BusinessEntity MapBOToEF(
			BOBusinessEntity bo);

		BOBusinessEntity MapEFToBO(
			BusinessEntity efBusinessEntity);

		List<BOBusinessEntity> MapEFToBO(
			List<BusinessEntity> records);
	}
}

/*<Codenesium>
    <Hash>2d0b3650dc5011113a71d8c7139ae177</Hash>
</Codenesium>*/