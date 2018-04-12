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
	public abstract class AbstractProductSubcategoryRepository
	{
		protected ApplicationDbContext context;
		protected ILogger logger;

		public AbstractProductSubcategoryRepository(
			ILogger logger,
			ApplicationDbContext context)
		{
			this.logger = logger;
			this.context = context;
		}

		public virtual int Create(
			int productCategoryID,
			string name,
			Guid rowguid,
			DateTime modifiedDate)
		{
			var record = new EFProductSubcategory();

			MapPOCOToEF(
				0,
				productCategoryID,
				name,
				rowguid,
				modifiedDate,
				record);

			this.context.Set<EFProductSubcategory>().Add(record);
			this.context.SaveChanges();
			return record.ProductSubcategoryID;
		}

		public virtual void Update(
			int productSubcategoryID,
			int productCategoryID,
			string name,
			Guid rowguid,
			DateTime modifiedDate)
		{
			var record = this.SearchLinqEF(x => x.ProductSubcategoryID == productSubcategoryID).FirstOrDefault();
			if (record == null)
			{
				this.logger.LogError($"Unable to find id:{productSubcategoryID}");
			}
			else
			{
				MapPOCOToEF(
					productSubcategoryID,
					productCategoryID,
					name,
					rowguid,
					modifiedDate,
					record);
				this.context.SaveChanges();
			}
		}

		public virtual void Delete(
			int productSubcategoryID)
		{
			var record = this.SearchLinqEF(x => x.ProductSubcategoryID == productSubcategoryID).FirstOrDefault();

			if (record == null)
			{
				return;
			}
			else
			{
				this.context.Set<EFProductSubcategory>().Remove(record);
				this.context.SaveChanges();
			}
		}

		public virtual Response GetById(int productSubcategoryID)
		{
			var response = new Response();

			this.SearchLinqPOCO(x => x.ProductSubcategoryID == productSubcategoryID, response);
			return response;
		}

		public virtual POCOProductSubcategory GetByIdDirect(int productSubcategoryID)
		{
			var response = new Response();

			this.SearchLinqPOCO(x => x.ProductSubcategoryID == productSubcategoryID, response);
			return response.ProductSubcategories.FirstOrDefault();
		}

		public virtual Response GetWhere(Expression<Func<EFProductSubcategory, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			var response = new Response();

			this.SearchLinqPOCO(predicate, response, skip, take, orderClause);
			return response;
		}

		public virtual Response GetWhereDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			var response = new Response();

			this.SearchLinqPOCODynamic(predicate, response, skip, take, orderClause);
			return response;
		}

		public virtual List<POCOProductSubcategory> GetWhereDirect(Expression<Func<EFProductSubcategory, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			var response = new Response();

			this.SearchLinqPOCO(predicate, response, skip, take, orderClause);
			return response.ProductSubcategories;
		}

		private void SearchLinqPOCO(Expression<Func<EFProductSubcategory, bool>> predicate, Response response, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<EFProductSubcategory> records = this.SearchLinqEF(predicate, skip, take, orderClause);
			records.ForEach(x => MapEFToPOCO(x, response));
		}

		private void SearchLinqPOCODynamic(string predicate, Response response, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<EFProductSubcategory> records = this.SearchLinqEFDynamic(predicate, skip, take, orderClause);
			records.ForEach(x => MapEFToPOCO(x, response));
		}

		protected virtual List<EFProductSubcategory> SearchLinqEF(Expression<Func<EFProductSubcategory, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			throw new NotImplementedException("This method should be implemented in a derived class");
		}

		protected virtual List<EFProductSubcategory> SearchLinqEFDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			throw new NotImplementedException("This method should be implemented in a derived class");
		}

		public static void MapPOCOToEF(
			int productSubcategoryID,
			int productCategoryID,
			string name,
			Guid rowguid,
			DateTime modifiedDate,
			EFProductSubcategory efProductSubcategory)
		{
			efProductSubcategory.SetProperties(productSubcategoryID.ToInt(), productCategoryID.ToInt(), name, rowguid, modifiedDate.ToDateTime());
		}

		public static void MapEFToPOCO(
			EFProductSubcategory efProductSubcategory,
			Response response)
		{
			if (efProductSubcategory == null)
			{
				return;
			}

			response.AddProductSubcategory(new POCOProductSubcategory(efProductSubcategory.ProductSubcategoryID.ToInt(), efProductSubcategory.ProductCategoryID.ToInt(), efProductSubcategory.Name, efProductSubcategory.Rowguid, efProductSubcategory.ModifiedDate.ToDateTime()));

			ProductCategoryRepository.MapEFToPOCO(efProductSubcategory.ProductCategory, response);
		}
	}
}

/*<Codenesium>
    <Hash>37ddd4c061b287ee5b9d15dba053fd57</Hash>
</Codenesium>*/