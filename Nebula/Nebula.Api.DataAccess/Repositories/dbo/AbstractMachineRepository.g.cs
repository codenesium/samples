using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;
using NebulaNS.Api.Contracts;

namespace NebulaNS.Api.DataAccess
{
	public abstract class AbstractMachineRepository: AbstractRepository
	{
		protected ApplicationDbContext Context { get; }
		protected ILogger Logger { get; }
		protected IObjectMapper Mapper { get; }

		public AbstractMachineRepository(
			IObjectMapper mapper,
			ILogger logger,
			ApplicationDbContext context)
			: base ()
		{
			this.Mapper = mapper;
			this.Logger = logger;
			this.Context = context;
		}

		public virtual Task<List<POCOMachine>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqPOCO(x => true, skip, take, orderClause);
		}

		public async virtual Task<POCOMachine> Get(int id)
		{
			Machine record = await this.GetById(id);

			return this.Mapper.MachineMapEFToPOCO(record);
		}

		public async virtual Task<POCOMachine> Create(
			ApiMachineModel model)
		{
			Machine record = new Machine();

			this.Mapper.MachineMapModelToEF(
				default (int),
				model,
				record);

			this.Context.Set<Machine>().Add(record);
			await this.Context.SaveChangesAsync();

			return this.Mapper.MachineMapEFToPOCO(record);
		}

		public async virtual Task Update(
			int id,
			ApiMachineModel model)
		{
			Machine record = await this.GetById(id);

			if (record == null)
			{
				throw new RecordNotFoundException($"Unable to find id:{id}");
			}
			else
			{
				this.Mapper.MachineMapModelToEF(
					id,
					model,
					record);

				await this.Context.SaveChangesAsync();
			}
		}

		public async virtual Task Delete(
			int id)
		{
			Machine record = await this.GetById(id);

			if (record == null)
			{
				return;
			}
			else
			{
				this.Context.Set<Machine>().Remove(record);
				await this.Context.SaveChangesAsync();
			}
		}

		public async Task<POCOMachine> MachineGuid(Guid machineGuid)
		{
			var records = await this.SearchLinqPOCO(x => x.MachineGuid == machineGuid);

			return records.FirstOrDefault();
		}

		protected async Task<List<POCOMachine>> Where(Expression<Func<Machine, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<POCOMachine> records = await this.SearchLinqPOCO(predicate, skip, take, orderClause);

			return records;
		}

		private async Task<List<POCOMachine>> SearchLinqPOCO(Expression<Func<Machine, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<POCOMachine> response = new List<POCOMachine>();
			List<Machine> records = await this.SearchLinqEF(predicate, skip, take, orderClause);

			records.ForEach(x => response.Add(this.Mapper.MachineMapEFToPOCO(x)));
			return response;
		}

		private async Task<List<Machine>> SearchLinqEF(Expression<Func<Machine, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrWhiteSpace(orderClause))
			{
				orderClause = $"{nameof(Machine.Id)} ASC";
			}
			return await this.Context.Set<Machine>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToListAsync<Machine>();
		}

		private async Task<List<Machine>> SearchLinqEFDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrWhiteSpace(orderClause))
			{
				orderClause = $"{nameof(Machine.Id)} ASC";
			}

			return await this.Context.Set<Machine>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToListAsync<Machine>();
		}

		private async Task<Machine> GetById(int id)
		{
			List<Machine> records = await this.SearchLinqEF(x => x.Id == id);

			return records.FirstOrDefault();
		}
	}
}

/*<Codenesium>
    <Hash>e181f1a3ca3a1cd6e9452e4618d869ca</Hash>
</Codenesium>*/