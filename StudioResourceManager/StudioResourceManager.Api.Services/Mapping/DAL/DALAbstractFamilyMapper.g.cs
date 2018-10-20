using Microsoft.EntityFrameworkCore;
using StudioResourceManagerNS.Api.Contracts;
using StudioResourceManagerNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace StudioResourceManagerNS.Api.Services
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
				bo.PrimaryContactPhone,
				bo.IsDeleted);
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
				ef.PrimaryContactPhone,
				ef.IsDeleted);
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
    <Hash>ebab11fa4acf18ab178b4f2e88dfd9b4</Hash>
</Codenesium>*/