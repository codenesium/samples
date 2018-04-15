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
	public abstract class AbstractCultureRepository
	{
		protected ApplicationDbContext context;
		protected ILogger logger;
		protected IObjectMapper mapper;

		public AbstractCultureRepository(
			IObjectMapper mapper,
			ILogger logger,
			ApplicationDbContext context)
		{
			this.mapper = mapper;
			this.logger = logger;
			this.context = context;
		}

		public virtual string Create(
			CultureModel model)
		{
			var record = new EFCulture();

			this.mapper.CultureMapModelToEF(
				default (string),
				model,
				record);

			this.context.Set<EFCulture>().Add(record);
			this.context.SaveChanges();
			return record.CultureID;
		}

		public virtual void Update(
			string cultureID,
			CultureModel model)
		{
			var record = this.SearchLinqEF(x => x.CultureID == cultureID).FirstOrDefault();
			if (record == null)
			{
				this.logger.LogError($"Unable to find id:{cultureID}");
			}
			else
			{
				this.mapper.CultureMapModelToEF(
					cultureID,
					model,
					record);
				this.context.SaveChanges();
			}
		}

		public virtual void Delete(
			string cultureID)
		{
			var record = this.SearchLinqEF(x => x.CultureID == cultureID).FirstOrDefault();

			if (record == null)
			{
				return;
			}
			else
			{
				this.context.Set<EFCulture>().Remove(record);
				this.context.SaveChanges();
			}
		}

		public virtual ApiResponse GetById(string cultureID)
		{
			var response = new ApiResponse();

			this.SearchLinqPOCO(x => x.CultureID == cultureID, response);
			return response;
		}

		public virtual POCOCulture GetByIdDirect(string cultureID)
		{
			var response = new ApiResponse();

			this.SearchLinqPOCO(x => x.CultureID == cultureID, response);
			return response.Cultures.FirstOrDefault();
		}

		public virtual ApiResponse GetWhere(Expression<Func<EFCulture, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
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

		public virtual List<POCOCulture> GetWhereDirect(Expression<Func<EFCulture, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			var response = new ApiResponse();

			this.SearchLinqPOCO(predicate, response, skip, take, orderClause);
			return response.Cultures;
		}

		private void SearchLinqPOCO(Expression<Func<EFCulture, bool>> predicate, ApiResponse response, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<EFCulture> records = this.SearchLinqEF(predicate, skip, take, orderClause);
			records.ForEach(x => this.mapper.CultureMapEFToPOCO(x, response));
		}

		private void SearchLinqPOCODynamic(string predicate, ApiResponse response, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<EFCulture> records = this.SearchLinqEFDynamic(predicate, skip, take, orderClause);
			records.ForEach(x => this.mapper.CultureMapEFToPOCO(x, response));
		}

		protected virtual List<EFCulture> SearchLinqEF(Expression<Func<EFCulture, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			throw new NotImplementedException("This method should be implemented in a derived class");
		}

		protected virtual List<EFCulture> SearchLinqEFDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			throw new NotImplementedException("This method should be implemented in a derived class");
		}
	}
}

/*<Codenesium>
    <Hash>6a2993e1c1a6bdfb0a46bb32690ab9c1</Hash>
</Codenesium>*/