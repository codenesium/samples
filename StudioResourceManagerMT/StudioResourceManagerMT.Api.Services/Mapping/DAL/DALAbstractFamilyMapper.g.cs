using Microsoft.EntityFrameworkCore;
using StudioResourceManagerMTNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace StudioResourceManagerMTNS.Api.Services
{
	public abstract class DALAbstractFamilyMapper
	{
		public virtual Family MapBOToEF(
			BOFamily bo)
		{
			Family efFamily = new Family();
			efFamily.SetProperties(
				bo.Id,
				bo.Note,
				bo.PrimaryContactEmail,
				bo.PrimaryContactFirstName,
				bo.PrimaryContactLastName,
				bo.PrimaryContactPhone);
			return efFamily;
		}

		public virtual BOFamily MapEFToBO(
			Family ef)
		{
			var bo = new BOFamily();

			bo.SetProperties(
				ef.Id,
				ef.Note,
				ef.PrimaryContactEmail,
				ef.PrimaryContactFirstName,
				ef.PrimaryContactLastName,
				ef.PrimaryContactPhone);
			return bo;
		}

		public virtual List<BOFamily> MapEFToBO(
			List<Family> records)
		{
			List<BOFamily> response = new List<BOFamily>();

			records.ForEach(r =>
			{
				response.Add(this.MapEFToBO(r));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>29cf2839fc26cfeb134c4a46ecd4ac88</Hash>
</Codenesium>*/