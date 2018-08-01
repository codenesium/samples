using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
	public abstract class DALAbstractIllustrationMapper
	{
		public virtual Illustration MapBOToEF(
			BOIllustration bo)
		{
			Illustration efIllustration = new Illustration();
			efIllustration.SetProperties(
				bo.Diagram,
				bo.IllustrationID,
				bo.ModifiedDate);
			return efIllustration;
		}

		public virtual BOIllustration MapEFToBO(
			Illustration ef)
		{
			var bo = new BOIllustration();

			bo.SetProperties(
				ef.IllustrationID,
				ef.Diagram,
				ef.ModifiedDate);
			return bo;
		}

		public virtual List<BOIllustration> MapEFToBO(
			List<Illustration> records)
		{
			List<BOIllustration> response = new List<BOIllustration>();

			records.ForEach(r =>
			{
				response.Add(this.MapEFToBO(r));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>9d1c48b7f80aec79a9137b7b8afb8bf1</Hash>
</Codenesium>*/