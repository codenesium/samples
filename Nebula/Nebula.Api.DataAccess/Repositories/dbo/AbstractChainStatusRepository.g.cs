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
	public abstract class AbstractChainStatusRepository
	{
		protected ApplicationDbContext Context { get; }
		protected ILogger Logger { get; }
		protected IObjectMapper Mapper { get; }

		public AbstractChainStatusRepository(
			IObjectMapper mapper,
			ILogger logger,
			ApplicationDbContext context)
		{
			this.Mapper = mapper;
			this.Logger = logger;
			this.Context = context;
		}

		public virtual List<POCOChainStatus> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqPOCO(x => true, skip, take, orderClause);
		}

		public virtual POCOChainStatus Get(int id)
		{
			return this.SearchLinqPOCO(x => x.Id == id).FirstOrDefault();
		}

		public virtual POCOChainStatus Create(
			ApiChainStatusModel model)
		{
			ChainStatus record = new ChainStatus();

			this.Mapper.ChainStatusMapModelToEF(
				default (int),
				model,
				record);

			this.Context.Set<ChainStatus>().Add(record);
			this.Context.SaveChanges();
			return this.Mapper.ChainStatusMapEFToPOCO(record);
		}

		public virtual void Update(
			int id,
			ApiChainStatusModel model)
		{
			ChainStatus record = this.SearchLinqEF(x => x.Id == id).FirstOrDefault();
			if (record == null)
			{
				throw new RecordNotFoundException($"Unable to find id:{id}");
			}
			else
			{
				this.Mapper.ChainStatusMapModelToEF(
					id,
					model,
					record);
				this.Context.SaveChanges();
			}
		}

		public virtual void Delete(
			int id)
		{
			ChainStatus record = this.SearchLinqEF(x => x.Id == id).FirstOrDefault();

			if (record == null)
			{
				return;
			}
			else
			{
				this.Context.Set<ChainStatus>().Remove(record);
				this.Context.SaveChanges();
			}
		}

		public POCOChainStatus Name(string name)
		{
			return this.SearchLinqPOCO(x => x.Name == name).FirstOrDefault();
		}

		protected List<POCOChainStatus> Where(Expression<Func<ChainStatus, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqPOCO(predicate, skip, take, orderClause);
		}

		private List<POCOChainStatus> SearchLinqPOCO(Expression<Func<ChainStatus, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<POCOChainStatus> response = new List<POCOChainStatus>();
			List<ChainStatus> records = this.SearchLinqEF(predicate, skip, take, orderClause);
			records.ForEach(x => response.Add(this.Mapper.ChainStatusMapEFToPOCO(x)));
			return response;
		}

		private List<ChainStatus> SearchLinqEF(Expression<Func<ChainStatus, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrWhiteSpace(orderClause))
			{
				orderClause = $"{nameof(ChainStatus.Id)} ASC";
			}
			return this.Context.Set<ChainStatus>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<ChainStatus>();
		}

		private List<ChainStatus> SearchLinqEFDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrWhiteSpace(orderClause))
			{
				orderClause = $"{nameof(ChainStatus.Id)} ASC";
			}

			return this.Context.Set<ChainStatus>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<ChainStatus>();
		}
	}
}

/*<Codenesium>
    <Hash>beb8485b7b9f4b89998cd7f9766c2501</Hash>
</Codenesium>*/