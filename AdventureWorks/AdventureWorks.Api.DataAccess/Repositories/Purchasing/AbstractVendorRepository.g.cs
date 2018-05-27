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
		protected IDALVendorMapper Mapper { get; }

		public AbstractVendorRepository(
			IDALVendorMapper mapper,
			ILogger logger,
			ApplicationDbContext context)
			: base ()
		{
			this.Mapper = mapper;
			this.Logger = logger;
			this.Context = context;
		}

		public virtual Task<List<DTOVendor>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqDTO(x => true, skip, take, orderClause);
		}

		public async virtual Task<DTOVendor> Get(int businessEntityID)
		{
			Vendor record = await this.GetById(businessEntityID);

			return this.Mapper.MapEFToDTO(record);
		}

		public async virtual Task<DTOVendor> Create(
			DTOVendor dto)
		{
			Vendor record = new Vendor();

			this.Mapper.MapDTOToEF(
				default (int),
				dto,
				record);

			this.Context.Set<Vendor>().Add(record);
			await this.Context.SaveChangesAsync();

			return this.Mapper.MapEFToDTO(record);
		}

		public async virtual Task Update(
			int businessEntityID,
			DTOVendor dto)
		{
			Vendor record = await this.GetById(businessEntityID);

			if (record == null)
			{
				throw new RecordNotFoundException($"Unable to find id:{businessEntityID}");
			}
			else
			{
				this.Mapper.MapDTOToEF(
					businessEntityID,
					dto,
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

		public async Task<DTOVendor> GetAccountNumber(string accountNumber)
		{
			var records = await this.SearchLinqDTO(x => x.AccountNumber == accountNumber);

			return records.FirstOrDefault();
		}

		protected async Task<List<DTOVendor>> Where(Expression<Func<Vendor, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<DTOVendor> records = await this.SearchLinqDTO(predicate, skip, take, orderClause);

			return records;
		}

		private async Task<List<DTOVendor>> SearchLinqDTO(Expression<Func<Vendor, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<DTOVendor> response = new List<DTOVendor>();
			List<Vendor> records = await this.SearchLinqEF(predicate, skip, take, orderClause);

			records.ForEach(x => response.Add(this.Mapper.MapEFToDTO(x)));
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
    <Hash>c542a4d153195b8d197e0ef7e1d1b9f7</Hash>
</Codenesium>*/