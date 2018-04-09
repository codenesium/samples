using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;

namespace AdventureWorksNS.Api.DataAccess
{
	public interface IProductPhotoRepository
	{
		int Create(byte[] thumbNailPhoto,
		           string thumbnailPhotoFileName,
		           byte[] largePhoto,
		           string largePhotoFileName,
		           DateTime modifiedDate);

		void Update(int productPhotoID, byte[] thumbNailPhoto,
		            string thumbnailPhotoFileName,
		            byte[] largePhoto,
		            string largePhotoFileName,
		            DateTime modifiedDate);

		void Delete(int productPhotoID);

		Response GetById(int productPhotoID);

		POCOProductPhoto GetByIdDirect(int productPhotoID);

		Response GetWhere(Expression<Func<EFProductPhoto, bool>> predicate, int skip = 0, int take = Int32.MaxValue, string orderClause = "");

		List<POCOProductPhoto> GetWhereDirect(Expression<Func<EFProductPhoto, bool>> predicate, int skip = 0, int take = Int32.MaxValue, string orderClause = "");

		Response GetWhereDynamic(string predicate, int skip = 0, int take = Int32.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>b8c8f18d840f5670d42b2db6d271a631</Hash>
</Codenesium>*/