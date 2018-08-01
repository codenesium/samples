using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using TestsNS.Api.Contracts;
using TestsNS.Api.DataAccess;

namespace TestsNS.Api.Services
{
	public abstract class DALAbstractTimestampCheckMapper
	{
		public virtual TimestampCheck MapBOToEF(
			BOTimestampCheck bo)
		{
			TimestampCheck efTimestampCheck = new TimestampCheck();
			efTimestampCheck.SetProperties(
				bo.Id,
				bo.Name,
				bo.Timestamp);
			return efTimestampCheck;
		}

		public virtual BOTimestampCheck MapEFToBO(
			TimestampCheck ef)
		{
			var bo = new BOTimestampCheck();

			bo.SetProperties(
				ef.Id,
				ef.Name,
				ef.Timestamp);
			return bo;
		}

		public virtual List<BOTimestampCheck> MapEFToBO(
			List<TimestampCheck> records)
		{
			List<BOTimestampCheck> response = new List<BOTimestampCheck>();

			records.ForEach(r =>
			{
				response.Add(this.MapEFToBO(r));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>1b153f03e75ac444f6ad309ae84f3c90</Hash>
</Codenesium>*/