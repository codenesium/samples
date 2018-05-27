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
		protected IDALMachineRefTeamMapper Mapper { get; }

		public AbstractMachineRefTeamRepository(
			IDALMachineRefTeamMapper mapper,
			ILogger logger,
			ApplicationDbContext context)
			: base ()
		{
			this.Mapper = mapper;
			this.Logger = logger;
			this.Context = context;
		}

		public virtual Task<List<DTOMachineRefTeam>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqDTO(x => true, skip, take, orderClause);
		}

		public async virtual Task<DTOMachineRefTeam> Get(int id)
		{
			MachineRefTeam record = await this.GetById(id);

			return this.Mapper.MapEFToDTO(record);
		}

		public async virtual Task<DTOMachineRefTeam> Create(
			DTOMachineRefTeam dto)
		{
			MachineRefTeam record = new MachineRefTeam();

			this.Mapper.MapDTOToEF(
				default (int),
				dto,
				record);

			this.Context.Set<MachineRefTeam>().Add(record);
			await this.Context.SaveChangesAsync();

			return this.Mapper.MapEFToDTO(record);
		}

		public async virtual Task Update(
			int id,
			DTOMachineRefTeam dto)
		{
			MachineRefTeam record = await this.GetById(id);

			if (record == null)
			{
				throw new RecordNotFoundException($"Unable to find id:{id}");
			}
			else
			{
				this.Mapper.MapDTOToEF(
					id,
					dto,
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

		protected async Task<List<DTOMachineRefTeam>> Where(Expression<Func<MachineRefTeam, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<DTOMachineRefTeam> records = await this.SearchLinqDTO(predicate, skip, take, orderClause);

			return records;
		}

		private async Task<List<DTOMachineRefTeam>> SearchLinqDTO(Expression<Func<MachineRefTeam, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<DTOMachineRefTeam> response = new List<DTOMachineRefTeam>();
			List<MachineRefTeam> records = await this.SearchLinqEF(predicate, skip, take, orderClause);

			records.ForEach(x => response.Add(this.Mapper.MapEFToDTO(x)));
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
    <Hash>4fb67c23bb91d4142b7febd4645b16a6</Hash>
</Codenesium>*/