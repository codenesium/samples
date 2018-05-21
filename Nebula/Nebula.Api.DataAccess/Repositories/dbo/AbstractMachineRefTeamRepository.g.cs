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
	public abstract class AbstractMachineRefTeamRepository: AbstractRepository
	{
		protected ApplicationDbContext Context { get; }
		protected ILogger Logger { get; }
		protected IObjectMapper Mapper { get; }

		public AbstractMachineRefTeamRepository(
			IObjectMapper mapper,
			ILogger logger,
			ApplicationDbContext context)
			: base ()
		{
			this.Mapper = mapper;
			this.Logger = logger;
			this.Context = context;
		}

		public virtual Task<List<POCOMachineRefTeam>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqPOCO(x => true, skip, take, orderClause);
		}

		public async virtual Task<POCOMachineRefTeam> Get(int id)
		{
			MachineRefTeam record = await this.GetById(id);

			return this.Mapper.MachineRefTeamMapEFToPOCO(record);
		}

		public async virtual Task<POCOMachineRefTeam> Create(
			ApiMachineRefTeamModel model)
		{
			MachineRefTeam record = new MachineRefTeam();

			this.Mapper.MachineRefTeamMapModelToEF(
				default (int),
				model,
				record);

			this.Context.Set<MachineRefTeam>().Add(record);
			await this.Context.SaveChangesAsync();

			return this.Mapper.MachineRefTeamMapEFToPOCO(record);
		}

		public async virtual Task Update(
			int id,
			ApiMachineRefTeamModel model)
		{
			MachineRefTeam record = await this.GetById(id);

			if (record == null)
			{
				throw new RecordNotFoundException($"Unable to find id:{id}");
			}
			else
			{
				this.Mapper.MachineRefTeamMapModelToEF(
					id,
					model,
					record);

				await this.Context.SaveChangesAsync();
			}
		}

		public async virtual Task Delete(
			int id)
		{
			MachineRefTeam record = await this.GetById(id);

			if (record == null)
			{
				return;
			}
			else
			{
				this.Context.Set<MachineRefTeam>().Remove(record);
				await this.Context.SaveChangesAsync();
			}
		}

		protected async Task<List<POCOMachineRefTeam>> Where(Expression<Func<MachineRefTeam, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<POCOMachineRefTeam> records = await this.SearchLinqPOCO(predicate, skip, take, orderClause);

			return records;
		}

		private async Task<List<POCOMachineRefTeam>> SearchLinqPOCO(Expression<Func<MachineRefTeam, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<POCOMachineRefTeam> response = new List<POCOMachineRefTeam>();
			List<MachineRefTeam> records = await this.SearchLinqEF(predicate, skip, take, orderClause);

			records.ForEach(x => response.Add(this.Mapper.MachineRefTeamMapEFToPOCO(x)));
			return response;
		}

		private async Task<List<MachineRefTeam>> SearchLinqEF(Expression<Func<MachineRefTeam, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrWhiteSpace(orderClause))
			{
				orderClause = $"{nameof(MachineRefTeam.Id)} ASC";
			}
			return await this.Context.Set<MachineRefTeam>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToListAsync<MachineRefTeam>();
		}

		private async Task<List<MachineRefTeam>> SearchLinqEFDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrWhiteSpace(orderClause))
			{
				orderClause = $"{nameof(MachineRefTeam.Id)} ASC";
			}

			return await this.Context.Set<MachineRefTeam>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToListAsync<MachineRefTeam>();
		}

		private async Task<MachineRefTeam> GetById(int id)
		{
			List<MachineRefTeam> records = await this.SearchLinqEF(x => x.Id == id);

			return records.FirstOrDefault();
		}
	}
}

/*<Codenesium>
    <Hash>4ee6811b2dfdb9bdda29205dc0f689dd</Hash>
</Codenesium>*/