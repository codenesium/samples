using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;

namespace AdventureWorksNS.Api.DataAccess
{
	public abstract class AbstractVendorRepository: AbstractRepository
	{
		protected ApplicationDbContext Context { get; }
		protected ILogger Logger { get; }
		protected IObjectMapper Mapper { get; }

		public AbstractVendorRepository(
			IObjectMapper mapper,
			ILogger logger,
			ApplicationDbContext context)
			: base ()
		{
			this.Mapper = mapper;
			this.Logger = logger;
			this.Context = context;
		}

		public virtual Task<List<POCOVendor>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqPOCO(x => true, skip, take, orderClause);
		}

		public async virtual Task<POCOVendor> Get(int businessEntityID)
		{
			Vendor record = await this.GetById(businessEntityID);

			return this.Mapper.VendorMapEFToPOCO(record);
		}

		public async virtual Task<POCOVendor> Create(
			ApiVendorModel model)
		{
			Vendor record = new Vendor();

			this.Mapper.VendorMapModelToEF(
				default (int),
				model,
				record);

			this.Context.Set<Vendor>().Add(record);
			await this.Context.SaveChangesAsync();

			return this.Mapper.VendorMapEFToPOCO(record);
		}

		public async virtual Task Update(
			int businessEntityID,
			ApiVendorModel model)
		{
			Vendor record = await this.GetById(businessEntityID);

			if (record == null)
			{
				throw new RecordNotFoundException($"Unable to find id:{businessEntityID}");
			}
			else
			{
				this.Mapper.VendorMapModelToEF(
					businessEntityID,
					model,
					record);

				await this.Context.SaveChangesAsync();
			}
		}

		public async virtual Task Delete(
			int businessEntityID)
		{
			Vendor record = await this.GetById(businessEntityID);

			if (record == null)
			{
				return;
			}
			else
			{
				this.Context.Set<Vendor>().Remove(record);
				await this.Context.SaveChangesAsync();
			}
		}

		public async Task<POCOVendor> GetAccountNumber(string accountNumber)
		{
			var records = await this.SearchLinqPOCO(x => x.AccountNumber == accountNumber);

			return records.FirstOrDefault();
		}

		protected async Task<List<POCOVendor>> Where(Expression<Func<Vendor, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<POCOVendor> records = await this.SearchLinqPOCO(predicate, skip, take, orderClause);

			return records;
		}

		private async Task<List<POCOVendor>> SearchLinqPOCO(Expression<Func<Vendor, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<POCOVendor> response = new List<POCOVendor>();
			List<Vendor> records = await this.SearchLinqEF(predicate, skip, take, orderClause);

			records.ForEach(x => response.Add(this.Mapper.VendorMapEFToPOCO(x)));
			return response;
		}

		private async Task<List<Vendor>> SearchLinqEF(Expression<Func<Vendor, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrWhiteSpace(orderClause))
			{
				orderClause = $"{nameof(Vendor.BusinessEntityID)} ASC";
			}
			return await this.Context.Set<Vendor>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToListAsync<Vendor>();
		}

		private async Task<List<Vendor>> SearchLinqEFDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrWhiteSpace(orderClause))
			{
				orderClause = $"{nameof(Vendor.BusinessEntityID)} ASC";
			}

			return await this.Context.Set<Vendor>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToListAsync<Vendor>();
		}

		private async Task<Vendor> GetById(int businessEntityID)
		{
			List<Vendor> records = await this.SearchLinqEF(x => x.BusinessEntityID == businessEntityID);

			return records.FirstOrDefault();
		}
	}
}

/*<Codenesium>
    <Hash>5e04e6f3bc140aa4cb5793a28160b6e2</Hash>
</Codenesium>*/