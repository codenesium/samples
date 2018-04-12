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

		public AbstractSalesTaxRateRepository(
			ILogger logger,
			ApplicationDbContext context)
		{
			this.logger = logger;
			this.context = context;
		}

		public virtual int Create(
			int stateProvinceID,
			int taxType,
			decimal taxRate,
			string name,
			Guid rowguid,
			DateTime modifiedDate)
		{
			var record = new EFSalesTaxRate();

			MapPOCOToEF(
				0,
				stateProvinceID,
				taxType,
				taxRate,
				name,
				rowguid,
				modifiedDate,
				record);

			this.context.Set<EFSalesTaxRate>().Add(record);
			this.context.SaveChanges();
			return record.SalesTaxRateID;
		}

		public virtual void Update(
			int salesTaxRateID,
			int stateProvinceID,
			int taxType,
			decimal taxRate,
			string name,
			Guid rowguid,
			DateTime modifiedDate)
		{
			var record = this.SearchLinqEF(x => x.SalesTaxRateID == salesTaxRateID).FirstOrDefault();
			if (record == null)
			{
				this.logger.LogError($"Unable to find id:{salesTaxRateID}");
			}
			else
			{
				MapPOCOToEF(
					salesTaxRateID,
					stateProvinceID,
					taxType,
					taxRate,
					name,
					rowguid,
					modifiedDate,
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

		public virtual Response GetById(int salesTaxRateID)
		{
			var response = new Response();

			this.SearchLinqPOCO(x => x.SalesTaxRateID == salesTaxRateID, response);
			return response;
		}

		public virtual POCOSalesTaxRate GetByIdDirect(int salesTaxRateID)
		{
			var response = new Response();

			this.SearchLinqPOCO(x => x.SalesTaxRateID == salesTaxRateID, response);
			return response.SalesTaxRates.FirstOrDefault();
		}

		public virtual Response GetWhere(Expression<Func<EFSalesTaxRate, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			var response = new Response();

			this.SearchLinqPOCO(predicate, response, skip, take, orderClause);
			return response;
		}

		public virtual Response GetWhereDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			var response = new Response();

			this.SearchLinqPOCODynamic(predicate, response, skip, take, orderClause);
			return response;
		}

		public virtual List<POCOSalesTaxRate> GetWhereDirect(Expression<Func<EFSalesTaxRate, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			var response = new Response();

			this.SearchLinqPOCO(predicate, response, skip, take, orderClause);
			return response.SalesTaxRates;
		}

		private void SearchLinqPOCO(Expression<Func<EFSalesTaxRate, bool>> predicate, Response response, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<EFSalesTaxRate> records = this.SearchLinqEF(predicate, skip, take, orderClause);
			records.ForEach(x => MapEFToPOCO(x, response));
		}

		private void SearchLinqPOCODynamic(string predicate, Response response, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<EFSalesTaxRate> records = this.SearchLinqEFDynamic(predicate, skip, take, orderClause);
			records.ForEach(x => MapEFToPOCO(x, response));
		}

		protected virtual List<EFSalesTaxRate> SearchLinqEF(Expression<Func<EFSalesTaxRate, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			throw new NotImplementedException("This method should be implemented in a derived class");
		}

		protected virtual List<EFSalesTaxRate> SearchLinqEFDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			throw new NotImplementedException("This method should be implemented in a derived class");
		}

		public static void MapPOCOToEF(
			int salesTaxRateID,
			int stateProvinceID,
			int taxType,
			decimal taxRate,
			string name,
			Guid rowguid,
			DateTime modifiedDate,
			EFSalesTaxRate efSalesTaxRate)
		{
			efSalesTaxRate.SetProperties(salesTaxRateID.ToInt(), stateProvinceID.ToInt(), taxType, taxRate, name, rowguid, modifiedDate.ToDateTime());
		}

		public static void MapEFToPOCO(
			EFSalesTaxRate efSalesTaxRate,
			Response response)
		{
			if (efSalesTaxRate == null)
			{
				return;
			}

			response.AddSalesTaxRate(new POCOSalesTaxRate(efSalesTaxRate.SalesTaxRateID.ToInt(), efSalesTaxRate.StateProvinceID.ToInt(), efSalesTaxRate.TaxType, efSalesTaxRate.TaxRate, efSalesTaxRate.Name, efSalesTaxRate.Rowguid, efSalesTaxRate.ModifiedDate.ToDateTime()));

			StateProvinceRepository.MapEFToPOCO(efSalesTaxRate.StateProvince, response);
		}
	}
}

/*<Codenesium>
    <Hash>fb5fa47bf095c0351560c01e7159927e</Hash>
</Codenesium>*/