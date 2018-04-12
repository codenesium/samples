using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using ESPIOTNS.Api.Contracts;

namespace ESPIOTNS.Api.DataAccess
{
	public interface IDeviceRepository
	{
		int Create(
			Guid publicId,
			string name);

		void Update(int id,
		            Guid publicId,
		            string name);

		void Delete(int id);

		Response GetById(int id);

		POCODevice GetByIdDirect(int id);

		Response GetWhere(Expression<Func<EFDevice, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		List<POCODevice> GetWhereDirect(Expression<Func<EFDevice, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		Response GetWhereDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>13d14a8a33f609b9d6c5ac076e30f889</Hash>
</Codenesium>*/