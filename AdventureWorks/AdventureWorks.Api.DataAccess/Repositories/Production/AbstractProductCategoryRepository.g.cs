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
	public abstract class AbstractProductCategoryRepository
	{
		protected ApplicationDbContext context;
		protected ILogger logger;
		protected IObjectMapper mapper;

		public AbstractProductCategoryRepository(
			IObjectMapper mapper,
			ILogger logger,
			ApplicationDbContext context)
		{
			this.mapper = mapper;
			this.logger = logger;
			this.context = context;
		}

		public virtual int Create(
			ProductCategoryModel model)
		{
			var record = new EFProductCategory();

			this.mapper.ProductCategoryMapModelToEF(
				default (int),
				model,
				record);

			this.context.Set<EFProductCategory>().Add(record);
			this.context.SaveChanges();
			return record.ProductCategoryID;
		}

		public virtual void Update(
			int productCategoryID,
			ProductCategoryModel model)
		{
			var record = this.SearchLinqEF(x => x.ProductCategoryID == productCategoryID).FirstOrDefault();
			if (record == null)
			{
				this.logger.LogError($"Unable to find id:{productCategoryID}");
			}
			else
			{
				this.mapper.ProductCategoryMapModelToEF(
					productCategoryID,
					model,
					record);
				this.context.SaveChanges();
			}
		}

		public virtual void Delete(
			int productCategoryID)
		{
			var record = this.SearchLinqEF(x => x.ProductCategoryID == productCategoryID).FirstOrDefault();

			if (record == null)
			{
				return;
			}
			else
			{
				this.context.Set<EFProductCategory>().Remove(record);
				this.context.SaveChanges();
			}
		}

		public virtual ApiResponse GetById(int productCategoryID)
		{
			var response = new ApiResponse();

			this.SearchLinqPOCO(x => x.ProductCategoryID == productCategoryID, response);
			return response;
		}

		public virtual POCOProductCategory GetByIdDirect(int productCategoryID)
		{
			var response = new ApiResponse();

			this.SearchLinqPOCO(x => x.ProductCategoryID == productCategoryID, response);
			return response.ProductCategories.FirstOrDefault();
		}

		public virtual ApiResponse GetWhere(Expression<Func<EFProductCategory, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			var response = new ApiResponse();

			this.SearchLinqPOCO(predicate, response, skip, take, orderClause);
			return response;
		}

		public virtual ApiResponse GetWhereDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			var response = new ApiResponse();

			this.SearchLinqPOCODynamic(predicate, response, skip, take, orderClause);
			return response;
		}

		public virtual List<POCOProductCategory> GetWhereDirect(Expression<Func<EFProductCategory, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			var response = new ApiResponse();

			this.SearchLinqPOCO(predicate, response, skip, take, orderClause);
			return response.ProductCategories;
		}

		private void SearchLinqPOCO(Expression<Func<EFProductCategory, bool>> predicate, ApiResponse response, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<EFProductCategory> records = this.SearchLinqEF(predicate, skip, take, orderClause);
			records.ForEach(x => this.mapper.ProductCategoryMapEFToPOCO(x, response));
		}

		private void SearchLinqPOCODynamic(string predicate, ApiResponse response, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<EFProductCategory> records = this.SearchLinqEFDynamic(predicate, skip, take, orderClause);
			records.ForEach(x => this.mapper.ProductCategoryMapEFToPOCO(x, response));
		}

		protected virtual List<EFProductCategory> SearchLinqEF(Expression<Func<EFProductCategory, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			throw new NotImplementedException("This method should be implemented in a derived class");
		}

		protected virtual List<EFProductCategory> SearchLinqEFDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			throw new NotImplementedException("This method should be implemented in a derived class");
		}
	}
}

/*<Codenesium>
    <Hash>9f15e79adead6f55d936f69671a6826e</Hash>
</Codenesium>*/