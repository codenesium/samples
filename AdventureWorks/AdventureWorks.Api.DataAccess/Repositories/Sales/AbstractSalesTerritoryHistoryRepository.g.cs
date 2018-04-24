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
	public abstract class AbstractSalesTerritoryHistoryRepository
	{
		protected ApplicationDbContext Context { get; }
		protected ILogger Logger { get; }
		protected IObjectMapper Mapper { get; }

		public AbstractSalesTerritoryHistoryRepository(
			IObjectMapper mapper,
			ILogger logger,
			ApplicationDbContext context)
		{
			this.Mapper = mapper;
			this.Logger = logger;
			this.Context = context;
		}

		public virtual int Create(
			SalesTerritoryHistoryModel model)
		{
			EFSalesTerritoryHistory record = new EFSalesTerritoryHistory();

			this.Mapper.SalesTerritoryHistoryMapModelToEF(
				default (int),
				model,
				record);

			this.Context.Set<EFSalesTerritoryHistory>().Add(record);
			this.Context.SaveChanges();
			return record.BusinessEntityID;
		}

		public virtual void Update(
			int businessEntityID,
			SalesTerritoryHistoryModel model)
		{
			EFSalesTerritoryHistory record = this.SearchLinqEF(x => x.BusinessEntityID == businessEntityID).FirstOrDefault();
			if (record == null)
			{
				throw new RecordNotFoundException($"Unable to find id:{businessEntityID}");
			}
			else
			{
				this.Mapper.SalesTerritoryHistoryMapModelToEF(
					businessEntityID,
					model,
					record);
				this.Context.SaveChanges();
			}
		}

		public virtual void Delete(
			int businessEntityID)
		{
			EFSalesTerritoryHistory record = this.SearchLinqEF(x => x.BusinessEntityID == businessEntityID).FirstOrDefault();

			if (record == null)
			{
				return;
			}
			else
			{
				this.Context.Set<EFSalesTerritoryHistory>().Remove(record);
				this.Context.SaveChanges();
			}
		}

		public virtual ApiResponse GetById(int businessEntityID)
		{
			return this.SearchLinqPOCO(x => x.BusinessEntityID == businessEntityID);
		}

		public virtual POCOSalesTerritoryHistory GetByIdDirect(int businessEntityID)
		{
			return this.SearchLinqPOCO(x => x.BusinessEntityID == businessEntityID).SalesTerritoryHistories.FirstOrDefault();
		}

		public virtual ApiResponse GetWhere(Expression<Func<EFSalesTerritoryHistory, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqPOCO(predicate, skip, take, orderClause);
		}

		public virtual ApiResponse GetWhereDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqPOCODynamic(predicate, skip, take, orderClause);
		}

		public virtual List<POCOSalesTerritoryHistory> GetWhereDirect(Expression<Func<EFSalesTerritoryHistory, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqPOCO(predicate, skip, take, orderClause).SalesTerritoryHistories;
		}

		private ApiResponse SearchLinqPOCO(Expression<Func<EFSalesTerritoryHistory, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			ApiResponse response = new ApiResponse();

			List<EFSalesTerritoryHistory> records = this.SearchLinqEF(predicate, skip, take, orderClause);
			records.ForEach(x => this.Mapper.SalesTerritoryHistoryMapEFToPOCO(x, response));
			return response;
		}

		private ApiResponse SearchLinqPOCODynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			ApiResponse response = new ApiResponse();

			List<EFSalesTerritoryHistory> records = this.SearchLinqEFDynamic(predicate, skip, take, orderClause);
			records.ForEach(x => this.Mapper.SalesTerritoryHistoryMapEFToPOCO(x, response));
			return response;
		}

		protected virtual List<EFSalesTerritoryHistory> SearchLinqEF(Expression<Func<EFSalesTerritoryHistory, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			throw new NotImplementedException("This method should be implemented in a derived class");
		}

		protected virtual List<EFSalesTerritoryHistory> SearchLinqEFDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			throw new NotImplementedException("This method should be implemented in a derived class");
		}
	}
}

/*<Codenesium>
    <Hash>f1761a8e21becf8846335bf9ddfa9098</Hash>
</Codenesium>*/