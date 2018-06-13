using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FileServiceNS.Api.DataAccess
{
        public interface IFileTypeRepository
        {
                Task<FileType> Create(FileType item);

                Task Update(FileType item);

                Task Delete(int id);

                Task<FileType> Get(int id);

                Task<List<FileType>> All(int limit = int.MaxValue, int offset =  0, string orderClause = "");

                Task<List<File>> Files(int fileTypeId, int limit = int.MaxValue, int offset = 0);
        }
}

/*<Codenesium>
    <Hash>7752064b54322e739ecd6669539d03bd</Hash>
</Codenesium>*/