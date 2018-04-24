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
	public abstract class AbstractTransactionHistoryArchiveRepository
	{
		protected ApplicationDbContext Context { get; }
		protected ILogger Logger { get; }
		protected IObjectMapper Mapper { get; }

		public AbstractTransactionHistoryArchiveRepository(
			IObjectMapper mapper,
			ILogger logger,
			ApplicationDbContext context)
		{
			this.Mapper = mapper;
			this.Logger = logger;
			this.Context = context;
		}

		public virtual int Create(
			TransactionHistoryArchiveModel model)
		{
			EFTransactionHistoryArchive record = new EFTransactionHistoryArchive();

			this.Mapper.TransactionHistoryArchiveMapModelToEF(
				default (int),
				model,
				record);

			this.Context.Set<EFTransactionHistoryArchive>().Add(record);
			this.Context.SaveChanges();
			return record.TransactionID;
		}

		public virtual void Update(
			int transactionID,
			TransactionHistoryArchiveModel model)
		{
			EFTransactionHistoryArchive record = this.SearchLinqEF(x => x.TransactionID == transactionID).FirstOrDefault();
			if (record == null)
			{
				throw new RecordNotFoundException($"Unable to find id:{transactionID}");
			}
			else
			{
				this.Mapper.TransactionHistoryArchiveMapModelToEF(
					transactionID,
					model,
					record);
				this.Context.SaveChanges();
			}
		}

		public virtual void Delete(
			int transactionID)
		{
			EFTransactionHistoryArchive record = this.SearchLinqEF(x => x.TransactionID == transactionID).FirstOrDefault();

			if (record == null)
			{
				return;
			}
			else
			{
				this.Context.Set<EFTransactionHistoryArchive>().Remove(record);
				this.Context.SaveChanges();
			}
		}

		public virtual ApiResponse GetById(int transactionID)
		{
			return this.SearchLinqPOCO(x => x.TransactionID == transactionID);
		}

		public virtual POCOTransactionHistoryArchive GetByIdDirect(int transactionID)
		{
			return this.SearchLinqPOCO(x => x.TransactionID == transactionID).TransactionHistoryArchives.FirstOrDefault();
		}

		public virtual ApiResponse GetWhere(Expression<Func<EFTransactionHistoryArchive, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqPOCO(predicate, skip, take, orderClause);
		}

		public virtual ApiResponse GetWhereDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqPOCODynamic(predicate, skip, take, orderClause);
		}

		public virtual List<POCOTransactionHistoryArchive> GetWhereDirect(Expression<Func<EFTransactionHistoryArchive, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqPOCO(predicate, skip, take, orderClause).TransactionHistoryArchives;
		}

		private ApiResponse SearchLinqPOCO(Expression<Func<EFTransactionHistoryArchive, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			ApiResponse response = new ApiResponse();

			List<EFTransactionHistoryArchive> records = this.SearchLinqEF(predicate, skip, take, orderClause);
			records.ForEach(x => this.Mapper.TransactionHistoryArchiveMapEFToPOCO(x, response));
			return response;
		}

		private ApiResponse SearchLinqPOCODynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			ApiResponse response = new ApiResponse();

			List<EFTransactionHistoryArchive> records = this.SearchLinqEFDynamic(predicate, skip, take, orderClause);
			records.ForEach(x => this.Mapper.TransactionHistoryArchiveMapEFToPOCO(x, response));
			return response;
		}

		protected virtual List<EFTransactionHistoryArchive> SearchLinqEF(Expression<Func<EFTransactionHistoryArchive, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			throw new NotImplementedException("This method should be implemented in a derived class");
		}

		protected virtual List<EFTransactionHistoryArchive> SearchLinqEFDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			throw new NotImplementedException("This method should be implemented in a derived class");
		}
	}
}

/*<Codenesium>
    <Hash>7ce2c9bc7e259ed6e09809d8eb9bdaba</Hash>
</Codenesium>*/