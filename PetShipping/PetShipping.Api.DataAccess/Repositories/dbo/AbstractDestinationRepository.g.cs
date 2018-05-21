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
	public abstract class AbstractDestinationRepository: AbstractRepository
	{
		protected ApplicationDbContext Context { get; }
		protected ILogger Logger { get; }
		protected IObjectMapper Mapper { get; }

		public AbstractDestinationRepository(
			IObjectMapper mapper,
			ILogger logger,
			ApplicationDbContext context)
			: base ()
		{
			this.Mapper = mapper;
			this.Logger = logger;
			this.Context = context;
		}

		public virtual Task<List<POCODestination>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqPOCO(x => true, skip, take, orderClause);
		}

		public async virtual Task<POCODestination> Get(int id)
		{
			Destination record = await this.GetById(id);

			return this.Mapper.DestinationMapEFToPOCO(record);
		}

		public async virtual Task<POCODestination> Create(
			ApiDestinationModel model)
		{
			Destination record = new Destination();

			this.Mapper.DestinationMapModelToEF(
				default (int),
				model,
				record);

			this.Context.Set<Destination>().Add(record);
			await this.Context.SaveChangesAsync();

			return this.Mapper.DestinationMapEFToPOCO(record);
		}

		public async virtual Task Update(
			int id,
			ApiDestinationModel model)
		{
			Destination record = await this.GetById(id);

			if (record == null)
			{
				throw new RecordNotFoundException($"Unable to find id:{id}");
			}
			else
			{
				this.Mapper.DestinationMapModelToEF(
					id,
					model,
					record);
				this.Context.SaveChangesAsync();
			}
		}

		public async virtual Task Delete(
			int id)
		{
			Destination record = await this.GetById(id);

			if (record == null)
			{
				return;
			}
			else
			{
				this.Context.Set<Destination>().Remove(record);
				await this.Context.SaveChangesAsync();
			}
		}

		protected async Task<List<POCODestination>> Where(Expression<Func<Destination, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<POCODestination> records = await this.SearchLinqPOCO(predicate, skip, take, orderClause);

			return records;
		}

		private async Task<List<POCODestination>> SearchLinqPOCO(Expression<Func<Destination, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<POCODestination> response = new List<POCODestination>();
			List<Destination> records = await this.SearchLinqEF(predicate, skip, take, orderClause);

			records.ForEach(x => response.Add(this.Mapper.DestinationMapEFToPOCO(x)));
			return response;
		}

		private async Task<List<Destination>> SearchLinqEF(Expression<Func<Destination, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrWhiteSpace(orderClause))
			{
				orderClause = $"{nameof(Destination.Id)} ASC";
			}
			return await this.Context.Set<Destination>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToListAsync<Destination>();
		}

		private async Task<List<Destination>> SearchLinqEFDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrWhiteSpace(orderClause))
			{
				orderClause = $"{nameof(Destination.Id)} ASC";
			}

			return await this.Context.Set<Destination>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToListAsync<Destination>();
		}

		private async Task<Destination> GetById(int id)
		{
			List<Destination> records = await this.SearchLinqEF(x => x.Id == id);

			return records.FirstOrDefault();
		}
	}
}

/*<Codenesium>
    <Hash>f8f3a5a558816082542d022a49aa47b9</Hash>
</Codenesium>*/