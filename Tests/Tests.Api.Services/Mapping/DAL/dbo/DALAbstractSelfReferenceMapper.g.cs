using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using TestsNS.Api.DataAccess;

namespace TestsNS.Api.Services
{
	public abstract class DALAbstractSelfReferenceMapper
	{
		public virtual SelfReference MapBOToEF(
			BOSelfReference bo)
		{
			SelfReference efSelfReference = new SelfReference();
			efSelfReference.SetProperties(
				bo.Id,
				bo.SelfReferenceId,
				bo.SelfReferenceId2);
			return efSelfReference;
		}

		public virtual BOSelfReference MapEFToBO(
			SelfReference ef)
		{
			var bo = new BOSelfReference();

			bo.SetProperties(
				ef.Id,
				ef.SelfReferenceId,
				ef.SelfReferenceId2);
			return bo;
		}

		public virtual List<BOSelfReference> MapEFToBO(
			List<SelfReference> records)
		{
			List<BOSelfReference> response = new List<BOSelfReference>();

			records.ForEach(r =>
			{
				response.Add(this.MapEFToBO(r));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>42ebee1e348fe794f5054fe9df588843</Hash>
</Codenesium>*/