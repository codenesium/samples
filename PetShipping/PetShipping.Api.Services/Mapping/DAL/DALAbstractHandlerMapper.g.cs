using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
namespace PetShippingNS.Api.Services
{
	public abstract class AbstractDALHandlerMapper
	{
		public virtual Handler MapBOToEF(
			BOHandler bo)
		{
			Handler efHandler = new Handler ();

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
			if (ef == null)
			{
				return null;
			}

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
    <Hash>8aeb83a795b956c6778646ba3b5714e8</Hash>
</Codenesium>*/