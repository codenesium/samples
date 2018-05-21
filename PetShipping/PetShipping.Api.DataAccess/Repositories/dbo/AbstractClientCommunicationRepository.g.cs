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
	public abstract class AbstractClientCommunicationRepository: AbstractRepository
	{
		protected ApplicationDbContext Context { get; }
		protected ILogger Logger { get; }
		protected IObjectMapper Mapper { get; }

		public AbstractClientCommunicationRepository(
			IObjectMapper mapper,
			ILogger logger,
			ApplicationDbContext context)
			: base ()
		{
			this.Mapper = mapper;
			this.Logger = logger;
			this.Context = context;
		}

		public virtual Task<List<POCOClientCommunication>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqPOCO(x => true, skip, take, orderClause);
		}

		public async virtual Task<POCOClientCommunication> Get(int id)
		{
			ClientCommunication record = await this.GetById(id);

			return this.Mapper.ClientCommunicationMapEFToPOCO(record);
		}

		public async virtual Task<POCOClientCommunication> Create(
			ApiClientCommunicationModel model)
		{
			ClientCommunication record = new ClientCommunication();

			this.Mapper.ClientCommunicationMapModelToEF(
				default (int),
				model,
				record);

			this.Context.Set<ClientCommunication>().Add(record);
			await this.Context.SaveChangesAsync();

			return this.Mapper.ClientCommunicationMapEFToPOCO(record);
		}

		public async virtual Task Update(
			int id,
			ApiClientCommunicationModel model)
		{
			ClientCommunication record = await this.GetById(id);

			if (record == null)
			{
				throw new RecordNotFoundException($"Unable to find id:{id}");
			}
			else
			{
				this.Mapper.ClientCommunicationMapModelToEF(
					id,
					model,
					record);
				this.Context.SaveChangesAsync();
			}
		}

		public async virtual Task Delete(
			int id)
		{
			ClientCommunication record = await this.GetById(id);

			if (record == null)
			{
				return;
			}
			else
			{
				this.Context.Set<ClientCommunication>().Remove(record);
				await this.Context.SaveChangesAsync();
			}
		}

		protected async Task<List<POCOClientCommunication>> Where(Expression<Func<ClientCommunication, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<POCOClientCommunication> records = await this.SearchLinqPOCO(predicate, skip, take, orderClause);

			return records;
		}

		private async Task<List<POCOClientCommunication>> SearchLinqPOCO(Expression<Func<ClientCommunication, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<POCOClientCommunication> response = new List<POCOClientCommunication>();
			List<ClientCommunication> records = await this.SearchLinqEF(predicate, skip, take, orderClause);

			records.ForEach(x => response.Add(this.Mapper.ClientCommunicationMapEFToPOCO(x)));
			return response;
		}

		private async Task<List<ClientCommunication>> SearchLinqEF(Expression<Func<ClientCommunication, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrWhiteSpace(orderClause))
			{
				orderClause = $"{nameof(ClientCommunication.Id)} ASC";
			}
			return await this.Context.Set<ClientCommunication>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToListAsync<ClientCommunication>();
		}

		private async Task<List<ClientCommunication>> SearchLinqEFDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrWhiteSpace(orderClause))
			{
				orderClause = $"{nameof(ClientCommunication.Id)} ASC";
			}

			return await this.Context.Set<ClientCommunication>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToListAsync<ClientCommunication>();
		}

		private async Task<ClientCommunication> GetById(int id)
		{
			List<ClientCommunication> records = await this.SearchLinqEF(x => x.Id == id);

			return records.FirstOrDefault();
		}
	}
}

/*<Codenesium>
    <Hash>dfbfdcca0c37c8abfe91dfcc041e0056</Hash>
</Codenesium>*/