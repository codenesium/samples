using System;
using System.Linq.Expressions;
using ESPIOTNS.Api.Contracts;

namespace ESPIOTNS.Api.DataAccess
{
	public interface IDeviceRepository
	{
		int Create(string name,
		           Guid publicId);

		void Update(int id, string name,
		            Guid publicId);

		void Delete(int id);

		void GetById(int id, Response response);

		void GetWhere(Expression<Func<Device, bool>> predicate, Response response,int skip = 0, int take = Int32.MaxValue, string orderClause = "");

		void GetWhereDynamic(string predicate, Response response,int skip = 0, int take = Int32.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>c438db5687e858a0d579dd8e6686b61c</Hash>
</Codenesium>*/