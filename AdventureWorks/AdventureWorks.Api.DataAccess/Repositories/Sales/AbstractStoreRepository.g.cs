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
	public abstract class AbstractStoreRepository: AbstractRepository
	{
		protected ApplicationDbContext Context { get; }
		protected ILogger Logger { get; }
		protected IObjectMapper Mapper { get; }

		public AbstractStoreRepository(
			IObjectMapper mapper,
			ILogger logger,
			ApplicationDbContext context)
			: base ()
		{
			this.Mapper = mapper;
			this.Logger = logger;
			this.Context = context;
		}

		public virtual Task<List<POCOStore>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqPOCO(x => true, skip, take, orderClause);
		}

		public async virtual Task<POCOStore> Get(int businessEntityID)
		{
			Store record = await this.GetById(businessEntityID);

			return this.Mapper.StoreMapEFToPOCO(record);
		}

		public async virtual Task<POCOStore> Create(
			ApiStoreModel model)
		{
			Store record = new Store();

			this.Mapper.StoreMapModelToEF(
				default (int),
				model,
				record);

			this.Context.Set<Store>().Add(record);
			await this.Context.SaveChangesAsync();

			return this.Mapper.StoreMapEFToPOCO(record);
		}

		public async virtual Task Update(
			int businessEntityID,
			ApiStoreModel model)
		{
			Store record = await this.GetById(businessEntityID);

			if (record == null)
			{
				throw new RecordNotFoundException($"Unable to find id:{businessEntityID}");
			}
			else
			{
				this.Mapper.StoreMapModelToEF(
					businessEntityID,
					model,
					record);

				await this.Context.SaveChangesAsync();
			}
		}

		public async virtual Task Delete(
			int businessEntityID)
		{
			Store record = await this.GetById(businessEntityID);

			if (record == null)
			{
				return;
			}
			else
			{
				this.Context.Set<Store>().Remove(record);
				await this.Context.SaveChangesAsync();
			}
		}

		public async Task<List<POCOStore>> GetSalesPersonID(Nullable<int> salesPersonID)
		{
			var records = await this.SearchLinqPOCO(x => x.SalesPersonID == salesPersonID);

			return records;
		}
		public async Task<List<POCOStore>> GetDemographics(string demographics)
		{
			var records = await this.SearchLinqPOCO(x => x.Demographics == demographics);

			return records;
		}

		protected async Task<List<POCOStore>> Where(Expression<Func<Store, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<POCOStore> records = await this.SearchLinqPOCO(predicate, skip, take, orderClause);

			return records;
		}

		private async Task<List<POCOStore>> SearchLinqPOCO(Expression<Func<Store, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<POCOStore> response = new List<POCOStore>();
			List<Store> records = await this.SearchLinqEF(predicate, skip, take, orderClause);

			records.ForEach(x => response.Add(this.Mapper.StoreMapEFToPOCO(x)));
			return response;
		}

		private async Task<List<Store>> SearchLinqEF(Expression<Func<Store, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrWhiteSpace(orderClause))
			{
				orderClause = $"{nameof(Store.BusinessEntityID)} ASC";
			}
			return await this.Context.Set<Store>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToListAsync<Store>();
		}

		private async Task<List<Store>> SearchLinqEFDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrWhiteSpace(orderClause))
			{
				orderClause = $"{nameof(Store.BusinessEntityID)} ASC";
			}

			return await this.Context.Set<Store>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToListAsync<Store>();
		}

		private async Task<Store> GetById(int businessEntityID)
		{
			List<Store> records = await this.SearchLinqEF(x => x.BusinessEntityID == businessEntityID);

			return records.FirstOrDefault();
		}
	}
}

/*<Codenesium>
    <Hash>7ab5206ea8f1b724cfc40ee3590bcdba</Hash>
</Codenesium>*/