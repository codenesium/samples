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
		protected ApplicationDbContext Context { get; }
		protected ILogger Logger { get; }
		protected IObjectMapper Mapper { get; }

		public AbstractCultureRepository(
			IObjectMapper mapper,
			ILogger logger,
			ApplicationDbContext context)
		{
			this.Mapper = mapper;
			this.Logger = logger;
			this.Context = context;
		}

		public virtual string Create(
			CultureModel model)
		{
			EFCulture record = new EFCulture();

			this.Mapper.CultureMapModelToEF(
				default (string),
				model,
				record);

			this.Context.Set<EFCulture>().Add(record);
			this.Context.SaveChanges();
			return record.CultureID;
		}

		public virtual void Update(
			string cultureID,
			CultureModel model)
		{
			EFCulture record = this.SearchLinqEF(x => x.CultureID == cultureID).FirstOrDefault();
			if (record == null)
			{
				throw new RecordNotFoundException($"Unable to find id:{cultureID}");
			}
			else
			{
				this.Mapper.CultureMapModelToEF(
					cultureID,
					model,
					record);
				this.Context.SaveChanges();
			}
		}

		public virtual void Delete(
			string cultureID)
		{
			EFCulture record = this.SearchLinqEF(x => x.CultureID == cultureID).FirstOrDefault();

			if (record == null)
			{
				return;
			}
			else
			{
				this.Context.Set<EFCulture>().Remove(record);
				this.Context.SaveChanges();
			}
		}

		public virtual ApiResponse GetById(string cultureID)
		{
			return this.SearchLinqPOCO(x => x.CultureID == cultureID);
		}

		public virtual POCOCulture GetByIdDirect(string cultureID)
		{
			return this.SearchLinqPOCO(x => x.CultureID == cultureID).Cultures.FirstOrDefault();
		}

		public virtual ApiResponse GetWhere(Expression<Func<EFCulture, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqPOCO(predicate, skip, take, orderClause);
		}

		public virtual ApiResponse GetWhereDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqPOCODynamic(predicate, skip, take, orderClause);
		}

		public virtual List<POCOCulture> GetWhereDirect(Expression<Func<EFCulture, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqPOCO(predicate, skip, take, orderClause).Cultures;
		}

		private ApiResponse SearchLinqPOCO(Expression<Func<EFCulture, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			ApiResponse response = new ApiResponse();

			List<EFCulture> records = this.SearchLinqEF(predicate, skip, take, orderClause);
			records.ForEach(x => this.Mapper.CultureMapEFToPOCO(x, response));
			return response;
		}

		private ApiResponse SearchLinqPOCODynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			ApiResponse response = new ApiResponse();

			List<EFCulture> records = this.SearchLinqEFDynamic(predicate, skip, take, orderClause);
			records.ForEach(x => this.Mapper.CultureMapEFToPOCO(x, response));
			return response;
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
    <Hash>b263c03ecd8deacc03fd2f878ff18d80</Hash>
</Codenesium>*/