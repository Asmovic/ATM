using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ATM.Models
{
    public class Transactionz
    {
        public int Id { get; set; }


        [Required]
        [DataType(DataType.Currency)]
        public decimal Amount { get; set; }
        [Required]
        public int CheckingBalanceId { get; set; }
        public virtual CheckingBalance CheckingBalance { get; set; }



        
    }
}