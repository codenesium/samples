using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using AdventureWorksNS.Api.Contracts;

namespace AdventureWorksNS.Api.DataAccess
{
	public abstract class AbstractProductModelIllustrationRepository
	{
		protected ApplicationContext _context;
		protected ILogger _logger;

		public AbstractProductModelIllustrationRepository(ILogger logger,
		                                                  ApplicationContext context)
		{
			this._logger = logger;
			this._context = context;
		}

		public virtual int Create(int illustrationID,
		                          DateTime modifiedDate)
		{
			var record = new EFProductModelIllustration ();

			MapPOCOToEF(0, illustrationID,
			            modifiedDate, record);

			this._context.Set<EFProductModelIllustration>().Add(record);
			this._context.SaveChanges();
			return record.productModelID;
		}

		public virtual void Update(int productModelID, int illustrationID,
		                           DateTime modifiedDate)
		{
			var record =  this.SearchLinqEF(x => x.productModelID == productModelID).FirstOrDefault();
			if (record == null)
			{
				this._logger.LogError("Unable to find id:{0}",productModelID);
			}
			else
			{
				MapPOCOToEF(productModelID,  illustrationID,
				            modifiedDate, record);
				this._context.SaveChanges();
			}
		}

		public virtual void Delete(int productModelID)
		{
			var record = this.SearchLinqEF(x => x.productModelID == productModelID).FirstOrDefault();

			if (record == null)
			{
				return;
			}
			else
			{
				this._context.Set<EFProductModelIllustration>().Remove(record);
				this._context.SaveChanges();
			}
		}

		public virtual void GetById(int productModelID, Response response)
		{
			this.SearchLinqPOCO(x => x.productModelID == productModelID,response);
		}

		protected virtual List<EFProductModelIllustration> SearchLinqEF(Expression<Func<EFProductModelIllustration, bool>> predicate,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			throw new NotImplementedException("This method should be implemented in a derived class");
		}

		protected virtual List<EFProductModelIllustration> SearchLinqEFDynamic(string predicate,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			throw new NotImplementedException("This method should be implemented in a derived class");
		}

		public virtual void GetWhere(Expression<Func<EFProductModelIllustration, bool>> predicate, Response response,int skip = 0, int take = Int32.MaxValue, string orderClause = "")
		{
			this.SearchLinqPOCO(predicate, response, skip, take, orderClause);
		}

		public virtual void GetWhereDynamic(string predicate, Response response,int skip = 0, int take = Int32.MaxValue, string orderClause = "")
		{
			this.SearchLinqPOCODynamic(predicate, response, skip, take, orderClause);
		}

		private void SearchLinqPOCO(Expression<Func<EFProductModelIllustration, bool>> predicate,Response response,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			List<EFProductModelIllustration> records = this.SearchLinqEF(predicate,skip,take,orderClause);
			records.ForEach(x => MapEFToPOCO(x,response));
		}

		private void SearchLinqPOCODynamic(string predicate,Response response,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			List<EFProductModelIllustration> records = this.SearchLinqEFDynamic(predicate,skip,take,orderClause);
			records.ForEach(x => MapEFToPOCO(x,response));
		}

		public static void MapPOCOToEF(int productModelID, int illustrationID,
		                               DateTime modifiedDate, EFProductModelIllustration   efProductModelIllustration)
		{
			efProductModelIllustration.productModelID = productModelID;
			efProductModelIllustration.illustrationID = illustrationID;
			efProductModelIllustration.modifiedDate = modifiedDate;
		}

		public static void MapEFToPOCO(EFProductModelIllustration efProductModelIllustration,Response response)
		{
			if(efProductModelIllustration == null)
			{
				return;
			}
			response.AddProductModelIllustration(new POCOProductModelIllustration()
			{
				ProductModelID = efProductModelIllustration.productModelID.ToInt(),
				IllustrationID = efProductModelIllustration.illustrationID.ToInt(),
				ModifiedDate = efProductModelIllustration.modifiedDate.ToDateTime(),
			});
		}
	}
}

/*<Codenesium>
    <Hash>0e2d19b54a83545e9232b287ab9bcb10</Hash>
</Codenesium>*/