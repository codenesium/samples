using System;
using System.Linq.Expressions;
using ESPIOTNS.Api.Contracts;

namespace ESPIOTNS.Api.DataAccess
{
	public interface IDeviceRepository
	{
		int Create(Guid publicId,
		           string name);

		void Update(int id, Guid publicId,
		            string name);

		void Delete(int id);

		void GetById(int id, Response response);

		void GetWhere(Expression<Func<EFDevice, bool>> predicate, Response response,int skip = 0, int take = Int32.MaxValue, string orderClause = "");

		void GetWhereDynamic(string predicate, Response response,int skip = 0, int take = Int32.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>cf69e4d935bb4b62daeafd5722fd6c91</Hash>
</Codenesium>*/