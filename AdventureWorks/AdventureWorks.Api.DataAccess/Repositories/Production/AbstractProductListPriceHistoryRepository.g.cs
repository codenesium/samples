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
	public abstract class AbstractProductListPriceHistoryRepository
	{
		protected ApplicationDbContext Context { get; }
		protected ILogger Logger { get; }
		protected IObjectMapper Mapper { get; }

		public AbstractProductListPriceHistoryRepository(
			IObjectMapper mapper,
			ILogger logger,
			ApplicationDbContext context)
		{
			this.Mapper = mapper;
			this.Logger = logger;
			this.Context = context;
		}

		public virtual List<POCOProductListPriceHistory> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqPOCO(x => true, skip, take, orderClause);
		}

		public virtual POCOProductListPriceHistory Get(int productID)
		{
			return this.SearchLinqPOCO(x => x.ProductID == productID).FirstOrDefault();
		}

		public virtual POCOProductListPriceHistory Create(
			ApiProductListPriceHistoryModel model)
		{
			ProductListPriceHistory record = new ProductListPriceHistory();

			this.Mapper.ProductListPriceHistoryMapModelToEF(
				default (int),
				model,
				record);

			this.Context.Set<ProductListPriceHistory>().Add(record);
			this.Context.SaveChanges();
			return this.Mapper.ProductListPriceHistoryMapEFToPOCO(record);
		}

		public virtual void Update(
			int productID,
			ApiProductListPriceHistoryModel model)
		{
			ProductListPriceHistory record = this.SearchLinqEF(x => x.ProductID == productID).FirstOrDefault();
			if (record == null)
			{
				throw new RecordNotFoundException($"Unable to find id:{productID}");
			}
			else
			{
				this.Mapper.ProductListPriceHistoryMapModelToEF(
					productID,
					model,
					record);
				this.Context.SaveChanges();
			}
		}

		public virtual void Delete(
			int productID)
		{
			ProductListPriceHistory record = this.SearchLinqEF(x => x.ProductID == productID).FirstOrDefault();

			if (record == null)
			{
				return;
			}
			else
			{
				this.Context.Set<ProductListPriceHistory>().Remove(record);
				this.Context.SaveChanges();
			}
		}

		protected List<POCOProductListPriceHistory> Where(Expression<Func<ProductListPriceHistory, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqPOCO(predicate, skip, take, orderClause);
		}

		private List<POCOProductListPriceHistory> SearchLinqPOCO(Expression<Func<ProductListPriceHistory, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<POCOProductListPriceHistory> response = new List<POCOProductListPriceHistory>();
			List<ProductListPriceHistory> records = this.SearchLinqEF(predicate, skip, take, orderClause);
			records.ForEach(x => response.Add(this.Mapper.ProductListPriceHistoryMapEFToPOCO(x)));
			return response;
		}

		private List<ProductListPriceHistory> SearchLinqEF(Expression<Func<ProductListPriceHistory, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrWhiteSpace(orderClause))
			{
				orderClause = $"{nameof(ProductListPriceHistory.ProductID)} ASC";
			}
			return this.Context.Set<ProductListPriceHistory>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<ProductListPriceHistory>();
		}

		private List<ProductListPriceHistory> SearchLinqEFDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrWhiteSpace(orderClause))
			{
				orderClause = $"{nameof(ProductListPriceHistory.ProductID)} ASC";
			}

			return this.Context.Set<ProductListPriceHistory>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<ProductListPriceHistory>();
		}
	}
}

/*<Codenesium>
    <Hash>d9ebc1fcd29a039d37b84922b0cac94e</Hash>
</Codenesium>*/