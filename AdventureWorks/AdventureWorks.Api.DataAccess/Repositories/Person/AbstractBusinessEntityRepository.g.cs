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
	public abstract class AbstractBusinessEntityRepository: AbstractRepository
	{
		protected ApplicationDbContext Context { get; }
		protected ILogger Logger { get; }
		protected IObjectMapper Mapper { get; }

		public AbstractBusinessEntityRepository(
			IObjectMapper mapper,
			ILogger logger,
			ApplicationDbContext context)
			: base ()
		{
			this.Mapper = mapper;
			this.Logger = logger;
			this.Context = context;
		}

		public virtual Task<List<POCOBusinessEntity>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqPOCO(x => true, skip, take, orderClause);
		}

		public async virtual Task<POCOBusinessEntity> Get(int businessEntityID)
		{
			BusinessEntity record = await this.GetById(businessEntityID);

			return this.Mapper.BusinessEntityMapEFToPOCO(record);
		}

		public async virtual Task<POCOBusinessEntity> Create(
			ApiBusinessEntityModel model)
		{
			BusinessEntity record = new BusinessEntity();

			this.Mapper.BusinessEntityMapModelToEF(
				default (int),
				model,
				record);

			this.Context.Set<BusinessEntity>().Add(record);
			await this.Context.SaveChangesAsync();

			return this.Mapper.BusinessEntityMapEFToPOCO(record);
		}

		public async virtual Task Update(
			int businessEntityID,
			ApiBusinessEntityModel model)
		{
			BusinessEntity record = await this.GetById(businessEntityID);

			if (record == null)
			{
				throw new RecordNotFoundException($"Unable to find id:{businessEntityID}");
			}
			else
			{
				this.Mapper.BusinessEntityMapModelToEF(
					businessEntityID,
					model,
					record);
				this.Context.SaveChangesAsync();
			}
		}

		public async virtual Task Delete(
			int businessEntityID)
		{
			BusinessEntity record = await this.GetById(businessEntityID);

			if (record == null)
			{
				return;
			}
			else
			{
				this.Context.Set<BusinessEntity>().Remove(record);
				await this.Context.SaveChangesAsync();
			}
		}

		protected async Task<List<POCOBusinessEntity>> Where(Expression<Func<BusinessEntity, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<POCOBusinessEntity> records = await this.SearchLinqPOCO(predicate, skip, take, orderClause);

			return records;
		}

		private async Task<List<POCOBusinessEntity>> SearchLinqPOCO(Expression<Func<BusinessEntity, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<POCOBusinessEntity> response = new List<POCOBusinessEntity>();
			List<BusinessEntity> records = await this.SearchLinqEF(predicate, skip, take, orderClause);

			records.ForEach(x => response.Add(this.Mapper.BusinessEntityMapEFToPOCO(x)));
			return response;
		}

		private async Task<List<BusinessEntity>> SearchLinqEF(Expression<Func<BusinessEntity, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrWhiteSpace(orderClause))
			{
				orderClause = $"{nameof(BusinessEntity.BusinessEntityID)} ASC";
			}
			return await this.Context.Set<BusinessEntity>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToListAsync<BusinessEntity>();
		}

		private async Task<List<BusinessEntity>> SearchLinqEFDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrWhiteSpace(orderClause))
			{
				orderClause = $"{nameof(BusinessEntity.BusinessEntityID)} ASC";
			}

			return await this.Context.Set<BusinessEntity>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToListAsync<BusinessEntity>();
		}

		private async Task<BusinessEntity> GetById(int businessEntityID)
		{
			List<BusinessEntity> records = await this.SearchLinqEF(x => x.BusinessEntityID == businessEntityID);

			return records.FirstOrDefault();
		}
	}
}

/*<Codenesium>
    <Hash>fd88746d1d63f6690a714929e8443975</Hash>
</Codenesium>*/