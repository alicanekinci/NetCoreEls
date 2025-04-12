using Microsoft.Extensions.Logging;

public class MyService
{
    // Declare a private readonly field for the logger
    private readonly ILogger<MyService> _logger;

    // Constructor that accepts an ILogger<T> to be injected
    public MyService(ILogger<MyService> logger)
    {
        _logger = logger; // Assign the injected logger to the private field
    }

    // Method to run the service logic
    public void Run()
    {
        // Log an informational message at the start of the application
        _logger.LogInformation("Application has started!");

        try
        {
            // Simulate an exception to demonstrate error logging
            throw new Exception("Example error!");
        }
        catch (Exception ex)
        {
            // Log the exception with an error message
            _logger.LogError(ex, "An error occurred.");
        }
    }
}
