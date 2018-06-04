using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;
namespace FermataFishNS.Api.Services
{
	public abstract class AbstractDALStudentXFamilyMapper
	{
		public virtual StudentXFamily MapBOToEF(
			BOStudentXFamily bo)
		{
			StudentXFamily efStudentXFamily = new StudentXFamily ();

			efStudentXFamily.SetProperties(
				bo.FamilyId,
				bo.Id,
				bo.StudentId);
			return efStudentXFamily;
		}

		public virtual BOStudentXFamily MapEFToBO(
			StudentXFamily ef)
		{
			if (ef == null)
			{
				return null;
			}

			var bo = new BOStudentXFamily();

			bo.SetProperties(
				ef.Id,
				ef.FamilyId,
				ef.StudentId);
			return bo;
		}

		public virtual List<BOStudentXFamily> MapEFToBO(
			List<StudentXFamily> records)
		{
			List<BOStudentXFamily> response = new List<BOStudentXFamily>();

			records.ForEach(r =>
			{
				response.Add(this.MapEFToBO(r));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>3d188a725e665b0a87275e8337f7dd66</Hash>
</Codenesium>*/