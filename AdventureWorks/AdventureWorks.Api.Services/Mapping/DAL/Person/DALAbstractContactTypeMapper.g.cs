using AdventureWorksNS.Api.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
	public abstract class DALAbstractContactTypeMapper
	{
		public virtual ContactType MapBOToEF(
			BOContactType bo)
		{
			ContactType efContactType = new ContactType();
			efContactType.SetProperties(
				bo.ContactTypeID,
				bo.ModifiedDate,
				bo.Name);
			return efContactType;
		}

		public virtual BOContactType MapEFToBO(
			ContactType ef)
		{
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
    <Hash>def3816dabc0f161f6dd8552e8b63ff8</Hash>
</Codenesium>*/