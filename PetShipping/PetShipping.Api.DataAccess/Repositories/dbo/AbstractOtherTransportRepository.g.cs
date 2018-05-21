using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;
using PetShippingNS.Api.Contracts;

namespace PetShippingNS.Api.DataAccess
{
	public abstract class AbstractOtherTransportRepository: AbstractRepository
	{
		protected ApplicationDbContext Context { get; }
		protected ILogger Logger { get; }
		protected IObjectMapper Mapper { get; }

		public AbstractOtherTransportRepository(
			IObjectMapper mapper,
			ILogger logger,
			ApplicationDbContext context)
			: base ()
		{
			this.Mapper = mapper;
			this.Logger = logger;
			this.Context = context;
		}

		public virtual Task<List<POCOOtherTransport>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqPOCO(x => true, skip, take, orderClause);
		}

		public async virtual Task<POCOOtherTransport> Get(int id)
		{
			OtherTransport record = await this.GetById(id);

			return this.Mapper.OtherTransportMapEFToPOCO(record);
		}

		public async virtual Task<POCOOtherTransport> Create(
			ApiOtherTransportModel model)
		{
			OtherTransport record = new OtherTransport();

			this.Mapper.OtherTransportMapModelToEF(
				default (int),
				model,
				record);

			this.Context.Set<OtherTransport>().Add(record);
			await this.Context.SaveChangesAsync();

			return this.Mapper.OtherTransportMapEFToPOCO(record);
		}

		public async virtual Task Update(
			int id,
			ApiOtherTransportModel model)
		{
			OtherTransport record = await this.GetById(id);

			if (record == null)
			{
				throw new RecordNotFoundException($"Unable to find id:{id}");
			}
			else
			{
				this.Mapper.OtherTransportMapModelToEF(
					id,
					model,
					record);

				await this.Context.SaveChangesAsync();
			}
		}

		public async virtual Task Delete(
			int id)
		{
			OtherTransport record = await this.GetById(id);

			if (record == null)
			{
				return;
			}
			else
			{
				this.Context.Set<OtherTransport>().Remove(record);
				await this.Context.SaveChangesAsync();
			}
		}

		protected async Task<List<POCOOtherTransport>> Where(Expression<Func<OtherTransport, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<POCOOtherTransport> records = await this.SearchLinqPOCO(predicate, skip, take, orderClause);

			return records;
		}

		private async Task<List<POCOOtherTransport>> SearchLinqPOCO(Expression<Func<OtherTransport, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<POCOOtherTransport> response = new List<POCOOtherTransport>();
			List<OtherTransport> records = await this.SearchLinqEF(predicate, skip, take, orderClause);

			records.ForEach(x => response.Add(this.Mapper.OtherTransportMapEFToPOCO(x)));
			return response;
		}

		private async Task<List<OtherTransport>> SearchLinqEF(Expression<Func<OtherTransport, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrWhiteSpace(orderClause))
			{
				orderClause = $"{nameof(OtherTransport.Id)} ASC";
			}
			return await this.Context.Set<OtherTransport>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToListAsync<OtherTransport>();
		}

		private async Task<List<OtherTransport>> SearchLinqEFDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrWhiteSpace(orderClause))
			{
				orderClause = $"{nameof(OtherTransport.Id)} ASC";
			}

			return await this.Context.Set<OtherTransport>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToListAsync<OtherTransport>();
		}

		private async Task<OtherTransport> GetById(int id)
		{
			List<OtherTransport> records = await this.SearchLinqEF(x => x.Id == id);

			return records.FirstOrDefault();
		}
	}
}

/*<Codenesium>
    <Hash>47e5621d0f7374b586672c2802d15f85</Hash>
</Codenesium>*/