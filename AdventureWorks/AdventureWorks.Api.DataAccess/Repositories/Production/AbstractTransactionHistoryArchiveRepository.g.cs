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
		protected ApplicationDbContext context;
		protected ILogger logger;
		protected IObjectMapper mapper;

		public AbstractTransactionHistoryArchiveRepository(
			IObjectMapper mapper,
			ILogger logger,
			ApplicationDbContext context)
		{
			this.mapper = mapper;
			this.logger = logger;
			this.context = context;
		}

		public virtual int Create(
			TransactionHistoryArchiveModel model)
		{
			var record = new EFTransactionHistoryArchive();

			this.mapper.TransactionHistoryArchiveMapModelToEF(
				default (int),
				model,
				record);

			this.context.Set<EFTransactionHistoryArchive>().Add(record);
			this.context.SaveChanges();
			return record.TransactionID;
		}

		public virtual void Update(
			int transactionID,
			TransactionHistoryArchiveModel model)
		{
			var record = this.SearchLinqEF(x => x.TransactionID == transactionID).FirstOrDefault();
			if (record == null)
			{
				this.logger.LogError($"Unable to find id:{transactionID}");
			}
			else
			{
				this.mapper.TransactionHistoryArchiveMapModelToEF(
					transactionID,
					model,
					record);
				this.context.SaveChanges();
			}
		}

		public virtual void Delete(
			int transactionID)
		{
			var record = this.SearchLinqEF(x => x.TransactionID == transactionID).FirstOrDefault();

			if (record == null)
			{
				return;
			}
			else
			{
				this.context.Set<EFTransactionHistoryArchive>().Remove(record);
				this.context.SaveChanges();
			}
		}

		public virtual ApiResponse GetById(int transactionID)
		{
			var response = new ApiResponse();

			this.SearchLinqPOCO(x => x.TransactionID == transactionID, response);
			return response;
		}

		public virtual POCOTransactionHistoryArchive GetByIdDirect(int transactionID)
		{
			var response = new ApiResponse();

			this.SearchLinqPOCO(x => x.TransactionID == transactionID, response);
			return response.TransactionHistoryArchives.FirstOrDefault();
		}

		public virtual ApiResponse GetWhere(Expression<Func<EFTransactionHistoryArchive, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
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

		public virtual List<POCOTransactionHistoryArchive> GetWhereDirect(Expression<Func<EFTransactionHistoryArchive, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			var response = new ApiResponse();

			this.SearchLinqPOCO(predicate, response, skip, take, orderClause);
			return response.TransactionHistoryArchives;
		}

		private void SearchLinqPOCO(Expression<Func<EFTransactionHistoryArchive, bool>> predicate, ApiResponse response, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<EFTransactionHistoryArchive> records = this.SearchLinqEF(predicate, skip, take, orderClause);
			records.ForEach(x => this.mapper.TransactionHistoryArchiveMapEFToPOCO(x, response));
		}

		private void SearchLinqPOCODynamic(string predicate, ApiResponse response, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<EFTransactionHistoryArchive> records = this.SearchLinqEFDynamic(predicate, skip, take, orderClause);
			records.ForEach(x => this.mapper.TransactionHistoryArchiveMapEFToPOCO(x, response));
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
    <Hash>b1cb8c141ccd8b76d6df31a757ce4443</Hash>
</Codenesium>*/