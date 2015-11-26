using System;
using System.Collections.Generic;

namespace Coconut
{
	public class CoconutJob
	{
		public int Id { get; set; }
		public string Status { get; set; }
	}

	public class CoconutError
	{
		public string ErrorCode { get; set; }
		public string Message { get; set; }
		public string Status { get; set; }
	}
}