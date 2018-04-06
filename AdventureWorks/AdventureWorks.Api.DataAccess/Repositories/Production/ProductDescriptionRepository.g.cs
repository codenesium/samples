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
	public abstract class AbstractProductDescriptionRepository
	{
		protected ApplicationContext _context;
		protected ILogger _logger;

		public AbstractProductDescriptionRepository(ILogger logger,
		                                            ApplicationContext context)
		{
			this._logger = logger;
			this._context = context;
		}

		public virtual int Create(string description,
		                          Guid rowguid,
		                          DateTime modifiedDate)
		{
			var record = new EFProductDescription ();

			MapPOCOToEF(0, description,
			            rowguid,
			            modifiedDate, record);

			this._context.Set<EFProductDescription>().Add(record);
			this._context.SaveChanges();
			return record.ProductDescriptionID;
		}

		public virtual void Update(int productDescriptionID, string description,
		                           Guid rowguid,
		                           DateTime modifiedDate)
		{
			var record =  this.SearchLinqEF(x => x.ProductDescriptionID == productDescriptionID).FirstOrDefault();
			if (record == null)
			{
				this._logger.LogError("Unable to find id:{0}",productDescriptionID);
			}
			else
			{
				MapPOCOToEF(productDescriptionID,  description,
				            rowguid,
				            modifiedDate, record);
				this._context.SaveChanges();
			}
		}

		public virtual void Delete(int productDescriptionID)
		{
			var record = this.SearchLinqEF(x => x.ProductDescriptionID == productDescriptionID).FirstOrDefault();

			if (record == null)
			{
				return;
			}
			else
			{
				this._context.Set<EFProductDescription>().Remove(record);
				this._context.SaveChanges();
			}
		}

		public virtual void GetById(int productDescriptionID, Response response)
		{
			this.SearchLinqPOCO(x => x.ProductDescriptionID == productDescriptionID,response);
		}

		protected virtual List<EFProductDescription> SearchLinqEF(Expression<Func<EFProductDescription, bool>> predicate,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			throw new NotImplementedException("This method should be implemented in a derived class");
		}

		protected virtual List<EFProductDescription> SearchLinqEFDynamic(string predicate,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			throw new NotImplementedException("This method should be implemented in a derived class");
		}

		public virtual void GetWhere(Expression<Func<EFProductDescription, bool>> predicate, Response response,int skip = 0, int take = Int32.MaxValue, string orderClause = "")
		{
			this.SearchLinqPOCO(predicate, response, skip, take, orderClause);
		}

		public virtual void GetWhereDynamic(string predicate, Response response,int skip = 0, int take = Int32.MaxValue, string orderClause = "")
		{
			this.SearchLinqPOCODynamic(predicate, response, skip, take, orderClause);
		}

		private void SearchLinqPOCO(Expression<Func<EFProductDescription, bool>> predicate,Response response,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			List<EFProductDescription> records = this.SearchLinqEF(predicate,skip,take,orderClause);
			records.ForEach(x => MapEFToPOCO(x,response));
		}

		private void SearchLinqPOCODynamic(string predicate,Response response,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			List<EFProductDescription> records = this.SearchLinqEFDynamic(predicate,skip,take,orderClause);
			records.ForEach(x => MapEFToPOCO(x,response));
		}

		public static void MapPOCOToEF(int productDescriptionID, string description,
		                               Guid rowguid,
		                               DateTime modifiedDate, EFProductDescription   efProductDescription)
		{
			efProductDescription.ProductDescriptionID = productDescriptionID;
			efProductDescription.Description = description;
			efProductDescription.Rowguid = rowguid;
			efProductDescription.ModifiedDate = modifiedDate;
		}

		public static void MapEFToPOCO(EFProductDescription efProductDescription,Response response)
		{
			if(efProductDescription == null)
			{
				return;
			}
			response.AddProductDescription(new POCOProductDescription()
			{
				ProductDescriptionID = efProductDescription.ProductDescriptionID.ToInt(),
				Description = efProductDescription.Description,
				Rowguid = efProductDescription.Rowguid,
				ModifiedDate = efProductDescription.ModifiedDate.ToDateTime(),
			});
		}
	}
}

/*<Codenesium>
    <Hash>c735325cea855629e5897bcfd971540d</Hash>
</Codenesium>*/