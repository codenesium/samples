using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.Services
{
	public abstract class AbstractDALShiftMapper
	{
		public virtual Shift MapBOToEF(
			BOShift bo)
		{
			Shift efShift = new Shift ();

			efShift.SetProperties(
				bo.EndTime,
				bo.ModifiedDate,
				bo.Name,
				bo.ShiftID,
				bo.StartTime);
			return efShift;
		}

		public virtual BOShift MapEFToBO(
			Shift ef)
		{
			if (ef == null)
			{
				return null;
			}

			var bo = new BOShift();

			bo.SetProperties(
				ef.ShiftID,
				ef.EndTime,
				ef.ModifiedDate,
				ef.Name,
				ef.StartTime);
			return bo;
		}

		public virtual List<BOShift> MapEFToBO(
			List<Shift> records)
		{
			List<BOShift> response = new List<BOShift>();

			records.ForEach(r =>
			{
				response.Add(this.MapEFToBO(r));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>31b64e30ad3388b0041887c3de7cb46a</Hash>
</Codenesium>*/