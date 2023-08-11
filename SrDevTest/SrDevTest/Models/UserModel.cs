using System;
using SQLite;

namespace SrDevTest.Models
{
	public class UserModel
	{
     
            [AutoIncrement, PrimaryKey]
            public int id { get; set; }
            public string UserName { get; set; }
        
    }
}

