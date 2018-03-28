using System;
using System.Linq.Expressions;
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

		void GetById(int id, Response response);

		void GetWhere(Expression<Func<EFDeviceAction, bool>> predicate, Response response,int skip = 0, int take = Int32.MaxValue, string orderClause = "");

		void GetWhereDynamic(string predicate, Response response,int skip = 0, int take = Int32.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>961668d23ed3986b33ae6438d98c7534</Hash>
</Codenesium>*/