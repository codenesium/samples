using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using FermataFishNS.Api.Contracts;

namespace FermataFishNS.Api.DataAccess
{
	public abstract class AbstractSpaceFeatureRepository
	{
		protected ApplicationDbContext Context { get; }
		protected ILogger Logger { get; }
		protected IObjectMapper Mapper { get; }

		public AbstractSpaceFeatureRepository(
			IObjectMapper mapper,
			ILogger logger,
			ApplicationDbContext context)
		{
			this.Mapper = mapper;
			this.Logger = logger;
			this.Context = context;
		}

		public virtual int Create(
			SpaceFeatureModel model)
		{
			EFSpaceFeature record = new EFSpaceFeature();

			this.Mapper.SpaceFeatureMapModelToEF(
				default (int),
				model,
				record);

			this.Context.Set<EFSpaceFeature>().Add(record);
			this.Context.SaveChanges();
			return record.Id;
		}

		public virtual void Update(
			int id,
			SpaceFeatureModel model)
		{
			EFSpaceFeature record = this.SearchLinqEF(x => x.Id == id).FirstOrDefault();
			if (record == null)
			{
				throw new RecordNotFoundException($"Unable to find id:{id}");
			}
			else
			{
				this.Mapper.SpaceFeatureMapModelToEF(
					id,
					model,
					record);
				this.Context.SaveChanges();
			}
		}

		public virtual void Delete(
			int id)
		{
			EFSpaceFeature record = this.SearchLinqEF(x => x.Id == id).FirstOrDefault();

			if (record == null)
			{
				return;
			}
			else
			{
				this.Context.Set<EFSpaceFeature>().Remove(record);
				this.Context.SaveChanges();
			}
		}

		public virtual ApiResponse GetById(int id)
		{
			return this.SearchLinqPOCO(x => x.Id == id);
		}

		public virtual POCOSpaceFeature GetByIdDirect(int id)
		{
			return this.SearchLinqPOCO(x => x.Id == id).SpaceFeatures.FirstOrDefault();
		}

		public virtual ApiResponse GetWhere(Expression<Func<EFSpaceFeature, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqPOCO(predicate, skip, take, orderClause);
		}

		public virtual ApiResponse GetWhereDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqPOCODynamic(predicate, skip, take, orderClause);
		}

		public virtual List<POCOSpaceFeature> GetWhereDirect(Expression<Func<EFSpaceFeature, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqPOCO(predicate, skip, take, orderClause).SpaceFeatures;
		}

		private ApiResponse SearchLinqPOCO(Expression<Func<EFSpaceFeature, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			ApiResponse response = new ApiResponse();

			List<EFSpaceFeature> records = this.SearchLinqEF(predicate, skip, take, orderClause);
			records.ForEach(x => this.Mapper.SpaceFeatureMapEFToPOCO(x, response));
			return response;
		}

		private ApiResponse SearchLinqPOCODynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			ApiResponse response = new ApiResponse();

			List<EFSpaceFeature> records = this.SearchLinqEFDynamic(predicate, skip, take, orderClause);
			records.ForEach(x => this.Mapper.SpaceFeatureMapEFToPOCO(x, response));
			return response;
		}

		protected virtual List<EFSpaceFeature> SearchLinqEF(Expression<Func<EFSpaceFeature, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			throw new NotImplementedException("This method should be implemented in a derived class");
		}

		protected virtual List<EFSpaceFeature> SearchLinqEFDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			throw new NotImplementedException("This method should be implemented in a derived class");
		}
	}
}

/*<Codenesium>
    <Hash>47a72488abab0aa6d34e97a204cbba32</Hash>
</Codenesium>*/