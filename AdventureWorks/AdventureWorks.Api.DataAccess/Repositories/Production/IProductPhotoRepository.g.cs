using System;
using System.Linq.Expressions;
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

		void GetById(int productPhotoID, Response response);

		void GetWhere(Expression<Func<EFProductPhoto, bool>> predicate, Response response,int skip = 0, int take = Int32.MaxValue, string orderClause = "");

		void GetWhereDynamic(string predicate, Response response,int skip = 0, int take = Int32.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>682ae3b98e13219fc552850121cefaa4</Hash>
</Codenesium>*/