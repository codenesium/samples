using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using TestsNS.Api.DataAccess;

namespace TestsNS.Api.Services
{
	public abstract class DALAbstractIncludedColumnTestMapper
	{
		public virtual IncludedColumnTest MapBOToEF(
			BOIncludedColumnTest bo)
		{
			IncludedColumnTest efIncludedColumnTest = new IncludedColumnTest();
			efIncludedColumnTest.SetProperties(
				bo.Id,
				bo.Name,
				bo.Name2);
			return efIncludedColumnTest;
		}

		public virtual BOIncludedColumnTest MapEFToBO(
			IncludedColumnTest ef)
		{
			var bo = new BOIncludedColumnTest();

			bo.SetProperties(
				ef.Id,
				ef.Name,
				ef.Name2);
			return bo;
		}

		public virtual List<BOIncludedColumnTest> MapEFToBO(
			List<IncludedColumnTest> records)
		{
			List<BOIncludedColumnTest> response = new List<BOIncludedColumnTest>();

			records.ForEach(r =>
			{
				response.Add(this.MapEFToBO(r));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>1af831c3a5fe3df6ccda17abc5e2e058</Hash>
</Codenesium>*/