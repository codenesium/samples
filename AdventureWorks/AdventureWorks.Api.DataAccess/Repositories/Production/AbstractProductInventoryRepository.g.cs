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
	public abstract class AbstractProductInventoryRepository
	{
		protected ApplicationDbContext Context { get; }
		protected ILogger Logger { get; }
		protected IObjectMapper Mapper { get; }

		public AbstractProductInventoryRepository(
			IObjectMapper mapper,
			ILogger logger,
			ApplicationDbContext context)
		{
			this.Mapper = mapper;
			this.Logger = logger;
			this.Context = context;
		}

		public virtual List<POCOProductInventory> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqPOCO(x => true, skip, take, orderClause);
		}

		public virtual POCOProductInventory Get(int productID)
		{
			return this.SearchLinqPOCO(x => x.ProductID == productID).FirstOrDefault();
		}

		public virtual POCOProductInventory Create(
			ApiProductInventoryModel model)
		{
			ProductInventory record = new ProductInventory();

			this.Mapper.ProductInventoryMapModelToEF(
				default (int),
				model,
				record);

			this.Context.Set<ProductInventory>().Add(record);
			this.Context.SaveChanges();
			return this.Mapper.ProductInventoryMapEFToPOCO(record);
		}

		public virtual void Update(
			int productID,
			ApiProductInventoryModel model)
		{
			ProductInventory record = this.SearchLinqEF(x => x.ProductID == productID).FirstOrDefault();
			if (record == null)
			{
				throw new RecordNotFoundException($"Unable to find id:{productID}");
			}
			else
			{
				this.Mapper.ProductInventoryMapModelToEF(
					productID,
					model,
					record);
				this.Context.SaveChanges();
			}
		}

		public virtual void Delete(
			int productID)
		{
			ProductInventory record = this.SearchLinqEF(x => x.ProductID == productID).FirstOrDefault();

			if (record == null)
			{
				return;
			}
			else
			{
				this.Context.Set<ProductInventory>().Remove(record);
				this.Context.SaveChanges();
			}
		}

		protected List<POCOProductInventory> Where(Expression<Func<ProductInventory, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqPOCO(predicate, skip, take, orderClause);
		}

		private List<POCOProductInventory> SearchLinqPOCO(Expression<Func<ProductInventory, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<POCOProductInventory> response = new List<POCOProductInventory>();
			List<ProductInventory> records = this.SearchLinqEF(predicate, skip, take, orderClause);
			records.ForEach(x => response.Add(this.Mapper.ProductInventoryMapEFToPOCO(x)));
			return response;
		}

		private List<ProductInventory> SearchLinqEF(Expression<Func<ProductInventory, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrWhiteSpace(orderClause))
			{
				orderClause = $"{nameof(ProductInventory.ProductID)} ASC";
			}
			return this.Context.Set<ProductInventory>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<ProductInventory>();
		}

		private List<ProductInventory> SearchLinqEFDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrWhiteSpace(orderClause))
			{
				orderClause = $"{nameof(ProductInventory.ProductID)} ASC";
			}

			return this.Context.Set<ProductInventory>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<ProductInventory>();
		}
	}
}

/*<Codenesium>
    <Hash>77b076826aa7922aa708ff0740074b80</Hash>
</Codenesium>*/