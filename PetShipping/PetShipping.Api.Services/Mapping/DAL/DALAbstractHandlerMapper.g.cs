using Microsoft.EntityFrameworkCore;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace PetShippingNS.Api.Services
{
	public abstract class DALAbstractHandlerMapper
	{
		public virtual Handler MapBOToEF(
			BOHandler bo)
		{
			Handler efHandler = new Handler();
			efHandler.SetProperties(
				bo.CountryId,
				bo.Email,
				bo.FirstName,
				bo.Id,
				bo.LastName,
				bo.Phone);
			return efHandler;
		}

		public virtual BOHandler MapEFToBO(
			Handler ef)
		{
			var bo = new BOHandler();

			bo.SetProperties(
				ef.Id,
				ef.CountryId,
				ef.Email,
				ef.FirstName,
				ef.LastName,
				ef.Phone);
			return bo;
		}

		public virtual List<BOHandler> MapEFToBO(
			List<Handler> records)
		{
			List<BOHandler> response = new List<BOHandler>();

			records.ForEach(r =>
			{
				response.Add(this.MapEFToBO(r));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>b6036af3e7a539ec7a3df09b790d470c</Hash>
</Codenesium>*/