using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using FileServiceNS.Api.Contracts;

namespace FileServiceNS.Api.DataAccess
{
	public interface IFileRepository
	{
		int Create(
			Guid externalId,
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

		void Update(int id,
		            Guid externalId,
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

		Response GetById(int id);

		POCOFile GetByIdDirect(int id);

		Response GetWhere(Expression<Func<EFFile, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		List<POCOFile> GetWhereDirect(Expression<Func<EFFile, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		Response GetWhereDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>f97cd73045cf67089d7a31cc6e1ad825</Hash>
</Codenesium>*/