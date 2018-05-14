using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using AdventureWorksNS.Api.Contracts;

namespace AdventureWorksNS.Api.DataAccess
{
	public abstract class AbstractAddressTypeRepository
	{
		protected ApplicationDbContext Context { get; }
		protected ILogger Logger { get; }
		protected IObjectMapper Mapper { get; }

		public AbstractAddressTypeRepository(
			IObjectMapper mapper,
			ILogger logger,
			ApplicationDbContext context)
		{
			this.Mapper = mapper;
			this.Logger = logger;
			this.Context = context;
		}

		public virtual List<POCOAddressType> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqPOCO(x => true, skip, take, orderClause);
		}

		public virtual POCOAddressType Get(int addressTypeID)
		{
			return this.SearchLinqPOCO(x => x.AddressTypeID == addressTypeID).FirstOrDefault();
		}

		public virtual POCOAddressType Create(
			ApiAddressTypeModel model)
		{
			AddressType record = new AddressType();

			this.Mapper.AddressTypeMapModelToEF(
				default (int),
				model,
				record);

			this.Context.Set<AddressType>().Add(record);
			this.Context.SaveChanges();
			return this.Mapper.AddressTypeMapEFToPOCO(record);
		}

		public virtual void Update(
			int addressTypeID,
			ApiAddressTypeModel model)
		{
			AddressType record = this.SearchLinqEF(x => x.AddressTypeID == addressTypeID).FirstOrDefault();
			if (record == null)
			{
				throw new RecordNotFoundException($"Unable to find id:{addressTypeID}");
			}
			else
			{
				this.Mapper.AddressTypeMapModelToEF(
					addressTypeID,
					model,
					record);
				this.Context.SaveChanges();
			}
		}

		public virtual void Delete(
			int addressTypeID)
		{
			AddressType record = this.SearchLinqEF(x => x.AddressTypeID == addressTypeID).FirstOrDefault();

			if (record == null)
			{
				return;
			}
			else
			{
				this.Context.Set<AddressType>().Remove(record);
				this.Context.SaveChanges();
			}
		}

		public POCOAddressType GetName(string name)
		{
			return this.SearchLinqPOCO(x => x.Name == name).FirstOrDefault();
		}

		protected List<POCOAddressType> Where(Expression<Func<AddressType, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqPOCO(predicate, skip, take, orderClause);
		}

		private List<POCOAddressType> SearchLinqPOCO(Expression<Func<AddressType, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<POCOAddressType> response = new List<POCOAddressType>();
			List<AddressType> records = this.SearchLinqEF(predicate, skip, take, orderClause);
			records.ForEach(x => response.Add(this.Mapper.AddressTypeMapEFToPOCO(x)));
			return response;
		}

		private List<AddressType> SearchLinqEF(Expression<Func<AddressType, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrWhiteSpace(orderClause))
			{
				orderClause = $"{nameof(AddressType.AddressTypeID)} ASC";
			}
			return this.Context.Set<AddressType>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<AddressType>();
		}

		private List<AddressType> SearchLinqEFDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrWhiteSpace(orderClause))
			{
				orderClause = $"{nameof(AddressType.AddressTypeID)} ASC";
			}

			return this.Context.Set<AddressType>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<AddressType>();
		}
	}
}

/*<Codenesium>
    <Hash>9038070d327d69b9555907280b2622e0</Hash>
</Codenesium>*/