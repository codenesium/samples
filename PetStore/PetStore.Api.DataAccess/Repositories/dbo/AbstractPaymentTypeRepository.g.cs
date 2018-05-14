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
	public abstract class AbstractPaymentTypeRepository
	{
		protected ApplicationDbContext Context { get; }
		protected ILogger Logger { get; }
		protected IObjectMapper Mapper { get; }

		public AbstractPaymentTypeRepository(
			IObjectMapper mapper,
			ILogger logger,
			ApplicationDbContext context)
		{
			this.Mapper = mapper;
			this.Logger = logger;
			this.Context = context;
		}

		public virtual List<POCOPaymentType> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqPOCO(x => true, skip, take, orderClause);
		}

		public virtual POCOPaymentType Get(int id)
		{
			return this.SearchLinqPOCO(x => x.Id == id).FirstOrDefault();
		}

		public virtual POCOPaymentType Create(
			ApiPaymentTypeModel model)
		{
			PaymentType record = new PaymentType();

			this.Mapper.PaymentTypeMapModelToEF(
				default (int),
				model,
				record);

			this.Context.Set<PaymentType>().Add(record);
			this.Context.SaveChanges();
			return this.Mapper.PaymentTypeMapEFToPOCO(record);
		}

		public virtual void Update(
			int id,
			ApiPaymentTypeModel model)
		{
			PaymentType record = this.SearchLinqEF(x => x.Id == id).FirstOrDefault();
			if (record == null)
			{
				throw new RecordNotFoundException($"Unable to find id:{id}");
			}
			else
			{
				this.Mapper.PaymentTypeMapModelToEF(
					id,
					model,
					record);
				this.Context.SaveChanges();
			}
		}

		public virtual void Delete(
			int id)
		{
			PaymentType record = this.SearchLinqEF(x => x.Id == id).FirstOrDefault();

			if (record == null)
			{
				return;
			}
			else
			{
				this.Context.Set<PaymentType>().Remove(record);
				this.Context.SaveChanges();
			}
		}

		protected List<POCOPaymentType> Where(Expression<Func<PaymentType, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqPOCO(predicate, skip, take, orderClause);
		}

		private List<POCOPaymentType> SearchLinqPOCO(Expression<Func<PaymentType, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<POCOPaymentType> response = new List<POCOPaymentType>();
			List<PaymentType> records = this.SearchLinqEF(predicate, skip, take, orderClause);
			records.ForEach(x => response.Add(this.Mapper.PaymentTypeMapEFToPOCO(x)));
			return response;
		}

		private List<PaymentType> SearchLinqEF(Expression<Func<PaymentType, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrWhiteSpace(orderClause))
			{
				orderClause = $"{nameof(PaymentType.Id)} ASC";
			}
			return this.Context.Set<PaymentType>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<PaymentType>();
		}

		private List<PaymentType> SearchLinqEFDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrWhiteSpace(orderClause))
			{
				orderClause = $"{nameof(PaymentType.Id)} ASC";
			}

			return this.Context.Set<PaymentType>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<PaymentType>();
		}
	}
}

/*<Codenesium>
    <Hash>e473033923c05bc3fa9080a4d821dabc</Hash>
</Codenesium>*/