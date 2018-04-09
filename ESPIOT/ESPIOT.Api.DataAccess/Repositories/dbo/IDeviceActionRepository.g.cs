using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using ESPIOTNS.Api.Contracts;

namespace ESPIOTNS.Api.DataAccess
{
	public interface IDeviceActionRepository
	{
		int Create(int deviceId,
		           string name,
		           string @value);

		void Update(int id, int deviceId,
		            string name,
		            string @value);

		void Delete(int id);

		Response GetById(int id);

		POCODeviceAction GetByIdDirect(int id);

		Response GetWhere(Expression<Func<EFDeviceAction, bool>> predicate, int skip = 0, int take = Int32.MaxValue, string orderClause = "");

		List<POCODeviceAction> GetWhereDirect(Expression<Func<EFDeviceAction, bool>> predicate, int skip = 0, int take = Int32.MaxValue, string orderClause = "");

		Response GetWhereDynamic(string predicate, int skip = 0, int take = Int32.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>c39f88e58f7bfbfbfafcac5d16318c98</Hash>
</Codenesium>*/