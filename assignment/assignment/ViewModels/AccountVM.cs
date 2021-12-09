using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace assignment.ViewModels
{
    public class AccountVM
    {
        [DisplayName("Account Number")]
        public int AccountNum { get; set; }
        [DisplayName("Account Type")]
        public string AccountType { get; set; }
        public decimal Balance { get; set; }
        [DisplayName("ClientID")]
        public int ClientID { get; set; }
        [DisplayName("Last Name")]
        public string LastName { get; set; }
        [DisplayName("First Name")]
        public string FirstName { get; set; }
        public string Email { get; set; }
    }
}
