using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace FermataFishNS.Api.Services
{
	public abstract class DALAbstractStudentMapper
	{
		public virtual Student MapBOToEF(
			BOStudent bo)
		{
			Student efStudent = new Student();
			efStudent.SetProperties(
				bo.Birthday,
				bo.Email,
				bo.EmailRemindersEnabled,
				bo.FamilyId,
				bo.FirstName,
				bo.Id,
				bo.IsAdult,
				bo.LastName,
				bo.Phone,
				bo.SmsRemindersEnabled,
				bo.StudioId);
			return efStudent;
		}

		public virtual BOStudent MapEFToBO(
			Student ef)
		{
			var bo = new BOStudent();

			bo.SetProperties(
				ef.Id,
				ef.Birthday,
				ef.Email,
				ef.EmailRemindersEnabled,
				ef.FamilyId,
				ef.FirstName,
				ef.IsAdult,
				ef.LastName,
				ef.Phone,
				ef.SmsRemindersEnabled,
				ef.StudioId);
			return bo;
		}

		public virtual List<BOStudent> MapEFToBO(
			List<Student> records)
		{
			List<BOStudent> response = new List<BOStudent>();

			records.ForEach(r =>
			{
				response.Add(this.MapEFToBO(r));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>373216137727a738d864be16637efd30</Hash>
</Codenesium>*/