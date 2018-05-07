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

		public virtual int Create(
			AddressTypeModel model)
		{
			EFAddressType record = new EFAddressType();

			this.Mapper.AddressTypeMapModelToEF(
				default (int),
				model,
				record);

			this.Context.Set<EFAddressType>().Add(record);
			this.Context.SaveChanges();
			return record.AddressTypeID;
		}

		public virtual void Update(
			int addressTypeID,
			AddressTypeModel model)
		{
			EFAddressType record = this.SearchLinqEF(x => x.AddressTypeID == addressTypeID).FirstOrDefault();
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
			EFAddressType record = this.SearchLinqEF(x => x.AddressTypeID == addressTypeID).FirstOrDefault();

			if (record == null)
			{
				return;
			}
			else
			{
				this.Context.Set<EFAddressType>().Remove(record);
				this.Context.SaveChanges();
			}
		}

		public virtual POCOAddressType Get(int addressTypeID)
		{
			return this.SearchLinqPOCO(x => x.AddressTypeID == addressTypeID).FirstOrDefault();
		}

		public virtual List<POCOAddressType> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqPOCO(x => true, skip, take, orderClause);
		}

		private List<POCOAddressType> Where(Expression<Func<EFAddressType, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqPOCO(predicate, skip, take, orderClause);
		}

		private List<POCOAddressType> SearchLinqPOCO(Expression<Func<EFAddressType, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<POCOAddressType> response = new List<POCOAddressType>();
			List<EFAddressType> records = this.SearchLinqEF(predicate, skip, take, orderClause);
			records.ForEach(x => response.Add(this.Mapper.AddressTypeMapEFToPOCO(x)));
			return response;
		}

		private List<EFAddressType> SearchLinqEF(Expression<Func<EFAddressType, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrEmpty(orderClause))
			{
				return this.Context.Set<EFAddressType>().Where(predicate).AsQueryable().OrderBy("AddressTypeID ASC").Skip(skip).Take(take).ToList<EFAddressType>();
			}
			else
			{
				return this.Context.Set<EFAddressType>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<EFAddressType>();
			}
		}

		private List<EFAddressType> SearchLinqEFDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrEmpty(orderClause))
			{
				return this.Context.Set<EFAddressType>().Where(predicate).AsQueryable().OrderBy("AddressTypeID ASC").Skip(skip).Take(take).ToList<EFAddressType>();
			}
			else
			{
				return this.Context.Set<EFAddressType>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<EFAddressType>();
			}
		}
	}
}

/*<Codenesium>
    <Hash>7e1ce654004652ed734eac1cd2ec86c0</Hash>
</Codenesium>*/