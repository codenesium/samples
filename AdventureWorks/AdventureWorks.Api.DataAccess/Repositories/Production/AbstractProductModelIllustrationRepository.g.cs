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
		protected ApplicationDbContext context;
		protected ILogger logger;

		public AbstractProductModelIllustrationRepository(ILogger logger,
		                                                  ApplicationDbContext context)
		{
			this.logger = logger;
			this.context = context;
		}

		public virtual int Create(int illustrationID,
		                          DateTime modifiedDate)
		{
			var record = new EFProductModelIllustration ();

			MapPOCOToEF(0, illustrationID,
			            modifiedDate, record);

			this.context.Set<EFProductModelIllustration>().Add(record);
			this.context.SaveChanges();
			return record.ProductModelID;
		}

		public virtual void Update(int productModelID, int illustrationID,
		                           DateTime modifiedDate)
		{
			var record =  this.SearchLinqEF(x => x.ProductModelID == productModelID).FirstOrDefault();
			if (record == null)
			{
				this.logger.LogError("Unable to find id:{0}",productModelID);
			}
			else
			{
				MapPOCOToEF(productModelID,  illustrationID,
				            modifiedDate, record);
				this.context.SaveChanges();
			}
		}

		public virtual void Delete(int productModelID)
		{
			var record = this.SearchLinqEF(x => x.ProductModelID == productModelID).FirstOrDefault();

			if (record == null)
			{
				return;
			}
			else
			{
				this.context.Set<EFProductModelIllustration>().Remove(record);
				this.context.SaveChanges();
			}
		}

		public virtual void GetById(int productModelID, Response response)
		{
			this.SearchLinqPOCO(x => x.ProductModelID == productModelID,response);
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

		public virtual List<POCOProductModelIllustration > GetWhereDirect(Expression<Func<EFProductModelIllustration, bool>> predicate, int skip = 0, int take = Int32.MaxValue, string orderClause = "")
		{
			var response = new Response();

			this.SearchLinqPOCO(predicate, response, skip, take, orderClause);
			return response.ProductModelIllustrations;
		}
		public virtual POCOProductModelIllustration GetByIdDirect(int productModelID)
		{
			var response = new Response();

			this.SearchLinqPOCO(x => x.ProductModelID == productModelID,response);
			return response.ProductModelIllustrations.FirstOrDefault();
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
			efProductModelIllustration.ProductModelID = productModelID;
			efProductModelIllustration.IllustrationID = illustrationID;
			efProductModelIllustration.ModifiedDate = modifiedDate;
		}

		public static void MapEFToPOCO(EFProductModelIllustration efProductModelIllustration,Response response)
		{
			if(efProductModelIllustration == null)
			{
				return;
			}
			response.AddProductModelIllustration(new POCOProductModelIllustration()
			{
				ModifiedDate = efProductModelIllustration.ModifiedDate.ToDateTime(),

				ProductModelID = new ReferenceEntity<int>(efProductModelIllustration.ProductModelID,
				                                          "ProductModels"),
				IllustrationID = new ReferenceEntity<int>(efProductModelIllustration.IllustrationID,
				                                          "Illustrations"),
			});

			ProductModelRepository.MapEFToPOCO(efProductModelIllustration.ProductModel, response);

			IllustrationRepository.MapEFToPOCO(efProductModelIllustration.Illustration, response);
		}
	}
}

/*<Codenesium>
    <Hash>4b5197f480e75cb7cb2590ca29e60833</Hash>
</Codenesium>*/