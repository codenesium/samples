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
	public abstract class AbstractProductModelProductDescriptionCultureRepository
	{
		protected ApplicationDbContext context;
		protected ILogger logger;

		public AbstractProductModelProductDescriptionCultureRepository(ILogger logger,
		                                                               ApplicationDbContext context)
		{
			this.logger = logger;
			this.context = context;
		}

		public virtual int Create(int productDescriptionID,
		                          string cultureID,
		                          DateTime modifiedDate)
		{
			var record = new EFProductModelProductDescriptionCulture ();

			MapPOCOToEF(0, productDescriptionID,
			            cultureID,
			            modifiedDate, record);

			this.context.Set<EFProductModelProductDescriptionCulture>().Add(record);
			this.context.SaveChanges();
			return record.ProductModelID;
		}

		public virtual void Update(int productModelID, int productDescriptionID,
		                           string cultureID,
		                           DateTime modifiedDate)
		{
			var record =  this.SearchLinqEF(x => x.ProductModelID == productModelID).FirstOrDefault();
			if (record == null)
			{
				this.logger.LogError("Unable to find id:{0}",productModelID);
			}
			else
			{
				MapPOCOToEF(productModelID,  productDescriptionID,
				            cultureID,
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
				this.context.Set<EFProductModelProductDescriptionCulture>().Remove(record);
				this.context.SaveChanges();
			}
		}

		public virtual void GetById(int productModelID, Response response)
		{
			this.SearchLinqPOCO(x => x.ProductModelID == productModelID,response);
		}

		protected virtual List<EFProductModelProductDescriptionCulture> SearchLinqEF(Expression<Func<EFProductModelProductDescriptionCulture, bool>> predicate,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			throw new NotImplementedException("This method should be implemented in a derived class");
		}

		protected virtual List<EFProductModelProductDescriptionCulture> SearchLinqEFDynamic(string predicate,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			throw new NotImplementedException("This method should be implemented in a derived class");
		}

		public virtual void GetWhere(Expression<Func<EFProductModelProductDescriptionCulture, bool>> predicate, Response response,int skip = 0, int take = Int32.MaxValue, string orderClause = "")
		{
			this.SearchLinqPOCO(predicate, response, skip, take, orderClause);
		}

		public virtual void GetWhereDynamic(string predicate, Response response,int skip = 0, int take = Int32.MaxValue, string orderClause = "")
		{
			this.SearchLinqPOCODynamic(predicate, response, skip, take, orderClause);
		}

		public virtual List<POCOProductModelProductDescriptionCulture> GetWhereDirect(Expression<Func<EFProductModelProductDescriptionCulture, bool>> predicate, int skip = 0, int take = Int32.MaxValue, string orderClause = "")
		{
			var response = new Response();

			this.SearchLinqPOCO(predicate, response, skip, take, orderClause);
			return response.ProductModelProductDescriptionCultures;
		}
		public virtual POCOProductModelProductDescriptionCulture GetByIdDirect(int productModelID)
		{
			var response = new Response();

			this.SearchLinqPOCO(x => x.ProductModelID == productModelID,response);
			return response.ProductModelProductDescriptionCultures.FirstOrDefault();
		}

		private void SearchLinqPOCO(Expression<Func<EFProductModelProductDescriptionCulture, bool>> predicate,Response response,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			List<EFProductModelProductDescriptionCulture> records = this.SearchLinqEF(predicate,skip,take,orderClause);
			records.ForEach(x => MapEFToPOCO(x,response));
		}

		private void SearchLinqPOCODynamic(string predicate,Response response,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			List<EFProductModelProductDescriptionCulture> records = this.SearchLinqEFDynamic(predicate,skip,take,orderClause);
			records.ForEach(x => MapEFToPOCO(x,response));
		}

		public static void MapPOCOToEF(int productModelID, int productDescriptionID,
		                               string cultureID,
		                               DateTime modifiedDate, EFProductModelProductDescriptionCulture   efProductModelProductDescriptionCulture)
		{
			efProductModelProductDescriptionCulture.ProductModelID = productModelID;
			efProductModelProductDescriptionCulture.ProductDescriptionID = productDescriptionID;
			efProductModelProductDescriptionCulture.CultureID = cultureID;
			efProductModelProductDescriptionCulture.ModifiedDate = modifiedDate;
		}

		public static void MapEFToPOCO(EFProductModelProductDescriptionCulture efProductModelProductDescriptionCulture,Response response)
		{
			if(efProductModelProductDescriptionCulture == null)
			{
				return;
			}
			response.AddProductModelProductDescriptionCulture(new POCOProductModelProductDescriptionCulture()
			{
				ModifiedDate = efProductModelProductDescriptionCulture.ModifiedDate.ToDateTime(),

				ProductModelID = new ReferenceEntity<int>(efProductModelProductDescriptionCulture.ProductModelID,
				                                          "ProductModels"),
				ProductDescriptionID = new ReferenceEntity<int>(efProductModelProductDescriptionCulture.ProductDescriptionID,
				                                                "ProductDescriptions"),
				CultureID = new ReferenceEntity<string>(efProductModelProductDescriptionCulture.CultureID,
				                                        "Cultures"),
			});

			ProductModelRepository.MapEFToPOCO(efProductModelProductDescriptionCulture.ProductModel, response);

			ProductDescriptionRepository.MapEFToPOCO(efProductModelProductDescriptionCulture.ProductDescription, response);

			CultureRepository.MapEFToPOCO(efProductModelProductDescriptionCulture.Culture, response);
		}
	}
}

/*<Codenesium>
    <Hash>3aecb72155d24e8bf0bd4183b5b51362</Hash>
</Codenesium>*/