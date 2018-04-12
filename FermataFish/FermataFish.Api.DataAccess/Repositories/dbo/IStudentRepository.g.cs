using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using FermataFishNS.Api.Contracts;

namespace FermataFishNS.Api.DataAccess
{
	public interface IStudentRepository
	{
		int Create(
			string email,
			string firstName,
			string lastName,
			string phone,
			bool isAdult,
			DateTime birthday,
			int familyId,
			int studioId,
			bool smsRemindersEnabled,
			bool emailRemindersEnabled);

		void Update(int id,
		            string email,
		            string firstName,
		            string lastName,
		            string phone,
		            bool isAdult,
		            DateTime birthday,
		            int familyId,
		            int studioId,
		            bool smsRemindersEnabled,
		            bool emailRemindersEnabled);

		void Delete(int id);

		Response GetById(int id);

		POCOStudent GetByIdDirect(int id);

		Response GetWhere(Expression<Func<EFStudent, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		List<POCOStudent> GetWhereDirect(Expression<Func<EFStudent, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		Response GetWhereDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>857597fb7e37896b61623f47721ff9dc</Hash>
</Codenesium>*/