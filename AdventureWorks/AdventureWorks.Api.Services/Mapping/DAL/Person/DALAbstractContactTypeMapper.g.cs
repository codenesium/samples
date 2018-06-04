using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.Services
{
	public abstract class AbstractDALContactTypeMapper
	{
		public virtual ContactType MapBOToEF(
			BOContactType bo)
		{
			ContactType efContactType = new ContactType ();

			efContactType.SetProperties(
				bo.ContactTypeID,
				bo.ModifiedDate,
				bo.Name);
			return efContactType;
		}

		public virtual BOContactType MapEFToBO(
			ContactType ef)
		{
			if (ef == null)
			{
				return null;
			}

			var bo = new BOContactType();

			bo.SetProperties(
				ef.ContactTypeID,
				ef.ModifiedDate,
				ef.Name);
			return bo;
		}

		public virtual List<BOContactType> MapEFToBO(
			List<ContactType> records)
		{
			List<BOContactType> response = new List<BOContactType>();

			records.ForEach(r =>
			{
				response.Add(this.MapEFToBO(r));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>58b3f7a6606e91c6595b10cfe45e5375</Hash>
</Codenesium>*/