﻿using System.Text.Json.Serialization;

namespace Hidrolik.Domain.Dtos;

public class ResponseDto<T>
{
    public T Data { get; set; }
    public List<string> Errors { get; set; }
    [JsonIgnore]
    public int StatusCode { get; private set; }
    [JsonIgnore]
    public bool IsSuccess { get; private set; }

    public static ResponseDto<T> Success(T data, int statusCode)
    {
        return new ResponseDto<T> { Data = data, StatusCode = statusCode, IsSuccess = true };
    }
    public static ResponseDto<T> Success(int statusCode)
    {
        return new ResponseDto<T> { Data = default(T), StatusCode = statusCode, IsSuccess = true };
    }

    public static ResponseDto<T> Error(List<string> errors, int statusCode)
    {
        return new ResponseDto<T> { Errors = errors, StatusCode = statusCode, IsSuccess = false };
    }

    public static ResponseDto<T> Error(string error, int statusCode)
    {
        return new ResponseDto<T> { Errors = new List<string>() { error }, StatusCode = statusCode };
    }
}
