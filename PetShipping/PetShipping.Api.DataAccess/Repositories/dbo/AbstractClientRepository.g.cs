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
	public abstract class AbstractClientRepository
	{
		protected ApplicationDbContext Context { get; }
		protected ILogger Logger { get; }
		protected IObjectMapper Mapper { get; }

		public AbstractClientRepository(
			IObjectMapper mapper,
			ILogger logger,
			ApplicationDbContext context)
		{
			this.Mapper = mapper;
			this.Logger = logger;
			this.Context = context;
		}

		public virtual List<POCOClient> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqPOCO(x => true, skip, take, orderClause);
		}

		public virtual POCOClient Get(int id)
		{
			return this.SearchLinqPOCO(x => x.Id == id).FirstOrDefault();
		}

		public virtual POCOClient Create(
			ApiClientModel model)
		{
			Client record = new Client();

			this.Mapper.ClientMapModelToEF(
				default (int),
				model,
				record);

			this.Context.Set<Client>().Add(record);
			this.Context.SaveChanges();
			return this.Mapper.ClientMapEFToPOCO(record);
		}

		public virtual void Update(
			int id,
			ApiClientModel model)
		{
			Client record = this.SearchLinqEF(x => x.Id == id).FirstOrDefault();
			if (record == null)
			{
				throw new RecordNotFoundException($"Unable to find id:{id}");
			}
			else
			{
				this.Mapper.ClientMapModelToEF(
					id,
					model,
					record);
				this.Context.SaveChanges();
			}
		}

		public virtual void Delete(
			int id)
		{
			Client record = this.SearchLinqEF(x => x.Id == id).FirstOrDefault();

			if (record == null)
			{
				return;
			}
			else
			{
				this.Context.Set<Client>().Remove(record);
				this.Context.SaveChanges();
			}
		}

		protected List<POCOClient> Where(Expression<Func<Client, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqPOCO(predicate, skip, take, orderClause);
		}

		private List<POCOClient> SearchLinqPOCO(Expression<Func<Client, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<POCOClient> response = new List<POCOClient>();
			List<Client> records = this.SearchLinqEF(predicate, skip, take, orderClause);
			records.ForEach(x => response.Add(this.Mapper.ClientMapEFToPOCO(x)));
			return response;
		}

		private List<Client> SearchLinqEF(Expression<Func<Client, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrWhiteSpace(orderClause))
			{
				orderClause = $"{nameof(Client.Id)} ASC";
			}
			return this.Context.Set<Client>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<Client>();
		}

		private List<Client> SearchLinqEFDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrWhiteSpace(orderClause))
			{
				orderClause = $"{nameof(Client.Id)} ASC";
			}

			return this.Context.Set<Client>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<Client>();
		}
	}
}

/*<Codenesium>
    <Hash>781eb792bdae66164a1abcc6b9a09ad2</Hash>
</Codenesium>*/