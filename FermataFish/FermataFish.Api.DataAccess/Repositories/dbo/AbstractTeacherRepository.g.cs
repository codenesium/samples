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
	public abstract class AbstractTeacherRepository
	{
		protected ApplicationDbContext context;
		protected ILogger logger;

		public AbstractTeacherRepository(
			ILogger logger,
			ApplicationDbContext context)
		{
			this.logger = logger;
			this.context = context;
		}

		public virtual int Create(
			string firstName,
			string lastName,
			string email,
			string phone,
			DateTime birthday,
			int studioId)
		{
			var record = new EFTeacher();

			MapPOCOToEF(
				0,
				firstName,
				lastName,
				email,
				phone,
				birthday,
				studioId,
				record);

			this.context.Set<EFTeacher>().Add(record);
			this.context.SaveChanges();
			return record.Id;
		}

		public virtual void Update(
			int id,
			string firstName,
			string lastName,
			string email,
			string phone,
			DateTime birthday,
			int studioId)
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
					firstName,
					lastName,
					email,
					phone,
					birthday,
					studioId,
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
				this.context.Set<EFTeacher>().Remove(record);
				this.context.SaveChanges();
			}
		}

		public virtual Response GetById(int id)
		{
			var response = new Response();

			this.SearchLinqPOCO(x => x.Id == id, response);
			return response;
		}

		public virtual POCOTeacher GetByIdDirect(int id)
		{
			var response = new Response();

			this.SearchLinqPOCO(x => x.Id == id, response);
			return response.Teachers.FirstOrDefault();
		}

		public virtual Response GetWhere(Expression<Func<EFTeacher, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
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

		public virtual List<POCOTeacher> GetWhereDirect(Expression<Func<EFTeacher, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			var response = new Response();

			this.SearchLinqPOCO(predicate, response, skip, take, orderClause);
			return response.Teachers;
		}

		private void SearchLinqPOCO(Expression<Func<EFTeacher, bool>> predicate, Response response, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<EFTeacher> records = this.SearchLinqEF(predicate, skip, take, orderClause);
			records.ForEach(x => MapEFToPOCO(x, response));
		}

		private void SearchLinqPOCODynamic(string predicate, Response response, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<EFTeacher> records = this.SearchLinqEFDynamic(predicate, skip, take, orderClause);
			records.ForEach(x => MapEFToPOCO(x, response));
		}

		protected virtual List<EFTeacher> SearchLinqEF(Expression<Func<EFTeacher, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			throw new NotImplementedException("This method should be implemented in a derived class");
		}

		protected virtual List<EFTeacher> SearchLinqEFDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			throw new NotImplementedException("This method should be implemented in a derived class");
		}

		public static void MapPOCOToEF(
			int id,
			string firstName,
			string lastName,
			string email,
			string phone,
			DateTime birthday,
			int studioId,
			EFTeacher efTeacher)
		{
			efTeacher.SetProperties(id.ToInt(), firstName, lastName, email, phone, birthday, studioId.ToInt());
		}

		public static void MapEFToPOCO(
			EFTeacher efTeacher,
			Response response)
		{
			if (efTeacher == null)
			{
				return;
			}

			response.AddTeacher(new POCOTeacher(efTeacher.Id.ToInt(), efTeacher.FirstName, efTeacher.LastName, efTeacher.Email, efTeacher.Phone, efTeacher.Birthday, efTeacher.StudioId.ToInt()));

			StudioRepository.MapEFToPOCO(efTeacher.Studio, response);
		}
	}
}

/*<Codenesium>
    <Hash>7f3dc6b320fc6736cdf84234e151678a</Hash>
</Codenesium>*/