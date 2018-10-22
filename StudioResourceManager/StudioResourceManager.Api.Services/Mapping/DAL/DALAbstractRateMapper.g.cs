using Microsoft.EntityFrameworkCore;
using StudioResourceManagerNS.Api.Contracts;
using StudioResourceManagerNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace StudioResourceManagerNS.Api.Services
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
    <Hash>adec4e4a04a05e61e5aa9f4ccced2a90</Hash>
</Codenesium>*/