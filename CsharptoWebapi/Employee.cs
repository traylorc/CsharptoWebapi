using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CsharptoWebapi
{
    class Employee
    {
        
        
            public Employee()
            { }



            [Required]
            public int Id { get; set; }
            [Required, StringLength(30)]
            public string Login { get; set; }
            [Required, StringLength(30)]
            public string Password { get; set; }
            [Required, StringLength(30)]
            public string Firstname { get; set; }
            [Required, StringLength(30)]
            public string Lastname { get; set; }
            public bool IsManager { get; set; }

        
    }
}
