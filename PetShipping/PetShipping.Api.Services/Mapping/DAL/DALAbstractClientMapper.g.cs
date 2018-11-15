using Microsoft.EntityFrameworkCore;
using PetShippingNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace PetShippingNS.Api.Services
{
	public abstract class DALAbstractClientMapper
	{
		public virtual Client MapBOToEF(
			BOClient bo)
		{
			Client efClient = new Client();
			efClient.SetProperties(
				bo.Email,
				bo.FirstName,
				bo.Id,
				bo.LastName,
				bo.Note,
				bo.Phone);
			return efClient;
		}

		public virtual BOClient MapEFToBO(
			Client ef)
		{
			var bo = new BOClient();

			bo.SetProperties(
				ef.Id,
				ef.Email,
				ef.FirstName,
				ef.LastName,
				ef.Note,
				ef.Phone);
			return bo;
		}

		public virtual List<BOClient> MapEFToBO(
			List<Client> records)
		{
			List<BOClient> response = new List<BOClient>();

			records.ForEach(r =>
			{
				response.Add(this.MapEFToBO(r));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>c1ebac0966cf119892a257bed3e70b0b</Hash>
</Codenesium>*/