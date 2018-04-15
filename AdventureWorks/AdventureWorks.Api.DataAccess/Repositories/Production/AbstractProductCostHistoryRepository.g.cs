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
		protected ApplicationDbContext context;
		protected ILogger logger;
		protected IObjectMapper mapper;

		public AbstractProductCostHistoryRepository(
			IObjectMapper mapper,
			ILogger logger,
			ApplicationDbContext context)
		{
			this.mapper = mapper;
			this.logger = logger;
			this.context = context;
		}

		public virtual int Create(
			ProductCostHistoryModel model)
		{
			var record = new EFProductCostHistory();

			this.mapper.ProductCostHistoryMapModelToEF(
				default (int),
				model,
				record);

			this.context.Set<EFProductCostHistory>().Add(record);
			this.context.SaveChanges();
			return record.ProductID;
		}

		public virtual void Update(
			int productID,
			ProductCostHistoryModel model)
		{
			var record = this.SearchLinqEF(x => x.ProductID == productID).FirstOrDefault();
			if (record == null)
			{
				this.logger.LogError($"Unable to find id:{productID}");
			}
			else
			{
				this.mapper.ProductCostHistoryMapModelToEF(
					productID,
					model,
					record);
				this.context.SaveChanges();
			}
		}

		public virtual void Delete(
			int productID)
		{
			var record = this.SearchLinqEF(x => x.ProductID == productID).FirstOrDefault();

			if (record == null)
			{
				return;
			}
			else
			{
				this.context.Set<EFProductCostHistory>().Remove(record);
				this.context.SaveChanges();
			}
		}

		public virtual ApiResponse GetById(int productID)
		{
			var response = new ApiResponse();

			this.SearchLinqPOCO(x => x.ProductID == productID, response);
			return response;
		}

		public virtual POCOProductCostHistory GetByIdDirect(int productID)
		{
			var response = new ApiResponse();

			this.SearchLinqPOCO(x => x.ProductID == productID, response);
			return response.ProductCostHistories.FirstOrDefault();
		}

		public virtual ApiResponse GetWhere(Expression<Func<EFProductCostHistory, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
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

		public virtual List<POCOProductCostHistory> GetWhereDirect(Expression<Func<EFProductCostHistory, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			var response = new ApiResponse();

			this.SearchLinqPOCO(predicate, response, skip, take, orderClause);
			return response.ProductCostHistories;
		}

		private void SearchLinqPOCO(Expression<Func<EFProductCostHistory, bool>> predicate, ApiResponse response, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<EFProductCostHistory> records = this.SearchLinqEF(predicate, skip, take, orderClause);
			records.ForEach(x => this.mapper.ProductCostHistoryMapEFToPOCO(x, response));
		}

		private void SearchLinqPOCODynamic(string predicate, ApiResponse response, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<EFProductCostHistory> records = this.SearchLinqEFDynamic(predicate, skip, take, orderClause);
			records.ForEach(x => this.mapper.ProductCostHistoryMapEFToPOCO(x, response));
		}

		protected virtual List<EFProductCostHistory> SearchLinqEF(Expression<Func<EFProductCostHistory, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			throw new NotImplementedException("This method should be implemented in a derived class");
		}

		protected virtual List<EFProductCostHistory> SearchLinqEFDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			throw new NotImplementedException("This method should be implemented in a derived class");
		}
	}
}

/*<Codenesium>
    <Hash>83f0e90faf20c0847a79ad384b651904</Hash>
</Codenesium>*/