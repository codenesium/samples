using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FileServiceNS.Api.DataAccess
{
        public interface IFileRepository
        {
                Task<File> Create(File item);

                Task Update(File item);

                Task Delete(int id);

                Task<File> Get(int id);

                Task<List<File>> All(int limit = int.MaxValue, int offset =  0, string orderClause = "");
        }
}

/*<Codenesium>
    <Hash>911ed88c332e3c183cc06dca97ce36f6</Hash>
</Codenesium>*/