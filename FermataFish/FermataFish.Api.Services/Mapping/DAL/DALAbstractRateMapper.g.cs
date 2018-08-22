using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace FermataFishNS.Api.Services
{
	public abstract class DALAbstractRateMapper
	{
		public virtual Rate MapBOToEF(
			BORate bo)
		{
			Rate efRate = new Rate();
			efRate.SetProperties(
				bo.Id,
				bo.AmountPerMinute,
				bo.TeacherId,
				bo.TeacherSkillId,
				bo.StudioId);
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
				ef.TeacherSkillId,
				ef.StudioId);
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
    <Hash>a263288491e8845a5c16286020b035a0</Hash>
</Codenesium>*/