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
	public abstract class AbstractContactTypeRepository
	{
		protected ApplicationDbContext Context { get; }
		protected ILogger Logger { get; }
		protected IObjectMapper Mapper { get; }

		public AbstractContactTypeRepository(
			IObjectMapper mapper,
			ILogger logger,
			ApplicationDbContext context)
		{
			this.Mapper = mapper;
			this.Logger = logger;
			this.Context = context;
		}

		public virtual int Create(
			ContactTypeModel model)
		{
			var record = new EFContactType();

			this.Mapper.ContactTypeMapModelToEF(
				default (int),
				model,
				record);

			this.Context.Set<EFContactType>().Add(record);
			this.Context.SaveChanges();
			return record.ContactTypeID;
		}

		public virtual void Update(
			int contactTypeID,
			ContactTypeModel model)
		{
			var record = this.SearchLinqEF(x => x.ContactTypeID == contactTypeID).FirstOrDefault();
			if (record == null)
			{
				throw new Exception($"Unable to find id:{contactTypeID}");
			}
			else
			{
				this.Mapper.ContactTypeMapModelToEF(
					contactTypeID,
					model,
					record);
				this.Context.SaveChanges();
			}
		}

		public virtual void Delete(
			int contactTypeID)
		{
			var record = this.SearchLinqEF(x => x.ContactTypeID == contactTypeID).FirstOrDefault();

			if (record == null)
			{
				return;
			}
			else
			{
				this.Context.Set<EFContactType>().Remove(record);
				this.Context.SaveChanges();
			}
		}

		public virtual ApiResponse GetById(int contactTypeID)
		{
			return this.SearchLinqPOCO(x => x.ContactTypeID == contactTypeID);
		}

		public virtual POCOContactType GetByIdDirect(int contactTypeID)
		{
			return this.SearchLinqPOCO(x => x.ContactTypeID == contactTypeID).ContactTypes.FirstOrDefault();
		}

		public virtual ApiResponse GetWhere(Expression<Func<EFContactType, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqPOCO(predicate, skip, take, orderClause);
		}

		public virtual ApiResponse GetWhereDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqPOCODynamic(predicate, skip, take, orderClause);
		}

		public virtual List<POCOContactType> GetWhereDirect(Expression<Func<EFContactType, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqPOCO(predicate, skip, take, orderClause).ContactTypes;
		}

		private ApiResponse SearchLinqPOCO(Expression<Func<EFContactType, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			var response = new ApiResponse();

			List<EFContactType> records = this.SearchLinqEF(predicate, skip, take, orderClause);
			records.ForEach(x => this.Mapper.ContactTypeMapEFToPOCO(x, response));
			return response;
		}

		private ApiResponse SearchLinqPOCODynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			var response = new ApiResponse();

			List<EFContactType> records = this.SearchLinqEFDynamic(predicate, skip, take, orderClause);
			records.ForEach(x => this.Mapper.ContactTypeMapEFToPOCO(x, response));
			return response;
		}

		protected virtual List<EFContactType> SearchLinqEF(Expression<Func<EFContactType, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			throw new NotImplementedException("This method should be implemented in a derived class");
		}

		protected virtual List<EFContactType> SearchLinqEFDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			throw new NotImplementedException("This method should be implemented in a derived class");
		}
	}
}

/*<Codenesium>
    <Hash>bc179a46f44f69a2485897d6f6d02d15</Hash>
</Codenesium>*/