using System;
using System.Linq.Expressions;
using FileServiceNS.Api.Contracts;

namespace FileServiceNS.Api.DataAccess
{
	public interface IFileRepository
	{
		int Create(Guid externalId,
		           string privateKey,
		           string publicKey,
		           string location,
		           DateTime expiration,
		           string extension,
		           DateTime dateCreated,
		           decimal fileSizeInBytes,
		           int fileTypeId,
		           Nullable<int> bucketId,
		           string description);

		void Update(int id, Guid externalId,
		            string privateKey,
		            string publicKey,
		            string location,
		            DateTime expiration,
		            string extension,
		            DateTime dateCreated,
		            decimal fileSizeInBytes,
		            int fileTypeId,
		            Nullable<int> bucketId,
		            string description);

		void Delete(int id);

		void GetById(int id, Response response);

		void GetWhere(Expression<Func<EFFile, bool>> predicate, Response response,int skip = 0, int take = Int32.MaxValue, string orderClause = "");

		void GetWhereDynamic(string predicate, Response response,int skip = 0, int take = Int32.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>83be8e6ce6eb9f4db1559135fc5203c5</Hash>
</Codenesium>*/