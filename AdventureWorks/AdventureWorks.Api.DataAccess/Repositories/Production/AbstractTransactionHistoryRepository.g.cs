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
	public abstract class AbstractTransactionHistoryRepository
	{
		protected ApplicationDbContext Context { get; }
		protected ILogger Logger { get; }
		protected IObjectMapper Mapper { get; }

		public AbstractTransactionHistoryRepository(
			IObjectMapper mapper,
			ILogger logger,
			ApplicationDbContext context)
		{
			this.Mapper = mapper;
			this.Logger = logger;
			this.Context = context;
		}

		public virtual int Create(
			TransactionHistoryModel model)
		{
			EFTransactionHistory record = new EFTransactionHistory();

			this.Mapper.TransactionHistoryMapModelToEF(
				default (int),
				model,
				record);

			this.Context.Set<EFTransactionHistory>().Add(record);
			this.Context.SaveChanges();
			return record.TransactionID;
		}

		public virtual void Update(
			int transactionID,
			TransactionHistoryModel model)
		{
			EFTransactionHistory record = this.SearchLinqEF(x => x.TransactionID == transactionID).FirstOrDefault();
			if (record == null)
			{
				throw new RecordNotFoundException($"Unable to find id:{transactionID}");
			}
			else
			{
				this.Mapper.TransactionHistoryMapModelToEF(
					transactionID,
					model,
					record);
				this.Context.SaveChanges();
			}
		}

		public virtual void Delete(
			int transactionID)
		{
			EFTransactionHistory record = this.SearchLinqEF(x => x.TransactionID == transactionID).FirstOrDefault();

			if (record == null)
			{
				return;
			}
			else
			{
				this.Context.Set<EFTransactionHistory>().Remove(record);
				this.Context.SaveChanges();
			}
		}

		public virtual ApiResponse GetById(int transactionID)
		{
			return this.SearchLinqPOCO(x => x.TransactionID == transactionID);
		}

		public virtual POCOTransactionHistory GetByIdDirect(int transactionID)
		{
			return this.SearchLinqPOCO(x => x.TransactionID == transactionID).TransactionHistories.FirstOrDefault();
		}

		public virtual ApiResponse GetWhere(Expression<Func<EFTransactionHistory, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqPOCO(predicate, skip, take, orderClause);
		}

		public virtual ApiResponse GetWhereDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqPOCODynamic(predicate, skip, take, orderClause);
		}

		public virtual List<POCOTransactionHistory> GetWhereDirect(Expression<Func<EFTransactionHistory, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqPOCO(predicate, skip, take, orderClause).TransactionHistories;
		}

		private ApiResponse SearchLinqPOCO(Expression<Func<EFTransactionHistory, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			ApiResponse response = new ApiResponse();

			List<EFTransactionHistory> records = this.SearchLinqEF(predicate, skip, take, orderClause);
			records.ForEach(x => this.Mapper.TransactionHistoryMapEFToPOCO(x, response));
			return response;
		}

		private ApiResponse SearchLinqPOCODynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			ApiResponse response = new ApiResponse();

			List<EFTransactionHistory> records = this.SearchLinqEFDynamic(predicate, skip, take, orderClause);
			records.ForEach(x => this.Mapper.TransactionHistoryMapEFToPOCO(x, response));
			return response;
		}

		protected virtual List<EFTransactionHistory> SearchLinqEF(Expression<Func<EFTransactionHistory, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			throw new NotImplementedException("This method should be implemented in a derived class");
		}

		protected virtual List<EFTransactionHistory> SearchLinqEFDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			throw new NotImplementedException("This method should be implemented in a derived class");
		}
	}
}

/*<Codenesium>
    <Hash>a6d503998a85fe21b6faaa41f0360f9e</Hash>
</Codenesium>*/