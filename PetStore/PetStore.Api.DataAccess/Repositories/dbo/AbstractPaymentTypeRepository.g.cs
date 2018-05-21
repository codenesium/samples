using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;
using PetStoreNS.Api.Contracts;

namespace PetStoreNS.Api.DataAccess
{
	public abstract class AbstractPaymentTypeRepository: AbstractRepository
	{
		protected ApplicationDbContext Context { get; }
		protected ILogger Logger { get; }
		protected IObjectMapper Mapper { get; }

		public AbstractPaymentTypeRepository(
			IObjectMapper mapper,
			ILogger logger,
			ApplicationDbContext context)
			: base ()
		{
			this.Mapper = mapper;
			this.Logger = logger;
			this.Context = context;
		}

		public virtual Task<List<POCOPaymentType>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqPOCO(x => true, skip, take, orderClause);
		}

		public async virtual Task<POCOPaymentType> Get(int id)
		{
			PaymentType record = await this.GetById(id);

			return this.Mapper.PaymentTypeMapEFToPOCO(record);
		}

		public async virtual Task<POCOPaymentType> Create(
			ApiPaymentTypeModel model)
		{
			PaymentType record = new PaymentType();

			this.Mapper.PaymentTypeMapModelToEF(
				default (int),
				model,
				record);

			this.Context.Set<PaymentType>().Add(record);
			await this.Context.SaveChangesAsync();

			return this.Mapper.PaymentTypeMapEFToPOCO(record);
		}

		public async virtual Task Update(
			int id,
			ApiPaymentTypeModel model)
		{
			PaymentType record = await this.GetById(id);

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
				this.Context.SaveChangesAsync();
			}
		}

		public async virtual Task Delete(
			int id)
		{
			PaymentType record = await this.GetById(id);

			if (record == null)
			{
				return;
			}
			else
			{
				this.Context.Set<PaymentType>().Remove(record);
				await this.Context.SaveChangesAsync();
			}
		}

		protected async Task<List<POCOPaymentType>> Where(Expression<Func<PaymentType, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<POCOPaymentType> records = await this.SearchLinqPOCO(predicate, skip, take, orderClause);

			return records;
		}

		private async Task<List<POCOPaymentType>> SearchLinqPOCO(Expression<Func<PaymentType, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<POCOPaymentType> response = new List<POCOPaymentType>();
			List<PaymentType> records = await this.SearchLinqEF(predicate, skip, take, orderClause);

			records.ForEach(x => response.Add(this.Mapper.PaymentTypeMapEFToPOCO(x)));
			return response;
		}

		private async Task<List<PaymentType>> SearchLinqEF(Expression<Func<PaymentType, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrWhiteSpace(orderClause))
			{
				orderClause = $"{nameof(PaymentType.Id)} ASC";
			}
			return await this.Context.Set<PaymentType>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToListAsync<PaymentType>();
		}

		private async Task<List<PaymentType>> SearchLinqEFDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrWhiteSpace(orderClause))
			{
				orderClause = $"{nameof(PaymentType.Id)} ASC";
			}

			return await this.Context.Set<PaymentType>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToListAsync<PaymentType>();
		}

		private async Task<PaymentType> GetById(int id)
		{
			List<PaymentType> records = await this.SearchLinqEF(x => x.Id == id);

			return records.FirstOrDefault();
		}
	}
}

/*<Codenesium>
    <Hash>753041233e525d59df677e0e7d2845a0</Hash>
</Codenesium>*/