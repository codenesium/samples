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
	public abstract class AbstractDestinationRepository
	{
		protected ApplicationDbContext Context { get; }
		protected ILogger Logger { get; }
		protected IObjectMapper Mapper { get; }

		public AbstractDestinationRepository(
			IObjectMapper mapper,
			ILogger logger,
			ApplicationDbContext context)
		{
			this.Mapper = mapper;
			this.Logger = logger;
			this.Context = context;
		}

		public virtual List<POCODestination> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqPOCO(x => true, skip, take, orderClause);
		}

		public virtual POCODestination Get(int id)
		{
			return this.SearchLinqPOCO(x => x.Id == id).FirstOrDefault();
		}

		public virtual POCODestination Create(
			DestinationModel model)
		{
			Destination record = new Destination();

			this.Mapper.DestinationMapModelToEF(
				default (int),
				model,
				record);

			this.Context.Set<Destination>().Add(record);
			this.Context.SaveChanges();
			return this.Mapper.DestinationMapEFToPOCO(record);
		}

		public virtual void Update(
			int id,
			DestinationModel model)
		{
			Destination record = this.SearchLinqEF(x => x.Id == id).FirstOrDefault();
			if (record == null)
			{
				throw new RecordNotFoundException($"Unable to find id:{id}");
			}
			else
			{
				this.Mapper.DestinationMapModelToEF(
					id,
					model,
					record);
				this.Context.SaveChanges();
			}
		}

		public virtual void Delete(
			int id)
		{
			Destination record = this.SearchLinqEF(x => x.Id == id).FirstOrDefault();

			if (record == null)
			{
				return;
			}
			else
			{
				this.Context.Set<Destination>().Remove(record);
				this.Context.SaveChanges();
			}
		}

		protected List<POCODestination> Where(Expression<Func<Destination, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqPOCO(predicate, skip, take, orderClause);
		}

		private List<POCODestination> SearchLinqPOCO(Expression<Func<Destination, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<POCODestination> response = new List<POCODestination>();
			List<Destination> records = this.SearchLinqEF(predicate, skip, take, orderClause);
			records.ForEach(x => response.Add(this.Mapper.DestinationMapEFToPOCO(x)));
			return response;
		}

		private List<Destination> SearchLinqEF(Expression<Func<Destination, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrWhiteSpace(orderClause))
			{
				orderClause = $"{nameof(Destination.Id)} ASC";
			}
			return this.Context.Set<Destination>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<Destination>();
		}

		private List<Destination> SearchLinqEFDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrWhiteSpace(orderClause))
			{
				orderClause = $"{nameof(Destination.Id)} ASC";
			}

			return this.Context.Set<Destination>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<Destination>();
		}
	}
}

/*<Codenesium>
    <Hash>49b4587a9b8b53c43bf75ee423d859de</Hash>
</Codenesium>*/