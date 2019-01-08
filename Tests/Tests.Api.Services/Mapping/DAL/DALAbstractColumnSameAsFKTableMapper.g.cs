using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using TestsNS.Api.DataAccess;

namespace TestsNS.Api.Services
{
	public abstract class DALAbstractColumnSameAsFKTableMapper
	{
		public virtual ColumnSameAsFKTable MapBOToEF(
			BOColumnSameAsFKTable bo)
		{
			ColumnSameAsFKTable efColumnSameAsFKTable = new ColumnSameAsFKTable();
			efColumnSameAsFKTable.SetProperties(
				bo.Id,
				bo.Person,
				bo.PersonId);
			return efColumnSameAsFKTable;
		}

		public virtual BOColumnSameAsFKTable MapEFToBO(
			ColumnSameAsFKTable ef)
		{
			var bo = new BOColumnSameAsFKTable();

			bo.SetProperties(
				ef.Id,
				ef.Person,
				ef.PersonId);
			return bo;
		}

		public virtual List<BOColumnSameAsFKTable> MapEFToBO(
			List<ColumnSameAsFKTable> records)
		{
			List<BOColumnSameAsFKTable> response = new List<BOColumnSameAsFKTable>();

			records.ForEach(r =>
			{
				response.Add(this.MapEFToBO(r));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>a1d526630f8a75aa9b149c9b02a339ce</Hash>
</Codenesium>*/