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
		protected ApplicationDbContext context;
		protected ILogger logger;

		public AbstractSpaceXSpaceFeatureRepository(
			ILogger logger,
			ApplicationDbContext context)
		{
			this.logger = logger;
			this.context = context;
		}

		public virtual int Create(
			int spaceId,
			int spaceFeatureId)
		{
			var record = new EFSpaceXSpaceFeature();

			MapPOCOToEF(
				0,
				spaceId,
				spaceFeatureId,
				record);

			this.context.Set<EFSpaceXSpaceFeature>().Add(record);
			this.context.SaveChanges();
			return record.Id;
		}

		public virtual void Update(
			int id,
			int spaceId,
			int spaceFeatureId)
		{
			var record = this.SearchLinqEF(x => x.Id == id).FirstOrDefault();
			if (record == null)
			{
				this.logger.LogError($"Unable to find id:{id}");
			}
			else
			{
				MapPOCOToEF(
					id,
					spaceId,
					spaceFeatureId,
					record);
				this.context.SaveChanges();
			}
		}

		public virtual void Delete(
			int id)
		{
			var record = this.SearchLinqEF(x => x.Id == id).FirstOrDefault();

			if (record == null)
			{
				return;
			}
			else
			{
				this.context.Set<EFSpaceXSpaceFeature>().Remove(record);
				this.context.SaveChanges();
			}
		}

		public virtual Response GetById(int id)
		{
			var response = new Response();

			this.SearchLinqPOCO(x => x.Id == id, response);
			return response;
		}

		public virtual POCOSpaceXSpaceFeature GetByIdDirect(int id)
		{
			var response = new Response();

			this.SearchLinqPOCO(x => x.Id == id, response);
			return response.SpaceXSpaceFeatures.FirstOrDefault();
		}

		public virtual Response GetWhere(Expression<Func<EFSpaceXSpaceFeature, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			var response = new Response();

			this.SearchLinqPOCO(predicate, response, skip, take, orderClause);
			return response;
		}

		public virtual Response GetWhereDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			var response = new Response();

			this.SearchLinqPOCODynamic(predicate, response, skip, take, orderClause);
			return response;
		}

		public virtual List<POCOSpaceXSpaceFeature> GetWhereDirect(Expression<Func<EFSpaceXSpaceFeature, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			var response = new Response();

			this.SearchLinqPOCO(predicate, response, skip, take, orderClause);
			return response.SpaceXSpaceFeatures;
		}

		private void SearchLinqPOCO(Expression<Func<EFSpaceXSpaceFeature, bool>> predicate, Response response, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<EFSpaceXSpaceFeature> records = this.SearchLinqEF(predicate, skip, take, orderClause);
			records.ForEach(x => MapEFToPOCO(x, response));
		}

		private void SearchLinqPOCODynamic(string predicate, Response response, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<EFSpaceXSpaceFeature> records = this.SearchLinqEFDynamic(predicate, skip, take, orderClause);
			records.ForEach(x => MapEFToPOCO(x, response));
		}

		protected virtual List<EFSpaceXSpaceFeature> SearchLinqEF(Expression<Func<EFSpaceXSpaceFeature, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			throw new NotImplementedException("This method should be implemented in a derived class");
		}

		protected virtual List<EFSpaceXSpaceFeature> SearchLinqEFDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			throw new NotImplementedException("This method should be implemented in a derived class");
		}

		public static void MapPOCOToEF(
			int id,
			int spaceId,
			int spaceFeatureId,
			EFSpaceXSpaceFeature efSpaceXSpaceFeature)
		{
			efSpaceXSpaceFeature.SetProperties(id.ToInt(), spaceId.ToInt(), spaceFeatureId.ToInt());
		}

		public static void MapEFToPOCO(
			EFSpaceXSpaceFeature efSpaceXSpaceFeature,
			Response response)
		{
			if (efSpaceXSpaceFeature == null)
			{
				return;
			}

			response.AddSpaceXSpaceFeature(new POCOSpaceXSpaceFeature(efSpaceXSpaceFeature.Id.ToInt(), efSpaceXSpaceFeature.SpaceId.ToInt(), efSpaceXSpaceFeature.SpaceFeatureId.ToInt()));

			SpaceRepository.MapEFToPOCO(efSpaceXSpaceFeature.Space, response);

			SpaceFeatureRepository.MapEFToPOCO(efSpaceXSpaceFeature.SpaceFeature, response);
		}
	}
}

/*<Codenesium>
    <Hash>48ccf4d83ecd16a1c285442fae1b1042</Hash>
</Codenesium>*/