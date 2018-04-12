using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;

namespace AdventureWorksNS.Api.DataAccess
{
	public interface IProductPhotoRepository
	{
		int Create(
			byte[] thumbNailPhoto,
			string thumbnailPhotoFileName,
			byte[] largePhoto,
			string largePhotoFileName,
			DateTime modifiedDate);

		void Update(int productPhotoID,
		            byte[] thumbNailPhoto,
		            string thumbnailPhotoFileName,
		            byte[] largePhoto,
		            string largePhotoFileName,
		            DateTime modifiedDate);

		void Delete(int productPhotoID);

		Response GetById(int productPhotoID);

		POCOProductPhoto GetByIdDirect(int productPhotoID);

		Response GetWhere(Expression<Func<EFProductPhoto, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		List<POCOProductPhoto> GetWhereDirect(Expression<Func<EFProductPhoto, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		Response GetWhereDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>c80c9ce21d0dbaa284aed04dc60e2dd6</Hash>
</Codenesium>*/