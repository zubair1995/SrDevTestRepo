using System;
using SQLite;

namespace SrDevTest.Models
{
	public class NetworkInfoModel
	{
        [AutoIncrement, PrimaryKey]
        public int id { get; set; }
		public string code { get; set; }
		public string networkName { get; set; }
	}
}

