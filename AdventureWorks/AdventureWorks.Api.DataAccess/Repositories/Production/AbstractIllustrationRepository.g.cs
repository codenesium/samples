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
		protected ApplicationDbContext Context { get; }
		protected ILogger Logger { get; }
		protected IObjectMapper Mapper { get; }

		public AbstractIllustrationRepository(
			IObjectMapper mapper,
			ILogger logger,
			ApplicationDbContext context)
		{
			this.Mapper = mapper;
			this.Logger = logger;
			this.Context = context;
		}

		public virtual int Create(
			IllustrationModel model)
		{
			var record = new EFIllustration();

			this.Mapper.IllustrationMapModelToEF(
				default (int),
				model,
				record);

			this.Context.Set<EFIllustration>().Add(record);
			this.Context.SaveChanges();
			return record.IllustrationID;
		}

		public virtual void Update(
			int illustrationID,
			IllustrationModel model)
		{
			var record = this.SearchLinqEF(x => x.IllustrationID == illustrationID).FirstOrDefault();
			if (record == null)
			{
				throw new Exception($"Unable to find id:{illustrationID}");
			}
			else
			{
				this.Mapper.IllustrationMapModelToEF(
					illustrationID,
					model,
					record);
				this.Context.SaveChanges();
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
				this.Context.Set<EFIllustration>().Remove(record);
				this.Context.SaveChanges();
			}
		}

		public virtual ApiResponse GetById(int illustrationID)
		{
			return this.SearchLinqPOCO(x => x.IllustrationID == illustrationID);
		}

		public virtual POCOIllustration GetByIdDirect(int illustrationID)
		{
			return this.SearchLinqPOCO(x => x.IllustrationID == illustrationID).Illustrations.FirstOrDefault();
		}

		public virtual ApiResponse GetWhere(Expression<Func<EFIllustration, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqPOCO(predicate, skip, take, orderClause);
		}

		public virtual ApiResponse GetWhereDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqPOCODynamic(predicate, skip, take, orderClause);
		}

		public virtual List<POCOIllustration> GetWhereDirect(Expression<Func<EFIllustration, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqPOCO(predicate, skip, take, orderClause).Illustrations;
		}

		private ApiResponse SearchLinqPOCO(Expression<Func<EFIllustration, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			var response = new ApiResponse();

			List<EFIllustration> records = this.SearchLinqEF(predicate, skip, take, orderClause);
			records.ForEach(x => this.Mapper.IllustrationMapEFToPOCO(x, response));
			return response;
		}

		private ApiResponse SearchLinqPOCODynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			var response = new ApiResponse();

			List<EFIllustration> records = this.SearchLinqEFDynamic(predicate, skip, take, orderClause);
			records.ForEach(x => this.Mapper.IllustrationMapEFToPOCO(x, response));
			return response;
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
    <Hash>e8a1af84386d4537879708d5add65519</Hash>
</Codenesium>*/