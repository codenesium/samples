using System;
using System.Linq.Expressions;
using System.Collections.Generic;
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

		Response GetById(int id);

		POCODevice GetByIdDirect(int id);

		Response GetWhere(Expression<Func<EFDevice, bool>> predicate, int skip = 0, int take = Int32.MaxValue, string orderClause = "");

		List<POCODevice> GetWhereDirect(Expression<Func<EFDevice, bool>> predicate, int skip = 0, int take = Int32.MaxValue, string orderClause = "");

		Response GetWhereDynamic(string predicate, int skip = 0, int take = Int32.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>974ff5ee969750be6fca6ed05e8ed746</Hash>
</Codenesium>*/