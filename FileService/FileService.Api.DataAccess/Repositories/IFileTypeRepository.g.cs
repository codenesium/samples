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

                Task<List<FileType>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
        }
}

/*<Codenesium>
    <Hash>302a882e8cd6b62b745e3c342cb10984</Hash>
</Codenesium>*/