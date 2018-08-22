using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace FermataFishNS.Api.Services
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
				bo.PcEmail,
				bo.PcFirstName,
				bo.PcLastName,
				bo.PcPhone,
				bo.StudioId);
			return efFamily;
		}

		public virtual BOFamily MapEFToBO(
			Family ef)
		{
			var bo = new BOFamily();

			bo.SetProperties(
				ef.Id,
				ef.Note,
				ef.PcEmail,
				ef.PcFirstName,
				ef.PcLastName,
				ef.PcPhone,
				ef.StudioId);
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
    <Hash>af85a0254c7be0051bfd2b20e38e2bee</Hash>
</Codenesium>*/