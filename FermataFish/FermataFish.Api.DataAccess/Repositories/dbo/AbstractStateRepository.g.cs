using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using FermataFishNS.Api.Contracts;

namespace FermataFishNS.Api.DataAccess
{
	public abstract class AbstractStateRepository
	{
		protected ApplicationDbContext Context { get; }
		protected ILogger Logger { get; }
		protected IObjectMapper Mapper { get; }

		public AbstractStateRepository(
			IObjectMapper mapper,
			ILogger logger,
			ApplicationDbContext context)
		{
			this.Mapper = mapper;
			this.Logger = logger;
			this.Context = context;
		}

		public virtual List<POCOState> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqPOCO(x => true, skip, take, orderClause);
		}

		public virtual POCOState Get(int id)
		{
			return this.SearchLinqPOCO(x => x.Id == id).FirstOrDefault();
		}

		public virtual POCOState Create(
			StateModel model)
		{
			State record = new State();

			this.Mapper.StateMapModelToEF(
				default (int),
				model,
				record);

			this.Context.Set<State>().Add(record);
			this.Context.SaveChanges();
			return this.Mapper.StateMapEFToPOCO(record);
		}

		public virtual void Update(
			int id,
			StateModel model)
		{
			State record = this.SearchLinqEF(x => x.Id == id).FirstOrDefault();
			if (record == null)
			{
				throw new RecordNotFoundException($"Unable to find id:{id}");
			}
			else
			{
				this.Mapper.StateMapModelToEF(
					id,
					model,
					record);
				this.Context.SaveChanges();
			}
		}

		public virtual void Delete(
			int id)
		{
			State record = this.SearchLinqEF(x => x.Id == id).FirstOrDefault();

			if (record == null)
			{
				return;
			}
			else
			{
				this.Context.Set<State>().Remove(record);
				this.Context.SaveChanges();
			}
		}

		protected List<POCOState> Where(Expression<Func<State, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqPOCO(predicate, skip, take, orderClause);
		}

		private List<POCOState> SearchLinqPOCO(Expression<Func<State, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<POCOState> response = new List<POCOState>();
			List<State> records = this.SearchLinqEF(predicate, skip, take, orderClause);
			records.ForEach(x => response.Add(this.Mapper.StateMapEFToPOCO(x)));
			return response;
		}

		private List<State> SearchLinqEF(Expression<Func<State, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrWhiteSpace(orderClause))
			{
				orderClause = $"{nameof(State.Id)} ASC";
			}
			return this.Context.Set<State>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<State>();
		}

		private List<State> SearchLinqEFDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrWhiteSpace(orderClause))
			{
				orderClause = $"{nameof(State.Id)} ASC";
			}

			return this.Context.Set<State>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<State>();
		}
	}
}

/*<Codenesium>
    <Hash>c6bc17c9c01d77e6fc05802d8c4469e3</Hash>
</Codenesium>*/