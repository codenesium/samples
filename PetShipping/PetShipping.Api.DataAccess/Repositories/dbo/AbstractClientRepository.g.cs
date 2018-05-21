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
	public abstract class AbstractClientRepository: AbstractRepository
	{
		protected ApplicationDbContext Context { get; }
		protected ILogger Logger { get; }
		protected IObjectMapper Mapper { get; }

		public AbstractClientRepository(
			IObjectMapper mapper,
			ILogger logger,
			ApplicationDbContext context)
			: base ()
		{
			this.Mapper = mapper;
			this.Logger = logger;
			this.Context = context;
		}

		public virtual Task<List<POCOClient>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqPOCO(x => true, skip, take, orderClause);
		}

		public async virtual Task<POCOClient> Get(int id)
		{
			Client record = await this.GetById(id);

			return this.Mapper.ClientMapEFToPOCO(record);
		}

		public async virtual Task<POCOClient> Create(
			ApiClientModel model)
		{
			Client record = new Client();

			this.Mapper.ClientMapModelToEF(
				default (int),
				model,
				record);

			this.Context.Set<Client>().Add(record);
			await this.Context.SaveChangesAsync();

			return this.Mapper.ClientMapEFToPOCO(record);
		}

		public async virtual Task Update(
			int id,
			ApiClientModel model)
		{
			Client record = await this.GetById(id);

			if (record == null)
			{
				throw new RecordNotFoundException($"Unable to find id:{id}");
			}
			else
			{
				this.Mapper.ClientMapModelToEF(
					id,
					model,
					record);
				this.Context.SaveChangesAsync();
			}
		}

		public async virtual Task Delete(
			int id)
		{
			Client record = await this.GetById(id);

			if (record == null)
			{
				return;
			}
			else
			{
				this.Context.Set<Client>().Remove(record);
				await this.Context.SaveChangesAsync();
			}
		}

		protected async Task<List<POCOClient>> Where(Expression<Func<Client, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<POCOClient> records = await this.SearchLinqPOCO(predicate, skip, take, orderClause);

			return records;
		}

		private async Task<List<POCOClient>> SearchLinqPOCO(Expression<Func<Client, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<POCOClient> response = new List<POCOClient>();
			List<Client> records = await this.SearchLinqEF(predicate, skip, take, orderClause);

			records.ForEach(x => response.Add(this.Mapper.ClientMapEFToPOCO(x)));
			return response;
		}

		private async Task<List<Client>> SearchLinqEF(Expression<Func<Client, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrWhiteSpace(orderClause))
			{
				orderClause = $"{nameof(Client.Id)} ASC";
			}
			return await this.Context.Set<Client>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToListAsync<Client>();
		}

		private async Task<List<Client>> SearchLinqEFDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrWhiteSpace(orderClause))
			{
				orderClause = $"{nameof(Client.Id)} ASC";
			}

			return await this.Context.Set<Client>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToListAsync<Client>();
		}

		private async Task<Client> GetById(int id)
		{
			List<Client> records = await this.SearchLinqEF(x => x.Id == id);

			return records.FirstOrDefault();
		}
	}
}

/*<Codenesium>
    <Hash>3ef5c6fe0475daef69d5e5d12ec75fb8</Hash>
</Codenesium>*/