using System;
using System.Linq.Expressions;
using AdventureWorksNS.Api.Contracts;

namespace AdventureWorksNS.Api.DataAccess
{
	public interface IPhoneNumberTypeRepository
	{
		int Create(string name,
		           DateTime modifiedDate);

		void Update(int phoneNumberTypeID, string name,
		            DateTime modifiedDate);

		void Delete(int phoneNumberTypeID);

		void GetById(int phoneNumberTypeID, Response response);

		void GetWhere(Expression<Func<EFPhoneNumberType, bool>> predicate, Response response,int skip = 0, int take = Int32.MaxValue, string orderClause = "");

		void GetWhereDynamic(string predicate, Response response,int skip = 0, int take = Int32.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>8aeae50218003aaf5fff298fded55a93</Hash>
</Codenesium>*/