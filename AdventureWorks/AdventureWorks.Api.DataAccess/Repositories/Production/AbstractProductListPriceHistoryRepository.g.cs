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

		public virtual int Create(
			ProductListPriceHistoryModel model)
		{
			EFProductListPriceHistory record = new EFProductListPriceHistory();

			this.Mapper.ProductListPriceHistoryMapModelToEF(
				default (int),
				model,
				record);

			this.Context.Set<EFProductListPriceHistory>().Add(record);
			this.Context.SaveChanges();
			return record.ProductID;
		}

		public virtual void Update(
			int productID,
			ProductListPriceHistoryModel model)
		{
			EFProductListPriceHistory record = this.SearchLinqEF(x => x.ProductID == productID).FirstOrDefault();
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
			EFProductListPriceHistory record = this.SearchLinqEF(x => x.ProductID == productID).FirstOrDefault();

			if (record == null)
			{
				return;
			}
			else
			{
				this.Context.Set<EFProductListPriceHistory>().Remove(record);
				this.Context.SaveChanges();
			}
		}

		public virtual ApiResponse GetById(int productID)
		{
			return this.SearchLinqPOCO(x => x.ProductID == productID);
		}

		public virtual POCOProductListPriceHistory GetByIdDirect(int productID)
		{
			return this.SearchLinqPOCO(x => x.ProductID == productID).ProductListPriceHistories.FirstOrDefault();
		}

		public virtual ApiResponse GetWhere(Expression<Func<EFProductListPriceHistory, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqPOCO(predicate, skip, take, orderClause);
		}

		public virtual ApiResponse GetWhereDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqPOCODynamic(predicate, skip, take, orderClause);
		}

		public virtual List<POCOProductListPriceHistory> GetWhereDirect(Expression<Func<EFProductListPriceHistory, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqPOCO(predicate, skip, take, orderClause).ProductListPriceHistories;
		}

		private ApiResponse SearchLinqPOCO(Expression<Func<EFProductListPriceHistory, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			ApiResponse response = new ApiResponse();

			List<EFProductListPriceHistory> records = this.SearchLinqEF(predicate, skip, take, orderClause);
			records.ForEach(x => this.Mapper.ProductListPriceHistoryMapEFToPOCO(x, response));
			return response;
		}

		private ApiResponse SearchLinqPOCODynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			ApiResponse response = new ApiResponse();

			List<EFProductListPriceHistory> records = this.SearchLinqEFDynamic(predicate, skip, take, orderClause);
			records.ForEach(x => this.Mapper.ProductListPriceHistoryMapEFToPOCO(x, response));
			return response;
		}

		protected virtual List<EFProductListPriceHistory> SearchLinqEF(Expression<Func<EFProductListPriceHistory, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			throw new NotImplementedException("This method should be implemented in a derived class");
		}

		protected virtual List<EFProductListPriceHistory> SearchLinqEFDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			throw new NotImplementedException("This method should be implemented in a derived class");
		}
	}
}

/*<Codenesium>
    <Hash>a33870710592b76c6f3032ec7a9818c2</Hash>
</Codenesium>*/