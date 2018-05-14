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
	public abstract class AbstractLinkLogRepository
	{
		protected ApplicationDbContext Context { get; }
		protected ILogger Logger { get; }
		protected IObjectMapper Mapper { get; }

		public AbstractLinkLogRepository(
			IObjectMapper mapper,
			ILogger logger,
			ApplicationDbContext context)
		{
			this.Mapper = mapper;
			this.Logger = logger;
			this.Context = context;
		}

		public virtual List<POCOLinkLog> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqPOCO(x => true, skip, take, orderClause);
		}

		public virtual POCOLinkLog Get(int id)
		{
			return this.SearchLinqPOCO(x => x.Id == id).FirstOrDefault();
		}

		public virtual POCOLinkLog Create(
			ApiLinkLogModel model)
		{
			LinkLog record = new LinkLog();

			this.Mapper.LinkLogMapModelToEF(
				default (int),
				model,
				record);

			this.Context.Set<LinkLog>().Add(record);
			this.Context.SaveChanges();
			return this.Mapper.LinkLogMapEFToPOCO(record);
		}

		public virtual void Update(
			int id,
			ApiLinkLogModel model)
		{
			LinkLog record = this.SearchLinqEF(x => x.Id == id).FirstOrDefault();
			if (record == null)
			{
				throw new RecordNotFoundException($"Unable to find id:{id}");
			}
			else
			{
				this.Mapper.LinkLogMapModelToEF(
					id,
					model,
					record);
				this.Context.SaveChanges();
			}
		}

		public virtual void Delete(
			int id)
		{
			LinkLog record = this.SearchLinqEF(x => x.Id == id).FirstOrDefault();

			if (record == null)
			{
				return;
			}
			else
			{
				this.Context.Set<LinkLog>().Remove(record);
				this.Context.SaveChanges();
			}
		}

		protected List<POCOLinkLog> Where(Expression<Func<LinkLog, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqPOCO(predicate, skip, take, orderClause);
		}

		private List<POCOLinkLog> SearchLinqPOCO(Expression<Func<LinkLog, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<POCOLinkLog> response = new List<POCOLinkLog>();
			List<LinkLog> records = this.SearchLinqEF(predicate, skip, take, orderClause);
			records.ForEach(x => response.Add(this.Mapper.LinkLogMapEFToPOCO(x)));
			return response;
		}

		private List<LinkLog> SearchLinqEF(Expression<Func<LinkLog, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrWhiteSpace(orderClause))
			{
				orderClause = $"{nameof(LinkLog.Id)} ASC";
			}
			return this.Context.Set<LinkLog>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<LinkLog>();
		}

		private List<LinkLog> SearchLinqEFDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrWhiteSpace(orderClause))
			{
				orderClause = $"{nameof(LinkLog.Id)} ASC";
			}

			return this.Context.Set<LinkLog>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<LinkLog>();
		}
	}
}

/*<Codenesium>
    <Hash>a824628b0d94c33afaa4f1962d58a821</Hash>
</Codenesium>*/