using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using FileServiceNS.Api.Contracts;

namespace FileServiceNS.Api.DataAccess
{
	public interface IFileTypeRepository
	{
		POCOFileType Create(FileTypeModel model);

		void Update(int id,
		            FileTypeModel model);

		void Delete(int id);

		POCOFileType Get(int id);

		List<POCOFileType> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>933e78451e846d08ce5bdaf9391d04f2</Hash>
</Codenesium>*/