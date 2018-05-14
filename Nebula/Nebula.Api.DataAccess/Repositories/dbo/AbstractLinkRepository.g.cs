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
	public abstract class AbstractLinkRepository
	{
		protected ApplicationDbContext Context { get; }
		protected ILogger Logger { get; }
		protected IObjectMapper Mapper { get; }

		public AbstractLinkRepository(
			IObjectMapper mapper,
			ILogger logger,
			ApplicationDbContext context)
		{
			this.Mapper = mapper;
			this.Logger = logger;
			this.Context = context;
		}

		public virtual List<POCOLink> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqPOCO(x => true, skip, take, orderClause);
		}

		public virtual POCOLink Get(int id)
		{
			return this.SearchLinqPOCO(x => x.Id == id).FirstOrDefault();
		}

		public virtual POCOLink Create(
			ApiLinkModel model)
		{
			Link record = new Link();

			this.Mapper.LinkMapModelToEF(
				default (int),
				model,
				record);

			this.Context.Set<Link>().Add(record);
			this.Context.SaveChanges();
			return this.Mapper.LinkMapEFToPOCO(record);
		}

		public virtual void Update(
			int id,
			ApiLinkModel model)
		{
			Link record = this.SearchLinqEF(x => x.Id == id).FirstOrDefault();
			if (record == null)
			{
				throw new RecordNotFoundException($"Unable to find id:{id}");
			}
			else
			{
				this.Mapper.LinkMapModelToEF(
					id,
					model,
					record);
				this.Context.SaveChanges();
			}
		}

		public virtual void Delete(
			int id)
		{
			Link record = this.SearchLinqEF(x => x.Id == id).FirstOrDefault();

			if (record == null)
			{
				return;
			}
			else
			{
				this.Context.Set<Link>().Remove(record);
				this.Context.SaveChanges();
			}
		}

		public List<POCOLink> ChainId(int chainId)
		{
			return this.SearchLinqPOCO(x => x.ChainId == chainId);
		}
		public POCOLink ExternalId(Guid externalId)
		{
			return this.SearchLinqPOCO(x => x.ExternalId == externalId).FirstOrDefault();
		}

		protected List<POCOLink> Where(Expression<Func<Link, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqPOCO(predicate, skip, take, orderClause);
		}

		private List<POCOLink> SearchLinqPOCO(Expression<Func<Link, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<POCOLink> response = new List<POCOLink>();
			List<Link> records = this.SearchLinqEF(predicate, skip, take, orderClause);
			records.ForEach(x => response.Add(this.Mapper.LinkMapEFToPOCO(x)));
			return response;
		}

		private List<Link> SearchLinqEF(Expression<Func<Link, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrWhiteSpace(orderClause))
			{
				orderClause = $"{nameof(Link.Id)} ASC";
			}
			return this.Context.Set<Link>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<Link>();
		}

		private List<Link> SearchLinqEFDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrWhiteSpace(orderClause))
			{
				orderClause = $"{nameof(Link.Id)} ASC";
			}

			return this.Context.Set<Link>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<Link>();
		}
	}
}

/*<Codenesium>
    <Hash>6fa9ab98e0a21d92967a08b3f4c5e260</Hash>
</Codenesium>*/