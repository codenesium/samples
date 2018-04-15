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
	public abstract class AbstractIllustrationRepository
	{
		protected ApplicationDbContext context;
		protected ILogger logger;
		protected IObjectMapper mapper;

		public AbstractIllustrationRepository(
			IObjectMapper mapper,
			ILogger logger,
			ApplicationDbContext context)
		{
			this.mapper = mapper;
			this.logger = logger;
			this.context = context;
		}

		public virtual int Create(
			IllustrationModel model)
		{
			var record = new EFIllustration();

			this.mapper.IllustrationMapModelToEF(
				default (int),
				model,
				record);

			this.context.Set<EFIllustration>().Add(record);
			this.context.SaveChanges();
			return record.IllustrationID;
		}

		public virtual void Update(
			int illustrationID,
			IllustrationModel model)
		{
			var record = this.SearchLinqEF(x => x.IllustrationID == illustrationID).FirstOrDefault();
			if (record == null)
			{
				this.logger.LogError($"Unable to find id:{illustrationID}");
			}
			else
			{
				this.mapper.IllustrationMapModelToEF(
					illustrationID,
					model,
					record);
				this.context.SaveChanges();
			}
		}

		public virtual void Delete(
			int illustrationID)
		{
			var record = this.SearchLinqEF(x => x.IllustrationID == illustrationID).FirstOrDefault();

			if (record == null)
			{
				return;
			}
			else
			{
				this.context.Set<EFIllustration>().Remove(record);
				this.context.SaveChanges();
			}
		}

		public virtual ApiResponse GetById(int illustrationID)
		{
			var response = new ApiResponse();

			this.SearchLinqPOCO(x => x.IllustrationID == illustrationID, response);
			return response;
		}

		public virtual POCOIllustration GetByIdDirect(int illustrationID)
		{
			var response = new ApiResponse();

			this.SearchLinqPOCO(x => x.IllustrationID == illustrationID, response);
			return response.Illustrations.FirstOrDefault();
		}

		public virtual ApiResponse GetWhere(Expression<Func<EFIllustration, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
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

		public virtual List<POCOIllustration> GetWhereDirect(Expression<Func<EFIllustration, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			var response = new ApiResponse();

			this.SearchLinqPOCO(predicate, response, skip, take, orderClause);
			return response.Illustrations;
		}

		private void SearchLinqPOCO(Expression<Func<EFIllustration, bool>> predicate, ApiResponse response, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<EFIllustration> records = this.SearchLinqEF(predicate, skip, take, orderClause);
			records.ForEach(x => this.mapper.IllustrationMapEFToPOCO(x, response));
		}

		private void SearchLinqPOCODynamic(string predicate, ApiResponse response, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<EFIllustration> records = this.SearchLinqEFDynamic(predicate, skip, take, orderClause);
			records.ForEach(x => this.mapper.IllustrationMapEFToPOCO(x, response));
		}

		protected virtual List<EFIllustration> SearchLinqEF(Expression<Func<EFIllustration, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			throw new NotImplementedException("This method should be implemented in a derived class");
		}

		protected virtual List<EFIllustration> SearchLinqEFDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			throw new NotImplementedException("This method should be implemented in a derived class");
		}
	}
}

/*<Codenesium>
    <Hash>b1558fd3c26280926b5109d0d6ab7144</Hash>
</Codenesium>*/