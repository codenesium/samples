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
	public abstract class AbstractSpaceXSpaceFeatureRepository
	{
		protected ApplicationDbContext Context { get; }
		protected ILogger Logger { get; }
		protected IObjectMapper Mapper { get; }

		public AbstractSpaceXSpaceFeatureRepository(
			IObjectMapper mapper,
			ILogger logger,
			ApplicationDbContext context)
		{
			this.Mapper = mapper;
			this.Logger = logger;
			this.Context = context;
		}

		public virtual int Create(
			SpaceXSpaceFeatureModel model)
		{
			EFSpaceXSpaceFeature record = new EFSpaceXSpaceFeature();

			this.Mapper.SpaceXSpaceFeatureMapModelToEF(
				default (int),
				model,
				record);

			this.Context.Set<EFSpaceXSpaceFeature>().Add(record);
			this.Context.SaveChanges();
			return record.Id;
		}

		public virtual void Update(
			int id,
			SpaceXSpaceFeatureModel model)
		{
			EFSpaceXSpaceFeature record = this.SearchLinqEF(x => x.Id == id).FirstOrDefault();
			if (record == null)
			{
				throw new RecordNotFoundException($"Unable to find id:{id}");
			}
			else
			{
				this.Mapper.SpaceXSpaceFeatureMapModelToEF(
					id,
					model,
					record);
				this.Context.SaveChanges();
			}
		}

		public virtual void Delete(
			int id)
		{
			EFSpaceXSpaceFeature record = this.SearchLinqEF(x => x.Id == id).FirstOrDefault();

			if (record == null)
			{
				return;
			}
			else
			{
				this.Context.Set<EFSpaceXSpaceFeature>().Remove(record);
				this.Context.SaveChanges();
			}
		}

		public virtual ApiResponse GetById(int id)
		{
			return this.SearchLinqPOCO(x => x.Id == id);
		}

		public virtual POCOSpaceXSpaceFeature GetByIdDirect(int id)
		{
			return this.SearchLinqPOCO(x => x.Id == id).SpaceXSpaceFeatures.FirstOrDefault();
		}

		public virtual ApiResponse GetWhere(Expression<Func<EFSpaceXSpaceFeature, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqPOCO(predicate, skip, take, orderClause);
		}

		public virtual ApiResponse GetWhereDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqPOCODynamic(predicate, skip, take, orderClause);
		}

		public virtual List<POCOSpaceXSpaceFeature> GetWhereDirect(Expression<Func<EFSpaceXSpaceFeature, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqPOCO(predicate, skip, take, orderClause).SpaceXSpaceFeatures;
		}

		private ApiResponse SearchLinqPOCO(Expression<Func<EFSpaceXSpaceFeature, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			ApiResponse response = new ApiResponse();

			List<EFSpaceXSpaceFeature> records = this.SearchLinqEF(predicate, skip, take, orderClause);
			records.ForEach(x => this.Mapper.SpaceXSpaceFeatureMapEFToPOCO(x, response));
			return response;
		}

		private ApiResponse SearchLinqPOCODynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			ApiResponse response = new ApiResponse();

			List<EFSpaceXSpaceFeature> records = this.SearchLinqEFDynamic(predicate, skip, take, orderClause);
			records.ForEach(x => this.Mapper.SpaceXSpaceFeatureMapEFToPOCO(x, response));
			return response;
		}

		protected virtual List<EFSpaceXSpaceFeature> SearchLinqEF(Expression<Func<EFSpaceXSpaceFeature, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			throw new NotImplementedException("This method should be implemented in a derived class");
		}

		protected virtual List<EFSpaceXSpaceFeature> SearchLinqEFDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			throw new NotImplementedException("This method should be implemented in a derived class");
		}
	}
}

/*<Codenesium>
    <Hash>cadaccf595c1c359f0f404212fbb6b2d</Hash>
</Codenesium>*/