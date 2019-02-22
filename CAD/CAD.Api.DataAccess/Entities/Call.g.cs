using Codenesium.DataConversionExtensions;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace CADNS.Api.DataAccess
{
	[Table("Call", Schema="dbo")]
	public partial class Call : AbstractEntity
	{
		public Call()
		{
		}

		public virtual void SetProperties(
			int id,
			int? addressId,
			int? callDispositionId,
			int? callStatusId,
			string callString,
			int? callTypeId,
			DateTime? dateCleared,
			DateTime dateCreated,
			DateTime? dateDispatched,
			int quickCallNumber)
		{
			this.Id = id;
			this.AddressId = addressId;
			this.CallDispositionId = callDispositionId;
			this.CallStatusId = callStatusId;
			this.CallString = callString;
			this.CallTypeId = callTypeId;
			this.DateCleared = dateCleared;
			this.DateCreated = dateCreated;
			this.DateDispatched = dateDispatched;
			this.QuickCallNumber = quickCallNumber;
		}

		[Column("addressId")]
		public virtual int? AddressId { get; private set; }

		[Column("callDispositionId")]
		public virtual int? CallDispositionId { get; private set; }

		[Column("callStatusId")]
		public virtual int? CallStatusId { get; private set; }

		[MaxLength(24)]
		[Column("callString")]
		public virtual string CallString { get; private set; }

		[Column("callTypeId")]
		public virtual int? CallTypeId { get; private set; }

		[Column("dateCleared")]
		public virtual DateTime? DateCleared { get; private set; }

		[Column("dateCreated")]
		public virtual DateTime DateCreated { get; private set; }

		[Column("dateDispatched")]
		public virtual DateTime? DateDispatched { get; private set; }

		[Key]
		[Column("id")]
		public virtual int Id { get; private set; }

		[Column("quickCallNumber")]
		public virtual int QuickCallNumber { get; private set; }

		[ForeignKey("AddressId")]
		public virtual Address AddressIdNavigation { get; private set; }

		public void SetAddressIdNavigation(Address item)
		{
			this.AddressIdNavigation = item;
		}

		[ForeignKey("CallDispositionId")]
		public virtual CallDisposition CallDispositionIdNavigation { get; private set; }

		public void SetCallDispositionIdNavigation(CallDisposition item)
		{
			this.CallDispositionIdNavigation = item;
		}

		[ForeignKey("CallStatusId")]
		public virtual CallStatu CallStatusIdNavigation { get; private set; }

		public void SetCallStatusIdNavigation(CallStatu item)
		{
			this.CallStatusIdNavigation = item;
		}

		[ForeignKey("CallTypeId")]
		public virtual CallType CallTypeIdNavigation { get; private set; }

		public void SetCallTypeIdNavigation(CallType item)
		{
			this.CallTypeIdNavigation = item;
		}
	}
}

/*<Codenesium>
    <Hash>0bc6a41981acee30e24739f741e15a23</Hash>
</Codenesium>*/