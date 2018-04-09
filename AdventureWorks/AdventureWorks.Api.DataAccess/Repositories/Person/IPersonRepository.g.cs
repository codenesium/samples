using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;

namespace AdventureWorksNS.Api.DataAccess
{
	public interface IPersonRepository
	{
		int Create(string personType,
		           bool nameStyle,
		           string title,
		           string firstName,
		           string middleName,
		           string lastName,
		           string suffix,
		           int emailPromotion,
		           string additionalContactInfo,
		           string demographics,
		           Guid rowguid,
		           DateTime modifiedDate);

		void Update(int businessEntityID, string personType,
		            bool nameStyle,
		            string title,
		            string firstName,
		            string middleName,
		            string lastName,
		            string suffix,
		            int emailPromotion,
		            string additionalContactInfo,
		            string demographics,
		            Guid rowguid,
		            DateTime modifiedDate);

		void Delete(int businessEntityID);

		Response GetById(int businessEntityID);

		POCOPerson GetByIdDirect(int businessEntityID);

		Response GetWhere(Expression<Func<EFPerson, bool>> predicate, int skip = 0, int take = Int32.MaxValue, string orderClause = "");

		List<POCOPerson> GetWhereDirect(Expression<Func<EFPerson, bool>> predicate, int skip = 0, int take = Int32.MaxValue, string orderClause = "");

		Response GetWhereDynamic(string predicate, int skip = 0, int take = Int32.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>360f7a6caeffec1a7a0c16ff775814ba</Hash>
</Codenesium>*/