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
	public abstract class AbstractChainRepository
	{
		protected ApplicationDbContext Context { get; }
		protected ILogger Logger { get; }
		protected IObjectMapper Mapper { get; }

		public AbstractChainRepository(
			IObjectMapper mapper,
			ILogger logger,
			ApplicationDbContext context)
		{
			this.Mapper = mapper;
			this.Logger = logger;
			this.Context = context;
		}

		public virtual List<POCOChain> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqPOCO(x => true, skip, take, orderClause);
		}

		public virtual POCOChain Get(int id)
		{
			return this.SearchLinqPOCO(x => x.Id == id).FirstOrDefault();
		}

		public virtual POCOChain Create(
			ChainModel model)
		{
			Chain record = new Chain();

			this.Mapper.ChainMapModelToEF(
				default (int),
				model,
				record);

			this.Context.Set<Chain>().Add(record);
			this.Context.SaveChanges();
			return this.Mapper.ChainMapEFToPOCO(record);
		}

		public virtual void Update(
			int id,
			ChainModel model)
		{
			Chain record = this.SearchLinqEF(x => x.Id == id).FirstOrDefault();
			if (record == null)
			{
				throw new RecordNotFoundException($"Unable to find id:{id}");
			}
			else
			{
				this.Mapper.ChainMapModelToEF(
					id,
					model,
					record);
				this.Context.SaveChanges();
			}
		}

		public virtual void Delete(
			int id)
		{
			Chain record = this.SearchLinqEF(x => x.Id == id).FirstOrDefault();

			if (record == null)
			{
				return;
			}
			else
			{
				this.Context.Set<Chain>().Remove(record);
				this.Context.SaveChanges();
			}
		}

		public POCOChain ExternalId(Guid externalId)
		{
			return this.SearchLinqPOCO(x => x.ExternalId == externalId).FirstOrDefault();
		}

		protected List<POCOChain> Where(Expression<Func<Chain, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqPOCO(predicate, skip, take, orderClause);
		}

		private List<POCOChain> SearchLinqPOCO(Expression<Func<Chain, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<POCOChain> response = new List<POCOChain>();
			List<Chain> records = this.SearchLinqEF(predicate, skip, take, orderClause);
			records.ForEach(x => response.Add(this.Mapper.ChainMapEFToPOCO(x)));
			return response;
		}

		private List<Chain> SearchLinqEF(Expression<Func<Chain, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrWhiteSpace(orderClause))
			{
				orderClause = $"{nameof(Chain.Id)} ASC";
			}
			return this.Context.Set<Chain>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<Chain>();
		}

		private List<Chain> SearchLinqEFDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrWhiteSpace(orderClause))
			{
				orderClause = $"{nameof(Chain.Id)} ASC";
			}

			return this.Context.Set<Chain>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<Chain>();
		}
	}
}

/*<Codenesium>
    <Hash>3c177c018ddc392f2a1b42fe74b8ce14</Hash>
</Codenesium>*/