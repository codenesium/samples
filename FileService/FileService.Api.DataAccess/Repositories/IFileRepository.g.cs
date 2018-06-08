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

                Task<List<File>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
        }
}

/*<Codenesium>
    <Hash>2416cee98b1ced104c42502f0699b38e</Hash>
</Codenesium>*/