using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using PetStoreNS.Api.Contracts;

namespace PetStoreNS.Api.DataAccess
{
	public abstract class AbstractPenRepository
	{
		protected ApplicationDbContext Context { get; }
		protected ILogger Logger { get; }
		protected IObjectMapper Mapper { get; }

		public AbstractPenRepository(
			IObjectMapper mapper,
			ILogger logger,
			ApplicationDbContext context)
		{
			this.Mapper = mapper;
			this.Logger = logger;
			this.Context = context;
		}

		public virtual List<POCOPen> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqPOCO(x => true, skip, take, orderClause);
		}

		public virtual POCOPen Get(int id)
		{
			return this.SearchLinqPOCO(x => x.Id == id).FirstOrDefault();
		}

		public virtual POCOPen Create(
			PenModel model)
		{
			Pen record = new Pen();

			this.Mapper.PenMapModelToEF(
				default (int),
				model,
				record);

			this.Context.Set<Pen>().Add(record);
			this.Context.SaveChanges();
			return this.Mapper.PenMapEFToPOCO(record);
		}

		public virtual void Update(
			int id,
			PenModel model)
		{
			Pen record = this.SearchLinqEF(x => x.Id == id).FirstOrDefault();
			if (record == null)
			{
				throw new RecordNotFoundException($"Unable to find id:{id}");
			}
			else
			{
				this.Mapper.PenMapModelToEF(
					id,
					model,
					record);
				this.Context.SaveChanges();
			}
		}

		public virtual void Delete(
			int id)
		{
			Pen record = this.SearchLinqEF(x => x.Id == id).FirstOrDefault();

			if (record == null)
			{
				return;
			}
			else
			{
				this.Context.Set<Pen>().Remove(record);
				this.Context.SaveChanges();
			}
		}

		protected List<POCOPen> Where(Expression<Func<Pen, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqPOCO(predicate, skip, take, orderClause);
		}

		private List<POCOPen> SearchLinqPOCO(Expression<Func<Pen, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<POCOPen> response = new List<POCOPen>();
			List<Pen> records = this.SearchLinqEF(predicate, skip, take, orderClause);
			records.ForEach(x => response.Add(this.Mapper.PenMapEFToPOCO(x)));
			return response;
		}

		private List<Pen> SearchLinqEF(Expression<Func<Pen, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrWhiteSpace(orderClause))
			{
				orderClause = $"{nameof(Pen.Id)} ASC";
			}
			return this.Context.Set<Pen>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<Pen>();
		}

		private List<Pen> SearchLinqEFDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrWhiteSpace(orderClause))
			{
				orderClause = $"{nameof(Pen.Id)} ASC";
			}

			return this.Context.Set<Pen>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<Pen>();
		}
	}
}

/*<Codenesium>
    <Hash>d48d3240e01a3b742a18cd9b362a7b4b</Hash>
</Codenesium>*/