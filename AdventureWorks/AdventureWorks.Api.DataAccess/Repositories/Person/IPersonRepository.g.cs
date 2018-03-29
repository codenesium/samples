using System;
using System.Linq.Expressions;
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

		void GetById(int businessEntityID, Response response);

		void GetWhere(Expression<Func<EFPerson, bool>> predicate, Response response,int skip = 0, int take = Int32.MaxValue, string orderClause = "");

		void GetWhereDynamic(string predicate, Response response,int skip = 0, int take = Int32.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>0684f811584b83338689f091fd76c3c6</Hash>
</Codenesium>*/