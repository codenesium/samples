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
	public abstract class AbstractLinkStatusRepository
	{
		protected ApplicationDbContext Context { get; }
		protected ILogger Logger { get; }
		protected IObjectMapper Mapper { get; }

		public AbstractLinkStatusRepository(
			IObjectMapper mapper,
			ILogger logger,
			ApplicationDbContext context)
		{
			this.Mapper = mapper;
			this.Logger = logger;
			this.Context = context;
		}

		public virtual List<POCOLinkStatus> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqPOCO(x => true, skip, take, orderClause);
		}

		public virtual POCOLinkStatus Get(int id)
		{
			return this.SearchLinqPOCO(x => x.Id == id).FirstOrDefault();
		}

		public virtual POCOLinkStatus Create(
			LinkStatusModel model)
		{
			LinkStatus record = new LinkStatus();

			this.Mapper.LinkStatusMapModelToEF(
				default (int),
				model,
				record);

			this.Context.Set<LinkStatus>().Add(record);
			this.Context.SaveChanges();
			return this.Mapper.LinkStatusMapEFToPOCO(record);
		}

		public virtual void Update(
			int id,
			LinkStatusModel model)
		{
			LinkStatus record = this.SearchLinqEF(x => x.Id == id).FirstOrDefault();
			if (record == null)
			{
				throw new RecordNotFoundException($"Unable to find id:{id}");
			}
			else
			{
				this.Mapper.LinkStatusMapModelToEF(
					id,
					model,
					record);
				this.Context.SaveChanges();
			}
		}

		public virtual void Delete(
			int id)
		{
			LinkStatus record = this.SearchLinqEF(x => x.Id == id).FirstOrDefault();

			if (record == null)
			{
				return;
			}
			else
			{
				this.Context.Set<LinkStatus>().Remove(record);
				this.Context.SaveChanges();
			}
		}

		public POCOLinkStatus Name(string name)
		{
			return this.SearchLinqPOCO(x => x.Name == name).FirstOrDefault();
		}

		protected List<POCOLinkStatus> Where(Expression<Func<LinkStatus, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqPOCO(predicate, skip, take, orderClause);
		}

		private List<POCOLinkStatus> SearchLinqPOCO(Expression<Func<LinkStatus, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<POCOLinkStatus> response = new List<POCOLinkStatus>();
			List<LinkStatus> records = this.SearchLinqEF(predicate, skip, take, orderClause);
			records.ForEach(x => response.Add(this.Mapper.LinkStatusMapEFToPOCO(x)));
			return response;
		}

		private List<LinkStatus> SearchLinqEF(Expression<Func<LinkStatus, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrWhiteSpace(orderClause))
			{
				orderClause = $"{nameof(LinkStatus.Id)} ASC";
			}
			return this.Context.Set<LinkStatus>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<LinkStatus>();
		}

		private List<LinkStatus> SearchLinqEFDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrWhiteSpace(orderClause))
			{
				orderClause = $"{nameof(LinkStatus.Id)} ASC";
			}

			return this.Context.Set<LinkStatus>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<LinkStatus>();
		}
	}
}

/*<Codenesium>
    <Hash>d19c3f0c00ed8c8dd7b4c88f0ea52e6c</Hash>
</Codenesium>*/