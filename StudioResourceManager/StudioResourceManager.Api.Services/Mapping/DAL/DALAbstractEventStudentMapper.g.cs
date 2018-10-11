using Microsoft.EntityFrameworkCore;
using StudioResourceManagerNS.Api.Contracts;
using StudioResourceManagerNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace StudioResourceManagerNS.Api.Services
{
	public abstract class DALAbstractEventStudentMapper
	{
		public virtual EventStudent MapBOToEF(
			BOEventStudent bo)
		{
			EventStudent efEventStudent = new EventStudent();
			efEventStudent.SetProperties(
				bo.EventId,
				bo.StudentId);
			return efEventStudent;
		}

		public virtual BOEventStudent MapEFToBO(
			EventStudent ef)
		{
			var bo = new BOEventStudent();

			bo.SetProperties(
				ef.EventId,
				ef.StudentId);
			return bo;
		}

		public virtual List<BOEventStudent> MapEFToBO(
			List<EventStudent> records)
		{
			List<BOEventStudent> response = new List<BOEventStudent>();

			records.ForEach(r =>
			{
				response.Add(this.MapEFToBO(r));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>fe38412f25b5f8da07c2206e4f619818</Hash>
</Codenesium>*/