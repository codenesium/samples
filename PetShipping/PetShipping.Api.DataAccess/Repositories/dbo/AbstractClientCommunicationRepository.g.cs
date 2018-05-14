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
	public abstract class AbstractClientCommunicationRepository
	{
		protected ApplicationDbContext Context { get; }
		protected ILogger Logger { get; }
		protected IObjectMapper Mapper { get; }

		public AbstractClientCommunicationRepository(
			IObjectMapper mapper,
			ILogger logger,
			ApplicationDbContext context)
		{
			this.Mapper = mapper;
			this.Logger = logger;
			this.Context = context;
		}

		public virtual List<POCOClientCommunication> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqPOCO(x => true, skip, take, orderClause);
		}

		public virtual POCOClientCommunication Get(int id)
		{
			return this.SearchLinqPOCO(x => x.Id == id).FirstOrDefault();
		}

		public virtual POCOClientCommunication Create(
			ClientCommunicationModel model)
		{
			ClientCommunication record = new ClientCommunication();

			this.Mapper.ClientCommunicationMapModelToEF(
				default (int),
				model,
				record);

			this.Context.Set<ClientCommunication>().Add(record);
			this.Context.SaveChanges();
			return this.Mapper.ClientCommunicationMapEFToPOCO(record);
		}

		public virtual void Update(
			int id,
			ClientCommunicationModel model)
		{
			ClientCommunication record = this.SearchLinqEF(x => x.Id == id).FirstOrDefault();
			if (record == null)
			{
				throw new RecordNotFoundException($"Unable to find id:{id}");
			}
			else
			{
				this.Mapper.ClientCommunicationMapModelToEF(
					id,
					model,
					record);
				this.Context.SaveChanges();
			}
		}

		public virtual void Delete(
			int id)
		{
			ClientCommunication record = this.SearchLinqEF(x => x.Id == id).FirstOrDefault();

			if (record == null)
			{
				return;
			}
			else
			{
				this.Context.Set<ClientCommunication>().Remove(record);
				this.Context.SaveChanges();
			}
		}

		protected List<POCOClientCommunication> Where(Expression<Func<ClientCommunication, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqPOCO(predicate, skip, take, orderClause);
		}

		private List<POCOClientCommunication> SearchLinqPOCO(Expression<Func<ClientCommunication, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<POCOClientCommunication> response = new List<POCOClientCommunication>();
			List<ClientCommunication> records = this.SearchLinqEF(predicate, skip, take, orderClause);
			records.ForEach(x => response.Add(this.Mapper.ClientCommunicationMapEFToPOCO(x)));
			return response;
		}

		private List<ClientCommunication> SearchLinqEF(Expression<Func<ClientCommunication, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrWhiteSpace(orderClause))
			{
				orderClause = $"{nameof(ClientCommunication.Id)} ASC";
			}
			return this.Context.Set<ClientCommunication>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<ClientCommunication>();
		}

		private List<ClientCommunication> SearchLinqEFDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrWhiteSpace(orderClause))
			{
				orderClause = $"{nameof(ClientCommunication.Id)} ASC";
			}

			return this.Context.Set<ClientCommunication>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<ClientCommunication>();
		}
	}
}

/*<Codenesium>
    <Hash>1dcb27f9124ba076eadee8415e380fac</Hash>
</Codenesium>*/