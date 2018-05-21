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
	public abstract class AbstractHandlerRepository: AbstractRepository
	{
		protected ApplicationDbContext Context { get; }
		protected ILogger Logger { get; }
		protected IObjectMapper Mapper { get; }

		public AbstractHandlerRepository(
			IObjectMapper mapper,
			ILogger logger,
			ApplicationDbContext context)
			: base ()
		{
			this.Mapper = mapper;
			this.Logger = logger;
			this.Context = context;
		}

		public virtual Task<List<POCOHandler>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqPOCO(x => true, skip, take, orderClause);
		}

		public async virtual Task<POCOHandler> Get(int id)
		{
			Handler record = await this.GetById(id);

			return this.Mapper.HandlerMapEFToPOCO(record);
		}

		public async virtual Task<POCOHandler> Create(
			ApiHandlerModel model)
		{
			Handler record = new Handler();

			this.Mapper.HandlerMapModelToEF(
				default (int),
				model,
				record);

			this.Context.Set<Handler>().Add(record);
			await this.Context.SaveChangesAsync();

			return this.Mapper.HandlerMapEFToPOCO(record);
		}

		public async virtual Task Update(
			int id,
			ApiHandlerModel model)
		{
			Handler record = await this.GetById(id);

			if (record == null)
			{
				throw new RecordNotFoundException($"Unable to find id:{id}");
			}
			else
			{
				this.Mapper.HandlerMapModelToEF(
					id,
					model,
					record);
				this.Context.SaveChangesAsync();
			}
		}

		public async virtual Task Delete(
			int id)
		{
			Handler record = await this.GetById(id);

			if (record == null)
			{
				return;
			}
			else
			{
				this.Context.Set<Handler>().Remove(record);
				await this.Context.SaveChangesAsync();
			}
		}

		protected async Task<List<POCOHandler>> Where(Expression<Func<Handler, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<POCOHandler> records = await this.SearchLinqPOCO(predicate, skip, take, orderClause);

			return records;
		}

		private async Task<List<POCOHandler>> SearchLinqPOCO(Expression<Func<Handler, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<POCOHandler> response = new List<POCOHandler>();
			List<Handler> records = await this.SearchLinqEF(predicate, skip, take, orderClause);

			records.ForEach(x => response.Add(this.Mapper.HandlerMapEFToPOCO(x)));
			return response;
		}

		private async Task<List<Handler>> SearchLinqEF(Expression<Func<Handler, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrWhiteSpace(orderClause))
			{
				orderClause = $"{nameof(Handler.Id)} ASC";
			}
			return await this.Context.Set<Handler>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToListAsync<Handler>();
		}

		private async Task<List<Handler>> SearchLinqEFDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrWhiteSpace(orderClause))
			{
				orderClause = $"{nameof(Handler.Id)} ASC";
			}

			return await this.Context.Set<Handler>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToListAsync<Handler>();
		}

		private async Task<Handler> GetById(int id)
		{
			List<Handler> records = await this.SearchLinqEF(x => x.Id == id);

			return records.FirstOrDefault();
		}
	}
}

/*<Codenesium>
    <Hash>18c9b3b134e947f54f0b24b56e3b1579</Hash>
</Codenesium>*/