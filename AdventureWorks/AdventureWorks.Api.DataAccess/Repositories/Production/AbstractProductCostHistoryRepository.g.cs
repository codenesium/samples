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

		public virtual int Create(
			ProductCostHistoryModel model)
		{
			EFProductCostHistory record = new EFProductCostHistory();

			this.Mapper.ProductCostHistoryMapModelToEF(
				default (int),
				model,
				record);

			this.Context.Set<EFProductCostHistory>().Add(record);
			this.Context.SaveChanges();
			return record.ProductID;
		}

		public virtual void Update(
			int productID,
			ProductCostHistoryModel model)
		{
			EFProductCostHistory record = this.SearchLinqEF(x => x.ProductID == productID).FirstOrDefault();
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
			EFProductCostHistory record = this.SearchLinqEF(x => x.ProductID == productID).FirstOrDefault();

			if (record == null)
			{
				return;
			}
			else
			{
				this.Context.Set<EFProductCostHistory>().Remove(record);
				this.Context.SaveChanges();
			}
		}

		public virtual ApiResponse GetById(int productID)
		{
			return this.SearchLinqPOCO(x => x.ProductID == productID);
		}

		public virtual POCOProductCostHistory GetByIdDirect(int productID)
		{
			return this.SearchLinqPOCO(x => x.ProductID == productID).ProductCostHistories.FirstOrDefault();
		}

		public virtual ApiResponse GetWhere(Expression<Func<EFProductCostHistory, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqPOCO(predicate, skip, take, orderClause);
		}

		public virtual ApiResponse GetWhereDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqPOCODynamic(predicate, skip, take, orderClause);
		}

		public virtual List<POCOProductCostHistory> GetWhereDirect(Expression<Func<EFProductCostHistory, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqPOCO(predicate, skip, take, orderClause).ProductCostHistories;
		}

		private ApiResponse SearchLinqPOCO(Expression<Func<EFProductCostHistory, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			ApiResponse response = new ApiResponse();

			List<EFProductCostHistory> records = this.SearchLinqEF(predicate, skip, take, orderClause);
			records.ForEach(x => this.Mapper.ProductCostHistoryMapEFToPOCO(x, response));
			return response;
		}

		private ApiResponse SearchLinqPOCODynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			ApiResponse response = new ApiResponse();

			List<EFProductCostHistory> records = this.SearchLinqEFDynamic(predicate, skip, take, orderClause);
			records.ForEach(x => this.Mapper.ProductCostHistoryMapEFToPOCO(x, response));
			return response;
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
    <Hash>0a17ba1588f143bc697f3baa3100d45f</Hash>
</Codenesium>*/