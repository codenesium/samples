using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using PetShippingNS.Api.Contracts;

namespace PetShippingNS.Api.DataAccess
{
	public abstract class AbstractHandlerRepository
	{
		protected ApplicationDbContext Context { get; }
		protected ILogger Logger { get; }
		protected IObjectMapper Mapper { get; }

		public AbstractHandlerRepository(
			IObjectMapper mapper,
			ILogger logger,
			ApplicationDbContext context)
		{
			this.Mapper = mapper;
			this.Logger = logger;
			this.Context = context;
		}

		public virtual List<POCOHandler> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqPOCO(x => true, skip, take, orderClause);
		}

		public virtual POCOHandler Get(int id)
		{
			return this.SearchLinqPOCO(x => x.Id == id).FirstOrDefault();
		}

		public virtual POCOHandler Create(
			HandlerModel model)
		{
			Handler record = new Handler();

			this.Mapper.HandlerMapModelToEF(
				default (int),
				model,
				record);

			this.Context.Set<Handler>().Add(record);
			this.Context.SaveChanges();
			return this.Mapper.HandlerMapEFToPOCO(record);
		}

		public virtual void Update(
			int id,
			HandlerModel model)
		{
			Handler record = this.SearchLinqEF(x => x.Id == id).FirstOrDefault();
			if (record == null)
			{
				throw new RecordNotFoundException($"Unable to find id:{id}");
			}
			else
			{
				this.Mapper.HandlerMapModelToEF(
					id,
					model,
					record);
				this.Context.SaveChanges();
			}
		}

		public virtual void Delete(
			int id)
		{
			Handler record = this.SearchLinqEF(x => x.Id == id).FirstOrDefault();

			if (record == null)
			{
				return;
			}
			else
			{
				this.Context.Set<Handler>().Remove(record);
				this.Context.SaveChanges();
			}
		}

		protected List<POCOHandler> Where(Expression<Func<Handler, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqPOCO(predicate, skip, take, orderClause);
		}

		private List<POCOHandler> SearchLinqPOCO(Expression<Func<Handler, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<POCOHandler> response = new List<POCOHandler>();
			List<Handler> records = this.SearchLinqEF(predicate, skip, take, orderClause);
			records.ForEach(x => response.Add(this.Mapper.HandlerMapEFToPOCO(x)));
			return response;
		}

		private List<Handler> SearchLinqEF(Expression<Func<Handler, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrWhiteSpace(orderClause))
			{
				orderClause = $"{nameof(Handler.Id)} ASC";
			}
			return this.Context.Set<Handler>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<Handler>();
		}

		private List<Handler> SearchLinqEFDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrWhiteSpace(orderClause))
			{
				orderClause = $"{nameof(Handler.Id)} ASC";
			}

			return this.Context.Set<Handler>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<Handler>();
		}
	}
}

/*<Codenesium>
    <Hash>b081f47b50f23f6c818352a1ec5085f3</Hash>
</Codenesium>*/