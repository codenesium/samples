using Microsoft.EntityFrameworkCore;
using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace NebulaNS.Api.Services
{
	public abstract class DALAbstractSysdiagramMapper
	{
		public virtual Sysdiagram MapBOToEF(
			BOSysdiagram bo)
		{
			Sysdiagram efSysdiagram = new Sysdiagram();
			efSysdiagram.SetProperties(
				bo.Definition,
				bo.DiagramId,
				bo.Name,
				bo.PrincipalId,
				bo.Version);
			return efSysdiagram;
		}

		public virtual BOSysdiagram MapEFToBO(
			Sysdiagram ef)
		{
			var bo = new BOSysdiagram();

			bo.SetProperties(
				ef.DiagramId,
				ef.Definition,
				ef.Name,
				ef.PrincipalId,
				ef.Version);
			return bo;
		}

		public virtual List<BOSysdiagram> MapEFToBO(
			List<Sysdiagram> records)
		{
			List<BOSysdiagram> response = new List<BOSysdiagram>();

			records.ForEach(r =>
			{
				response.Add(this.MapEFToBO(r));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>ccfa25849cc2703434a770c1d42a7372</Hash>
</Codenesium>*/