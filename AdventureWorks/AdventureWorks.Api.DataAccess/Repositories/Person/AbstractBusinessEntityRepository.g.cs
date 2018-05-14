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
	public abstract class AbstractBusinessEntityRepository
	{
		protected ApplicationDbContext Context { get; }
		protected ILogger Logger { get; }
		protected IObjectMapper Mapper { get; }

		public AbstractBusinessEntityRepository(
			IObjectMapper mapper,
			ILogger logger,
			ApplicationDbContext context)
		{
			this.Mapper = mapper;
			this.Logger = logger;
			this.Context = context;
		}

		public virtual List<POCOBusinessEntity> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqPOCO(x => true, skip, take, orderClause);
		}

		public virtual POCOBusinessEntity Get(int businessEntityID)
		{
			return this.SearchLinqPOCO(x => x.BusinessEntityID == businessEntityID).FirstOrDefault();
		}

		public virtual POCOBusinessEntity Create(
			ApiBusinessEntityModel model)
		{
			BusinessEntity record = new BusinessEntity();

			this.Mapper.BusinessEntityMapModelToEF(
				default (int),
				model,
				record);

			this.Context.Set<BusinessEntity>().Add(record);
			this.Context.SaveChanges();
			return this.Mapper.BusinessEntityMapEFToPOCO(record);
		}

		public virtual void Update(
			int businessEntityID,
			ApiBusinessEntityModel model)
		{
			BusinessEntity record = this.SearchLinqEF(x => x.BusinessEntityID == businessEntityID).FirstOrDefault();
			if (record == null)
			{
				throw new RecordNotFoundException($"Unable to find id:{businessEntityID}");
			}
			else
			{
				this.Mapper.BusinessEntityMapModelToEF(
					businessEntityID,
					model,
					record);
				this.Context.SaveChanges();
			}
		}

		public virtual void Delete(
			int businessEntityID)
		{
			BusinessEntity record = this.SearchLinqEF(x => x.BusinessEntityID == businessEntityID).FirstOrDefault();

			if (record == null)
			{
				return;
			}
			else
			{
				this.Context.Set<BusinessEntity>().Remove(record);
				this.Context.SaveChanges();
			}
		}

		protected List<POCOBusinessEntity> Where(Expression<Func<BusinessEntity, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqPOCO(predicate, skip, take, orderClause);
		}

		private List<POCOBusinessEntity> SearchLinqPOCO(Expression<Func<BusinessEntity, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<POCOBusinessEntity> response = new List<POCOBusinessEntity>();
			List<BusinessEntity> records = this.SearchLinqEF(predicate, skip, take, orderClause);
			records.ForEach(x => response.Add(this.Mapper.BusinessEntityMapEFToPOCO(x)));
			return response;
		}

		private List<BusinessEntity> SearchLinqEF(Expression<Func<BusinessEntity, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrWhiteSpace(orderClause))
			{
				orderClause = $"{nameof(BusinessEntity.BusinessEntityID)} ASC";
			}
			return this.Context.Set<BusinessEntity>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<BusinessEntity>();
		}

		private List<BusinessEntity> SearchLinqEFDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrWhiteSpace(orderClause))
			{
				orderClause = $"{nameof(BusinessEntity.BusinessEntityID)} ASC";
			}

			return this.Context.Set<BusinessEntity>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<BusinessEntity>();
		}
	}
}

/*<Codenesium>
    <Hash>cb52c0f1b6924a39c99bd5d816b97d47</Hash>
</Codenesium>*/