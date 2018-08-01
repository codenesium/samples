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
    <Hash>13426f32e6522ac4dc2a5f420d05b446</Hash>
</Codenesium>*/