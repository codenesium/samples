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
	public abstract class AbstractBusinessEntityAddressRepository: AbstractRepository
	{
		protected ApplicationDbContext Context { get; }
		protected ILogger Logger { get; }
		protected IObjectMapper Mapper { get; }

		public AbstractBusinessEntityAddressRepository(
			IObjectMapper mapper,
			ILogger logger,
			ApplicationDbContext context)
			: base ()
		{
			this.Mapper = mapper;
			this.Logger = logger;
			this.Context = context;
		}

		public virtual Task<List<POCOBusinessEntityAddress>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqPOCO(x => true, skip, take, orderClause);
		}

		public async virtual Task<POCOBusinessEntityAddress> Get(int businessEntityID)
		{
			BusinessEntityAddress record = await this.GetById(businessEntityID);

			return this.Mapper.BusinessEntityAddressMapEFToPOCO(record);
		}

		public async virtual Task<POCOBusinessEntityAddress> Create(
			ApiBusinessEntityAddressModel model)
		{
			BusinessEntityAddress record = new BusinessEntityAddress();

			this.Mapper.BusinessEntityAddressMapModelToEF(
				default (int),
				model,
				record);

			this.Context.Set<BusinessEntityAddress>().Add(record);
			await this.Context.SaveChangesAsync();

			return this.Mapper.BusinessEntityAddressMapEFToPOCO(record);
		}

		public async virtual Task Update(
			int businessEntityID,
			ApiBusinessEntityAddressModel model)
		{
			BusinessEntityAddress record = await this.GetById(businessEntityID);

			if (record == null)
			{
				throw new RecordNotFoundException($"Unable to find id:{businessEntityID}");
			}
			else
			{
				this.Mapper.BusinessEntityAddressMapModelToEF(
					businessEntityID,
					model,
					record);
				this.Context.SaveChangesAsync();
			}
		}

		public async virtual Task Delete(
			int businessEntityID)
		{
			BusinessEntityAddress record = await this.GetById(businessEntityID);

			if (record == null)
			{
				return;
			}
			else
			{
				this.Context.Set<BusinessEntityAddress>().Remove(record);
				await this.Context.SaveChangesAsync();
			}
		}

		public async Task<List<POCOBusinessEntityAddress>> GetAddressID(int addressID)
		{
			var records = await this.SearchLinqPOCO(x => x.AddressID == addressID);

			return records;
		}
		public async Task<List<POCOBusinessEntityAddress>> GetAddressTypeID(int addressTypeID)
		{
			var records = await this.SearchLinqPOCO(x => x.AddressTypeID == addressTypeID);

			return records;
		}

		protected async Task<List<POCOBusinessEntityAddress>> Where(Expression<Func<BusinessEntityAddress, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<POCOBusinessEntityAddress> records = await this.SearchLinqPOCO(predicate, skip, take, orderClause);

			return records;
		}

		private async Task<List<POCOBusinessEntityAddress>> SearchLinqPOCO(Expression<Func<BusinessEntityAddress, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<POCOBusinessEntityAddress> response = new List<POCOBusinessEntityAddress>();
			List<BusinessEntityAddress> records = await this.SearchLinqEF(predicate, skip, take, orderClause);

			records.ForEach(x => response.Add(this.Mapper.BusinessEntityAddressMapEFToPOCO(x)));
			return response;
		}

		private async Task<List<BusinessEntityAddress>> SearchLinqEF(Expression<Func<BusinessEntityAddress, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrWhiteSpace(orderClause))
			{
				orderClause = $"{nameof(BusinessEntityAddress.BusinessEntityID)} ASC";
			}
			return await this.Context.Set<BusinessEntityAddress>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToListAsync<BusinessEntityAddress>();
		}

		private async Task<List<BusinessEntityAddress>> SearchLinqEFDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrWhiteSpace(orderClause))
			{
				orderClause = $"{nameof(BusinessEntityAddress.BusinessEntityID)} ASC";
			}

			return await this.Context.Set<BusinessEntityAddress>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToListAsync<BusinessEntityAddress>();
		}

		private async Task<BusinessEntityAddress> GetById(int businessEntityID)
		{
			List<BusinessEntityAddress> records = await this.SearchLinqEF(x => x.BusinessEntityID == businessEntityID);

			return records.FirstOrDefault();
		}
	}
}

/*<Codenesium>
    <Hash>674b0a361cfa5a2b64fb1fbed3bfc025</Hash>
</Codenesium>*/