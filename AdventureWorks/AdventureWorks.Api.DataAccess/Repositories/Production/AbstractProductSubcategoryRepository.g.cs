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
		protected ApplicationDbContext Context { get; }
		protected ILogger Logger { get; }
		protected IObjectMapper Mapper { get; }

		public AbstractProductSubcategoryRepository(
			IObjectMapper mapper,
			ILogger logger,
			ApplicationDbContext context)
		{
			this.Mapper = mapper;
			this.Logger = logger;
			this.Context = context;
		}

		public virtual List<POCOProductSubcategory> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqPOCO(x => true, skip, take, orderClause);
		}

		public virtual POCOProductSubcategory Get(int productSubcategoryID)
		{
			return this.SearchLinqPOCO(x => x.ProductSubcategoryID == productSubcategoryID).FirstOrDefault();
		}

		public virtual POCOProductSubcategory Create(
			ApiProductSubcategoryModel model)
		{
			ProductSubcategory record = new ProductSubcategory();

			this.Mapper.ProductSubcategoryMapModelToEF(
				default (int),
				model,
				record);

			this.Context.Set<ProductSubcategory>().Add(record);
			this.Context.SaveChanges();
			return this.Mapper.ProductSubcategoryMapEFToPOCO(record);
		}

		public virtual void Update(
			int productSubcategoryID,
			ApiProductSubcategoryModel model)
		{
			ProductSubcategory record = this.SearchLinqEF(x => x.ProductSubcategoryID == productSubcategoryID).FirstOrDefault();
			if (record == null)
			{
				throw new RecordNotFoundException($"Unable to find id:{productSubcategoryID}");
			}
			else
			{
				this.Mapper.ProductSubcategoryMapModelToEF(
					productSubcategoryID,
					model,
					record);
				this.Context.SaveChanges();
			}
		}

		public virtual void Delete(
			int productSubcategoryID)
		{
			ProductSubcategory record = this.SearchLinqEF(x => x.ProductSubcategoryID == productSubcategoryID).FirstOrDefault();

			if (record == null)
			{
				return;
			}
			else
			{
				this.Context.Set<ProductSubcategory>().Remove(record);
				this.Context.SaveChanges();
			}
		}

		public POCOProductSubcategory GetName(string name)
		{
			return this.SearchLinqPOCO(x => x.Name == name).FirstOrDefault();
		}

		protected List<POCOProductSubcategory> Where(Expression<Func<ProductSubcategory, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqPOCO(predicate, skip, take, orderClause);
		}

		private List<POCOProductSubcategory> SearchLinqPOCO(Expression<Func<ProductSubcategory, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<POCOProductSubcategory> response = new List<POCOProductSubcategory>();
			List<ProductSubcategory> records = this.SearchLinqEF(predicate, skip, take, orderClause);
			records.ForEach(x => response.Add(this.Mapper.ProductSubcategoryMapEFToPOCO(x)));
			return response;
		}

		private List<ProductSubcategory> SearchLinqEF(Expression<Func<ProductSubcategory, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrWhiteSpace(orderClause))
			{
				orderClause = $"{nameof(ProductSubcategory.ProductSubcategoryID)} ASC";
			}
			return this.Context.Set<ProductSubcategory>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<ProductSubcategory>();
		}

		private List<ProductSubcategory> SearchLinqEFDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrWhiteSpace(orderClause))
			{
				orderClause = $"{nameof(ProductSubcategory.ProductSubcategoryID)} ASC";
			}

			return this.Context.Set<ProductSubcategory>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<ProductSubcategory>();
		}
	}
}

/*<Codenesium>
    <Hash>e2aa8f6b76d951aa67222d6e87411608</Hash>
</Codenesium>*/