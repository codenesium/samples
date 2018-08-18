using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace FermataFishNS.Api.Services
{
	public abstract class DALAbstractStudentXFamilyMapper
	{
		public virtual StudentXFamily MapBOToEF(
			BOStudentXFamily bo)
		{
			StudentXFamily efStudentXFamily = new StudentXFamily();
			efStudentXFamily.SetProperties(
				bo.FamilyId,
				bo.Id,
				bo.StudentId);
			return efStudentXFamily;
		}

		public virtual BOStudentXFamily MapEFToBO(
			StudentXFamily ef)
		{
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
    <Hash>0277fbda9afef3b05b68afea9bb1b310</Hash>
</Codenesium>*/