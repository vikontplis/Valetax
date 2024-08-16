namespace Valetax.Infrastructure.DTO;

public class ProblemDetailsResponse
{
    public ProblemDetailsResponse(string type, long id, string message)
    {
        Type = type;
        Id = id;
        Data = new Data { Message = message };
    }

    public string Type { get; set; }
    public long Id { get; set; }
    public Data Data { get; set; }
}

public class Data
{
    public string Message { get; set; }
}