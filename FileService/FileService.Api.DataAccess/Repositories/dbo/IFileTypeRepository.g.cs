using System;
using System.Linq.Expressions;
using FileServiceNS.Api.Contracts;

namespace FileServiceNS.Api.DataAccess
{
	public interface IFileTypeRepository
	{
		int Create(string name);

		void Update(int id, string name);

		void Delete(int id);

		void GetById(int id, Response response);

		void GetWhere(Expression<Func<FileType, bool>> predicate, Response response,int skip = 0, int take = Int32.MaxValue, string orderClause = "");

		void GetWhereDynamic(string predicate, Response response,int skip = 0, int take = Int32.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>d869311879de9b74197ae631e51c99aa</Hash>
</Codenesium>*/