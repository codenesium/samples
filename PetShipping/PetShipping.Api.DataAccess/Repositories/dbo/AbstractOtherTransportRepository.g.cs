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
	public abstract class AbstractOtherTransportRepository
	{
		protected ApplicationDbContext Context { get; }
		protected ILogger Logger { get; }
		protected IObjectMapper Mapper { get; }

		public AbstractOtherTransportRepository(
			IObjectMapper mapper,
			ILogger logger,
			ApplicationDbContext context)
		{
			this.Mapper = mapper;
			this.Logger = logger;
			this.Context = context;
		}

		public virtual List<POCOOtherTransport> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqPOCO(x => true, skip, take, orderClause);
		}

		public virtual POCOOtherTransport Get(int id)
		{
			return this.SearchLinqPOCO(x => x.Id == id).FirstOrDefault();
		}

		public virtual POCOOtherTransport Create(
			OtherTransportModel model)
		{
			OtherTransport record = new OtherTransport();

			this.Mapper.OtherTransportMapModelToEF(
				default (int),
				model,
				record);

			this.Context.Set<OtherTransport>().Add(record);
			this.Context.SaveChanges();
			return this.Mapper.OtherTransportMapEFToPOCO(record);
		}

		public virtual void Update(
			int id,
			OtherTransportModel model)
		{
			OtherTransport record = this.SearchLinqEF(x => x.Id == id).FirstOrDefault();
			if (record == null)
			{
				throw new RecordNotFoundException($"Unable to find id:{id}");
			}
			else
			{
				this.Mapper.OtherTransportMapModelToEF(
					id,
					model,
					record);
				this.Context.SaveChanges();
			}
		}

		public virtual void Delete(
			int id)
		{
			OtherTransport record = this.SearchLinqEF(x => x.Id == id).FirstOrDefault();

			if (record == null)
			{
				return;
			}
			else
			{
				this.Context.Set<OtherTransport>().Remove(record);
				this.Context.SaveChanges();
			}
		}

		protected List<POCOOtherTransport> Where(Expression<Func<OtherTransport, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqPOCO(predicate, skip, take, orderClause);
		}

		private List<POCOOtherTransport> SearchLinqPOCO(Expression<Func<OtherTransport, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<POCOOtherTransport> response = new List<POCOOtherTransport>();
			List<OtherTransport> records = this.SearchLinqEF(predicate, skip, take, orderClause);
			records.ForEach(x => response.Add(this.Mapper.OtherTransportMapEFToPOCO(x)));
			return response;
		}

		private List<OtherTransport> SearchLinqEF(Expression<Func<OtherTransport, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrWhiteSpace(orderClause))
			{
				orderClause = $"{nameof(OtherTransport.Id)} ASC";
			}
			return this.Context.Set<OtherTransport>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<OtherTransport>();
		}

		private List<OtherTransport> SearchLinqEFDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrWhiteSpace(orderClause))
			{
				orderClause = $"{nameof(OtherTransport.Id)} ASC";
			}

			return this.Context.Set<OtherTransport>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<OtherTransport>();
		}
	}
}

/*<Codenesium>
    <Hash>f97bdd2b826774eb177a0aead3d7fa46</Hash>
</Codenesium>*/