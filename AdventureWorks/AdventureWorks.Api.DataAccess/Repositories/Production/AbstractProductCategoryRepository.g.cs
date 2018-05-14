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
		protected ApplicationDbContext Context { get; }
		protected ILogger Logger { get; }
		protected IObjectMapper Mapper { get; }

		public AbstractProductCategoryRepository(
			IObjectMapper mapper,
			ILogger logger,
			ApplicationDbContext context)
		{
			this.Mapper = mapper;
			this.Logger = logger;
			this.Context = context;
		}

		public virtual List<POCOProductCategory> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqPOCO(x => true, skip, take, orderClause);
		}

		public virtual POCOProductCategory Get(int productCategoryID)
		{
			return this.SearchLinqPOCO(x => x.ProductCategoryID == productCategoryID).FirstOrDefault();
		}

		public virtual POCOProductCategory Create(
			ApiProductCategoryModel model)
		{
			ProductCategory record = new ProductCategory();

			this.Mapper.ProductCategoryMapModelToEF(
				default (int),
				model,
				record);

			this.Context.Set<ProductCategory>().Add(record);
			this.Context.SaveChanges();
			return this.Mapper.ProductCategoryMapEFToPOCO(record);
		}

		public virtual void Update(
			int productCategoryID,
			ApiProductCategoryModel model)
		{
			ProductCategory record = this.SearchLinqEF(x => x.ProductCategoryID == productCategoryID).FirstOrDefault();
			if (record == null)
			{
				throw new RecordNotFoundException($"Unable to find id:{productCategoryID}");
			}
			else
			{
				this.Mapper.ProductCategoryMapModelToEF(
					productCategoryID,
					model,
					record);
				this.Context.SaveChanges();
			}
		}

		public virtual void Delete(
			int productCategoryID)
		{
			ProductCategory record = this.SearchLinqEF(x => x.ProductCategoryID == productCategoryID).FirstOrDefault();

			if (record == null)
			{
				return;
			}
			else
			{
				this.Context.Set<ProductCategory>().Remove(record);
				this.Context.SaveChanges();
			}
		}

		public POCOProductCategory GetName(string name)
		{
			return this.SearchLinqPOCO(x => x.Name == name).FirstOrDefault();
		}

		protected List<POCOProductCategory> Where(Expression<Func<ProductCategory, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqPOCO(predicate, skip, take, orderClause);
		}

		private List<POCOProductCategory> SearchLinqPOCO(Expression<Func<ProductCategory, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<POCOProductCategory> response = new List<POCOProductCategory>();
			List<ProductCategory> records = this.SearchLinqEF(predicate, skip, take, orderClause);
			records.ForEach(x => response.Add(this.Mapper.ProductCategoryMapEFToPOCO(x)));
			return response;
		}

		private List<ProductCategory> SearchLinqEF(Expression<Func<ProductCategory, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrWhiteSpace(orderClause))
			{
				orderClause = $"{nameof(ProductCategory.ProductCategoryID)} ASC";
			}
			return this.Context.Set<ProductCategory>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<ProductCategory>();
		}

		private List<ProductCategory> SearchLinqEFDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrWhiteSpace(orderClause))
			{
				orderClause = $"{nameof(ProductCategory.ProductCategoryID)} ASC";
			}

			return this.Context.Set<ProductCategory>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<ProductCategory>();
		}
	}
}

/*<Codenesium>
    <Hash>130be8f796eee37822f0567c99bdc160</Hash>
</Codenesium>*/