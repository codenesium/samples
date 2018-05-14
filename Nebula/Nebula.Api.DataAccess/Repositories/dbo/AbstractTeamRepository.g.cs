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
	public abstract class AbstractTeamRepository
	{
		protected ApplicationDbContext Context { get; }
		protected ILogger Logger { get; }
		protected IObjectMapper Mapper { get; }

		public AbstractTeamRepository(
			IObjectMapper mapper,
			ILogger logger,
			ApplicationDbContext context)
		{
			this.Mapper = mapper;
			this.Logger = logger;
			this.Context = context;
		}

		public virtual List<POCOTeam> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqPOCO(x => true, skip, take, orderClause);
		}

		public virtual POCOTeam Get(int id)
		{
			return this.SearchLinqPOCO(x => x.Id == id).FirstOrDefault();
		}

		public virtual POCOTeam Create(
			ApiTeamModel model)
		{
			Team record = new Team();

			this.Mapper.TeamMapModelToEF(
				default (int),
				model,
				record);

			this.Context.Set<Team>().Add(record);
			this.Context.SaveChanges();
			return this.Mapper.TeamMapEFToPOCO(record);
		}

		public virtual void Update(
			int id,
			ApiTeamModel model)
		{
			Team record = this.SearchLinqEF(x => x.Id == id).FirstOrDefault();
			if (record == null)
			{
				throw new RecordNotFoundException($"Unable to find id:{id}");
			}
			else
			{
				this.Mapper.TeamMapModelToEF(
					id,
					model,
					record);
				this.Context.SaveChanges();
			}
		}

		public virtual void Delete(
			int id)
		{
			Team record = this.SearchLinqEF(x => x.Id == id).FirstOrDefault();

			if (record == null)
			{
				return;
			}
			else
			{
				this.Context.Set<Team>().Remove(record);
				this.Context.SaveChanges();
			}
		}

		public POCOTeam Name(string name)
		{
			return this.SearchLinqPOCO(x => x.Name == name).FirstOrDefault();
		}

		protected List<POCOTeam> Where(Expression<Func<Team, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqPOCO(predicate, skip, take, orderClause);
		}

		private List<POCOTeam> SearchLinqPOCO(Expression<Func<Team, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<POCOTeam> response = new List<POCOTeam>();
			List<Team> records = this.SearchLinqEF(predicate, skip, take, orderClause);
			records.ForEach(x => response.Add(this.Mapper.TeamMapEFToPOCO(x)));
			return response;
		}

		private List<Team> SearchLinqEF(Expression<Func<Team, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrWhiteSpace(orderClause))
			{
				orderClause = $"{nameof(Team.Id)} ASC";
			}
			return this.Context.Set<Team>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<Team>();
		}

		private List<Team> SearchLinqEFDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrWhiteSpace(orderClause))
			{
				orderClause = $"{nameof(Team.Id)} ASC";
			}

			return this.Context.Set<Team>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<Team>();
		}
	}
}

/*<Codenesium>
    <Hash>2cac1c74031ed5d585cea21606597049</Hash>
</Codenesium>*/