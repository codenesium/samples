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
	public abstract class AbstractClaspRepository
	{
		protected ApplicationDbContext Context { get; }
		protected ILogger Logger { get; }
		protected IObjectMapper Mapper { get; }

		public AbstractClaspRepository(
			IObjectMapper mapper,
			ILogger logger,
			ApplicationDbContext context)
		{
			this.Mapper = mapper;
			this.Logger = logger;
			this.Context = context;
		}

		public virtual List<POCOClasp> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqPOCO(x => true, skip, take, orderClause);
		}

		public virtual POCOClasp Get(int id)
		{
			return this.SearchLinqPOCO(x => x.Id == id).FirstOrDefault();
		}

		public virtual POCOClasp Create(
			ApiClaspModel model)
		{
			Clasp record = new Clasp();

			this.Mapper.ClaspMapModelToEF(
				default (int),
				model,
				record);

			this.Context.Set<Clasp>().Add(record);
			this.Context.SaveChanges();
			return this.Mapper.ClaspMapEFToPOCO(record);
		}

		public virtual void Update(
			int id,
			ApiClaspModel model)
		{
			Clasp record = this.SearchLinqEF(x => x.Id == id).FirstOrDefault();
			if (record == null)
			{
				throw new RecordNotFoundException($"Unable to find id:{id}");
			}
			else
			{
				this.Mapper.ClaspMapModelToEF(
					id,
					model,
					record);
				this.Context.SaveChanges();
			}
		}

		public virtual void Delete(
			int id)
		{
			Clasp record = this.SearchLinqEF(x => x.Id == id).FirstOrDefault();

			if (record == null)
			{
				return;
			}
			else
			{
				this.Context.Set<Clasp>().Remove(record);
				this.Context.SaveChanges();
			}
		}

		protected List<POCOClasp> Where(Expression<Func<Clasp, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqPOCO(predicate, skip, take, orderClause);
		}

		private List<POCOClasp> SearchLinqPOCO(Expression<Func<Clasp, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<POCOClasp> response = new List<POCOClasp>();
			List<Clasp> records = this.SearchLinqEF(predicate, skip, take, orderClause);
			records.ForEach(x => response.Add(this.Mapper.ClaspMapEFToPOCO(x)));
			return response;
		}

		private List<Clasp> SearchLinqEF(Expression<Func<Clasp, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrWhiteSpace(orderClause))
			{
				orderClause = $"{nameof(Clasp.Id)} ASC";
			}
			return this.Context.Set<Clasp>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<Clasp>();
		}

		private List<Clasp> SearchLinqEFDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrWhiteSpace(orderClause))
			{
				orderClause = $"{nameof(Clasp.Id)} ASC";
			}

			return this.Context.Set<Clasp>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<Clasp>();
		}
	}
}

/*<Codenesium>
    <Hash>7bb9886c30d7df976a99e902f0ed5bc0</Hash>
</Codenesium>*/