using System;
using System.Linq.Expressions;
using FileServiceNS.Api.Contracts;

namespace FileServiceNS.Api.DataAccess
{
	public interface IFileRepository
	{
		int Create(Nullable<int> bucketId,
		           DateTime dateCreated,
		           string description,
		           DateTime expiration,
		           string extension,
		           Guid externalId,
		           decimal fileSizeInBytes,
		           int fileTypeId,
		           string location,
		           string privateKey,
		           string publicKey);

		void Update(int id, Nullable<int> bucketId,
		            DateTime dateCreated,
		            string description,
		            DateTime expiration,
		            string extension,
		            Guid externalId,
		            decimal fileSizeInBytes,
		            int fileTypeId,
		            string location,
		            string privateKey,
		            string publicKey);

		void Delete(int id);

		void GetById(int id, Response response);

		void GetWhere(Expression<Func<File, bool>> predicate, Response response,int skip = 0, int take = Int32.MaxValue, string orderClause = "");

		void GetWhereDynamic(string predicate, Response response,int skip = 0, int take = Int32.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>f950d52364cab3db1bdb99e68814fe3c</Hash>
</Codenesium>*/