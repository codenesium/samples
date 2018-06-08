using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Codenesium.DataConversionExtensions.AspNetCore;

namespace PetShippingNS.Api.DataAccess
{
        [Table("ClientCommunication", Schema="dbo")]
        public partial class ClientCommunication: AbstractEntity
        {
                public ClientCommunication()
                {
                }

                public void SetProperties(
                        int clientId,
                        DateTime dateCreated,
                        int employeeId,
                        int id,
                        string notes)
                {
                        this.ClientId = clientId;
                        this.DateCreated = dateCreated;
                        this.EmployeeId = employeeId;
                        this.Id = id;
                        this.Notes = notes;
                }

                [Column("clientId", TypeName="int")]
                public int ClientId { get; private set; }

                [Column("dateCreated", TypeName="datetime")]
                public DateTime DateCreated { get; private set; }

                [Column("employeeId", TypeName="int")]
                public int EmployeeId { get; private set; }

                [Key]
                [Column("id", TypeName="int")]
                public int Id { get; private set; }

                [Column("notes", TypeName="text(2147483647)")]
                public string Notes { get; private set; }

                [ForeignKey("ClientId")]
                public virtual Client Client { get; set; }

                [ForeignKey("EmployeeId")]
                public virtual Employee Employee { get; set; }
        }
}

/*<Codenesium>
    <Hash>23baa2b45e99f02c81ce3f4bea178f40</Hash>
</Codenesium>*/