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

		public AbstractContactTypeRepository(
			ILogger logger,
			ApplicationDbContext context)
		{
			this.logger = logger;
			this.context = context;
		}

		public virtual int Create(
			string name,
			DateTime modifiedDate)
		{
			var record = new EFContactType();

			MapPOCOToEF(
				0,
				name,
				modifiedDate,
				record);

			this.context.Set<EFContactType>().Add(record);
			this.context.SaveChanges();
			return record.ContactTypeID;
		}

		public virtual void Update(
			int contactTypeID,
			string name,
			DateTime modifiedDate)
		{
			var record = this.SearchLinqEF(x => x.ContactTypeID == contactTypeID).FirstOrDefault();
			if (record == null)
			{
				this.logger.LogError($"Unable to find id:{contactTypeID}");
			}
			else
			{
				MapPOCOToEF(
					contactTypeID,
					name,
					modifiedDate,
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

		public virtual Response GetById(int contactTypeID)
		{
			var response = new Response();

			this.SearchLinqPOCO(x => x.ContactTypeID == contactTypeID, response);
			return response;
		}

		public virtual POCOContactType GetByIdDirect(int contactTypeID)
		{
			var response = new Response();

			this.SearchLinqPOCO(x => x.ContactTypeID == contactTypeID, response);
			return response.ContactTypes.FirstOrDefault();
		}

		public virtual Response GetWhere(Expression<Func<EFContactType, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
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

		public virtual List<POCOContactType> GetWhereDirect(Expression<Func<EFContactType, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			var response = new Response();

			this.SearchLinqPOCO(predicate, response, skip, take, orderClause);
			return response.ContactTypes;
		}

		private void SearchLinqPOCO(Expression<Func<EFContactType, bool>> predicate, Response response, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<EFContactType> records = this.SearchLinqEF(predicate, skip, take, orderClause);
			records.ForEach(x => MapEFToPOCO(x, response));
		}

		private void SearchLinqPOCODynamic(string predicate, Response response, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<EFContactType> records = this.SearchLinqEFDynamic(predicate, skip, take, orderClause);
			records.ForEach(x => MapEFToPOCO(x, response));
		}

		protected virtual List<EFContactType> SearchLinqEF(Expression<Func<EFContactType, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			throw new NotImplementedException("This method should be implemented in a derived class");
		}

		protected virtual List<EFContactType> SearchLinqEFDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			throw new NotImplementedException("This method should be implemented in a derived class");
		}

		public static void MapPOCOToEF(
			int contactTypeID,
			string name,
			DateTime modifiedDate,
			EFContactType efContactType)
		{
			efContactType.SetProperties(contactTypeID.ToInt(), name, modifiedDate.ToDateTime());
		}

		public static void MapEFToPOCO(
			EFContactType efContactType,
			Response response)
		{
			if (efContactType == null)
			{
				return;
			}

			response.AddContactType(new POCOContactType(efContactType.ContactTypeID.ToInt(), efContactType.Name, efContactType.ModifiedDate.ToDateTime()));
		}
	}
}

/*<Codenesium>
    <Hash>63ea52ff45f8abb7873f76ad33af98d1</Hash>
</Codenesium>*/