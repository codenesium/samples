using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using TestsNS.Api.Contracts;
using TestsNS.Api.DataAccess;

namespace TestsNS.Api.Services
{
	public abstract class DALAbstractVPersonMapper
	{
		public virtual VPerson MapBOToEF(
			BOVPerson bo)
		{
			VPerson efVPerson = new VPerson();
			efVPerson.SetProperties(
				bo.PersonId,
				bo.PersonName);
			return efVPerson;
		}

		public virtual BOVPerson MapEFToBO(
			VPerson ef)
		{
			var bo = new BOVPerson();

			bo.SetProperties(
				ef.PersonId,
				ef.PersonName);
			return bo;
		}

		public virtual List<BOVPerson> MapEFToBO(
			List<VPerson> records)
		{
			List<BOVPerson> response = new List<BOVPerson>();

			records.ForEach(r =>
			{
				response.Add(this.MapEFToBO(r));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>79ca228459edb3295dabb23b070ec69e</Hash>
</Codenesium>*/