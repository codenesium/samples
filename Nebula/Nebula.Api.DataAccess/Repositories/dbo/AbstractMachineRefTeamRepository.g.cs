using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using NebulaNS.Api.Contracts;

namespace NebulaNS.Api.DataAccess
{
	public abstract class AbstractMachineRefTeamRepository
	{
		protected ApplicationDbContext Context { get; }
		protected ILogger Logger { get; }
		protected IObjectMapper Mapper { get; }

		public AbstractMachineRefTeamRepository(
			IObjectMapper mapper,
			ILogger logger,
			ApplicationDbContext context)
		{
			this.Mapper = mapper;
			this.Logger = logger;
			this.Context = context;
		}

		public virtual List<POCOMachineRefTeam> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqPOCO(x => true, skip, take, orderClause);
		}

		public virtual POCOMachineRefTeam Get(int id)
		{
			return this.SearchLinqPOCO(x => x.Id == id).FirstOrDefault();
		}

		public virtual POCOMachineRefTeam Create(
			MachineRefTeamModel model)
		{
			MachineRefTeam record = new MachineRefTeam();

			this.Mapper.MachineRefTeamMapModelToEF(
				default (int),
				model,
				record);

			this.Context.Set<MachineRefTeam>().Add(record);
			this.Context.SaveChanges();
			return this.Mapper.MachineRefTeamMapEFToPOCO(record);
		}

		public virtual void Update(
			int id,
			MachineRefTeamModel model)
		{
			MachineRefTeam record = this.SearchLinqEF(x => x.Id == id).FirstOrDefault();
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
				this.Context.SaveChanges();
			}
		}

		public virtual void Delete(
			int id)
		{
			MachineRefTeam record = this.SearchLinqEF(x => x.Id == id).FirstOrDefault();

			if (record == null)
			{
				return;
			}
			else
			{
				this.Context.Set<MachineRefTeam>().Remove(record);
				this.Context.SaveChanges();
			}
		}

		protected List<POCOMachineRefTeam> Where(Expression<Func<MachineRefTeam, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqPOCO(predicate, skip, take, orderClause);
		}

		private List<POCOMachineRefTeam> SearchLinqPOCO(Expression<Func<MachineRefTeam, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<POCOMachineRefTeam> response = new List<POCOMachineRefTeam>();
			List<MachineRefTeam> records = this.SearchLinqEF(predicate, skip, take, orderClause);
			records.ForEach(x => response.Add(this.Mapper.MachineRefTeamMapEFToPOCO(x)));
			return response;
		}

		private List<MachineRefTeam> SearchLinqEF(Expression<Func<MachineRefTeam, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrWhiteSpace(orderClause))
			{
				orderClause = $"{nameof(MachineRefTeam.Id)} ASC";
			}
			return this.Context.Set<MachineRefTeam>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<MachineRefTeam>();
		}

		private List<MachineRefTeam> SearchLinqEFDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrWhiteSpace(orderClause))
			{
				orderClause = $"{nameof(MachineRefTeam.Id)} ASC";
			}

			return this.Context.Set<MachineRefTeam>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<MachineRefTeam>();
		}
	}
}

/*<Codenesium>
    <Hash>300c1ceea68215298a73859dcd031521</Hash>
</Codenesium>*/