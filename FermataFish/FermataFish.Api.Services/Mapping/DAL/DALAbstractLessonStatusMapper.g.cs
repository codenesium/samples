using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace FermataFishNS.Api.Services
{
	public abstract class DALAbstractLessonStatusMapper
	{
		public virtual LessonStatus MapBOToEF(
			BOLessonStatus bo)
		{
			LessonStatus efLessonStatus = new LessonStatus();
			efLessonStatus.SetProperties(
				bo.Id,
				bo.Name,
				bo.StudioId);
			return efLessonStatus;
		}

		public virtual BOLessonStatus MapEFToBO(
			LessonStatus ef)
		{
			var bo = new BOLessonStatus();

			bo.SetProperties(
				ef.Id,
				ef.Name,
				ef.StudioId);
			return bo;
		}

		public virtual List<BOLessonStatus> MapEFToBO(
			List<LessonStatus> records)
		{
			List<BOLessonStatus> response = new List<BOLessonStatus>();

			records.ForEach(r =>
			{
				response.Add(this.MapEFToBO(r));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>9e4c771aa112744287885577c1b52b84</Hash>
</Codenesium>*/