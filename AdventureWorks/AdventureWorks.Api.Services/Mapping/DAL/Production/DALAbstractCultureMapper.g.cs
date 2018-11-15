using AdventureWorksNS.Api.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
	public abstract class DALAbstractCultureMapper
	{
		public virtual Culture MapBOToEF(
			BOCulture bo)
		{
			Culture efCulture = new Culture();
			efCulture.SetProperties(
				bo.CultureID,
				bo.ModifiedDate,
				bo.Name);
			return efCulture;
		}

		public virtual BOCulture MapEFToBO(
			Culture ef)
		{
			var bo = new BOCulture();

			bo.SetProperties(
				ef.CultureID,
				ef.ModifiedDate,
				ef.Name);
			return bo;
		}

		public virtual List<BOCulture> MapEFToBO(
			List<Culture> records)
		{
			List<BOCulture> response = new List<BOCulture>();

			records.ForEach(r =>
			{
				response.Add(this.MapEFToBO(r));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>2d57b12bd060060f779517e0c50f4430</Hash>
</Codenesium>*/