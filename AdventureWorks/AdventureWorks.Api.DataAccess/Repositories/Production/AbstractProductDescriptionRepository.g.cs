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
		protected ApplicationDbContext context;
		protected ILogger logger;

		public AbstractProductDescriptionRepository(ILogger logger,
		                                            ApplicationDbContext context)
		{
			this.logger = logger;
			this.context = context;
		}

		public virtual int Create(string description,
		                          Guid rowguid,
		                          DateTime modifiedDate)
		{
			var record = new EFProductDescription ();

			MapPOCOToEF(0, description,
			            rowguid,
			            modifiedDate, record);

			this.context.Set<EFProductDescription>().Add(record);
			this.context.SaveChanges();
			return record.ProductDescriptionID;
		}

		public virtual void Update(int productDescriptionID, string description,
		                           Guid rowguid,
		                           DateTime modifiedDate)
		{
			var record =  this.SearchLinqEF(x => x.ProductDescriptionID == productDescriptionID).FirstOrDefault();
			if (record == null)
			{
				this.logger.LogError($"Unable to find id:{productDescriptionID}");
			}
			else
			{
				MapPOCOToEF(productDescriptionID,  description,
				            rowguid,
				            modifiedDate, record);
				this.context.SaveChanges();
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
				this.context.Set<EFProductDescription>().Remove(record);
				this.context.SaveChanges();
			}
		}

		public virtual Response GetById(int productDescriptionID)
		{
			var response = new Response();

			this.SearchLinqPOCO(x => x.ProductDescriptionID == productDescriptionID,response);
			return response;
		}

		public virtual POCOProductDescription GetByIdDirect(int productDescriptionID)
		{
			var response = new Response();

			this.SearchLinqPOCO(x => x.ProductDescriptionID == productDescriptionID,response);
			return response.ProductDescriptions.FirstOrDefault();
		}

		public virtual Response GetWhere(Expression<Func<EFProductDescription, bool>> predicate, int skip = 0, int take = Int32.MaxValue, string orderClause = "")
		{
			var response = new Response();

			this.SearchLinqPOCO(predicate, response, skip, take, orderClause);
			return response;
		}

		public virtual Response GetWhereDynamic(string predicate, int skip = 0, int take = Int32.MaxValue, string orderClause = "")
		{
			var response = new Response();

			this.SearchLinqPOCODynamic(predicate, response, skip, take, orderClause);
			return response;
		}

		public virtual List<POCOProductDescription> GetWhereDirect(Expression<Func<EFProductDescription, bool>> predicate, int skip = 0, int take = Int32.MaxValue, string orderClause = "")
		{
			var response = new Response();

			this.SearchLinqPOCO(predicate, response, skip, take, orderClause);
			return response.ProductDescriptions;
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

		protected virtual List<EFProductDescription> SearchLinqEF(Expression<Func<EFProductDescription, bool>> predicate,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			throw new NotImplementedException("This method should be implemented in a derived class");
		}

		protected virtual List<EFProductDescription> SearchLinqEFDynamic(string predicate,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			throw new NotImplementedException("This method should be implemented in a derived class");
		}

		public static void MapPOCOToEF(int productDescriptionID, string description,
		                               Guid rowguid,
		                               DateTime modifiedDate, EFProductDescription   efProductDescription)
		{
			efProductDescription.SetProperties(productDescriptionID.ToInt(),description,rowguid,modifiedDate.ToDateTime());
		}

		public static void MapEFToPOCO(EFProductDescription efProductDescription,Response response)
		{
			if(efProductDescription == null)
			{
				return;
			}
			response.AddProductDescription(new POCOProductDescription(efProductDescription.ProductDescriptionID.ToInt(),efProductDescription.Description,efProductDescription.Rowguid,efProductDescription.ModifiedDate.ToDateTime()));
		}
	}
}

/*<Codenesium>
    <Hash>b9162da4d856ebcd65e3ee9441415fe1</Hash>
</Codenesium>*/