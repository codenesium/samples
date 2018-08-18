using Microsoft.EntityFrameworkCore;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace OctopusDeployNS.Api.Services
{
	public abstract class DALAbstractKeyAllocationMapper
	{
		public virtual KeyAllocation MapBOToEF(
			BOKeyAllocation bo)
		{
			KeyAllocation efKeyAllocation = new KeyAllocation();
			efKeyAllocation.SetProperties(
				bo.Allocated,
				bo.CollectionName);
			return efKeyAllocation;
		}

		public virtual BOKeyAllocation MapEFToBO(
			KeyAllocation ef)
		{
			var bo = new BOKeyAllocation();

			bo.SetProperties(
				ef.CollectionName,
				ef.Allocated);
			return bo;
		}

		public virtual List<BOKeyAllocation> MapEFToBO(
			List<KeyAllocation> records)
		{
			List<BOKeyAllocation> response = new List<BOKeyAllocation>();

			records.ForEach(r =>
			{
				response.Add(this.MapEFToBO(r));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>3d9f9345039d745b0a3095d88e6710b0</Hash>
</Codenesium>*/