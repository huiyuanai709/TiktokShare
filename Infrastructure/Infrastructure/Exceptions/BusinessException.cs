namespace Infrastructure.Exceptions;

public class BusinessException : Exception
{
    /// <summary>
    /// 错误代码
    /// </summary>
    public int Code { get; set; }

    /// <summary>
    /// 错误信息
    /// </summary>
    public string Message { get; set; }

    public BusinessException(string message) : this(1, message)
    {
    }

    public BusinessException(int code, string message)
    {
        Code = code;
        Message = message;
    }
}