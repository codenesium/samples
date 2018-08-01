using Microsoft.EntityFrameworkCore;
using PetStoreNS.Api.Contracts;
using PetStoreNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace PetStoreNS.Api.Services
{
	public interface IDALPenMapper
	{
		Pen MapBOToEF(
			BOPen bo);

		BOPen MapEFToBO(
			Pen efPen);

		List<BOPen> MapEFToBO(
			List<Pen> records);
	}
}

/*<Codenesium>
    <Hash>a5366070006483abdd982334d376dbd7</Hash>
</Codenesium>*/