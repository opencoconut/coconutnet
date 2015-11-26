using System;
namespace Coconut
{
	 public class CoconutException: ApplicationException
	 {
	     public CoconutException(string Message,
	                  Exception innerException): base(Message,innerException) {}
	     public CoconutException(string Message) : base(Message) {}
	     public CoconutException() {}
	 }
}

