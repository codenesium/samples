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
	public abstract class AbstractSalesPersonRepository: AbstractRepository
	{
		protected ApplicationDbContext Context { get; }
		protected ILogger Logger { get; }
		protected IObjectMapper Mapper { get; }

		public AbstractSalesPersonRepository(
			IObjectMapper mapper,
			ILogger logger,
			ApplicationDbContext context)
			: base ()
		{
			this.Mapper = mapper;
			this.Logger = logger;
			this.Context = context;
		}

		public virtual Task<List<POCOSalesPerson>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqPOCO(x => true, skip, take, orderClause);
		}

		public async virtual Task<POCOSalesPerson> Get(int businessEntityID)
		{
			SalesPerson record = await this.GetById(businessEntityID);

			return this.Mapper.SalesPersonMapEFToPOCO(record);
		}

		public async virtual Task<POCOSalesPerson> Create(
			ApiSalesPersonModel model)
		{
			SalesPerson record = new SalesPerson();

			this.Mapper.SalesPersonMapModelToEF(
				default (int),
				model,
				record);

			this.Context.Set<SalesPerson>().Add(record);
			await this.Context.SaveChangesAsync();

			return this.Mapper.SalesPersonMapEFToPOCO(record);
		}

		public async virtual Task Update(
			int businessEntityID,
			ApiSalesPersonModel model)
		{
			SalesPerson record = await this.GetById(businessEntityID);

			if (record == null)
			{
				throw new RecordNotFoundException($"Unable to find id:{businessEntityID}");
			}
			else
			{
				this.Mapper.SalesPersonMapModelToEF(
					businessEntityID,
					model,
					record);
				this.Context.SaveChangesAsync();
			}
		}

		public async virtual Task Delete(
			int businessEntityID)
		{
			SalesPerson record = await this.GetById(businessEntityID);

			if (record == null)
			{
				return;
			}
			else
			{
				this.Context.Set<SalesPerson>().Remove(record);
				await this.Context.SaveChangesAsync();
			}
		}

		protected async Task<List<POCOSalesPerson>> Where(Expression<Func<SalesPerson, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<POCOSalesPerson> records = await this.SearchLinqPOCO(predicate, skip, take, orderClause);

			return records;
		}

		private async Task<List<POCOSalesPerson>> SearchLinqPOCO(Expression<Func<SalesPerson, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<POCOSalesPerson> response = new List<POCOSalesPerson>();
			List<SalesPerson> records = await this.SearchLinqEF(predicate, skip, take, orderClause);

			records.ForEach(x => response.Add(this.Mapper.SalesPersonMapEFToPOCO(x)));
			return response;
		}

		private async Task<List<SalesPerson>> SearchLinqEF(Expression<Func<SalesPerson, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrWhiteSpace(orderClause))
			{
				orderClause = $"{nameof(SalesPerson.BusinessEntityID)} ASC";
			}
			return await this.Context.Set<SalesPerson>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToListAsync<SalesPerson>();
		}

		private async Task<List<SalesPerson>> SearchLinqEFDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrWhiteSpace(orderClause))
			{
				orderClause = $"{nameof(SalesPerson.BusinessEntityID)} ASC";
			}

			return await this.Context.Set<SalesPerson>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToListAsync<SalesPerson>();
		}

		private async Task<SalesPerson> GetById(int businessEntityID)
		{
			List<SalesPerson> records = await this.SearchLinqEF(x => x.BusinessEntityID == businessEntityID);

			return records.FirstOrDefault();
		}
	}
}

/*<Codenesium>
    <Hash>8d7ace9819bdb51c4c1e3fca2763db3c</Hash>
</Codenesium>*/