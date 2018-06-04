using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;
namespace FermataFishNS.Api.Services
{
	public abstract class AbstractDALRateMapper
	{
		public virtual Rate MapBOToEF(
			BORate bo)
		{
			Rate efRate = new Rate ();

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
			if (ef == null)
			{
				return null;
			}

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
    <Hash>773132af06945b2554dac0a87905b4f6</Hash>
</Codenesium>*/