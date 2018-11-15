using Microsoft.EntityFrameworkCore;
using StudioResourceManagerMTNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace StudioResourceManagerMTNS.Api.Services
{
	public abstract class DALAbstractRateMapper
	{
		public virtual Rate MapBOToEF(
			BORate bo)
		{
			Rate efRate = new Rate();
			efRate.SetProperties(
				bo.AmountPerMinute,
				bo.Id,
				bo.TeacherId,
				bo.TeacherSkillId);
			return efRate;
		}

		public virtual BORate MapEFToBO(
			Rate ef)
		{
			var bo = new BORate();

			bo.SetProperties(
				ef.Id,
				ef.AmountPerMinute,
				ef.TeacherId,
				ef.TeacherSkillId);
			return bo;
		}

		public virtual List<BORate> MapEFToBO(
			List<Rate> records)
		{
			List<BORate> response = new List<BORate>();

			records.ForEach(r =>
			{
				response.Add(this.MapEFToBO(r));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>0e1b516354665905a4b35f41a70637c9</Hash>
</Codenesium>*/