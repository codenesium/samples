using Codenesium.DataConversionExtensions;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TicketingCRMNS.Api.DataAccess
{
        [Table("TransactionStatus", Schema="dbo")]
        public partial class TransactionStatus : AbstractEntity
        {
                public TransactionStatus()
                {
                }

                public virtual void SetProperties(
                        int id,
                        string name)
                {
                        this.Id = id;
                        this.Name = name;
                }

                [Key]
                [Column("id")]
                public int Id { get; private set; }

                [Column("name")]
                public string Name { get; private set; }
        }
}

/*<Codenesium>
    <Hash>7d8d36cb9e6100fa2131a22cec8281fb</Hash>
</Codenesium>*/