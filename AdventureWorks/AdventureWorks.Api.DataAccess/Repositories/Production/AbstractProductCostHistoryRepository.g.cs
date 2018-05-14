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
	public abstract class AbstractProductCostHistoryRepository
	{
		protected ApplicationDbContext Context { get; }
		protected ILogger Logger { get; }
		protected IObjectMapper Mapper { get; }

		public AbstractProductCostHistoryRepository(
			IObjectMapper mapper,
			ILogger logger,
			ApplicationDbContext context)
		{
			this.Mapper = mapper;
			this.Logger = logger;
			this.Context = context;
		}

		public virtual List<POCOProductCostHistory> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqPOCO(x => true, skip, take, orderClause);
		}

		public virtual POCOProductCostHistory Get(int productID)
		{
			return this.SearchLinqPOCO(x => x.ProductID == productID).FirstOrDefault();
		}

		public virtual POCOProductCostHistory Create(
			ApiProductCostHistoryModel model)
		{
			ProductCostHistory record = new ProductCostHistory();

			this.Mapper.ProductCostHistoryMapModelToEF(
				default (int),
				model,
				record);

			this.Context.Set<ProductCostHistory>().Add(record);
			this.Context.SaveChanges();
			return this.Mapper.ProductCostHistoryMapEFToPOCO(record);
		}

		public virtual void Update(
			int productID,
			ApiProductCostHistoryModel model)
		{
			ProductCostHistory record = this.SearchLinqEF(x => x.ProductID == productID).FirstOrDefault();
			if (record == null)
			{
				throw new RecordNotFoundException($"Unable to find id:{productID}");
			}
			else
			{
				this.Mapper.ProductCostHistoryMapModelToEF(
					productID,
					model,
					record);
				this.Context.SaveChanges();
			}
		}

		public virtual void Delete(
			int productID)
		{
			ProductCostHistory record = this.SearchLinqEF(x => x.ProductID == productID).FirstOrDefault();

			if (record == null)
			{
				return;
			}
			else
			{
				this.Context.Set<ProductCostHistory>().Remove(record);
				this.Context.SaveChanges();
			}
		}

		protected List<POCOProductCostHistory> Where(Expression<Func<ProductCostHistory, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqPOCO(predicate, skip, take, orderClause);
		}

		private List<POCOProductCostHistory> SearchLinqPOCO(Expression<Func<ProductCostHistory, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<POCOProductCostHistory> response = new List<POCOProductCostHistory>();
			List<ProductCostHistory> records = this.SearchLinqEF(predicate, skip, take, orderClause);
			records.ForEach(x => response.Add(this.Mapper.ProductCostHistoryMapEFToPOCO(x)));
			return response;
		}

		private List<ProductCostHistory> SearchLinqEF(Expression<Func<ProductCostHistory, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrWhiteSpace(orderClause))
			{
				orderClause = $"{nameof(ProductCostHistory.ProductID)} ASC";
			}
			return this.Context.Set<ProductCostHistory>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<ProductCostHistory>();
		}

		private List<ProductCostHistory> SearchLinqEFDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrWhiteSpace(orderClause))
			{
				orderClause = $"{nameof(ProductCostHistory.ProductID)} ASC";
			}

			return this.Context.Set<ProductCostHistory>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<ProductCostHistory>();
		}
	}
}

/*<Codenesium>
    <Hash>cb8457850740475762e9fd2178074434</Hash>
</Codenesium>*/