namespace BLL.Exceptions
{
	public class ReviewNotFoundException : Exception
	{
		public ReviewNotFoundException(string message = "Test not found.") : base(message) { }
	}
}
