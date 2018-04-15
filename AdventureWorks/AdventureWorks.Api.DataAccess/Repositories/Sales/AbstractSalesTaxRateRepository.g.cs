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
	public abstract class AbstractSalesTaxRateRepository
	{
		protected ApplicationDbContext context;
		protected ILogger logger;
		protected IObjectMapper mapper;

		public AbstractSalesTaxRateRepository(
			IObjectMapper mapper,
			ILogger logger,
			ApplicationDbContext context)
		{
			this.mapper = mapper;
			this.logger = logger;
			this.context = context;
		}

		public virtual int Create(
			SalesTaxRateModel model)
		{
			var record = new EFSalesTaxRate();

			this.mapper.SalesTaxRateMapModelToEF(
				default (int),
				model,
				record);

			this.context.Set<EFSalesTaxRate>().Add(record);
			this.context.SaveChanges();
			return record.SalesTaxRateID;
		}

		public virtual void Update(
			int salesTaxRateID,
			SalesTaxRateModel model)
		{
			var record = this.SearchLinqEF(x => x.SalesTaxRateID == salesTaxRateID).FirstOrDefault();
			if (record == null)
			{
				this.logger.LogError($"Unable to find id:{salesTaxRateID}");
			}
			else
			{
				this.mapper.SalesTaxRateMapModelToEF(
					salesTaxRateID,
					model,
					record);
				this.context.SaveChanges();
			}
		}

		public virtual void Delete(
			int salesTaxRateID)
		{
			var record = this.SearchLinqEF(x => x.SalesTaxRateID == salesTaxRateID).FirstOrDefault();

			if (record == null)
			{
				return;
			}
			else
			{
				this.context.Set<EFSalesTaxRate>().Remove(record);
				this.context.SaveChanges();
			}
		}

		public virtual ApiResponse GetById(int salesTaxRateID)
		{
			var response = new ApiResponse();

			this.SearchLinqPOCO(x => x.SalesTaxRateID == salesTaxRateID, response);
			return response;
		}

		public virtual POCOSalesTaxRate GetByIdDirect(int salesTaxRateID)
		{
			var response = new ApiResponse();

			this.SearchLinqPOCO(x => x.SalesTaxRateID == salesTaxRateID, response);
			return response.SalesTaxRates.FirstOrDefault();
		}

		public virtual ApiResponse GetWhere(Expression<Func<EFSalesTaxRate, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
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

		public virtual List<POCOSalesTaxRate> GetWhereDirect(Expression<Func<EFSalesTaxRate, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			var response = new ApiResponse();

			this.SearchLinqPOCO(predicate, response, skip, take, orderClause);
			return response.SalesTaxRates;
		}

		private void SearchLinqPOCO(Expression<Func<EFSalesTaxRate, bool>> predicate, ApiResponse response, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<EFSalesTaxRate> records = this.SearchLinqEF(predicate, skip, take, orderClause);
			records.ForEach(x => this.mapper.SalesTaxRateMapEFToPOCO(x, response));
		}

		private void SearchLinqPOCODynamic(string predicate, ApiResponse response, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<EFSalesTaxRate> records = this.SearchLinqEFDynamic(predicate, skip, take, orderClause);
			records.ForEach(x => this.mapper.SalesTaxRateMapEFToPOCO(x, response));
		}

		protected virtual List<EFSalesTaxRate> SearchLinqEF(Expression<Func<EFSalesTaxRate, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			throw new NotImplementedException("This method should be implemented in a derived class");
		}

		protected virtual List<EFSalesTaxRate> SearchLinqEFDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			throw new NotImplementedException("This method should be implemented in a derived class");
		}
	}
}

/*<Codenesium>
    <Hash>29304d9b820e547ebe088da0827729bc</Hash>
</Codenesium>*/