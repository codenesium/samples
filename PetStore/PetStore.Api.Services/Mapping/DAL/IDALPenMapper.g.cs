using Microsoft.EntityFrameworkCore;
using PetStoreNS.Api.Contracts;
using PetStoreNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace PetStoreNS.Api.Services
{
	public partial interface IDALPenMapper
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
    <Hash>d03c74b6095913556fa1d3fa65d8a160</Hash>
</Codenesium>*/