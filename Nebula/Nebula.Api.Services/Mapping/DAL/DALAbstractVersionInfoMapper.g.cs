using Microsoft.EntityFrameworkCore;
using NebulaNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace NebulaNS.Api.Services
{
	public abstract class DALAbstractVersionInfoMapper
	{
		public virtual VersionInfo MapBOToEF(
			BOVersionInfo bo)
		{
			VersionInfo efVersionInfo = new VersionInfo();
			efVersionInfo.SetProperties(
				bo.AppliedOn,
				bo.Description,
				bo.Version);
			return efVersionInfo;
		}

		public virtual BOVersionInfo MapEFToBO(
			VersionInfo ef)
		{
			var bo = new BOVersionInfo();

			bo.SetProperties(
				ef.Version,
				ef.AppliedOn,
				ef.Description);
			return bo;
		}

		public virtual List<BOVersionInfo> MapEFToBO(
			List<VersionInfo> records)
		{
			List<BOVersionInfo> response = new List<BOVersionInfo>();

			records.ForEach(r =>
			{
				response.Add(this.MapEFToBO(r));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>0bfdd0a0d084583d3aaa0a6d87728158</Hash>
</Codenesium>*/