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
		protected ApplicationDbContext context;
		protected ILogger logger;
		protected IObjectMapper mapper;

		public AbstractContactTypeRepository(
			IObjectMapper mapper,
			ILogger logger,
			ApplicationDbContext context)
		{
			this.mapper = mapper;
			this.logger = logger;
			this.context = context;
		}

		public virtual int Create(
			ContactTypeModel model)
		{
			var record = new EFContactType();

			this.mapper.ContactTypeMapModelToEF(
				default (int),
				model,
				record);

			this.context.Set<EFContactType>().Add(record);
			this.context.SaveChanges();
			return record.ContactTypeID;
		}

		public virtual void Update(
			int contactTypeID,
			ContactTypeModel model)
		{
			var record = this.SearchLinqEF(x => x.ContactTypeID == contactTypeID).FirstOrDefault();
			if (record == null)
			{
				this.logger.LogError($"Unable to find id:{contactTypeID}");
			}
			else
			{
				this.mapper.ContactTypeMapModelToEF(
					contactTypeID,
					model,
					record);
				this.context.SaveChanges();
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
				this.context.Set<EFContactType>().Remove(record);
				this.context.SaveChanges();
			}
		}

		public virtual ApiResponse GetById(int contactTypeID)
		{
			var response = new ApiResponse();

			this.SearchLinqPOCO(x => x.ContactTypeID == contactTypeID, response);
			return response;
		}

		public virtual POCOContactType GetByIdDirect(int contactTypeID)
		{
			var response = new ApiResponse();

			this.SearchLinqPOCO(x => x.ContactTypeID == contactTypeID, response);
			return response.ContactTypes.FirstOrDefault();
		}

		public virtual ApiResponse GetWhere(Expression<Func<EFContactType, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			var response = new ApiResponse();

			this.SearchLinqPOCO(predicate, response, skip, take, orderClause);
			return response;
		}

		public virtual ApiResponse GetWhereDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			var response = new ApiResponse();

			this.SearchLinqPOCODynamic(predicate, response, skip, take, orderClause);
			return response;
		}

		public virtual List<POCOContactType> GetWhereDirect(Expression<Func<EFContactType, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			var response = new ApiResponse();

			this.SearchLinqPOCO(predicate, response, skip, take, orderClause);
			return response.ContactTypes;
		}

		private void SearchLinqPOCO(Expression<Func<EFContactType, bool>> predicate, ApiResponse response, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<EFContactType> records = this.SearchLinqEF(predicate, skip, take, orderClause);
			records.ForEach(x => this.mapper.ContactTypeMapEFToPOCO(x, response));
		}

		private void SearchLinqPOCODynamic(string predicate, ApiResponse response, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<EFContactType> records = this.SearchLinqEFDynamic(predicate, skip, take, orderClause);
			records.ForEach(x => this.mapper.ContactTypeMapEFToPOCO(x, response));
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
    <Hash>44604d80e131e44a812601e46808498c</Hash>
</Codenesium>*/