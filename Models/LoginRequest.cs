namespace mvc.Models;

public class LoginRequest
{
	int protocol { get; set; } = 1; 
	string client { get; set; } = "test client"; 
	string clientver { get; set; } = "1.0"; 
}
