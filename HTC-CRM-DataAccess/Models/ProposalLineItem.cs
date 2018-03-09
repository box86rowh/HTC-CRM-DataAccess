using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper.Contrib.Extensions;
using Dapper;
using System.Data;
using HTC_CRM_DataAccess.Interfaces;
using TypeLite;


namespace HTC_CRM_DataAccess.Models
{
    [TsClass]
    [Table("AA_ProposalLineItems")]
    public class ProposalLineItem : BusinessObject, IDeletable
    {
        public int ProposalId { get; set; }
        public string Content { get; set; }
        public bool IsDeleted { get; set; }

        public static IEnumerable<ProposalLineItem> GetByProposalId(IDbConnection db, int proposalId)
        {
            return db.Query<ProposalLineItem>(@"select * from AA_ProposalLineItems where ProposalId = @id", new { id = proposalId });
        }
    }
}
