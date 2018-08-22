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
				bo.Id,
				bo.FamilyId,
				bo.StudentId,
				bo.StudioId);
			return efStudentXFamily;
		}

		public virtual BOStudentXFamily MapEFToBO(
			StudentXFamily ef)
		{
			var bo = new BOStudentXFamily();

			bo.SetProperties(
				ef.Id,
				ef.FamilyId,
				ef.StudentId,
				ef.StudioId);
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
    <Hash>aa8eb6d71f2c5e8686a5f5d5479f05bf</Hash>
</Codenesium>*/